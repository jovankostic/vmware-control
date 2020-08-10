using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TZPUInterfejs
{
    public partial class Form1 : Form
    {
        VIMcmd vimcmd;
        System.Diagnostics.Process process;
        public Form1()
        {
            vimcmd = new VIMcmd("1Aa!23456789");
            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    
        private void StartApp(string path)
        {
            Process.Start(path);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            process = new System.Diagnostics.Process();
            //Process.Start("C:\\Program Files (x86)\\VMware\\VMware Workstation\\VMWare.exe");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /* string arString = "cd \"C:\\Program Files (x" +
                 "86)\\VMware\\VMware VIX\" && vmrun -T ws sta" +
                 "rt \"D:\\Virtual Machines\\" + vmText.Text + "\\" + vmText.Text + ".vmx\"";
             System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
             startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
             startInfo.Verb = "runas";
             startInfo.FileName = "cmd.exe";
             startInfo.Arguments = "/c" + arString;
             process.StartInfo = startInfo;
             process.Start();*/
            if (!vimcmd.CorrectName("192.168.64.131", vmText.Text))
                MessageBox.Show("Uneto ime virtualne masine ne postoji");
            else
            {
                try
                {
                    vimcmd.connectVMNetwork("192.168.64.131", vmText.Text, vimcmd.PowerOn);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Niste pravilno uneli ime virtualne masine" + ex.Message);
                }


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            /*  string arString = "cd \"C:\\Program Files (" +
                  "x86)\\VMware\\VMware VIX\" && vmrun stop \"D:\\" +
                  "Virtual Machines\\" + vmText.Text + "\\" + vmText.Text + ".vmx\"";
              System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
              startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
              startInfo.Verb = "runas";
              startInfo.FileName = "cmd.exe";
              startInfo.Arguments = "/c" + arString;
              process.StartInfo = startInfo;
              process.Start();*/
            if (!vimcmd.CorrectName("192.168.64.131", vmText.Text))
                MessageBox.Show("Uneto ime virtualne masine ne postoji");
            else
            {
                try
                {

                    vimcmd.connectVMNetwork("192.168.64.131", vmText.Text, vimcmd.PowerOff);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lose uneta virtualna masina ili je trazena virtualna masina vec ugasena" + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //snapshot
            /*  string arString = "cd \"C:\\Program Files (x86)" +
                  "\\VMware\\VMware VIX\" && vmrun revertToSnapshot \"D:\\Virtual Machines\\" + vmText.Text
                  + "\\" + vmText.Text + ".vmx\"" + " Snapshot 1";
              System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
              startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
              startInfo.Verb = "runas";
              startInfo.FileName = "cmd.exe";
              startInfo.Arguments = "/c" + arString;
              process.StartInfo = startInfo;
              process.Start();*/
            if (!vimcmd.CorrectName("192.168.64.131", vmText.Text))
                MessageBox.Show("Uneto ime virtualne masine ne postoji");
            else
            {
                try
                {

                    vimcmd.connectVMNetwork("192.168.64.131", vmText.Text, vimcmd.Revert);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lose uneta virtualna masina!" + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                IPForm ipfrm = new IPForm(vmText.Text);
                ipfrm.Show();
            }
            catch (Exception ex)
            { MessageBox.Show("Lose uneta VM");
            }
            
        }
    }
}
