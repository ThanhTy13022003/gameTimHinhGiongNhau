using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;

namespace GameTimHinhGiongNhau
{
    public partial class Form1 : Form
    {
        List<int> num = new List<int>() { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20, 21, 21, 22, 22, 23, 23, 24, 24, 25, 25, 26, 26, 27, 27, 28, 28, 29, 29, 30, 30 };
        string FirstChoice;
        string SecondChoice;
        int tries;
        List<PictureBox> pictures = new List<PictureBox>();
        PictureBox pic1ST;
        PictureBox pic2ND;
        int totalTime;
        int countTime;
        bool gOver = false;
        quantrimang socket;

        public Form1()
        {
            InitializeComponent();
            socket = new quantrimang();
            LoadPic();
            
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            countTime--;
            
            if (countTime < 1)
            {
                GameOver("Thua roi!!");
                foreach (PictureBox x in pictures)
                {
                    if (x.Tag != null)
                    {
                        x.Image = Image.FromFile((@"C:\Users\Lenovo\Desktop\GameTimHinhGiongNhau\GameTimHinhGiongNhau\bin\Debug\net6.0-windows\icon\" + (string)x.Tag) + ".jpg");
                    }
                }
            }
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGme();
        }
        private void LoadPic()
        {
            int LeftPos = 20;
            int topPos = 20;
            int row = 0;
            for (int i = 0; i < 60; i++)
            {
                PictureBox newPic = new PictureBox();
                newPic.Height = 50;
                newPic.Width = 50;
                newPic.BackColor = Color.LightGray;
                newPic.SizeMode = PictureBoxSizeMode.StretchImage;
                newPic.Click += NewPic_Click;
                pictures.Add(newPic);

                if (row < 6)
                {
                    row++;
                    newPic.Left = LeftPos;
                    newPic.Top = topPos;
                    this.Controls.Add(newPic);
                    LeftPos = LeftPos + 60;

                }
                if (row == 6)
                {
                    LeftPos = 20;
                    topPos += 60;
                    row = 0;
                }
            }
            RestartGme();
        }
        private void NewPic_Click(object sender, EventArgs e)
        {
            if (gOver)
            {
                //khong cho nhap chuot khi tro choi over
                return;
            }
            if (FirstChoice == null)
            {
                pic1ST = sender as PictureBox;
                if (pic1ST.Tag != null && pic1ST.Image == null)
                {
                    string imagePath = Path.Combine(Application.StartupPath, "icon", $"{pic1ST.Tag}.jpg");
                    if (File.Exists(imagePath))
                    {
                        pic1ST.Image = Image.FromFile(imagePath);
                        FirstChoice = (string)pic1ST.Tag;
                    }
                    else
                    {

                        MessageBox.Show("ko thay hinh anh!");
                    } 

                }
            }
            else if (SecondChoice == null)
            {
                pic2ND = sender as PictureBox;
                if (pic2ND.Tag != null && pic2ND.Image == null)
                {
                    pic2ND.Image = Image.FromFile((@"C:\Users\Lenovo\Desktop\GameTimHinhGiongNhau\GameTimHinhGiongNhau\bin\Debug\net6.0-windows\icon\" + (string)pic2ND.Tag) + ".jpg");
                    SecondChoice = (string)pic2ND.Tag;
                }
            }
            else
            {
                CheckPicture(pic1ST, pic2ND);
            }
        }

        private void RestartGme()
        {


            //random ds goc
            var randomList = num.OrderBy(x => Guid.NewGuid()).ToList();
            // gan ds random cho ds goc
            num = randomList;
            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Image = null;
                pictures[i].Tag = num[i].ToString();

            }
            tries = 0;
            lblStatus.Text = "Mismatched: " + tries + " time.";
            
            gOver = false;
            GameTimer.Stop();
            countTime = totalTime;


        }

        private void CheckPicture(PictureBox First, PictureBox Sencond)
        {
            if (FirstChoice == SecondChoice)
            {
                First.Tag = null;
                Sencond.Tag = null;

            }
            else
            {
                tries++;
                lblStatus.Text = "Mismatched " + tries + " times.";
            }
            FirstChoice = null;
            SecondChoice = null;
            foreach (PictureBox pics in pictures.ToList())
            {
                if (pics.Tag != null)
                {
                    pics.Image = null;
                }
            }
            //Ktra neu tat ca da dc hoan thanh
            if (pictures.All(O => O.Tag == pictures[0].Tag))
            {
                GameOver("GameOver");

            }
        }
        private void GameOver(string mess)
        {
            GameTimer.Stop();
            gOver = true;
            MessageBox.Show(mess + "click Restart ", "But hien ra va noi: ");
        }

        private void btnLan_Click(object sender, EventArgs e)
        {
            socket.IP = txtIP.Text;

            if (!socket.ConnectServer())
            {
                socket.CreateServer();

                Thread listenThread = new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        try
                        {
                            Listen();
                            break;
                        }
                        catch
                        {

                        }
                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            else
            {
                Listen();
                socket.Send("Thông tin từ Client");
            }

        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txtIP.Text))
            {
                txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }
        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                string data = (string)socket.Receive();
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }


    }
}