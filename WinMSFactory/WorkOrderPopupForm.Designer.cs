﻿namespace WinMSFactory
{
	partial class WorkOrderPopupForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.cboFactory = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cboLine = new System.Windows.Forms.ComboBox();
			this.cboProcess = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cboWorker = new System.Windows.Forms.ComboBox();
			this.cboProduct = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
			this.dtpWorkStartTime = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.dtpWorkFinishTime = new System.Windows.Forms.DateTimePicker();
			this.dataGridViewControl1 = new WinMSFactory.DataGridViewControl();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 492);
			this.panel1.Size = new System.Drawing.Size(515, 40);
			// 
			// btnConfirm
			// 
			this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
			this.btnConfirm.FlatAppearance.BorderSize = 0;
			this.btnConfirm.Location = new System.Drawing.Point(216, 0);
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.FlatAppearance.BorderSize = 0;
			this.btnCancel.Location = new System.Drawing.Point(335, 0);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// cboFactory
			// 
			this.cboFactory.FormattingEnabled = true;
			this.cboFactory.Location = new System.Drawing.Point(86, 25);
			this.cboFactory.Name = "cboFactory";
			this.cboFactory.Size = new System.Drawing.Size(121, 24);
			this.cboFactory.TabIndex = 1;
			this.cboFactory.SelectedIndexChanged += new System.EventHandler(this.cboFactory_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(43, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "공장";
			// 
			// cboLine
			// 
			this.cboLine.FormattingEnabled = true;
			this.cboLine.Location = new System.Drawing.Point(288, 25);
			this.cboLine.Name = "cboLine";
			this.cboLine.Size = new System.Drawing.Size(121, 24);
			this.cboLine.TabIndex = 2;
			this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
			// 
			// cboProcess
			// 
			this.cboProcess.FormattingEnabled = true;
			this.cboProcess.Location = new System.Drawing.Point(86, 84);
			this.cboProcess.Name = "cboProcess";
			this.cboProcess.Size = new System.Drawing.Size(121, 24);
			this.cboProcess.TabIndex = 3;
			this.cboProcess.SelectedIndexChanged += new System.EventHandler(this.cboProcess_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(245, 29);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 16);
			this.label7.TabIndex = 2;
			this.label7.Text = "라인";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(43, 88);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(30, 16);
			this.label8.TabIndex = 2;
			this.label8.Text = "공정";
			// 
			// cboWorker
			// 
			this.cboWorker.FormattingEnabled = true;
			this.cboWorker.Location = new System.Drawing.Point(288, 84);
			this.cboWorker.Name = "cboWorker";
			this.cboWorker.Size = new System.Drawing.Size(121, 24);
			this.cboWorker.TabIndex = 4;
			// 
			// cboProduct
			// 
			this.cboProduct.FormattingEnabled = true;
			this.cboProduct.Location = new System.Drawing.Point(86, 143);
			this.cboProduct.Name = "cboProduct";
			this.cboProduct.Size = new System.Drawing.Size(121, 24);
			this.cboProduct.TabIndex = 5;
			this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(234, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "작업자";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(43, 147);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "품목";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(21, 205);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 16);
			this.label5.TabIndex = 2;
			this.label5.Text = "작업일자";
			// 
			// dtpWorkDate
			// 
			this.dtpWorkDate.Location = new System.Drawing.Point(86, 202);
			this.dtpWorkDate.Name = "dtpWorkDate";
			this.dtpWorkDate.Size = new System.Drawing.Size(172, 22);
			this.dtpWorkDate.TabIndex = 6;
			// 
			// dtpWorkStartTime
			// 
			this.dtpWorkStartTime.CustomFormat = "HH:mm";
			this.dtpWorkStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpWorkStartTime.Location = new System.Drawing.Point(86, 258);
			this.dtpWorkStartTime.Name = "dtpWorkStartTime";
			this.dtpWorkStartTime.ShowUpDown = true;
			this.dtpWorkStartTime.Size = new System.Drawing.Size(121, 22);
			this.dtpWorkStartTime.TabIndex = 7;
			this.dtpWorkStartTime.Value = new System.DateTime(2020, 8, 19, 9, 0, 0, 0);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(21, 261);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "시작시간";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(223, 261);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 16);
			this.label9.TabIndex = 2;
			this.label9.Text = "종료시간";
			// 
			// dtpWorkFinishTime
			// 
			this.dtpWorkFinishTime.CustomFormat = "HH:mm";
			this.dtpWorkFinishTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpWorkFinishTime.Location = new System.Drawing.Point(288, 258);
			this.dtpWorkFinishTime.Name = "dtpWorkFinishTime";
			this.dtpWorkFinishTime.ShowUpDown = true;
			this.dtpWorkFinishTime.Size = new System.Drawing.Size(121, 22);
			this.dtpWorkFinishTime.TabIndex = 8;
			this.dtpWorkFinishTime.Value = new System.DateTime(2020, 8, 19, 9, 0, 0, 0);
			// 
			// dataGridViewControl1
			// 
			this.dataGridViewControl1.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridViewControl1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewControl1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewControl1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewControl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewControl1.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewControl1.IsAllCheckColumnHeader = true;
			this.dataGridViewControl1.IsAutoGenerateColumns = false;
			this.dataGridViewControl1.Location = new System.Drawing.Point(20, 306);
			this.dataGridViewControl1.MultiSelect = false;
			this.dataGridViewControl1.Name = "dataGridViewControl1";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewControl1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewControl1.RowHeadersVisible = false;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DimGray;
			this.dataGridViewControl1.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewControl1.RowTemplate.Height = 27;
			this.dataGridViewControl1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewControl1.Size = new System.Drawing.Size(475, 150);
			this.dataGridViewControl1.TabIndex = 9;
			this.dataGridViewControl1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewControl1_CellClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(234, 151);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "작업량";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(288, 148);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
			this.numericUpDown1.TabIndex = 5;
			// 
			// WorkOrderPopupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(515, 532);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.dataGridViewControl1);
			this.Controls.Add(this.dtpWorkFinishTime);
			this.Controls.Add(this.dtpWorkStartTime);
			this.Controls.Add(this.dtpWorkDate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cboProduct);
			this.Controls.Add(this.cboProcess);
			this.Controls.Add(this.cboWorker);
			this.Controls.Add(this.cboLine);
			this.Controls.Add(this.cboFactory);
			this.Name = "WorkOrderPopupForm";
			this.Text = "작업지시";
			this.Load += new System.EventHandler(this.WorkOrderPopupForm_Load);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.cboFactory, 0);
			this.Controls.SetChildIndex(this.cboLine, 0);
			this.Controls.SetChildIndex(this.cboWorker, 0);
			this.Controls.SetChildIndex(this.cboProcess, 0);
			this.Controls.SetChildIndex(this.cboProduct, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.label9, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.dtpWorkDate, 0);
			this.Controls.SetChildIndex(this.dtpWorkStartTime, 0);
			this.Controls.SetChildIndex(this.dtpWorkFinishTime, 0);
			this.Controls.SetChildIndex(this.dataGridViewControl1, 0);
			this.Controls.SetChildIndex(this.numericUpDown1, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox cboFactory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboLine;
		private System.Windows.Forms.ComboBox cboProcess;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cboWorker;
		private System.Windows.Forms.ComboBox cboProduct;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpWorkDate;
		private System.Windows.Forms.DateTimePicker dtpWorkStartTime;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker dtpWorkFinishTime;
		private DataGridViewControl dataGridViewControl1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
	}
}
