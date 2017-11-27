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

namespace GameClient
{
    public partial class ClientGUI : Form
    {
        byte[] bytes = new byte[1024];
        static IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        static IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
        Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        

        public ClientGUI()
        {
            InitializeComponent();
            sender.Connect(remoteEP);
            textBox1.Text = "Connected";
        }

        private void ClientGUI_Load(object sender, EventArgs e)
        {
            /*client.Connect("localhost", 1100);
            textBox1.Text = "Connected";*/
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*NetworkStream serverStream = client.GetStream();
            byte[] outStream = Encoding.ASCII.GetBytes("end");
            serverStream.Write(outStream ,0, outStream.Length);*/

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
