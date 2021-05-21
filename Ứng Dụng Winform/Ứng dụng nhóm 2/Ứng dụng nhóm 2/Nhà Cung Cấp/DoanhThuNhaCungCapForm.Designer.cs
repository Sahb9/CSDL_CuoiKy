namespace Ứng_dụng_nhóm_2
{
    partial class DoanhThuNhaCungCapForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboBoxNhaCungCap = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelTenCty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxNhaCungCap
            // 
            this.comboBoxNhaCungCap.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxNhaCungCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNhaCungCap.FocusedColor = System.Drawing.Color.Empty;
            this.comboBoxNhaCungCap.FocusedState.Parent = this.comboBoxNhaCungCap;
            this.comboBoxNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxNhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxNhaCungCap.FormattingEnabled = true;
            this.comboBoxNhaCungCap.HoverState.Parent = this.comboBoxNhaCungCap;
            this.comboBoxNhaCungCap.ItemHeight = 30;
            this.comboBoxNhaCungCap.ItemsAppearance.Parent = this.comboBoxNhaCungCap;
            this.comboBoxNhaCungCap.Location = new System.Drawing.Point(150, 12);
            this.comboBoxNhaCungCap.Name = "comboBoxNhaCungCap";
            this.comboBoxNhaCungCap.ShadowDecoration.Parent = this.comboBoxNhaCungCap;
            this.comboBoxNhaCungCap.Size = new System.Drawing.Size(168, 36);
            this.comboBoxNhaCungCap.TabIndex = 0;
            this.comboBoxNhaCungCap.SelectedIndexChanged += new System.EventHandler(this.comboBoxNhaCungCap_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Nhà Cung Cấp";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 83);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Tien$";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(299, 216);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // labelTenCty
            // 
            this.labelTenCty.AutoSize = true;
            this.labelTenCty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenCty.Location = new System.Drawing.Point(12, 57);
            this.labelTenCty.Name = "labelTenCty";
            this.labelTenCty.Size = new System.Drawing.Size(92, 13);
            this.labelTenCty.TabIndex = 3;
            this.labelTenCty.Text = "Tên Công Ty : ";
            // 
            // DoanhThuNhaCungCapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(331, 300);
            this.Controls.Add(this.labelTenCty);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxNhaCungCap);
            this.Name = "DoanhThuNhaCungCapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoanhThuNhaCungCapForm";
            this.Load += new System.EventHandler(this.DoanhThuNhaCungCapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox comboBoxNhaCungCap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label labelTenCty;
    }
}