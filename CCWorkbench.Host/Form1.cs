using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace CCWorkbench.Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.ServiceModel.ServiceHost host =null;

        private void btnStart_Click(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(CCWorkbench.Server.Service1));
            host.Open();
            this.label1.Text = "服务启动成功！";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (host.State!=CommunicationState.Closed)
            {
                host.Close();
                this.label1.Text = "服务停止成功！";
            }
        }
    }
}
