using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaloClick
{
    public partial class Main : Form
    {
        private long _clicks = 0;
        private double CaloriesBurnt
        {
            get
            {
                return _clicks * 1.42;
            }
        }

        public Main()
        {
            InitializeComponent();

            MouseHook.Start();
            MouseHook.MouseAction += delegate {
                _clicks += 1;

                if (this.InvokeRequired)
                {
                    this.Invoke((Action)delegate { updateUI(); });
                }
                else updateUI();
            };
        }

        private void Exit()
        {
            MouseHook.stop();
            Application.Exit();
        }

        private void updateUI()
        {
            ui_ClicksCount.Text = _clicks.ToString();
            ui_CaloriesBurned.Text = CaloriesBurnt.ToString();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Coded by Nicolas Quenault\n\nfacebook.com/nquenault\ntwitter.com/nquenault",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = topMostToolStripMenuItem.Checked;
        }
    }
}
