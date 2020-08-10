namespace TZPUInterfejs
{
    partial class IPForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipTXT = new System.Windows.Forms.TextBox();
            this.subnetTXT = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP adresa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subnet maska:";
            // 
            // ipTXT
            // 
            this.ipTXT.Location = new System.Drawing.Point(203, 53);
            this.ipTXT.Name = "ipTXT";
            this.ipTXT.Size = new System.Drawing.Size(240, 22);
            this.ipTXT.TabIndex = 2;
            // 
            // subnetTXT
            // 
            this.subnetTXT.Location = new System.Drawing.Point(203, 107);
            this.subnetTXT.Name = "subnetTXT";
            this.subnetTXT.Size = new System.Drawing.Size(240, 22);
            this.subnetTXT.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 44);
            this.button1.TabIndex = 4;
            this.button1.Text = "Postavi ip adresu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 259);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.subnetTXT);
            this.Controls.Add(this.ipTXT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IPForm";
            this.Text = "IPForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipTXT;
        private System.Windows.Forms.TextBox subnetTXT;
        private System.Windows.Forms.Button button1;
    }
}