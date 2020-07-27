﻿using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;

namespace WinMSFactory.BOM
{
    
    public partial class BOMManageForm : BasicForm
    {
        BomService bomSv = new BomService();
        ProductGroupService pdgSv = new ProductGroupService();

        List<BomVO> SelectedAllMaterial;
        List<BomVO> CheckedList;
        char UseCheck = 'Y';

        public ProductInsertVO ProductInfo { get; set; }
        public string ProductNm { get; set; }
        public int ProductID { get; set; }
        public char BOMEnrollStatus { get; internal set; }

        // BOM 등록 및 수정
        public BOMManageForm()
        {
            InitializeComponent();
            CheckedList = new List<BomVO>();
        }

        private void BOMManageForm_Load(object sender, EventArgs e)
        {
            // 왼쪽 그리드 뷰에는 반제품, 재료 만 조회 가능
            cboSearch.ComboBinding(BomService.CboProductType(), "Member", "");
            cboType.ComboBinding(pdgSv.ProductGroupComboBindingsNotAll(),"Product_Group_ID", "Product_Group_Name");

            rdoActive.Checked = true;
            txtProductName.Text = ProductNm;

            dgv.IsAllCheckColumnHeader = true;

            MaterialColumns();
            SelectedAllMaterial = bomSv.SelectMaterialSettings("반제품", "재료");
            dgv.DataSource = SelectedAllMaterial; // 반제품, 재료만 조회

        }

        private void MaterialColumns()
        {
            dgv.AddNewColumns("번호", "Product_ID", 100, true);
            dgv.AddNewColumns("제품 그룹명", "Product_Group_Name", 140, true);
            dgv.AddNewColumns("제품명", "Product_Name", 100, true);
            dgv.AddNewColumns("품명 스펙", "Product_Information", 100, true);
            dgv.AddNewColumns("기본 단위", "Product_Unit", 100, true);
            dgv.AddNewColumns("비고 1", "Product_Note1", 100, true);
            dgv.AddNewColumns("비고 2", "Product_Note2", 100, true);

            dgv2.AddNewColumns("번호", "Product_ID", 100, true);
            dgv2.AddNewColumns("제품 그룹명", "Product_Group_Name", 100, true);
            dgv2.AddNewColumns("제품명", "Product_Name", 100, true);
            dgv2.AddNewColumns("품명 스펙", "Product_Information", 100, true);
            dgv2.AddNewColumns("필요 수량", "Bom_Use_Quantity", 100, true);
        }


