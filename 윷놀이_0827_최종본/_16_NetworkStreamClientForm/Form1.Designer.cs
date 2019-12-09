namespace _16_NetworkStreamClientForm
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSendData = new System.Windows.Forms.TextBox();
            this.lbRecvData = new System.Windows.Forms.ListBox();
            this.btnClientStop = new System.Windows.Forms.Button();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.btnEraseListBox = new System.Windows.Forms.Button();
            this.btnFlip = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnRed2 = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnBlue2 = new System.Windows.Forms.Button();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.btnTurn = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnTurn2 = new System.Windows.Forms.Button();
            this.btNick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSendData
            // 
            this.tbSendData.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.tbSendData.Location = new System.Drawing.Point(972, 633);
            this.tbSendData.Name = "tbSendData";
            this.tbSendData.Size = new System.Drawing.Size(191, 21);
            this.tbSendData.TabIndex = 10;
            this.tbSendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbSendData_KeyDown);
            // 
            // lbRecvData
            // 
            this.lbRecvData.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.lbRecvData.FormattingEnabled = true;
            this.lbRecvData.HorizontalExtent = 1000;
            this.lbRecvData.HorizontalScrollbar = true;
            this.lbRecvData.ItemHeight = 12;
            this.lbRecvData.Location = new System.Drawing.Point(972, 347);
            this.lbRecvData.Name = "lbRecvData";
            this.lbRecvData.Size = new System.Drawing.Size(191, 280);
            this.lbRecvData.TabIndex = 9;
            // 
            // btnClientStop
            // 
            this.btnClientStop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClientStop.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClientStop.Location = new System.Drawing.Point(1098, 321);
            this.btnClientStop.Name = "btnClientStop";
            this.btnClientStop.Size = new System.Drawing.Size(65, 20);
            this.btnClientStop.TabIndex = 7;
            this.btnClientStop.Text = "나가기";
            this.btnClientStop.UseVisualStyleBackColor = false;
            this.btnClientStop.Click += new System.EventHandler(this.BtnClientStop_Click);
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClientConnect.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClientConnect.Location = new System.Drawing.Point(1098, 288);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(65, 21);
            this.btnClientConnect.TabIndex = 8;
            this.btnClientConnect.Text = "입장하기";
            this.btnClientConnect.UseVisualStyleBackColor = false;
            this.btnClientConnect.Click += new System.EventHandler(this.BtnClientConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(961, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "방번호";
            // 
            // tbIp
            // 
            this.tbIp.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.tbIp.Location = new System.Drawing.Point(1008, 261);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(94, 21);
            this.tbIp.TabIndex = 6;
            this.tbIp.Text = "192.168.0.155";
            this.tbIp.Visible = false;
            // 
            // btnEraseListBox
            // 
            this.btnEraseListBox.Font = new System.Drawing.Font("굴림", 9F);
            this.btnEraseListBox.Location = new System.Drawing.Point(1109, 660);
            this.btnEraseListBox.Name = "btnEraseListBox";
            this.btnEraseListBox.Size = new System.Drawing.Size(54, 19);
            this.btnEraseListBox.TabIndex = 11;
            this.btnEraseListBox.Text = "지우기";
            this.btnEraseListBox.UseVisualStyleBackColor = true;
            this.btnEraseListBox.Click += new System.EventHandler(this.BtnEraseListBox_Click);
            // 
            // btnFlip
            // 
            this.btnFlip.BackColor = System.Drawing.Color.Peru;
            this.btnFlip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFlip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFlip.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlip.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFlip.Location = new System.Drawing.Point(854, 354);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(97, 45);
            this.btnFlip.TabIndex = 13;
            this.btnFlip.Text = "윷던지기";
            this.btnFlip.UseVisualStyleBackColor = false;
            this.btnFlip.Click += new System.EventHandler(this.BtnFlip_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRed.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRed.Location = new System.Drawing.Point(878, 493);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(75, 29);
            this.btnRed.TabIndex = 14;
            this.btnRed.Text = "RED1";
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.BtnRed_Click);
            // 
            // btnRed2
            // 
            this.btnRed2.BackColor = System.Drawing.Color.Red;
            this.btnRed2.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRed2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRed2.Location = new System.Drawing.Point(878, 522);
            this.btnRed2.Name = "btnRed2";
            this.btnRed2.Size = new System.Drawing.Size(75, 29);
            this.btnRed2.TabIndex = 15;
            this.btnRed2.Text = "RED2";
            this.btnRed2.UseVisualStyleBackColor = false;
            this.btnRed2.Click += new System.EventHandler(this.BtnRed2_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBlue.Location = new System.Drawing.Point(868, 495);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(84, 29);
            this.btnBlue.TabIndex = 16;
            this.btnBlue.Text = "BLUE1";
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.BtnBlue_Click);
            // 
            // btnBlue2
            // 
            this.btnBlue2.BackColor = System.Drawing.Color.Blue;
            this.btnBlue2.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlue2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBlue2.Location = new System.Drawing.Point(868, 524);
            this.btnBlue2.Name = "btnBlue2";
            this.btnBlue2.Size = new System.Drawing.Size(84, 29);
            this.btnBlue2.TabIndex = 17;
            this.btnBlue2.Text = "BLUE2";
            this.btnBlue2.UseVisualStyleBackColor = false;
            this.btnBlue2.Click += new System.EventHandler(this.BtnBlue2_Click);
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(1008, 288);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(84, 20);
            this.cbPort.TabIndex = 18;
            // 
            // btnTurn
            // 
            this.btnTurn.BackColor = System.Drawing.Color.Red;
            this.btnTurn.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTurn.Location = new System.Drawing.Point(876, 430);
            this.btnTurn.Name = "btnTurn";
            this.btnTurn.Size = new System.Drawing.Size(76, 65);
            this.btnTurn.TabIndex = 19;
            this.btnTurn.Text = "Turn Next";
            this.btnTurn.UseVisualStyleBackColor = false;
            this.btnTurn.Click += new System.EventHandler(this.BtnTurn_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStart.Font = new System.Drawing.Font("궁서", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.ForeColor = System.Drawing.Color.Red;
            this.btnStart.Location = new System.Drawing.Point(868, 279);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 34);
            this.btnStart.TabIndex = 20;
            this.btnStart.Text = "선착순";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnTurn2
            // 
            this.btnTurn2.BackColor = System.Drawing.Color.Blue;
            this.btnTurn2.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurn2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTurn2.Location = new System.Drawing.Point(867, 430);
            this.btnTurn2.Name = "btnTurn2";
            this.btnTurn2.Size = new System.Drawing.Size(84, 68);
            this.btnTurn2.TabIndex = 21;
            this.btnTurn2.Text = "Trun Next";
            this.btnTurn2.UseVisualStyleBackColor = false;
            this.btnTurn2.Click += new System.EventHandler(this.BtnTurn2_Click);
            // 
            // btNick
            // 
            this.btNick.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btNick.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btNick.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btNick.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btNick.Location = new System.Drawing.Point(878, 633);
            this.btNick.Name = "btNick";
            this.btNick.Size = new System.Drawing.Size(87, 31);
            this.btNick.TabIndex = 22;
            this.btNick.Text = "닉네임 설정";
            this.btNick.UseVisualStyleBackColor = false;
            this.btNick.Click += new System.EventHandler(this.BtNick_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 915);
            this.Controls.Add(this.btNick);
            this.Controls.Add(this.btnTurn2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnTurn);
            this.Controls.Add(this.cbPort);
            this.Controls.Add(this.btnBlue2);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnRed2);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.btnFlip);
            this.Controls.Add(this.btnEraseListBox);
            this.Controls.Add(this.tbSendData);
            this.Controls.Add(this.lbRecvData);
            this.Controls.Add(this.btnClientStop);
            this.Controls.Add(this.btnClientConnect);
            this.Controls.Add(this.tbIp);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSendData;
        private System.Windows.Forms.ListBox lbRecvData;
        private System.Windows.Forms.Button btnClientStop;
        private System.Windows.Forms.Button btnClientConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Button btnEraseListBox;
        private System.Windows.Forms.Button btnFlip;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnRed2;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnBlue2;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Button btnTurn;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnTurn2;
        private System.Windows.Forms.Button btNick;
    }
}

