﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory.Control
{
    public partial class FromToDateControl : UserControl
    {
        public FromToDateControl()
        {
            InitializeComponent();
        }

        private void FromToDateControl_Load(object sender, EventArgs e)
        {
            //if (dtpFrom.Value > dtpTo.Value)
            //{
            //    MessageBox.Show("날짜를 잘못 입력하셨습니다.");
            //    dtpFrom.Value = dtpTo.Value.AddDays(-1);
            //    return;
            //}
        }

    }
}
