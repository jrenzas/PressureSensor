namespace PressureSensor
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUnits = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelPressure = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownAlarm = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe Script", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 135);
            this.button1.TabIndex = 0;
            this.button1.Text = "Go!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(44, 153);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(31, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port";
            // 
            // labelUnits
            // 
            this.labelUnits.AutoSize = true;
            this.labelUnits.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnits.Location = new System.Drawing.Point(362, 33);
            this.labelUnits.Name = "labelUnits";
            this.labelUnits.Size = new System.Drawing.Size(52, 29);
            this.labelUnits.TabIndex = 3;
            this.labelUnits.Text = "psi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(280, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 62);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // labelPressure
            // 
            this.labelPressure.AutoSize = true;
            this.labelPressure.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPressure.Location = new System.Drawing.Point(283, 33);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(73, 29);
            this.labelPressure.TabIndex = 6;
            this.labelPressure.Text = "00.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Alarm Threshold (psi)";
            // 
            // numericUpDownAlarm
            // 
            this.numericUpDownAlarm.Location = new System.Drawing.Point(376, 153);
            this.numericUpDownAlarm.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownAlarm.Name = "numericUpDownAlarm";
            this.numericUpDownAlarm.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownAlarm.TabIndex = 7;
            this.numericUpDownAlarm.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownAlarm.ValueChanged += new System.EventHandler(this.numericUpDownAlarm_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 177);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownAlarm);
            this.Controls.Add(this.labelPressure);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelUnits);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Pressure Sensor, Russ Renzas, 2015";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUnits;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label labelPressure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownAlarm;
    }
}

