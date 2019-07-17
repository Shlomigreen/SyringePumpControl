namespace PumpControl
{
    partial class VolumeCalculator
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
            this.tb_units = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_time = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_volume = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_ok = new System.Windows.Forms.Button();
            this.tb_rate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_units
            // 
            this.tb_units.Enabled = false;
            this.tb_units.Location = new System.Drawing.Point(93, 32);
            this.tb_units.Name = "tb_units";
            this.tb_units.Size = new System.Drawing.Size(85, 20);
            this.tb_units.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rate Untis:";
            // 
            // tb_time
            // 
            this.tb_time.Location = new System.Drawing.Point(93, 59);
            this.tb_time.Name = "tb_time";
            this.tb_time.Size = new System.Drawing.Size(85, 20);
            this.tb_time.TabIndex = 2;
            this.tb_time.TextChanged += new System.EventHandler(this.tb_time_TextChanged);
            this.tb_time.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_time_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Runtime(min):";
            // 
            // tb_volume
            // 
            this.tb_volume.Enabled = false;
            this.tb_volume.Location = new System.Drawing.Point(50, 105);
            this.tb_volume.Name = "tb_volume";
            this.tb_volume.Size = new System.Drawing.Size(85, 20);
            this.tb_volume.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Volume to Dispense:";
            // 
            // bt_ok
            // 
            this.bt_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(92)))), ((int)(((byte)(78)))));
            this.bt_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ok.ForeColor = System.Drawing.Color.White;
            this.bt_ok.Location = new System.Drawing.Point(57, 132);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 27);
            this.bt_ok.TabIndex = 6;
            this.bt_ok.Text = "OK";
            this.bt_ok.UseVisualStyleBackColor = false;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // tb_rate
            // 
            this.tb_rate.Enabled = false;
            this.tb_rate.Location = new System.Drawing.Point(93, 6);
            this.tb_rate.Name = "tb_rate";
            this.tb_rate.Size = new System.Drawing.Size(85, 20);
            this.tb_rate.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Rate:";
            // 
            // VolumeCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(194)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(190, 162);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_volume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_time);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_rate);
            this.Controls.Add(this.tb_units);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VolumeCalculator";
            this.Text = "Volume Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_units;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_volume;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.TextBox tb_rate;
        private System.Windows.Forms.Label label4;
    }
}