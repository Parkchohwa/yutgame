namespace _16_NetworkStreamClientForm
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.btconnetc = new System.Windows.Forms.Button();
            this.btdisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btconnetc
            // 
            this.btconnetc.BackColor = System.Drawing.Color.DarkGray;
            this.btconnetc.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btconnetc.ForeColor = System.Drawing.SystemColors.Control;
            this.btconnetc.Location = new System.Drawing.Point(91, 413);
            this.btconnetc.Name = "btconnetc";
            this.btconnetc.Size = new System.Drawing.Size(178, 63);
            this.btconnetc.TabIndex = 0;
            this.btconnetc.Text = "윷놀이 시작하기";
            this.btconnetc.UseVisualStyleBackColor = false;
            this.btconnetc.Click += new System.EventHandler(this.Btconnetc_Click);
            // 
            // btdisconnect
            // 
            this.btdisconnect.BackColor = System.Drawing.Color.DarkGray;
            this.btdisconnect.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btdisconnect.ForeColor = System.Drawing.SystemColors.Control;
            this.btdisconnect.Location = new System.Drawing.Point(374, 413);
            this.btdisconnect.Name = "btdisconnect";
            this.btdisconnect.Size = new System.Drawing.Size(141, 63);
            this.btdisconnect.TabIndex = 0;
            this.btdisconnect.Text = "그만하기";
            this.btdisconnect.UseVisualStyleBackColor = false;
            this.btdisconnect.Click += new System.EventHandler(this.Btdisconnect_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(718, 488);
            this.Controls.Add(this.btdisconnect);
            this.Controls.Add(this.btconnetc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btconnetc;
        private System.Windows.Forms.Button btdisconnect;
    }
}