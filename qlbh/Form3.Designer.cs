namespace qlbh
{
    partial class FormBaoCao
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoluong = new System.Windows.Forms.Label();
            this.Nhacc = new System.Windows.Forms.Label();
            this.listNhaCC = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(221, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(264, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Báo cáo chi tiết Sản phẩm";
            // 
            // txtSoluong
            // 
            this.txtSoluong.AutoSize = true;
            this.txtSoluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoluong.Location = new System.Drawing.Point(12, 143);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(98, 25);
            this.txtSoluong.TabIndex = 14;
            this.txtSoluong.Text = "Số lượng";
            // 
            // Nhacc
            // 
            this.Nhacc.AutoSize = true;
            this.Nhacc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nhacc.Location = new System.Drawing.Point(12, 104);
            this.Nhacc.Name = "Nhacc";
            this.Nhacc.Size = new System.Drawing.Size(186, 25);
            this.Nhacc.TabIndex = 15;
            this.Nhacc.Text = "Tên nhà cung cấp";
            // 
            // listNhaCC
            // 
            this.listNhaCC.FormattingEnabled = true;
            this.listNhaCC.Location = new System.Drawing.Point(243, 108);
            this.listNhaCC.Name = "listNhaCC";
            this.listNhaCC.Size = new System.Drawing.Size(242, 21);
            this.listNhaCC.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(159, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 20);
            this.textBox1.TabIndex = 17;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(443, 143);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(242, 20);
            this.textBox2.TabIndex = 18;
            // 
            // FormBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(712, 502);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listNhaCC);
            this.Controls.Add(this.Nhacc);
            this.Controls.Add(this.txtSoluong);
            this.Controls.Add(this.label8);
            this.Name = "FormBaoCao";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtSoluong;
        private System.Windows.Forms.Label Nhacc;
        private System.Windows.Forms.ComboBox listNhaCC;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}