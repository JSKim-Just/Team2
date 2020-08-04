﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class ProductionStatusForm : BasicForm
    {
        ProductionService service = new ProductionService();
        // 생산 실적 현황
        
        public ProductionStatusForm()
        {
            InitializeComponent();
        }

        private void frmAWoHis_Load(object sender, EventArgs e)
        {
            // 일부는 팝업창을 따로 만들어 보여줄 것 (보류)
            FirstGridViewColumns();
            SecondGridViewColumns();
            ThirdGridViewColumns();

            dgv.DataSource = service.ProductionStatusSelect();
            dgv2.DataSource = service.DefectiveSelect();
            
        }

        private void ThirdGridViewColumns()
        {
            //dgv3.AddNewColumns("작업지시번호", "", 100, false);
            //dgv3.AddNewColumns("비가동 코드", "", 100, false);
            dgv3.AddNewColumns("비가동 일자", "", 100, true);
            dgv3.AddNewColumns("비가동 명칭", "", 100, true);
            dgv3.AddNewColumns("작업자", "", 100, true); //비가동 - 작업지시 번호 - 작업자 코드 - 작업자 명 
            //dgv3.AddNewColumns("비가동 시작시간", "", 100, false);
            //dgv3.AddNewColumns("비가동 종료시간", "", 100, false);
            dgv3.AddNewColumns("비가동 총 시간", "", 100, true); // 비가동 종료 시간 - 비가동 시작시간
        }

        private void SecondGridViewColumns()
        {
            dgv2.AddNewColumns("불량코드", "defection_code", 100, false);
            dgv2.AddNewColumns("불량명", "defection_name", 100, true);
            dgv2.AddNewColumns("불량 수량", "", 100, true);
            dgv2.AddNewColumns("불량 일자", "", 100, true);
            dgv2.AddNewColumns("비고", "", 100, true);
        }

        private void FirstGridViewColumns()
        {
            dgv.AddNewColumns("작업지시 번호", "", 100, true);
            dgv.AddNewColumns("작업일자", "", 100, true);
            dgv.AddNewColumns("품목명칭", "", 100, true);
            dgv.AddNewColumns("지시수량", "", 100, true);
            dgv.AddNewColumns("양품수량", "", 100, true);
            dgv.AddNewColumns("불량수량", "", 100, true);
            dgv.AddNewColumns("작업자", "", 100, true);
            dgv.AddNewColumns("작업시작시간", "", 100, true);
            dgv.AddNewColumns("작업종료시간", "", 100, true);
        }
        
        
    }
}