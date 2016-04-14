using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace FKS
{
    public partial class Form1 : Form
    {

        string a;
        int b;
        int c;
        int flag;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.ShowBalloonTip(500);
            pictureBox1.LoadAsync("http://www.paper-glasses.com/api/twipi/come25136/bigger");
            textBox1.Text = Properties.Settings.Default.Leftkey;
            textBox2.Text = Properties.Settings.Default.Rightkey;
        }

        private void keyboardHook1_KeyboardHooked(object sender, HongliangSoft.Utilities.Gui.KeyboardHookedEventArgs e)
        {
            //Console.WriteLine(e.KeyCode);

            a = e.KeyCode.ToString();
            if (c != 1)
            {
                if (b == 0)
                {

                    //左移動
                    if (a == Properties.Settings.Default.Leftkey)
                    {
                        //Console.WriteLine("F9キーが押されました。");

                        var sim = new InputSimulator();
                        sim.Keyboard.ModifiedKeyStroke(
                          new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.LWIN },
                          VirtualKeyCode.LEFT
                        );

                        b = 1;
                    }

                    //右移動
                    if (a == Properties.Settings.Default.Rightkey)
                    {
                        var sim = new InputSimulator();
                        sim.Keyboard.ModifiedKeyStroke(
                          new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.LWIN },
                          VirtualKeyCode.RIGHT
                        );

                        b = 1;
                    }

                }
                else
                {
                    b = 0;
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 1;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = a;
            Properties.Settings.Default.Leftkey = a;

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            textBox2.Text = a;
            Properties.Settings.Default.Rightkey = a;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag != 1)
            {
                e.Cancel = true;
                c = 0;
                this.Hide();

            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            c = 1;
            this.Visible = true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
