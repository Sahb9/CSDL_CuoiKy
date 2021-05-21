namespace Ứng_dụng_nhóm_2
{
    partial class DoanhThuCuaHangForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelCuaHang = new System.Windows.Forms.Label();
            this.comboBoxCuaHang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelTenCH = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 83);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Tien$";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(299, 216);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // labelCuaHang
            // 
            this.labelCuaHang.AutoSize = true;
            this.labelCuaHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCuaHang.Location = new System.Drawing.Point(12, 11);
            this.labelCuaHang.Name = "labelCuaHang";
            this.labelCuaHang.Size = new System.Drawing.Size(101, 16);
            this.labelCuaHang.TabIndex = 4;
            this.labelCuaHang.Text = "Mã Cửa Hàng";
            // 
            // comboBoxCuaHang
            // 
            this.comboBoxCuaHang.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxCuaHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxCuaHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCuaHang.FocusedColor = System.Drawing.Color.Empty;
            this.comboBoxCuaHang.FocusedState.Parent = this.comboBoxCuaHang;
            this.comboBoxCuaHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxCuaHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxCuaHang.FormattingEnabled = true;
            this.comboBoxCuaHang.HoverState.Parent = this.comboBoxCuaHang;
            this.comboBoxCuaHang.ItemHeight = 30;
            this.comboBoxCuaHang.ItemsAppearance.Parent = this.comboBoxCuaHang;
            this.comboBoxCuaHang.Location = new System.Drawing.Point(151, 12);
            this.comboBoxCuaHang.Name = "comboBoxCuaHang";
            this.comboBoxCuaHang.ShadowDecoration.Parent = this.comboBoxCuaHang;
            this.comboBoxCuaHang.Size = new System.Drawing.Size(168, 36);
            this.comboBoxCuaHang.TabIndex = 3;
            this.comboBoxCuaHang.SelectedIndexChanged += new System.EventHandler(this.comboBoxCuaHang_SelectedIndexChanged);
            // 
            // labelTenCH
            // 
            this.labelTenCH.AutoSize = true;
            this.labelTenCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenCH.Location = new System.Drawing.Point(12, 58);
            this.labelTenCH.Name = "labelTenCH";
            this.labelTenCH.Size = new System.Drawing.Size(101, 13);
            this.labelTenCH.TabIndex = 6;
            this.labelTenCH.Text = "Tên Cửa Hàng : ";
            // 
            // DoanhThuCuaHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(331, 300);
            this.Controls.Add(this.labelTenCH);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelCuaHang);
            this.Controls.Add(this.comboBoxCuaHang);
            this.Name = "DoanhThuCuaHangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoanhThuCuaHangForm";
            this.Load += new System.EventHandler(this.DoanhThuCuaHangForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label labelCuaHang;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxCuaHang;
        private System.Windows.Forms.Label labelTenCH;
    }
}