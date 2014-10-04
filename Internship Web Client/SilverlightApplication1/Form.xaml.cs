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
using System.Windows.Navigation;

namespace SilverlightApplication1
{
    public partial class Form : Page
    {
        form_VM m_oform_VM;

        public Form(string lastname, string firstname, string matno, string gno)
        {
            InitializeComponent();
            m_oform_VM = new form_VM();
            this.DataContext = m_oform_VM;

            m_oform_VM.Navigatetologinpage += new EventHandler(Navigatetologinpage_v);
                 

            m_oform_VM.lastName = lastname;
            m_oform_VM.firstName = firstname;
            m_oform_VM.matriculationNo = matno;
            m_oform_VM.groupNo = gno;
            m_oform_VM.startDate = DateTime.Now;
            m_oform_VM.endDate = DateTime.Now;

  
           }

        private void Navigatetologinpage_v(object sender, EventArgs e)
        {
            this.Content = new MainPage();
        }

       
       

    }
}