        private void buttonControl1_Click(object sender, EventArgs e)
        {
            if (cboSearch.SelectedIndex == 0) // 전체 선택시
            {
                if(txtSearch.Text.Length<1)
                    dgv.DataSource = SelectedAllMaterial;
                else
                {
                    var SortedList = (from sort in SelectedAllMaterial
                                      where sort.Product_Name.Contains(txtSearch.Text) && (sort.Product_Group_Name == "반제품"
                                      || sort.Product_Group_Name == "재료")
                                      select sort).ToList();
                    
                    dgv.DataSource = SortedList;
                }
            }
            else
            {
                if (txtSearch.Text.Length < 1)
                    dgv.DataSource = SelectedAllMaterial.FindAll(p => p.Product_Group_Name == cboSearch.Text);

                else
                {
                    var SortedList = (from sort in SelectedAllMaterial
                                      where sort.Product_Name.Contains(txtSearch.Text) && sort.Product_Group_Name.Equals(cboSearch.Text)
                                      select sort).ToList();

                    dgv.DataSource = SortedList;
                }
            }
           
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            // 초기화 진행 시
            cboSearch.SelectedIndex = 0;

            dgv.Columns.Clear();
            dgv2.Columns.Clear();
            BOMManageForm_Load(null, null);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (dgv2.Rows.Count < 2)
            {
                MessageBox.Show("재료를 2개 이상 추가해주세요");
                return;
            }
            // 재료 수량이 입력이 안된 경우 중단 시킴
            foreach(DataGridViewRow row in dgv2.Rows)
            { 
                if(dgv2[5,row.Index].Value == null)
                {
                    MessageBox.Show("수량을 모두 입력해주세요");
                    return;
                }
            }

            if (MessageBox.Show("등록을 진행하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            // BOM 테이블에 등록
            List<BOMInsertUpdateVO> InsertBOMLists = new List<BOMInsertUpdateVO>();
            
            // dgv2에서 목록 Sorting
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                InsertBOMLists.Add(new BOMInsertUpdateVO
                {
                    Higher_Product_ID = ProductID,
                    Lower_Product_ID = dgv2[1,i].Value.ToInt(),   // 재료들의 ID
                    Bom_Use_Quantity = dgv2[5,i].Value.ToInt(),
                    Final_Regist_Time = DateTime.Now.Date,
                    Final_Regist_Employee = "직원명",                        // 나중에 로그인 완성시 직원 명 넣어줄 것
                    Bom_Use = UseCheck,
                    Bom_Status = BOMEnrollStatus// BOM 사용 여부 넣어줄 것
                }) ;
            }


            if (bomSv.InsertUpdateProduct(InsertBOMLists))
            {
                // BOM Log에 등록
                BomLogVO AddLog = new BomLogVO
                {
                    High_Product_ID = ProductID,
                    Bom_Enroll_Date = DateTime.Now,
                    Employee_ID = 1,                                 // 직원명, ID는 회원가입이 만들어진 후 꼭 수정할 것
                    Bom_Use = UseCheck,
                    Bom_Log_Status = "BIS",             // BOM 입력
                    Bom_Exists = 'Y'
                };
                BomLogService service = new BomLogService();

                service.InsertLogs(AddLog);

                MessageBox.Show("BOM 등록이 완료되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void rdoActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoActive.Checked)
                UseCheck = 'Y';
            else if (rdoDeActive.Checked)
                UseCheck = 'N';
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            

            foreach(DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv[0, row.Index];

                if (chk.Value == null)
                    continue;

                if((bool)chk.Value == true)
                {
                    
                    CheckedList.Add(new BomVO
                    {
                        Product_ID = dgv[1, row.Index].Value.ToInt(),
                        Product_Group_Name = dgv[2, row.Index].Value.ToString(),
                        Product_Name = dgv[3, row.Index].Value.ToString(),
                        Product_Information = dgv[4, row.Index].Value.ToString(),
                        Bom_Use_Quantity = 1
                    }) ;
                }
            }

            // dgv 갱신
            dgv2.DataSource = null;
            dgv2.DataSource = CheckedList;

            // 첫번째 그리드 뷰에 대한 모든 체크박스 없앰
            foreach (DataGridViewRow row in dgv.Rows)
                dgv[0, row.Index].Value = null;

            // 필요 수량은 변경 가능하도록 설정
            foreach (DataGridViewRow row in dgv2.Rows)
                dgv2[5, row.Index].ReadOnly = false;
            
        }


        private void btnUnRegister_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv2[0, row.Index];

                if (chk.Value == null)
                    continue;

                if ((bool)chk.Value == true)
                    CheckedList.RemoveAll(p => p.Product_ID == dgv2[1, row.Index].Value.ToInt());
            }

            dgv2.DataSource = null;
            dgv2.DataSource = CheckedList;

            //List<int> delRows = new List<int>();
            //for(int i = 0; i<dgv2.Rows.Count; i++)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv2[0, i];

            //    if (chk.Value == null)
            //        continue;

            //    if ((bool)chk.Value == true)
            //        delRows.Add(i);                    
            //}

            //if (delRows.Count > 0)
            //{
            //    for (int i = delRows.Count - 1; i > -1; i--)
            //    {
            //        CheckedList.RemoveAt(i);
            //    }
            //}

            foreach (DataGridViewRow row in dgv2.Rows)
                dgv[0, row.Index].Value = null;
        }
    }
    
}
