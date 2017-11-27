using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ClientGUI
{
    public partial class Game : Form
    {
        Socket sender;
        byte[] bytes = new byte[1024];
        int enemyHealth = 46, playerHealth = 50;
        byte[] msg;
        int bytesSent;
        int bytesRec;
        bool enemyShield = false;
        bool playerShield = false;
        bool change = true;
        bool empower = false;
        int calc;
        int empowered;

        public Game()
        {
            InitializeComponent();
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender = socket;
            txtHealth.Text = Convert.ToString(enemyHealth);
            txtPlayerHp.Text = Convert.ToString(playerHealth);
            pictureBox1.Image = Draw(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = Image.FromFile(@"C:\Users\Tatsura\Desktop\C#\ClientGUI\images\sakura.jpg");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            sender.Connect(remoteEP);

        }

        private void Game_Load(object sender, EventArgs e)
        {
            txtHealth.ReadOnly = true;
            btnAttack.Enabled = true;
            btnNext.Enabled = false;


        }

        //Draw the enemy name and red square border
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Brushes.Red, 10), new Rectangle(146, 70, 237, 173));
            //e.Graphics.FillRectangle((Brushes.Red), new Rectangle(202, 106, 100, 100));
            e.Graphics.DrawString("The Square", new Font(FontFamily.GenericMonospace, 18), Brushes.Purple, new PointF(180, 0));
        }

        //Close the form and disconnect from server
        private void button1_Click(object sender, EventArgs e)
        {
            Disconnect();
            this.Close();
        }

        private void Disconnect()
        {
            sender.Close();
        }

        //Button to attack
        private void btnAttack_Click(object sender, EventArgs e)
        {
            //Nested if statements for when enemy enemyShield is active and if player has empowered attack
            if (enemyShield == false)
            {
                if (empower == true)
                {
                    calc = 5 + empowered;
                    enemyHealth = enemyHealth - calc;
                    txtHealth.Text = Convert.ToString(enemyHealth);
                    txtLog.AppendText("You dealt a whopping " + calc + " damage!\n");
                    empower = false;
                    empowered = 0;
                }
                else if (empower == false)
                {
                    calc = enemyHealth - 5;
                    enemyHealth = calc;
                    txtHealth.Text = Convert.ToString(enemyHealth);
                    txtLog.AppendText("You dealt 5 damage!\n");
                }

            }
            else if (enemyShield == true)
            {
                if (empower == false)
                {
                    calc = enemyHealth - 3;
                    enemyHealth = calc;
                    txtHealth.Text = Convert.ToString(enemyHealth);
                    txtLog.AppendText("Reduced damage! You dealt 3 damage!\n");
                    enemyShield = false;
                    pictureBox1.Image = Draw(pictureBox1.Width, pictureBox1.Height);
                }
                else if (empower == true)
                {
                    int reduced;
                    reduced = (empowered + 5) / 2;
                    calc = enemyHealth - reduced;
                    enemyHealth = calc;
                    txtHealth.Text = Convert.ToString(enemyHealth);
                    txtLog.AppendText("Reduced damage! You dealt " + reduced + " damage!\n");
                    enemyShield = false;
                    empower = false;
                    empowered = 0;
                    pictureBox1.Image = Draw(pictureBox1.Width, pictureBox1.Height);
                }
            }

            //If enemy health reaches zero show winning message box 
            if (enemyHealth <= 0)
            {
                Disconnect();
                MessageBox.Show("Humanity is saved! \nGame Over");
                txtLog.Text = String.Empty;
                this.Hide();
            }

            btnAttack.Enabled = false;
            btnEmpower.Enabled = false;
            btnShield.Enabled = false;
            btnNext.Enabled = true;
        }

        //Button to empower attack
        private void btnEmpower_Click(object sender, EventArgs e)
        {
            empower = true;
            empowered += 3;
            if (enemyShield == true)
            {
                pictureBox1.Image = Draw(pictureBox1.Width, pictureBox1.Height);
            }
            txtLog.AppendText("Empowered! +3 damage! Your next attack deals more damage\n");
            btnAttack.Enabled = false;
            btnEmpower.Enabled = false;
            btnShield.Enabled = false;
            btnNext.Enabled = true;
        }

        //Button for player to put up enemyShield
        private void btnShield_Click(object sender, EventArgs e)
        {
            playerShield = true;
            txtLog.AppendText("You put up your enemyShield! You will take reduced damage\n");
            btnAttack.Enabled = false;
            btnEmpower.Enabled = false;
            btnShield.Enabled = false;
            btnNext.Enabled = true;
        }

        //Button to proceed the enemy turn
        private void btnNext_Click(object sender, EventArgs e)
        {
            EnemyTurn();

            //If player helath reaches zero show losing message box
            if (playerHealth <= 0)
            {
                Disconnect();
                MessageBox.Show("Humanity is doomed... \nGame Over");
                txtLog.Text = String.Empty;
                this.Hide();
            }
            if (enemyShield == true)
            {
                pictureBox1.Image = Draw2(pictureBox1.Width, pictureBox1.Height);
            }
            btnAttack.Enabled = true;
            btnEmpower.Enabled = true;
            btnShield.Enabled = true;
            btnNext.Enabled = false;


        }

        private void txtHealth_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPlayerHp_TextChanged(object sender, EventArgs e)
        {

        }

        //Method to receive text from server to decide enemy action
        private void EnemyTurn()
        {
            string log = "";
            int calc, dmg = 0;           

            msg = Encoding.ASCII.GetBytes("hey");
            bytesSent = sender.Send(msg);
            bytesRec = sender.Receive(bytes);
            string get = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            switch (get)
            {
                case "attack":
                    if (playerShield == false)
                    {
                        log = "Enemy attacked you!";
                        dmg = 6;
                        calc = playerHealth - dmg;
                        playerHealth = calc;
                        txtPlayerHp.Text = Convert.ToString(playerHealth);
                        txtLog.AppendText(log + " You lost " + dmg + " enemyHealth\n");
                        enemyShield = false;
                    }
                    else if (playerShield == true)
                    {
                        log = "Enemy attacked you!";
                        dmg = 3;
                        calc = playerHealth - dmg;
                        playerHealth = calc;
                        txtPlayerHp.Text = Convert.ToString(playerHealth);
                        txtLog.AppendText(log + " Reduced damage! You lost " + dmg + " enemyHealth\n");
                        playerShield = false;
                        enemyShield = false;
                    }
                    break;
                case "magic":
                    if (playerShield == false)
                    {
                        log = "Enemy used magic!";
                        dmg = 7;
                        calc = playerHealth - dmg;
                        playerHealth = calc;
                        txtPlayerHp.Text = Convert.ToString(playerHealth);
                        txtLog.AppendText(log + " You lost " + dmg + " enemyHealth\n");
                        enemyShield = false;
                    }
                    else if(playerShield == true)
                    {
                        log = "Enemy used magic!";
                        dmg = 4;
                        calc = playerHealth - dmg;
                        playerHealth = calc;
                        txtPlayerHp.Text = Convert.ToString(playerHealth);
                        txtLog.AppendText(log + " Reduced damage! You lost " + dmg + " enemyHealth\n");
                        playerShield = false;
                        enemyShield = false;
                    }
                    break;
                case "enemyShield":
                    log = "Enemy has deployed enemyShield!\n";
                    enemyShield = true;
                    pictureBox1.Image = Draw2(pictureBox1.Width, pictureBox1.Height);
                    txtLog.AppendText(log);
                    break;
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //Button to change background
        private void btnPicture_Click(object sender, EventArgs e)
        {
            if (change == false)
            {
                change = true;
                pictureBox2.Image = Image.FromFile(@"C:\Users\Tatsura\Desktop\C#\ClientGUI\images\sakura.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (change == true)
            {
                change = false;
                pictureBox2.Image = Image.FromFile(@"C:\Users\Tatsura\Desktop\C#\ClientGUI\images\underground_sea_cave.jpg");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        //Method that draws a red square within a picturebox
        public Bitmap Draw(int width, int height)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle(new SolidBrush(Color.Red), 0, 0, 200, 200);

            return bitmap;
        }

        

        //Method that draws a blue square within a picturebox
        public Bitmap Draw2(int width, int height)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 200, 200);

            return bitmap;
        }
    }
}
