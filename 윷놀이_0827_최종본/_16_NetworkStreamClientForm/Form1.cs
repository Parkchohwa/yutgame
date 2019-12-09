using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_NetworkStreamClientForm
{
    public partial class Form1 : Form
    {
        Socket client;
        IPEndPoint ipep;

        NetworkStream ns;
        StreamWriter sw;

        Thread tRecv;
        bool isRecv = true;

        delegate void AddMsgData(string data);
        AddMsgData addMsgData = null;

        Form2 fm2 = new Form2();
        bool bNick = false;

        Rectangle[] rect = new Rectangle[39];
        Random rand = new Random();
        MediaPlayer.MediaPlayerClass bgm = new MediaPlayer.MediaPlayerClass();
        
        // rectangle 만들기
        int panX = 750;
        int panY = 750;
        int malX = 50;
        int malY = 50;
        int a = 1;
        int b = 1;
        int c = 1;

        bool redTwo = false;
        bool blueTwo = false;

        int num;

        // 빨간 말
        int w = 0;
        int x = 0;
        // 파란 말
        int y = 0;
        int z = 0;

        SoundPlayer bitmusic = new SoundPlayer();
        SoundPlayer bitDo = new SoundPlayer();
        SoundPlayer bitgae = new SoundPlayer();
        SoundPlayer bitgrl = new SoundPlayer();
        SoundPlayer bityut = new SoundPlayer();
        SoundPlayer bitmo = new SoundPlayer();
        SoundPlayer click = new SoundPlayer();
        SoundPlayer box = new SoundPlayer();
        SoundPlayer win = new SoundPlayer();
        SoundPlayer lose = new SoundPlayer();
        SoundPlayer onemore = new SoundPlayer();
        SoundPlayer bg = new SoundPlayer();

        //이미지 gif
        Image firstPicture, Do, gae, grl, yut, mo, image;
        Rectangle rects;

        Image red1 = Image.FromFile("조조.png");
        Image red2 = Image.FromFile("하우돈.png");
        Image blue1 = Image.FromFile("유비.png");
        Image blue2 = Image.FromFile("제갈공명.png");
        Image red3 = Image.FromFile("업은말1.png");
        Image blue3 = Image.FromFile("업은말2.png");

        Image aniImage = null;
        System.Windows.Forms.Timer changeImage = new System.Windows.Forms.Timer(); //gif 이미지 띄우기
 
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.DoubleBuffered = true;
            this.FormClosed += Form1_FormClosed;
            this.Load += Form1_Load1;
            rects = new Rectangle(890, 15, 250, 250);
            makeMap();
            firstPicture = _16_NetworkStreamClientForm.Properties.Resources.윷놀이첫화면;
            Do = _16_NetworkStreamClientForm.Properties.Resources.도도;
            gae = _16_NetworkStreamClientForm.Properties.Resources.개개;
            grl = _16_NetworkStreamClientForm.Properties.Resources.걸걸;
            yut = _16_NetworkStreamClientForm.Properties.Resources.윷윷2;
            mo = _16_NetworkStreamClientForm.Properties.Resources.모모2;
            image = _16_NetworkStreamClientForm.Properties.Resources.윷놀이GIF;

            btnStart.Enabled = false;
            btnTurn.Enabled = false;
            btnTurn2.Enabled = false;
            btnFlip.Enabled = false;
            btnRed.Enabled = false;
            btnRed2.Enabled = false;
            btnBlue.Enabled = false;
            btnBlue2.Enabled = false;
           this.Text = "윷놀이 게임";
        }
 
        private void Form1_Load1(object sender, EventArgs e)
        {
            cbPort.Items.Add(9000);  //방번호 콤보박스에서 선택 할 포트번호
            cbPort.Items.Add(8000);
            cbPort.Items.Add(7000);

            bitmusic.SoundLocation = "던질때.wav";
            bitDo.SoundLocation = "도.wav";
            bitgae.SoundLocation = "개.wav";
            bitgrl.SoundLocation = "걸.wav";
            bityut.SoundLocation = "윷.wav";
            bitmo.SoundLocation = "모.wav";

            bg.SoundLocation = "윷놀이인트로.wav";
            click.SoundLocation = "클릭.wav";
            box.SoundLocation = "메세지.wav";
            win.SoundLocation = "승리.wav";  
            lose.SoundLocation = "패.wav";
            onemore.SoundLocation = "한번더.wav";

            this.bgm.EnableContextMenu = true;
            this.bgm.FileName = @"C:\Lecture\_5_CSharp\TeamProject\Team_3\윷놀이_0827_최종본\_16_NetworkStreamClientForm\bin\Debug/윷놀이인트로.mp3";
            this.bgm.Stop();
        }
        void makeMap()
        {
            for (int i = 1; i < 6; i++)
            {
                rect[i] = new Rectangle(panX + 30, panY - (malY * 3) * i + 30, malX, malY);
            }
            for (int i = 6; i < 11; i++)
            {
                rect[i] = new Rectangle(panX - (malX * 3) * a + 30, 0 + 30, malX, malY);
                a++;
            }
            for (int i = 11; i < 16; i++)
            {
                rect[i] = new Rectangle(0 + 30, malY * 3 * b + 30, malX, malY);
                b++;
            }
            for (int i = 16; i < 20; i++)
            {
                rect[i] = new Rectangle(malX * 3 * c + 30, panY + 30, malX, malY);
                c++;
            }
            rect[20] = new Rectangle(625 + 30, 125 + 30, 50, 50);
            rect[21] = new Rectangle(500 + 30, 250 + 30, 50, 50);
            rect[22] = new Rectangle(375 + 30, 375 + 30, 50, 50);
            rect[23] = new Rectangle(250 + 30, 500 + 30, 50, 50);
            rect[24] = new Rectangle(125 + 30, 625 + 30, 50, 50);

            rect[25] = new Rectangle(125 + 30, 125 + 30, 50, 50);
            rect[26] = new Rectangle(250 + 30, 250 + 30, 50, 50);
            rect[27] = new Rectangle(500 + 30, 500 + 30, 50, 50);
            rect[28] = new Rectangle(625 + 30, 625 + 30, 50, 50);
            rect[29] = new Rectangle(750 + 30, 750 + 30, 50, 50);

            rect[0] = new Rectangle(1300,1300,1,1);

            rect[35] = new Rectangle(910 + 30, 650 + 30, 50, 50);
            rect[36] = new Rectangle(910 + 30, 710 + 30, 50, 50);
            rect[37] = new Rectangle(970 + 30, 650 + 30, 50, 50);
            rect[38] = new Rectangle(970 + 30, 710 + 30, 50, 50);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames();
            Pen penGray = new Pen(Brushes.Gray, 5);
            e.Graphics.DrawLine(penGray, 55, 55, 805, 55);
            e.Graphics.DrawLine(penGray, 55, 55, 55, 805);
            e.Graphics.DrawLine(penGray, 805, 55, 805, 805);
            e.Graphics.DrawLine(penGray, 55, 805, 805, 805);
            e.Graphics.DrawLine(penGray, 55, 55, 805, 805);
            e.Graphics.DrawLine(penGray, 805, 55, 55, 805);

            e.Graphics.FillEllipse(Brushes.Gray, 15, 15, 80, 80);
            e.Graphics.FillEllipse(Brushes.Gray, 15, 765, 80, 80);
            e.Graphics.FillEllipse(Brushes.Gray, 765, 15, 80, 80);
            e.Graphics.FillEllipse(Brushes.Gray, 765, 765, 80, 80);
            e.Graphics.FillEllipse(Brushes.Gray, 390, 390, 80, 80);

            Pen pen = new Pen(Brushes.Black, 3);
            for (int i = 1; i < 39; i++)
            {
                e.Graphics.FillEllipse(Brushes.LightGray, rect[i]);
            }

            // 빨간 말 1번 움직임
            e.Graphics.DrawImage(red1, rect[w]);
            // 빨간 말 2번 움직임
            e.Graphics.DrawImage(red2, rect[x]);
            // 파란 말 1번 움직임
            e.Graphics.DrawImage(blue1, rect[y]);
            // 파란 말 2번 움직임
            e.Graphics.DrawImage(blue2, rect[z]);

            if(redTwo != false)
            {
                e.Graphics.DrawImage(red3, rect[x]);
            }
            if (blueTwo != false)
            {
                e.Graphics.DrawImage(blue3, rect[y]);
            }

            e.Graphics.DrawImage(this.firstPicture, rects);
            //pictureBox.Enabled = false; GIF를 중지하고 
            //GIF pictureBox.Enabled = true;를 실행하려는 경우에 사용할 수 있습니다 .
            if (num == 1)
            {
                e.Graphics.DrawImage(this.aniImage, rects); //gif - 10초
            }
            if (num == 2)
            {
                e.Graphics.DrawImage(this.aniImage, rects); //gif - 10초
            }
            if (num == 3)
            {
                e.Graphics.DrawImage(this.aniImage, rects); //gif - 10초
            }
            if (num == 4)
            {
                e.Graphics.DrawImage(this.aniImage, rects); //gif - 10초
            }
            if (num == 5)
            {
                e.Graphics.DrawImage(this.aniImage, rects); //gif - 10초
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ImageAnimator.Animate(image, new EventHandler(this.OnFrameChanged));
            //ImageAnimator.StopAnimate(image, new EventHandler(this.OnFrameChanged));
            base.OnLoad(e);
        }
        private void OnFrameChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                isRecv = false;
                if (client != null && client.Connected)
                    client.Close();
            }
            catch (Exception ex)
            {
                AddRecvListBox("Exception : " + ex.Message);
            }
        }
        void ProcessPacket(string recvData)
        {
           string[] datas = recvData.Split(new char[] { ':' });

                switch (datas[0])
                {
                    case " ":
                        AddRecvListBox(datas[1]); //상대방 채팅창에 보여지는 것
                       break;
                    case "P":
                        num = Int32.Parse(datas[1]);          // 사용
                    bitmusic.Play();
                    this.aniImage = this.image;
                    changeImage.Interval = 4000;
                    changeImage.Enabled = true;
                    changeImage.Tick += ChangeImage_Tick;
                    break;
                case "PDo":
                    num = Int32.Parse(datas[1]);
                    bitDo.Play();
                    this.aniImage = this.Do;
                    changeImage.Enabled = false;
                    break;
                case "Pgae":
                    num = Int32.Parse(datas[1]);
                    bitgae.Play();
                    this.aniImage = this.gae;
                    changeImage.Enabled = false;
                    break;
                case "Pgrl":
                    num = Int32.Parse(datas[1]);
                    bitgrl.Play();
                    this.aniImage = this.grl;
                    changeImage.Enabled = false;
                    break;
                case "Pyut":
                    num = Int32.Parse(datas[1]);
                    bityut.Play();
                    this.aniImage = this.yut;
                    changeImage.Enabled = false;
                    break;
                case "Pmo":
                    num = Int32.Parse(datas[1]);
                    bitmo.Play();
                    this.aniImage = this.mo;
                    changeImage.Enabled = false;
                    break;
                    case "W":
                        w = Int32.Parse(datas[1]);      //레드1 인덱스 전달
                        break;
                    case "X":
                        x = Int32.Parse(datas[1]);      //레드2 인덱스 전달
                        break;
                    case "Y":
                        y = Int32.Parse(datas[1]);      // 블루1 인덱스 전달
                        break;
                    case "Z":
                        z = Int32.Parse(datas[1]);      // 블루2 인덱스 전달
                        break;
                    case "M":
                    box.Play();
                        MessageBox.Show(datas[1]);      // 메세지박스 전달
                    break;
                case "A":
                    win.Play();
                    MessageBox.Show(datas[1]);      //승리 메세지박스 전달
                    break;
                case "V":       //레드쪽 영향 주기
                        btnTurn.Enabled = bool.Parse(datas[1]);
                        btnFlip.Enabled= bool.Parse(datas[1]);
                        btnRed.Enabled= bool.Parse(datas[1]);
                        btnRed2.Enabled= bool.Parse(datas[1]);
                        break;
                    case "U":       // 블루쪽 영향 주기
                        btnTurn2.Enabled = bool.Parse(datas[1]);
                        btnFlip.Enabled = bool.Parse(datas[1]);
                        btnBlue.Enabled = bool.Parse(datas[1]);
                        btnBlue2.Enabled = bool.Parse(datas[1]);
                        break;
                    case "T":       // 스타트 버튼 누르면 블루쪽 영향 
                    box.Play();
                    MessageBox.Show(datas[1]);
                    this.Text = "파랑팀";
                        btnStart.Dispose();
                        btnRed.Dispose();
                        btnRed2.Dispose();
                        btnTurn.Dispose();
                        break;
                case "R":
                    redTwo = true;
                    break;
                case "S":
                    redTwo = false;
                    break;
                case "B":
                    blueTwo = true;
                    break;
                case "D":
                    blueTwo = false;
                    break;
                }
            Invalidate();
        }
        void ThreadRecv()
        {
            StreamReader sr = new StreamReader(ns);
            while (isRecv)
            {
                try
                {
                    string data = sr.ReadLine();
                    ProcessPacket(data);
                    
                }
                catch(Exception ex)
                {
                    AddRecvListBox("Exception : " + ex.Message);
                    btnClientConnect.Enabled = true;
                    btnClientStop.Enabled = false;
                    break;
                }
            }
        }
        private void BtnClientConnect_Click(object sender, EventArgs e) //입장하기 누르면
        {
            isRecv = true;
            client = 
                new Socket(AddressFamily.InterNetwork,
                           SocketType.Stream,
                           ProtocolType.Tcp);
            ipep =
                new IPEndPoint(IPAddress.Parse(tbIp.Text),
                                Int32.Parse(cbPort.Text));
            AddRecvListBox("서버 접속 시도...");
            client.Connect(ipep);
            AddRecvListBox("서버 입장 완료");
            ns = new NetworkStream(client);
            sw = new StreamWriter(ns);

            tRecv = new Thread(new ThreadStart(ThreadRecv));
            tRecv.Start();

            btnClientConnect.Enabled = false;
            btnClientStop.Enabled = true;
            btnStart.Enabled = true;
            this.bgm.Play();
        }
        private void BtnClientStop_Click(object sender, EventArgs e)
        {
            try
            {
                isRecv = false;
                if (client != null && client.Connected)
                    client.Close();
            }catch(Exception ex)
            {
                AddRecvListBox("Exception : " + ex.Message);
            }
            finally
            {
                btnClientConnect.Enabled = true;
                btnClientStop.Enabled = false;
                Application.Restart();
            }
        }
        private void TbSendData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)  //채팅창 글 적을 때 엔터 누르면
            {
                case Keys.Enter:
                    if (bNick == false)  //닉네임 저장 안하면
                    { 
                        string data = " :" + "<상대방> "+tbSendData.Text; //보내는 데이터
                        sw.WriteLine(data);  // data 를 ProcessPacke에 보냄
                        AddRecvListBox("<나>: "+tbSendData.Text); 
                        //본인 클라이언트 창에 뜨는 데이터
                    }
                    else //닉네임 저장 하면
                    {
                        string data = " :<"+Form2.name+"> "+tbSendData.Text; //보내는 데이터
                        sw.WriteLine(data);  // data 를 ProcessPacke에 보냄
                        AddRecvListBox("<" + Form2.name + ">: " +tbSendData.Text); 
                        //본인 클라이언트 창에 뜨는 데이터
                    }
                    sw.Flush();         // 즉시 보낸다.
                    tbSendData.Clear();
                    break; 
            }
        }
        void AddRecvListBox(string data)
        {
            if (lbRecvData.InvokeRequired)
            {
                // 사용중일 때는 .NET에 등록하게 처리를 맡긴다
                Invoke(addMsgData, new object[] { data });
            }
            else
            {
                lbRecvData.Items.Add(data);
                lbRecvData.SelectedIndex = lbRecvData.Items.Count - 1;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            addMsgData = AddRecvListBox;
        }
        private void BtnEraseListBox_Click(object sender, EventArgs e)
        {
            lbRecvData.Items.Clear();
        }

        private void BtnTurn_Click(object sender, EventArgs e)      // 레드 턴종료
        {
            click.Play();
            // 레드 버튼 및 던지기 비활성화
            btnTurn.Enabled = false;
            btnRed.Enabled = false;     
            btnRed2.Enabled = false;
            btnFlip.Enabled = false;
            
            if (sw != null && client.Connected)     //상대 블루 버튼 활성화
            {
                string pack = String.Format("U:{0}", true.ToString());
                sw.WriteLine(pack);
                sw.Flush();
            }
        }

        private void BtnTurn2_Click(object sender, EventArgs e)     // 블루 턴종료
        {
            click.Play();
            // 블루 버튼 및 던지기 비활성화
            btnTurn2.Enabled = false;
            btnBlue.Enabled = false;
            btnBlue2.Enabled = false;
            btnFlip.Enabled = false;

            if (sw != null && client.Connected)     //상대 레드 버튼 활성화
            {
                string pack = String.Format("V:{0}", true.ToString());
                sw.WriteLine(pack);
                sw.Flush();
            }
        }
        private void BtnStart_Click(object sender, EventArgs e)     // 선착순 버튼
        {
            this.Text = "빨간팀";
            click.Play();
            btnStart.Dispose();     //선착순 버튼 없애기
            btnTurn.Enabled = true; //레드 버튼 및 던지기 활성화
            btnRed.Enabled = true;
            btnRed2.Enabled = true;
            btnFlip.Enabled = true;
            btnBlue.Dispose();      //레드진형 블루버튼 없애기
            btnBlue2.Dispose();
            btnTurn2.Dispose();
            box.Play();
            MessageBox.Show("당신은 빨간 말 입니다");
           
            if (sw != null && client.Connected) // 블루진형 선착순 버튼 및 레드버튼 없애기
            {
                string pack = String.Format("T:{0}","당신은 파란 말 입니다");
                sw.WriteLine(pack);
                sw.Flush();
            }
        }
        private void BtNick_Click(object sender, EventArgs e)
        {
            click.Play();
            fm2.Show();
            bNick = true;
        }
        private void BtnFlip_Click(object sender, EventArgs e)
        {
           
            bitmusic.Play();
            int rN = rand.Next(16) + 1;
            if (rN == 1 || rN == 2 || rN == 3 || rN == 4)
            {
                num = 1;
            }
            else if (rN == 5 || rN == 6 || rN == 7 || rN == 8 || rN == 9 || rN == 10)
            {
                num = 2;
            }
            else if (rN == 11 || rN == 12 || rN == 13 || rN == 14)
            {
                num = 3;
            }
            else if (rN == 15)
            {
                num = 4;
            }
            else if (rN == 16)
            {
                num = 5;
            }

            if (sw != null && client.Connected)
            {
                string pack = String.Format("P:{0}", num.ToString());
                sw.WriteLine(pack);
                sw.Flush();
            }
            this.aniImage = this.image;
            changeImage.Interval = 4000;
            changeImage.Enabled = true;
            changeImage.Tick += ChangeImage_Tick;
        }

        private void BtnRed_Click(object sender, EventArgs e)
        {
            click.Play();
            int preW = w;
            if (w < 5)
            {
                w += num;

            }
            else if (w == 5)
            {
                w += (14 + num);

            }
            else if (w > 5 && w < 10)
            {
                w += num;

            }
            else if (w == 10)
            {
                if (num < 3)
                {
                    w += (num + 14);

                }
                if (num == 3)
                {
                    w = 22;

                }
                if (num > 3)
                {
                    w += (13 + num);

                }
            }
            else if (w > 10 && w < 15)
            {
                w += num;

            }
            else if (w == 15)
            {
                if (num < 5)
                {
                    w += num;

                }
                if (num == 5)
                {
                    w = 29;

                }
            }
            else if (w == 16)
            {
                if (num < 4)
                {
                    w += num;

                }
                if (num == 4)
                {
                    w = 29;

                }
                if (num == 5)
                {
                    w = 35;
                    if (x != 36)
                    {
                        box.Play();
                        MessageBox.Show("빨강 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (x == 36)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (w == 17)
            {
                if (num < 3)
                {
                    w += num;

                }
                if (num == 3)
                {
                    w = 29;

                }
                if (num > 3)
                {
                    w = 35;
                    if (x != 36)
                    {
                        box.Play();
                        MessageBox.Show("빨강 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (x == 36)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (w == 18)
            {
                if (num == 1)
                {
                    w += num;

                }
                if (num == 2)
                {
                    w = 29;

                }
                if (num > 2)
                {
                    w = 35;
                    if (x != 36)
                    {
                        box.Play();
                        MessageBox.Show("빨강 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (x == 36)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (w == 19)
            {
                if (num == 1)
                {
                    w = 29;

                }
                if (num > 1)
                {
                    w = 35;
                    if (x != 36)
                    {
                        box.Play();
                        MessageBox.Show("빨강 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (x == 36)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (w == 20)
            {
                if (num < 5)
                {
                    w += num;

                }
                if (num == 5)
                {
                    w = 15;

                }
            }
            else if (w == 21)
            {
                if (num < 4)
                {
                    w += num;

                }
                if (num >= 4)
                {
                    w += (-10 + num);

                }
            }
            else if (w == 22)
            {
                if (num < 4)
                {
                    w += (4 + num);

                }
                if (num >= 4)
                {
                    w = 35;
                    if (x != 36)
                    {
                        box.Play();
                        MessageBox.Show("빨강 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (x == 36)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (w == 23)
            {
                if (num == 1)
                {
                    w += num;
                }
                if (num >= 2)
                {
                    w += (-10 + num);
                }
            }
            else if (w == 24)
            {
                w += (-10 + num);
            }
            else if (w == 25)
            {
                if (num == 1)
                {
                    w += num;
                }
                if (num == 2)
                {
                    w = 22;
                }
                if (num > 2)
                {
                    w += (-1 + num);
                }
            }
            else if (w == 26)
            {
                if (num == 1)
                {
                    w = 22;
                }
                if (num < 5)
                {
                    w += (-1 + num);
                }
                if (num == 5)
                {
                    w = 35;
                    if (x != 36)
                    {
                        box.Play();
                        MessageBox.Show("빨강 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (x == 36)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (w == 27)
            {
                if (num < 3)
                {
                    w += num;
                }
                if (num >= 3)
                {
                    w = 35;
                    if (x != 36)
                    {
                        box.Play();
                        MessageBox.Show("빨강 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (x == 36)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (w == 28)
            {
                if (num == 1)
                {
                    w += num;
                }
                if (num > 1)
                {
                    w = 35;
                    if (x != 36)
                    {
                        box.Play();
                        MessageBox.Show("빨강 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (x == 36)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (w == 29)
            {
                w = 35;
                if (x != 36)
                {
                    box.Play();
                    MessageBox.Show("빨강 1번말 goal");
                    if (sw != null && client.Connected)
                    {
                        string pack = String.Format("M:{0}", "빨강 1번말 goal");
                        sw.WriteLine(pack);
                        sw.Flush();
                    }
                }
                else if (x == 36)
                {
                    redTwo = false;
                    win.Play();
                    MessageBox.Show("빨강팀 승리하셨습니다.");
                    if (sw != null && client.Connected)
                    {
                        string pack = String.Format("S:{0}", false);
                        sw.WriteLine(pack);
                        sw.Flush();
                        pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                        sw.WriteLine(pack);
                        sw.Flush();
                    }
                }
            }
            if (w == y)
            {
                blueTwo = false;
                box.Play();
                MessageBox.Show("파랑 말이 잡혔습니다\r\n\r\n한번더~!");
                y = 0;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("D:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("M:{0}", "파랑 말이 잡혔습니다\r\n\r\n한번더~!");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (w == z)
            {
                blueTwo = false;
                box.Play();
                MessageBox.Show("파랑 말이 잡혔습니다\r\n\r\n한번더~!");
                z = 0;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("D:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("M:{0}", "파랑 말이 잡혔습니다\r\n\r\n한번더~!");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }

            if (preW != 0 && x != 0 && preW == x)
            {
                x = w;
                redTwo = true;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("R:{0}", true);
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (x == 35)
            {
                redTwo = false;
                x = 36;
                win.Play();
                MessageBox.Show("빨강팀 승리하셨습니다.");
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("S:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (sw != null && client.Connected)
            {
                string pack = String.Format("W:{0}", w.ToString());
                sw.WriteLine(pack);
                sw.Flush();
                pack = String.Format("Z:{0}", z.ToString());
                sw.WriteLine(pack);
                sw.Flush();
                pack = String.Format("X:{0}", x.ToString());
                sw.WriteLine(pack);
                sw.Flush();
                pack = String.Format("Y:{0}", y.ToString());
                sw.WriteLine(pack);
                sw.Flush();
            }
            Invalidate();
        }
        private void BtnRed2_Click(object sender, EventArgs e)
        {
            click.Play();
            int preX = x;
            if (x < 5)
            {
                x += num;
            }
            else if (x == 5)
            {
                x += (14 + num);
            }
            else if (x > 5 && x < 10)
            {
                x += num;
            }
            else if (x == 10)
            {
                if (num < 3)
                {
                    x += (num + 14);
                }
                if (num == 3)
                {
                    x = 22;
                }
                if (num > 3)
                {
                    x += (13 + num);
                }
            }
            else if (x > 10 && x < 15)
            {
                x += num;
            }
            else if (x == 15)
            {
                if (num < 5)
                {
                    x += num;
                }
                if (num == 5)
                {
                    x = 29;
                }
            }
            else if (x == 16)
            {
                if (num < 4)
                {
                    x += num;
                }
                if (num == 4)
                {
                    x = 29;
                }
                if (num == 5)
                {
                    x = 36;
                }
            }
            else if (x == 17)
            {
                if (num < 3)
                {
                    x += num;
                }
                if (num == 3)
                {
                    x = 29;
                }
                if (num > 3)
                {
                    x = 36;
                }
            }
            else if (x == 18)
            {
                if (num == 1)
                {
                    x += num;
                }
                if (num == 2)
                {
                    x = 29;
                }
                if (num > 2)
                {
                    x = 36;
                }
            }
            else if (x == 19)
            {
                if (num == 1)
                {
                    x = 29;
                }
                if (num > 1)
                {
                    x = 36;
                    if (w != 35)
                    {
                        box.Play();
                        MessageBox.Show("빨강 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (w == 35)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (x == 20)
            {
                if (num < 5)
                {
                    x += num;
                }
                if (num == 5)
                {
                    x = 15;
                }
            }
            else if (x == 21)
            {
                if (num < 4)
                {
                    x += num;
                }
                if (num >= 4)
                {
                    x += (-10 + num);
                }
            }
            else if (x == 22)
            {
                if (num < 4)
                {
                    x += (4 + num);
                }
                if (num >= 4)
                {
                    x = 36;
                    if (w != 35)
                    {
                        box.Play();
                        MessageBox.Show("빨강 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (w == 35)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (x == 23)
            {
                if (num == 1)
                {
                    x += num;
                }
                if (num >= 2)
                {
                    x += (-10 + num);
                }
            }
            else if (x == 24)
            {
                x += (-10 + num);
            }
            else if (x == 25)
            {
                if (num == 1)
                {
                    x += num;
                }
                if (num == 2)
                {
                    x = 22;
                }
                if (num > 2)
                {
                    x += (-1 + num);
                }
            }
            else if (x == 26)
            {
                if (num == 1)
                {
                    x = 22;
                }
                if (num < 5)
                {
                    x += (-1 + num);
                }
                if (num == 5)
                {
                    x = 36;
                    if (w != 35)
                    {
                        box.Play();
                        MessageBox.Show("빨강 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (w == 35)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (x == 27)
            {
                if (num < 3)
                {
                    x += num;
                }
                if (num >= 3)
                {
                    x = 36;
                    if (w != 35)
                    {
                        box.Play();
                        MessageBox.Show("빨강 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (w == 35)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (x == 28)
            {
                if (num == 1)
                {
                    x += num;
                }
                if (num > 1)
                {
                    x = 36;
                    if (w != 35)
                    {
                        box.Play();
                        MessageBox.Show("빨강 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "빨강 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (w == 35)
                    {
                        redTwo = false;
                        win.Play();
                        MessageBox.Show("빨강팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("S:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (x == 29)
            {
                x = 36;
                if (w != 35)
                {
                    box.Play();
                    MessageBox.Show("빨강 2번말 goal");
                    if (sw != null && client.Connected)
                    {
                        string pack = String.Format("M:{0}", "빨강 2번말 goal");
                        sw.WriteLine(pack);
                        sw.Flush();
                    }
                }
                else if (w == 35)
                {
                    redTwo = false;
                    win.Play();
                    MessageBox.Show("빨강팀 승리하셨습니다.");
                    if (sw != null && client.Connected)
                    {
                        string pack = String.Format("S:{0}", false);
                        sw.WriteLine(pack);
                        sw.Flush();
                        pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                        sw.WriteLine(pack);
                        sw.Flush();
                    }
                }
            }
            if (x == y)
            {
                box.Play();
                MessageBox.Show("파랑 말이 잡혔습니다\r\n\r\n한번더~!");
                y = 0;
                blueTwo = false;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("D:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("M:{0}", "파랑 말이 잡혔습니다\r\n\r\n한번더~!");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }

            if (x == z)
            {
                box.Play();
                MessageBox.Show("파랑 말이 잡혔습니다\r\n\r\n한번더~!");
                z = 0;
                blueTwo = false;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("D:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("M:{0}", "파랑 말이 잡혔습니다\r\n\r\n한번더~!");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }

            if (preX != 0 && x != 0 && preX == w)
            {
                w = x;
                redTwo = true;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("R:{0}", true);
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (w == 36)
            {
                redTwo = false;
                w = 35;
                win.Play();
                MessageBox.Show("빨강팀 승리하셨습니다.");
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("S:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("A:{0}", "빨강팀 승리하셨습니다.");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (sw != null && client.Connected)
            {
                string pack = String.Format("W:{0}", w.ToString());
                sw.WriteLine(pack);
                sw.Flush();
                pack = String.Format("Z:{0}", z.ToString());
                sw.WriteLine(pack);
                sw.Flush();
                pack = String.Format("X:{0}", x.ToString());
                sw.WriteLine(pack);
                sw.Flush();
                pack = String.Format("Y:{0}", y.ToString());
                sw.WriteLine(pack);
                sw.Flush();
            }
            Invalidate();
        }
        private void BtnBlue_Click(object sender, EventArgs e)
        {
            click.Play();
            int preY = y;
            if (y < 5)
            {
                y += num;
            }
            else if (y == 5)
            {
                y += (14 + num);
            }
            else if (y > 5 && y < 10)
            {
                y += num;
            }
            else if (y == 10)
            {
                if (num < 3)
                {
                    y += (num + 14);
                }
                if (num == 3)
                {
                    y = 22;
                }
                if (num > 3)
                {
                    y += (13 + num);
                }
            }
            else if (y > 10 && y < 15)
            {
                y += num;
            }
            else if (y == 15)
            {
                if (num < 5)
                {
                    y += num;
                }
                if (num == 5)
                {
                    y = 29;
                }
            }
            else if (y == 16)
            {
                if (num < 4)
                {
                    y += num;
                }
                if (num == 4)
                {
                    y = 29;
                }
                if (num == 5)
                {
                    y = 37;
                    if (z != 38)
                    {
                        box.Play();
                        MessageBox.Show("파랑 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (z == 38)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (y == 17)
            {
                if (num < 3)
                {
                    y += num;
                }
                if (num == 3)
                {
                    y = 29;
                }
                if (num > 3)
                {
                    y = 37;
                    if (z != 38)
                    {
                        box.Play();
                        MessageBox.Show("파랑 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (z == 38)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (y == 18)
            {
                if (num == 1)
                {
                    y += num;
                }
                if (num == 2)
                {
                    y = 29;
                }
                if (num > 2)
                {
                    y = 37;
                    if (z != 38)
                    {
                        box.Play();
                        MessageBox.Show("파랑 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (z == 38)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (y == 19)
            {
                if (num == 1)
                {
                    y = 29;
                }
                if (num > 1)
                {
                    y = 37;
                    if (z != 38)
                    {
                        box.Play();
                        MessageBox.Show("파랑 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (z == 38)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (y == 20)
            {
                if (num < 5)
                {
                    y += num;
                }
                if (num == 5)
                {
                    y = 15;
                }
            }
            else if (y == 21)
            {
                if (num < 4)
                {
                    y += num;
                }
                if (num >= 4)
                {
                    y += (-10 + num);
                }
            }
            else if (y == 22)
            {
                if (num < 4)
                {
                    y += (4 + num);
                }
                if (num >= 4)
                {
                    y = 37;
                    if (z != 38)
                    {
                        box.Play();
                        MessageBox.Show("파랑 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (z == 38)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (y == 23)
            {
                if (num == 1)
                {
                    y += num;
                }
                if (num >= 2)
                {
                    y += (-10 + num);
                }
            }
            else if (y == 24)
            {
                y += (-10 + num);
            }
            else if (y == 25)
            {
                if (num == 1)
                {
                    y += num;
                }
                if (num == 2)
                {
                    y = 22;
                }
                if (num > 2)
                {
                    y += (-1 + num);
                }
            }
            else if (y == 26)
            {
                if (num == 1)
                {
                    y = 22;
                }
                if (num < 5)
                {
                    y += (-1 + num);
                }
                if (num == 5)
                {
                    y = 37;
                    if (z != 38)
                    {
                        box.Play();
                        MessageBox.Show("파랑 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (z == 38)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (y == 27)
            {
                if (num < 3)
                {
                    y += num;
                }
                if (num >= 3)
                {
                    y = 37;
                    if (z != 38)
                    {
                        box.Play();
                        MessageBox.Show("파랑 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (z == 38)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (y == 28)
            {
                if (num == 1)
                {
                    y += num;
                }
                if (num > 1)
                {
                    y = 37;
                    if (z != 38)
                    {
                        box.Play();
                        MessageBox.Show("파랑 1번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 1번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (z == 38)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (y == 29)
            {
                y = 37;
                if (z != 38)
                {
                    box.Play();
                    MessageBox.Show("파랑 1번말 goal");
                    if (sw != null && client.Connected)
                    {
                        string pack = String.Format("M:{0}", "파랑 1번말 goal");
                        sw.WriteLine(pack);
                        sw.Flush();
                    }
                }
                else if (z == 38)
                {
                    blueTwo = false;
                    win.Play();
                    MessageBox.Show("파랑팀 승리하셨습니다.");
                    if (sw != null && client.Connected)
                    {
                        string pack = String.Format("D:{0}", false);
                        sw.WriteLine(pack);
                        sw.Flush();
                        pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                        sw.WriteLine(pack);
                        sw.Flush();
                    }
                }
            }
            if (y == w)
            {
                w = 0;
                redTwo = false;
                box.Play();
                MessageBox.Show("빨강 말이 잡혔습니다\r\n\r\n한번더~!");
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("S:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("M:{0}", "빨강 말이 잡혔습니다\r\n\r\n한번더~!");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (y == x)
            {
                box.Play();
                MessageBox.Show("빨강 말이 잡혔습니다\r\n\r\n한번더~!");
                x = 0;
                redTwo = false;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("S:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("M:{0}", "빨강 말이 잡혔습니다\r\n\r\n한번더~!");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (preY != 0 && z != 0 && preY == z)
            {
                z = y;
                blueTwo = true;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("B:{0}", true);
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (z == 37)
            {
                blueTwo = false;
                z = 38;
                win.Play();
                MessageBox.Show("파랑팀 승리하셨습니다.");
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("D:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (sw != null && client.Connected)
            {
                string pack = String.Format("W:{0}", w.ToString());
                sw.WriteLine(pack);
                sw.Flush();

                pack = String.Format("Z:{0}", z.ToString());
                sw.WriteLine(pack);
                sw.Flush();

                pack = String.Format("X:{0}", x.ToString());
                sw.WriteLine(pack);
                sw.Flush();

                pack = String.Format("Y:{0}", y.ToString());
                sw.WriteLine(pack);
                sw.Flush();
            }
            Invalidate();
        }
        private void BtnBlue2_Click(object sender, EventArgs e)
        {
            click.Play();
            int preZ = z;
            if (z < 5)
            {
                z += num;
            }
            else if (z == 5)
            {
                z += (14 + num);
            }
            else if (z > 5 && z < 10)
            {
                z += num;
            }
            else if (z == 10)
            {
                if (num < 3)
                {
                    z += (num + 14);
                }
                if (num == 3)
                {
                    z = 22;
                }
                if (num > 3)
                {
                    z += (13 + num);
                }
            }
            else if (z > 10 && z < 15)
            {
                z += num;
            }
            else if (z == 15)
            {
                if (num < 5)
                {
                    z += num;
                }
                if (num == 5)
                {
                    z = 29;
                }
            }
            else if (z == 16)
            {
                if (num < 4)
                {
                    z += num;
                }
                if (num == 4)
                {
                    z = 29;
                }
                if (num == 5)
                {
                    z = 38;
                    if (y != 37)
                    {
                        box.Play();
                        MessageBox.Show("파랑 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (y == 37)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (z == 17)
            {
                if (num < 3)
                {
                    z += num;
                }
                if (num == 3)
                {
                    z = 29;
                }
                if (num > 3)
                {
                    z = 38;
                    if (y != 37)
                    {
                        box.Play();
                        MessageBox.Show("파랑 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (y == 37)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (z == 18)
            {
                if (num == 1)
                {
                    y += num;
                }
                if (num == 2)
                {
                    z = 29;
                }
                if (num > 2)
                {
                    z = 38;
                    if (y != 37)
                    {
                        box.Play();
                        MessageBox.Show("파랑 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (y == 37)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (z == 19)
            {
                if (num == 1)
                {
                    z = 29;
                }
                if (num > 1)
                {
                    z = 38;
                    if (y != 37)
                    {
                        box.Play();
                        MessageBox.Show("파랑 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (y == 37)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (z == 20)
            {
                if (num < 5)
                {
                    z += num;
                }
                if (num == 5)
                {
                    z = 15;
                }
            }
            else if (z == 21)
            {
                if (num < 4)
                {
                    z += num;
                }
                if (num >= 4)
                {
                    z += (-10 + num);
                }
            }
            else if (z == 22)
            {
                if (num < 4)
                {
                    z += (4 + num);
                }
                if (num >= 4)
                {
                    z = 38;
                    if (y != 37)
                    {
                        box.Play();
                        MessageBox.Show("파랑 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (y == 37)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (z == 23)
            {
                if (num == 1)
                {
                    z += num;
                }
                if (num >= 2)
                {
                    z += (-10 + num);
                }
            }
            else if (z == 24)
            {
                z += (-10 + num);
            }
            else if (z == 25)
            {
                if (num == 1)
                {
                    z += num;
                }
                if (num == 2)
                {
                    z = 22;
                }
                if (num > 2)
                {
                    z += (-1 + num);
                }
            }
            else if (z == 26)
            {
                if (num == 1)
                {
                    z = 22;
                }
                if (num < 5)
                {
                    z += (-1 + num);
                }
                if (num == 5)
                {
                    z = 38;
                    if (y != 37)
                    {
                        box.Play();
                        MessageBox.Show("파랑 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (y == 37)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (z == 27)
            {
                if (num < 3)
                {
                    z += num;
                }
                if (num >= 3)
                {
                    z = 38;
                    if (y != 37)
                    {
                        box.Play();
                        MessageBox.Show("파랑 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (y == 37)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (z == 28)
            {
                if (num == 1)
                {
                    z += num;
                }
                if (num > 1)
                {
                    z = 38;
                    if (y != 37)
                    {
                        box.Play();
                        MessageBox.Show("파랑 2번말 goal");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("M:{0}", "파랑 2번말 goal");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                    else if (y == 37)
                    {
                        blueTwo = false;
                        win.Play();
                        MessageBox.Show("파랑팀 승리하셨습니다.");
                        if (sw != null && client.Connected)
                        {
                            string pack = String.Format("D:{0}", false);
                            sw.WriteLine(pack);
                            sw.Flush();
                            pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                            sw.WriteLine(pack);
                            sw.Flush();
                        }
                    }
                }
            }
            else if (z == 29)
            {
                z = 38;
                if (y != 37)
                {
                    box.Play();
                    MessageBox.Show("파랑 2번말 goal");
                    if (sw != null && client.Connected)
                    {
                        string pack = String.Format("M:{0}", "파랑 2번말 goal");
                        sw.WriteLine(pack);
                        sw.Flush();
                    }
                }
                else if (y == 37)
                {
                    blueTwo = false;
                    win.Play();
                    MessageBox.Show("파랑팀 승리하셨습니다.");
                    if (sw != null && client.Connected)
                    {
                        string pack = String.Format("D:{0}", false);
                        sw.WriteLine(pack);
                        sw.Flush();
                        pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                        sw.WriteLine(pack);
                        sw.Flush();
                    }
                }
            }
            if (z == w)
            {
                box.Play();
                MessageBox.Show("빨강 말이 잡혔습니다\r\n\r\n한번더~!");
                w = 0;
                redTwo = false;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("S:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("M:{0}", "빨강 말이 잡혔습니다\r\n\r\n한번더~!");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (z == x)
            {
                box.Play();
                MessageBox.Show("빨강 말이 잡혔습니다\r\n\r\n한번더~!");
                x = 0;
                redTwo = false;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("S:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("M:{0}", "빨강 말이 잡혔습니다\r\n\r\n한번더~!");
                    sw.WriteLine(pack);
                    sw.Flush();
                    
                }
            }
            if (preZ != 0 && z != 0 && preZ == y)
            {
                y = z;
                blueTwo = true;
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("B:{0}", true);
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (y == 38)
            {
                blueTwo = false;
                y = 37;
                win.Play();
                MessageBox.Show("파랑팀 승리하셨습니다.");
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("D:{0}", false);
                    sw.WriteLine(pack);
                    sw.Flush();
                    pack = String.Format("A:{0}", "파랑팀 승리하셨습니다.");
                    sw.WriteLine(pack);
                    sw.Flush();
                }
            }
            if (sw != null && client.Connected)
            {
                string pack = String.Format("W:{0}", w.ToString());
                sw.WriteLine(pack);
                sw.Flush();

                pack = String.Format("Z:{0}", z.ToString());
                sw.WriteLine(pack);
                sw.Flush();

                pack = String.Format("X:{0}", x.ToString());
                sw.WriteLine(pack);
                sw.Flush();

                pack = String.Format("Y:{0}", y.ToString());
                sw.WriteLine(pack);
                sw.Flush();
            }
            Invalidate();
        }
        private void ChangeImage_Tick(object sender, EventArgs e)
        {

            if (num == 1)
            {
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("PDo:{0}", num.ToString());
                    sw.WriteLine(pack);
                    sw.Flush();
                }
                bitDo.Play();
                this.aniImage = this.Do;
                changeImage.Enabled = false;
                Invalidate();
            }
            if (num == 2)
            {
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("Pgae:{0}", num.ToString());
                    sw.WriteLine(pack);
                    sw.Flush();
                }
                bitgae.Play();
                this.aniImage = this.gae;
                changeImage.Enabled = false;
                Invalidate();
            }
            if (num == 3)
            {
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("Pgrl:{0}", num.ToString());
                    sw.WriteLine(pack);
                    sw.Flush();
                }
                bitgrl.Play();
                this.aniImage = this.grl;
                changeImage.Enabled = false;
                Invalidate();
            }
            if (num == 4)
            {
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("Pyut:{0}", num.ToString());
                    sw.WriteLine(pack);
                    sw.Flush();
                }
                bityut.Play();
                this.aniImage = this.yut;
                changeImage.Enabled = false;
                Invalidate();
            }
            if (num == 5)
            {
                if (sw != null && client.Connected)
                {
                    string pack = String.Format("Pmo:{0}", num.ToString());
                    sw.WriteLine(pack);
                    sw.Flush();
                }
                bitmo.Play();
                this.aniImage = this.mo;
                changeImage.Enabled = false;
                Invalidate();
            }
        }
    }
    
}
