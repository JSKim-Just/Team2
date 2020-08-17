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
using WinMSFactory.Services;

namespace WinMSFactory
{
    public partial class InOutListForm : ListForm
    {
        OrderService orderService = new OrderService();
        DataTable dt ;

        public InOutListForm()
        {
            InitializeComponent();
        }

        private void InOutListForm_Load(object sender, EventArgs e)
        {
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightBlue;
            dgv.ColumnHeadersHeight = 30;

            dgv.AddNewColumns("입출고", "gubun", 70, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv.AddNewColumns("번호", "release_no", 60, true, true, false, DataGridViewContentAlignment.MiddleRight);
            dgv.AddNewColumns("창고ID", "storage_id", 100, false, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv.AddNewColumns("창고", "storage_name", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv.AddNewColumns("품목", "product_id", 100, false, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv.AddNewColumns("품목유형", "product_type", 100, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv.AddNewColumns("품명", "product_name", 150, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            dgv.AddNewColumns("수량", "release_quantity", 80, true, true, false, DataGridViewContentAlignment.MiddleRight);
            dgv.AddNewColumns("입출고일", "release_date", 120, true, true, false, DataGridViewContentAlignment.MiddleLeft);
            
            
            dt = orderService.GetInOutList();
            dgv.DataSource = dt;

            ReleaseService releaseService = new ReleaseService();
            cboProduct.ComboBinding(releaseService.SelectProduct(), "Product_ID", "Product_Name", "전체");

            cboGubun.SelectedIndex = 0;            
        }



        private void Search(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                List<InOutVO> pList;
                OrderService service = new OrderService();

                string fromDate = fromToDateControl1.From.ToShortDateString();
                string toDate = fromToDateControl1.To.ToShortDateString();

                pList = service.GetInOutByDate(fromDate, toDate);
                int searchProduct = Convert.ToInt32(cboProduct.SelectedValue);
                
                if (cboGubun.SelectedIndex == 0)
                {                    
                    dgv.DataSource = orderService.GetInOutList();                    
                }
                else if (!string.IsNullOrEmpty(cboGubun.SelectedItem.ToString()))
                {
                    pList = (from item in pList
                             where item.gubun.Contains(cboGubun.SelectedItem.ToString())
                             select item).ToList();
                }

                if (cboProduct.SelectedIndex == 0)
                {
                    dgv.DataSource = orderService.GetInOutList();
                }
                else if(cboProduct.SelectedIndex != 0 )
                {
                    dgv.DataSource = orderService.GetInOutListByGubun(cboGubun.SelectedItem.ToString());
                    return;
                }
                else if (!string.IsNullOrEmpty(searchProduct.ToString()))
                {
                    pList = (from item in pList
                             where item.product_id == searchProduct
                             where item.gubun == "입고"                              
                             select item).ToList();
                }
                dgv.DataSource = null;
                dgv.DataSource = pList;
            }
        }
    }
}
