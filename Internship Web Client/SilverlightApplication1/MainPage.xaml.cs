using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace SilverlightApplication1
{
    public partial class MainPage : Page
    {
        MainPage_VM m_oMainPage_VM;

        public MainPage()
        {
            InitializeComponent();
            m_oMainPage_VM = new MainPage_VM();

            this.DataContext = m_oMainPage_VM;
            m_oMainPage_VM.Navigatetoformpage += new EventHandler(Navigatetoformpage_v);
            m_oMainPage_VM.Navigatetofbpage += new EventHandler(Navigatetofbpage_v);

            //ServiceReference1.WebServiceInternshipSoapClient ws = new ServiceReference1.WebServiceInternshipSoapClient();
            
        }

        private void Navigatetofbpage_v(object sender, EventArgs e)
        {
            student fb_param = sender as student;
            this.Content = new feedback();
        }

        private void Navigatetoformpage_v(object sender, EventArgs e)
        {
            student form_param = sender as student;
            this.Content = new Form(form_param.lastName,form_param.firstName,form_param.matriculationNumber,form_param.groupNumber);
            //this.Content = new Form(lastname, firstname, m_smatno, gno);
        }

        
       
       
    }
}
