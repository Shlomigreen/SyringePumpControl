namespace PumpControl
{
    partial class DiameterPickup
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
            this.combo_manufacturer = new System.Windows.Forms.ComboBox();
            this.lb_manufacturer = new System.Windows.Forms.Label();
            this.combo_syringeVolume = new System.Windows.Forms.ComboBox();
            this.lb_syringeVolume = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_diameter = new System.Windows.Forms.Label();
            this.lb_submitDiameter = new System.Windows.Forms.Label();
            this.bt_ok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.table_maxRate = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_mlhr = new System.Windows.Forms.Label();
            this.lb_mlmin = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_minulmin = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lb_minulhr = new System.Windows.Forms.Label();
            this.table_maxRate.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo_manufacturer
            // 
            this.combo_manufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_manufacturer.FormattingEnabled = true;
            this.combo_manufacturer.Location = new System.Drawing.Point(94, 28);
            this.combo_manufacturer.Name = "combo_manufacturer";
            this.combo_manufacturer.Size = new System.Drawing.Size(121, 21);
            this.combo_manufacturer.TabIndex = 0;
            this.combo_manufacturer.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lb_manufacturer
            // 
            this.lb_manufacturer.AutoSize = true;
            this.lb_manufacturer.Location = new System.Drawing.Point(8, 32);
            this.lb_manufacturer.Name = "lb_manufacturer";
            this.lb_manufacturer.Size = new System.Drawing.Size(73, 13);
            this.lb_manufacturer.TabIndex = 1;
            this.lb_manufacturer.Text = "Manufacturer:";
            // 
            // combo_syringeVolume
            // 
            this.combo_syringeVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_syringeVolume.FormattingEnabled = true;
            this.combo_syringeVolume.Location = new System.Drawing.Point(94, 70);
            this.combo_syringeVolume.Name = "combo_syringeVolume";
            this.combo_syringeVolume.Size = new System.Drawing.Size(74, 21);
            this.combo_syringeVolume.TabIndex = 0;
            this.combo_syringeVolume.TextChanged += new System.EventHandler(this.combo_syringeVolume_TextChanged);
            // 
            // lb_syringeVolume
            // 
            this.lb_syringeVolume.AutoSize = true;
            this.lb_syringeVolume.Location = new System.Drawing.Point(8, 74);
            this.lb_syringeVolume.Name = "lb_syringeVolume";
            this.lb_syringeVolume.Size = new System.Drawing.Size(83, 13);
            this.lb_syringeVolume.TabIndex = 1;
            this.lb_syringeVolume.Text = "Syringe Volume:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "mL";
            // 
            // lb_diameter
            // 
            this.lb_diameter.AutoSize = true;
            this.lb_diameter.Location = new System.Drawing.Point(12, 115);
            this.lb_diameter.Name = "lb_diameter";
            this.lb_diameter.Size = new System.Drawing.Size(52, 13);
            this.lb_diameter.TabIndex = 3;
            this.lb_diameter.Text = "Diameter:";
            // 
            // lb_submitDiameter
            // 
            this.lb_submitDiameter.AutoSize = true;
            this.lb_submitDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_submitDiameter.ForeColor = System.Drawing.Color.Red;
            this.lb_submitDiameter.Location = new System.Drawing.Point(95, 115);
            this.lb_submitDiameter.Name = "lb_submitDiameter";
            this.lb_submitDiameter.Size = new System.Drawing.Size(11, 13);
            this.lb_submitDiameter.TabIndex = 4;
            this.lb_submitDiameter.Text = " ";
            // 
            // bt_ok
            // 
            this.bt_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(92)))), ((int)(((byte)(78)))));
            this.bt_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ok.ForeColor = System.Drawing.Color.White;
            this.bt_ok.Location = new System.Drawing.Point(177, 147);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 27);
            this.bt_ok.TabIndex = 7;
            this.bt_ok.Text = "OK";
            this.bt_ok.UseVisualStyleBackColor = false;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(230, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Max Rate";
            // 
            // table_maxRate
            // 
            this.table_maxRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(214)))), ((int)(((byte)(200)))));
            this.table_maxRate.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.table_maxRate.ColumnCount = 2;
            this.table_maxRate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_maxRate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_maxRate.Controls.Add(this.lb_mlmin, 1, 0);
            this.table_maxRate.Controls.Add(this.lb_mlhr, 0, 0);
            this.table_maxRate.Location = new System.Drawing.Point(296, 29);
            this.table_maxRate.Name = "table_maxRate";
            this.table_maxRate.RowCount = 1;
            this.table_maxRate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_maxRate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_maxRate.Size = new System.Drawing.Size(135, 41);
            this.table_maxRate.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "mL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "hr";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "min";
            // 
            // lb_mlhr
            // 
            this.lb_mlhr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_mlhr.AutoSize = true;
            this.lb_mlhr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mlhr.Location = new System.Drawing.Point(28, 14);
            this.lb_mlhr.Name = "lb_mlhr";
            this.lb_mlhr.Size = new System.Drawing.Size(11, 13);
            this.lb_mlhr.TabIndex = 14;
            this.lb_mlhr.Text = " ";
            // 
            // lb_mlmin
            // 
            this.lb_mlmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_mlmin.AutoSize = true;
            this.lb_mlmin.Location = new System.Drawing.Point(96, 14);
            this.lb_mlmin.Name = "lb_mlmin";
            this.lb_mlmin.Size = new System.Drawing.Size(10, 13);
            this.lb_mlmin.TabIndex = 15;
            this.lb_mlmin.Text = " ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(233, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Min Rate";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(214)))), ((int)(((byte)(200)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lb_minulmin, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_minulhr, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(296, 96);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(135, 41);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // lb_minulmin
            // 
            this.lb_minulmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_minulmin.AutoSize = true;
            this.lb_minulmin.Location = new System.Drawing.Point(96, 14);
            this.lb_minulmin.Name = "lb_minulmin";
            this.lb_minulmin.Size = new System.Drawing.Size(10, 13);
            this.lb_minulmin.TabIndex = 17;
            this.lb_minulmin.Text = " ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(271, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "μL";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(320, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "hr";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(391, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "min";
            // 
            // lb_minulhr
            // 
            this.lb_minulhr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_minulhr.AutoSize = true;
            this.lb_minulhr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_minulhr.Location = new System.Drawing.Point(28, 14);
            this.lb_minulhr.Name = "lb_minulhr";
            this.lb_minulhr.Size = new System.Drawing.Size(11, 13);
            this.lb_minulhr.TabIndex = 16;
            this.lb_minulhr.Text = " ";
            // 
            // DiameterPickup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(194)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(438, 180);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.table_maxRate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.lb_submitDiameter);
            this.Controls.Add(this.lb_diameter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_syringeVolume);
            this.Controls.Add(this.combo_syringeVolume);
            this.Controls.Add(this.lb_manufacturer);
            this.Controls.Add(this.combo_manufacturer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DiameterPickup";
            this.Text = "Pick Diameter";
            this.table_maxRate.ResumeLayout(false);
            this.table_maxRate.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_manufacturer;
        private System.Windows.Forms.Label lb_manufacturer;
        private System.Windows.Forms.ComboBox combo_syringeVolume;
        private System.Windows.Forms.Label lb_syringeVolume;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_diameter;
        private System.Windows.Forms.Label lb_submitDiameter;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel table_maxRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_mlmin;
        private System.Windows.Forms.Label lb_mlhr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lb_minulmin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lb_minulhr;
    }
}