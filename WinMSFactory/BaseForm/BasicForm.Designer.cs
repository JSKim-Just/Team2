﻿namespace WinMSFactory
{
    partial class BasicForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.GuidLabel1 = new System.Windows.Forms.Label();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.separatorControl1);
            this.panel2.Controls.Add(this.GuidLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1753, 100);
            this.panel2.TabIndex = 4;
            // 
            // GuidLabel1
            // 
            this.GuidLabel1.AutoSize = true;
            this.GuidLabel1.Location = new System.Drawing.Point(94, 51);
            this.GuidLabel1.Name = "GuidLabel1";
            this.GuidLabel1.Size = new System.Drawing.Size(274, 15);
            this.GuidLabel1.TabIndex = 4;
            this.GuidLabel1.Text = "검색 영역 (필요에 따라 높이 조절 가능)";
            this.GuidLabel1.Visible = false;
            // 
            // separatorControl1
            // 
            this.separatorControl1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.separatorControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separatorControl1.Location = new System.Drawing.Point(0, 91);
            this.separatorControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Padding = new System.Windows.Forms.Padding(14, 14, 14, 14);
            this.separatorControl1.Size = new System.Drawing.Size(1753, 9);
            this.separatorControl1.TabIndex = 6;
            // 
            // BasicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1753, 951);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BasicForm";
            this.Text = "BasicForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Label GuidLabel1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
    }
}