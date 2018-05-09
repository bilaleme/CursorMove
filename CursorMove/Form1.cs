using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursorMove
{
    public partial class Form1 : Form
    {
        int property = 5;
        public Form1()
        {
            td = new System.Threading.Thread(new System.Threading.ThreadStart(MouseMove));
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            td.Abort();
        }

        System.Threading.Thread td;

        private void button1_Click(object sender, EventArgs e)
        {
            td = new System.Threading.Thread(new System.Threading.ThreadStart(MouseMove));
            td.Start();
            label1.Text = "Thread Started - Click Stop to Stop Movement";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            td.Abort();
            label1.Text = "";
        }

        private void MouseMove()
        {
            while (true)
            {
                Cursor cur = new Cursor(Cursor.Current.Handle);
                Cursor.Position = new Point(Cursor.Position.X + property, Cursor.Position.Y + property);
                System.Threading.Thread.Sleep(1000);
                property = property * -1;
            }
        }
    }
}
