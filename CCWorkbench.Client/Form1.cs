using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCWorkbench.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference3.Service1Client sc = new ServiceReference3.Service1Client();
            this.label1.Text = sc.GetData(12);
            ServiceReference3.CompositeType ct = new ServiceReference3.CompositeType();
            ct.BoolValue = true;
            ServiceReference3.Person p = new ServiceReference3.Person();
            p.Name = "12";




            ServiceReference4.ServiceTestClient sc4 = new ServiceReference4.ServiceTestClient();
            sc4.GetDataTest(33);

            ServiceReference5.Service1Client sc5 = new ServiceReference5.Service1Client();
            this.label1.Text = sc5.GetData(0);
            ServiceReference5.ServiceTestClient stc5 = new ServiceReference5.ServiceTestClient();
            this.label2.Text = stc5.GetDataTest(11);


        }
    }
}
