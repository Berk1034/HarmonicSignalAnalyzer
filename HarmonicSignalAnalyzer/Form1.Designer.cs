namespace HarmonicSignalAnalyzer
{
    partial class Form1
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
            this.pb_Graphics = new System.Windows.Forms.PictureBox();
            this.lbl_FiAngle = new System.Windows.Forms.Label();
            this.tb_FiAngle = new System.Windows.Forms.TextBox();
            this.btn_Calculate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Graphics)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_Graphics
            // 
            this.pb_Graphics.BackColor = System.Drawing.SystemColors.Window;
            this.pb_Graphics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Graphics.Location = new System.Drawing.Point(0, 0);
            this.pb_Graphics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pb_Graphics.Name = "pb_Graphics";
            this.pb_Graphics.Size = new System.Drawing.Size(862, 453);
            this.pb_Graphics.TabIndex = 0;
            this.pb_Graphics.TabStop = false;
            this.pb_Graphics.Resize += new System.EventHandler(this.pb_Graphics_Resize);
            // 
            // lbl_FiAngle
            // 
            this.lbl_FiAngle.AutoSize = true;
            this.lbl_FiAngle.Location = new System.Drawing.Point(272, 20);
            this.lbl_FiAngle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FiAngle.Name = "lbl_FiAngle";
            this.lbl_FiAngle.Size = new System.Drawing.Size(59, 17);
            this.lbl_FiAngle.TabIndex = 1;
            this.lbl_FiAngle.Text = "FiAngle:";
            // 
            // tb_FiAngle
            // 
            this.tb_FiAngle.Location = new System.Drawing.Point(336, 18);
            this.tb_FiAngle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_FiAngle.Name = "tb_FiAngle";
            this.tb_FiAngle.Size = new System.Drawing.Size(66, 22);
            this.tb_FiAngle.TabIndex = 2;
            this.tb_FiAngle.Text = "22,5";
            // 
            // btn_Calculate
            // 
            this.btn_Calculate.Location = new System.Drawing.Point(439, 16);
            this.btn_Calculate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Calculate.Name = "btn_Calculate";
            this.btn_Calculate.Size = new System.Drawing.Size(99, 32);
            this.btn_Calculate.TabIndex = 3;
            this.btn_Calculate.Text = "Calculate";
            this.btn_Calculate.UseVisualStyleBackColor = true;
            this.btn_Calculate.Click += new System.EventHandler(this.btn_Calculate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_FiAngle);
            this.panel1.Controls.Add(this.btn_Calculate);
            this.panel1.Controls.Add(this.tb_FiAngle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 389);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 64);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pb_Graphics);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pb_Graphics)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Graphics;
        private System.Windows.Forms.Label lbl_FiAngle;
        private System.Windows.Forms.TextBox tb_FiAngle;
        private System.Windows.Forms.Button btn_Calculate;
        private System.Windows.Forms.Panel panel1;
    }
}

