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
using System.ServiceModel.Description;

namespace CCWorkbench.Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.ServiceModel.ServiceHost host1 = null;
        ServiceHost host2 = null;
        private List<ServiceHost> serviceHosts = new List<ServiceHost>();
        /// <summary>
        /// 采用程序的方法绑定多个服务到1个端口。
        /// </summary>
        private void ServiceStart()
           
        {
            if (serviceHosts != null)
            {
                foreach (ServiceHost t in serviceHosts)
                {
                    if (t != null)
                        t.Close();
                }
            }
            else
            {
                serviceHosts = new List<ServiceHost>();
            }

            string serviceAddress = string.Format("http://{0}:{1}", "10.76.37.152", "5031");
            Dictionary<Type, Type> sevtypes = new Dictionary<Type, Type>();
            sevtypes.Add(typeof(CCWorkbench.Server.IService1), typeof(CCWorkbench.Server.Service1));
            sevtypes.Add(typeof(CCWorkbench.Server.IService2), typeof(CCWorkbench.Server.Service2));
            string endpointAddress = string.Empty;
            string tName = string.Empty;
            StringBuilder msgService = new StringBuilder();
            foreach (var item in sevtypes)
            {
                tName = item.Key.Name.Substring(1);
                endpointAddress = serviceAddress + tName;
                if (!serviceAddress.EndsWith("/"))
                    endpointAddress = string.Format("{0}/{1}", serviceAddress, tName);
                ServiceHost serviceHost = new ServiceHost(item.Value, new Uri(endpointAddress));
                //加载元数据结点
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                serviceHost.Description.Behaviors.Add(smb);
                serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

                WSHttpBinding wsb = new WSHttpBinding();
                wsb.Security.Mode = SecurityMode.None;
                serviceHost.AddServiceEndpoint(item.Key, wsb, endpointAddress);

                //加载NetTcpBinding结点
                //NetTcpBinding netTcpBinding = new NetTcpBinding();
                //netTcpBinding.Security.Mode = SecurityMode.None;
                //netTcpBinding.ReceiveTimeout = TimeSpan.Parse("00:10:00");
                //netTcpBinding.MaxBufferPoolSize = 2147483647;
                //netTcpBinding.MaxBufferSize = 2147483647;
                //netTcpBinding.MaxConnections = 10;
                //netTcpBinding.ReaderQuotas.MaxDepth = 2147483647;
                //netTcpBinding.ReaderQuotas.MaxStringContentLength = 2147483647;
                //netTcpBinding.ReaderQuotas.MaxArrayLength = 2147483647;
                //netTcpBinding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                //netTcpBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
                //netTcpBinding.MaxReceivedMessageSize = 2147483647;
                //serviceHost.AddServiceEndpoint(item.Key, netTcpBinding, endpointAddress);


                serviceHost.Opened += delegate
                {
                    msgService.AppendLine(string.Format("{0}开始监听 Uri 为 ：{1}/mex", tName, endpointAddress.ToString()));
                };
                serviceHost.Open();
                serviceHosts.Add(serviceHost);
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            //host1 = new ServiceHost(typeof(CCWorkbench.Server.Service1), new Uri("http://10.76.37.152:5031/ser1"));//如果此处有，配置文件中要注释掉baseAddress
            host1 = new ServiceHost(typeof(CCWorkbench.Server.Service1));
            host1.Open();

            //host2 = new ServiceHost(typeof(CCWorkbench.Server.Service2), new Uri("http://10.76.37.152:5031/ser2"));
            host2 = new ServiceHost(typeof(CCWorkbench.Server.Service2));
            host2.Open();

            //this.ServiceStart();
            this.label1.Text = "服务启动成功！";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (host1.State != CommunicationState.Closed)
            {
                host1.Close();

            }
            if (host2.State != CommunicationState.Closed)
            {
                host2.Close();
            }
            //foreach (var item in this.serviceHosts)
            //{
            //    if (item.State!=CommunicationState.Closed)
            //    {
            //        item.Close();
            //    }
            //}
            this.label1.Text = "服务停止成功！";
        }
    }
}
