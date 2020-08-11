﻿using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory
{
    public partial class ProductPriceManageForm : ListForm
    {

        ProductService service = new ProductService();
        List<ProductPriceManageVO> SelectList;
        public ProductPriceManageForm()
        {
            InitializeComponent();
        }

        private void ProductPriceForm_Load(object sender, EventArgs e)
        {
            MainColumns();

            SelectList = service.ProductPriceSelect();
            dgv.DataSource = SelectList;
        }

        private void MainColumns()
        {
            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
           
            dgv.AddNewColumns("업체명", "Company_Name", 150, true);
            dgv.AddNewColumns("품목명", "Product_Name", 200, true);
            dgv.AddNewColumns("품목 스펙(규격)", "Product_Information", 200, true);
            dgv.AddNewColumns("품목 단위", "Product_unit", 80, true);
            dgv.AddNewColumns("현재 단가", "Material_Current_Price_String", 120, true, true, false, RightAlign);
            dgv.AddNewColumns("이전 단가", "Material_Previous_Price_String", 120, true, true, false, RightAlign);
            dgv.AddNewColumns("시작일", "Start_Date", 100, true);
            dgv.AddNewColumns("종료일", "End_Date", 100, true);
            dgv.AddNewColumns("비고", "Note", 300, true);
            dgv.AddNewColumns("코드번호", "Material_Price_Code", 150, false);    // 코드 번호
            dgv.AddNewColumns("순위", "RankNum", 100, true);
            dgv.AddNewColumns("품목번호", "Product_ID", 100, true);
            dgv.AddNewColumns("업체번호", "Company_ID", 100, true);
        }


        private void Add(object sender, EventArgs e) // 등록
        {
            SettingFormOpen(true);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // 수정
        {
            if (e.RowIndex < 0)
                return;

            else if (IsLastInsert("수정", e.RowIndex) == false)
                return;

            string StartDate = Convert.ToDateTime(dgv[6, e.RowIndex].Value).ToShortDateString();
            string EndDate = string.Empty;

            if (dgv[7, e.RowIndex].Value == null)
                EndDate = null;

            ProductPriceManageVO ManageVO = new ProductPriceManageVO
            {
                Company_Name = dgv[0, e.RowIndex].Value.ToString(),
                Product_Name = dgv[1, e.RowIndex].Value.ToString(),
                Product_Information = dgv[2, e.RowIndex].Value.ToString(),
                Material_Current_Price_String = dgv[4, e.RowIndex].Value.ToString().Replace(" 원", ""),
                Material_Previous_Price_String = dgv[5, e.RowIndex].Value.ToString().Replace(" 원", ""),
                Start_Date_String = StartDate,
                End_Date_String = EndDate,
                Note = dgv[8, e.RowIndex].Value.ToString(),
                Material_Price_Code = dgv[9, e.RowIndex].Value.ToInt()
            };
            SettingFormOpen(false, ManageVO);
        }

        

        private void SettingFormOpen(bool IsInsert, ProductPriceManageVO ManageVO = null) // 등록 / 수정에 따른 폼 open
        {
            ProductPriceDialogForm frm = new ProductPriceDialogForm(IsInsert, ManageVO);

            if (frm.ShowDialog() == DialogResult.OK) // 정상적으로 실행 후 종료된 경우
            {
                ReviewDGV(); // 데이터 갱신!!
            }
        }

        private void ReviewDGV()
        {
            dgv.Columns.Clear();
            MainColumns();
            SelectList = service.ProductPriceSelect();
            dgv.DataSource = SelectList;
        }

        private void Delete(object sender, EventArgs e) // 삭제
        {
            if(dgv.SelectedRows.Count>0)
            {
                if(MessageBox.Show("정말로 삭제하시겠습니까?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int SelectedRow = dgv.SelectedRows[0].Index;

                    // 최근에 변경된 내용을 삭제하지 않았을 경우
                    if (IsLastInsert("삭제", SelectedRow) == false)
                        return;

                    int value = dgv.SelectedRows[0].Cells[9].Value.ToInt();
                    if(service.DeleteMaterialPrice(value))
                    {
                        MessageBox.Show("삭제를 완료하였습니다.");
                        ReviewDGV();
                    }
                }
            }
        }

        private bool IsLastInsert(string Status, int SelectedRow)
        {
            List<ProductPriceManageVO> list = (List<ProductPriceManageVO>)dgv.DataSource;

            int SelectNum = list.FindAll(p => p.Product_ID == dgv[11, SelectedRow].Value.ToInt()
                                                    && p.Company_ID == dgv[12, SelectedRow].Value.ToInt()).Max(p => p.RankNum);

            if (SelectNum != dgv[10, SelectedRow].Value.ToInt())
            {
                MessageBox.Show($"가장 최근에 생성된 {Status}만 변경이 가능합니다.");
                return false;
            }
            return true;
        }

        private void Search(object sender, EventArgs e)
        {
            SearchMethod();
        }

        private void SearchMethod()
        {
            if (textBox1.TextLength < 1)
            {
                var SortedList = (from item in SelectList
                                  where item.Start_Date >= fromToDate.From.AddDays(-1) && item.Start_Date <= fromToDate.To
                                  select item).ToList();

                dgv.DataSource = SortedList;
            }
            else
            {
                var SortedList = (from item in SelectList
                                  where item.Start_Date >= fromToDate.From.AddDays(-1) && item.Start_Date <= fromToDate.To && item.Product_Name.Contains(textBox1.Text)
                                  select item).ToList();

                dgv.DataSource = SortedList;
            }
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchMethod();
        }
        private void Clear(object sender, EventArgs e)
        {
            ReviewDGV();
        }
    }
}
