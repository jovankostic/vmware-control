using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TZPUInterfejs
{
    public partial class IPForm : Form
    {
        System.Diagnostics.Process process;
        String vmName;
        public IPForm(String ime)
        {
            InitializeComponent();
            process = new System.Diagnostics.Process();
            vmName = ime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arString = "cd \"C:\\Program Files (x" +
                 "86)\\VMware\\VMware VIX\" && vmrun -gu windows -gp windows runProgramInGuest \"D:\\Virtual Machines\\" + vmName +
"\\" +vmName + ".vmx\" -nowait -interactive \"C:\\Windows\\System32\\netsh.exe\" interface ipv4 set address \"Local Area Connection\" static" + " " +
ipTXT.Text + " " + subnetTXT.Text + " " + "192.168.21.2";


              System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
              startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
              startInfo.FileName = "cmd.exe";
              startInfo.Arguments = "/c" + arString;
              process.StartInfo = startInfo;
              process.Start();
        }
    }
}
