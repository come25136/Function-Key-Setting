using System;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace FKS
{
    public partial class Form1 : Form
    {

        int b = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.ShowBalloonTip(500);
        }

        private void keyboardHook1_KeyboardHooked(object sender, HongliangSoft.Utilities.Gui.KeyboardHookedEventArgs e)
        {
            //Console.WriteLine(e.KeyCode.ToString("d"));

            var a = int.Parse(e.KeyCode.ToString("d"));

            if (b == 0)
            {

                //F9キーが押されたか調べる
                if (a == 120)
                {
                    //Console.WriteLine("F9キーが押されました。");

                    var sim = new InputSimulator();
                    sim.Keyboard.ModifiedKeyStroke(
                      new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.LWIN },
                      VirtualKeyCode.LEFT
                    );

                    b = 1;
                }

                //F10キーが押されたか調べる
                if (a == 121)
                {
                    //Console.WriteLine("F10キーが押されました。");

                    var sim = new InputSimulator();
                    sim.Keyboard.ModifiedKeyStroke(
                      new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.LWIN },
                      VirtualKeyCode.RIGHT
                    );

                    b = 1;
                }

            } else {
                b = 0;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
