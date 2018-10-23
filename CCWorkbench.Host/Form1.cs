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
        System.ServiceModel.ServiceHost host1 =null;
        ServiceHost host2 = null;
        ServiceHost host3 = null;

        ServiceHost host4 = null;
        ServiceHost hostdouble = null;

        private void btnStart_Click(object sender, EventArgs e)
        {
            host1 = new ServiceHost(typeof(CCWorkbench.Server.Service1));
            host1.Open();

            host2 = new ServiceHost(typeof(Server.Service2));
            host2.Open();

            host3 = new ServiceHost(typeof(WcfServiceLibrary1.Service1));
            host3.Open();

            host4 = new ServiceHost(typeof(WcfServiceLibrary1.ServiceTest));
            host4.Open();

            hostdouble = new ServiceHost(typeof(WcfServiceLibrary1.ServiceDouble));
            hostdouble.Open();

            this.label1.Text = "服务启动成功！";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (host1.State!=CommunicationState.Closed)
            {
                host1.Close();
                
            }
            if (host2.State!=CommunicationState.Closed)

            {
                host2.Close();
            }

            if (host3.State != CommunicationState.Closed)

            {
                host3.Close();
            }

            this.label1.Text = "服务停止成功！";
        }
    }
}
