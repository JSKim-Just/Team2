﻿using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinCoffeePrince2nd.Util;
using WinMSFactory.Services;

namespace WinMSFactory
{
	public partial class EmployeeForm : WinMSFactory.ListForm
	{
		EmployeeService employeeService = new EmployeeService();
		DataTable dt;

		public EmployeeForm()
		{
			InitializeComponent();
		}

		private void EmployeeForm_Load(object sender, EventArgs e)
		{
			try
			{
				dataGridViewControl1.IsAllCheckColumnHeader = true;
				dataGridViewControl1.AddNewColumns("회원 ID", "EMPLOYEE_ID", 100);
				dataGridViewControl1.AddNewColumns("이름", "EMPLOYEE_NAME", 100);
				dataGridViewControl1.AddNewColumns("권한그룹", "ATH_GRP_NAME", 100);
				dataGridViewControl1.AddNewColumns("사용여부", "EMPLOYEE_USE", 100);
				dataGridViewControl1.AddNewColumns("최초등록시간", "FIRST_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최초등록사원", "FIRST_REGIST_EMPLOYEE_NAME", 100);
				dataGridViewControl1.AddNewColumns("최종등록시간", "FINAL_REGIST_TIME", 100);
				dataGridViewControl1.AddNewColumns("최종등록사원", "FINAL_REGIST_EMPLOYEE_NAME", 100);

				LoadData();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void LoadData()
		{
			dt = employeeService.GetAllEmployees();
			dataGridViewControl1.DataSource = dt;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			EmployeeVO employeeVO = this.GetEmployee();
			EmployeePopForm frm = new EmployeePopForm(employeeVO);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				string employee_id = dataGridViewControl1.GetCheckIDs("EMPLOYEE_ID");

				if (string.IsNullOrEmpty(employee_id))
					return;

				if (employeeService.DeleteEmployee(employee_id))
				{
					MessageBox.Show("정상적으로 삭제되었습니다.");
					LoadData();
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void dataGridViewControl1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			EmployeeVO employeeVO = this.GetEmployee();
			string employee_id = dataGridViewControl1["EMPLOYEE_ID", e.RowIndex].Value.ToString();
			EmployeePopForm frm = new EmployeePopForm(employeeVO, employee_id);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}
	}
}
