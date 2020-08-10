using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet.Common;
using Renci.SshNet;
using System.Diagnostics;
using System.IO;

namespace TZPUInterfejs
{
    class VIMcmd
    {
        private string _esxpassword;
        private const string _esxusername = "root";
        private const string _command_disconnectvmnetwork = "vim-cmd vmsvc/device.connection {0} 4000 0";
        private const string _command_connectvmnetwork = "vim-cmd vmsvc/device.connection {0} 4000 1";
        private const string _command_getallvms = "vim-cmd vmsvc/getallvms";
        private const string _command_getalldevices = "vim-cmd vmsvc/device.getdevices {0}";
        private  string _command_poweron = "vim-cmd vmsvc/power.on {0}";
        private  string _command_poweroff = "vim-cmd vmsvc/power.off {0}";
        private  string _command_revertToSnapshot = "vim-cmd vmsvc/snapshot.revert {0} 1 0";
        private const string _command_getIpAddress = "vim - cmd vmsvc/get.guest {0} |grep -m 1 \"ipAddress = \"\"";
        
        public VIMcmd(string esxpassword)
        {
            _esxpassword = esxpassword;
        }
        public void runVM()
        {

        }
        /*
         * description: executes command and returns status string
         * params
         * return
         * 
         * 
         * 
         */
        private string runNewCommand(string command, string esxserver)
        {
            string userName = _esxusername;
            string password = _esxpassword;
            string serverName = esxserver;
            string result = "";

            var keyboardAuthMethod = new KeyboardInteractiveAuthenticationMethod(userName);

            keyboardAuthMethod.AuthenticationPrompt += delegate (Object senderObject, AuthenticationPromptEventArgs eventArgs)
            {
                foreach (var prompt in eventArgs.Prompts)
                {

                    if (prompt.Request.Equals("Password: ", StringComparison.InvariantCultureIgnoreCase))
                    {
                        prompt.Response = password;

                    }

                }

            };

            var passwordAuthMethod = new PasswordAuthenticationMethod(userName, password);

            var connectInfo = new ConnectionInfo(serverName, userName, passwordAuthMethod, keyboardAuthMethod);

            SshClient serverConnection = new SshClient(connectInfo);
            serverConnection.Connect();
            SshCommand cmnd = serverConnection.CreateCommand(command);

            result = cmnd.Execute();
            serverConnection.Disconnect();
            return result;

        }

        /*
         * description: disconnects VM from network
         * params
         * return
         * 
         * 
         * 
         */
        public string disconnectVMNetwork(string vmserver, string vmname)
        {
            string vmline;
            string _vmid = "";
            string _vmname = "";
            string vmslist = getAllVMs(vmserver);

            // parse output
            // id vmname config file ...
            StringReader sr = new StringReader(vmslist);

            while ((vmline = sr.ReadLine()) != null)
            {
                string[] vmdata = vmline.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (vmdata.Length < 2)
                    throw new Exception("Error: List of VMs didn't return enough data.");

                _vmid = vmdata[0];
                _vmname = vmdata[1];

                if (_vmname == vmname)
                {
                    break;
                }

                _vmid = "";
            }

            if (_vmid == "")
                return "Didnt't find VM with this name.";

            string command = String.Format(_command_disconnectvmnetwork, _vmid);
            return runNewCommand(command, vmserver);
        }

        /*
         * description: connects VM to network
         * params
         * return
         * 
         * 
         * 
         */

            public string PowerOn
        {
            get { return this._command_poweron; }
        }
        public string PowerOff
        {
            get { return this._command_poweroff; }
        }
        public string Revert
        {
            get { return this._command_revertToSnapshot; }
        }
        public void connectVMNetwork(string vmserver, string vmname,string komanda)
        {
            
                string _vmid = getVMID(vmserver, vmname);

                // if (_vmid == "")
                // return "Didnt't find VM with this name.";

                string command = String.Format(komanda, _vmid);
                Console.Write(runNewCommand(command, vmserver));
                //  return runNewCommand(command, vmserver);
           
        }
        public bool CorrectName(string vmserver, string vmname)
        {
            string _vmid = getVMID(vmserver, vmname);
            if (_vmid == "")
                return false;
            return true;
        }

        public string getVMID(string vmserver, string vmname)
        {
            string vmline;
            string _vmname = "";
            string _vmid = "";

            string vmslist = getAllVMs(vmserver);
            // parse output
            // id vmname config file ...
            StringReader sr = new StringReader(vmslist);

            while ((vmline = sr.ReadLine()) != null)
            {
                string[] vmdata = vmline.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (vmdata.Length < 2)
                    throw new Exception("Error: List of VMs didn't return enough data.");

                _vmid = vmdata[0];
                _vmname = vmdata[1];

                if (_vmname == vmname)
                {
                    break;
                }

                _vmid = "";
            }

            return _vmid;
        }

        /*
         * description: get list of VMs
         * params
         * return
         * 
         * 
         * 
         */
        public string getAllVMs(string vmserver)
        {
            string command = String.Format(_command_getallvms, vmserver);
            return runNewCommand(command, vmserver);
        }

        /*
         * description: get all VM devices, finds VM id in first step, then parses and returns network connection status
         * params
         * return
         * 
         * 
         * 
         */
        public string getAllVMDevices(string vmserver, string vmid)
        {
            string command = String.Format(_command_getalldevices, vmid);
            return runNewCommand(command, vmserver);
        }
    }
}
