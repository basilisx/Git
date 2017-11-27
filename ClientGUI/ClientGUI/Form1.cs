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

namespace ClientGUI
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
           
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Go to next form if 'ready' is inputted in the textbox
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtEnter.Text == "ready")
            {
                Game frm1 = new Game();
                frm1.Show();
            }
            else if (txtEnter.Text != "ready")
            {
                MessageBox.Show("Invalid Input Mate!");              
            }
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
