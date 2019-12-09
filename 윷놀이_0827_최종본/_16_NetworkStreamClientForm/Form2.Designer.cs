namespace _16_NetworkStreamClientForm
{
    partial class Form2
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
            this.tbNick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btNickSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNick
            // 
            this.tbNick.Font = new System.Drawing.Font("나눔바른펜", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbNick.Location = new System.Drawing.Point(91, 37);
            this.tbNick.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbNick.Name = "tbNick";
            this.tbNick.Size = new System.Drawing.Size(110, 24);
            this.tbNick.TabIndex = 1;
           
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔스퀘어", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "닉네임";
            // 
            // btNickSave
            // 
            this.btNickSave.Font = new System.Drawing.Font("나눔바른펜", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btNickSave.Location = new System.Drawing.Point(25, 99);
            this.btNickSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btNickSave.Name = "btNickSave";
            this.btNickSave.Size = new System.Drawing.Size(74, 28);
            this.btNickSave.TabIndex = 2;
            this.btNickSave.Text = "저장";
            this.btNickSave.UseVisualStyleBackColor = true;
            this.btNickSave.Click += new System.EventHandler(this.BtNickSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("나눔바른펜", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btCancel.Location = new System.Drawing.Point(133, 99);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(68, 28);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "취소";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 147);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btNickSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNick);
            this.Font = new System.Drawing.Font("나눔바른펜", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btNickSave;
        private System.Windows.Forms.Button btCancel;
    }
}