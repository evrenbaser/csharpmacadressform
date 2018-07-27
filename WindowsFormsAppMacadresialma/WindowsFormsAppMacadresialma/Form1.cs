using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
namespace WindowsFormsAppMacadresialma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Mac()
        {
            ManagementClass manager = new ManagementClass("Win32_NetworkAdapterConfiguration");
            foreach (ManagementObject obj in manager.GetInstances())
            {
                if ((bool)obj["IPEnabled"])
                {
                    return obj["MacAddress"].ToString();
                }
            }

            return String.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string mac = Mac();// bir metot var yazacaz

            if (String.IsNullOrEmpty(mac))
            {
                MessageBox.Show("Biglisayarınızda bir ağ bağdaştırıcısı bulunamadı.");
            }
            else
            {
                MessageBox.Show("Mac adresiniz:"+ mac);
            }
           // Console.ReadKey();
        }
    }
}
