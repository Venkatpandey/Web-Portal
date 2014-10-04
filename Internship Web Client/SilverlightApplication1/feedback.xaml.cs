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
    public partial class feedback : Page
    {
        private int iRating
        {
            get { return m_iRating; }
            set
            {
                if (value != m_iRating)
                {

                    m_iRating = value;
                    m_ofeedback_VM.rate1 = value;
                }
            }
        }
        private int iRating_com
        {
            get { return m_iRating_com; }
            set
            {
                if (value != m_iRating_com)
                {

                    m_iRating_com = value;
                    m_ofeedback_VM.rate2 = value;
                }
            }
        }


       
        feedback_VM m_ofeedback_VM;
        private int m_iRating;
        private int m_iRating_com;


        public feedback()
        {
            InitializeComponent();
            m_ofeedback_VM = new feedback_VM();
            this.DataContext = m_ofeedback_VM;
            m_ofeedback_VM.Navigatetologinpage += new EventHandler(Navigatetologinpage_v);

        }
       

        private void Navigatetologinpage_v(object sender, EventArgs e)
        {
            this.Content = new MainPage();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChildWindow1 new_cw = new ChildWindow1();
            new_cw.Show();
        }

        private void img_1_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (img_1.Opacity == 1)
            {
                img_1.Opacity = 0.4;
                img_2.Opacity = 0.4;
                img_3.Opacity = 0.4;
                img_4.Opacity = 0.4;
                img_5.Opacity = 0.4;
                iRating = 0;
            }
            else
            {
                img_1.Opacity = 1;
                iRating = 1;
            }
        }
        private void img_2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (img_2.Opacity == 1)
            {
                img_2.Opacity = 0.4;
                img_3.Opacity = 0.4;
                img_4.Opacity = 0.4;
                img_5.Opacity = 0.4;
                iRating = 1;
            }
            else
            {
                img_1.Opacity = 1;
                img_2.Opacity = 1;
                iRating = 2;
            }
        }
        private void img_3_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            if (img_3.Opacity == 1)
            {
                img_3.Opacity = 0.4;
                img_4.Opacity = 0.4;
                img_5.Opacity = 0.4;
                iRating = 2;
            }
            else
            {
                img_1.Opacity = 1;
                img_2.Opacity = 1;
                img_3.Opacity = 1;
                iRating = 3;
            }
        }

        private void img_4_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (img_4.Opacity == 1)
            {
                img_4.Opacity = 0.4;
                img_5.Opacity = 0.4;
                iRating = 3;
            }
            else
            {
                img_1.Opacity = 1;
                img_2.Opacity = 1;
                img_3.Opacity = 1;
                img_4.Opacity = 1;
                iRating = 4;
            }
        }
        private void img_5_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (img_5.Opacity == 1)
            {
                img_5.Opacity = 0.4;
                iRating = 4;
            }
            else
            {
                img_1.Opacity = 1;
                img_2.Opacity = 1;
                img_3.Opacity = 1;
                img_4.Opacity = 1;
                img_5.Opacity = 1;
                iRating = 5;
            }
        }
        private void img_com_1_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (img_com_1.Opacity == 1)
            {
                img_com_1.Opacity = 0.4;
                img_com_2.Opacity = 0.4;
                img_com_3.Opacity = 0.4;
                img_com_4.Opacity = 0.4;
                img_com_5.Opacity = 0.4;
                iRating_com = 0;
            }
            else
            {
                img_com_1.Opacity = 1;
                iRating_com = 1;
            }
        }
        private void img_com_2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (img_com_2.Opacity == 1)
            {
                img_com_2.Opacity = 0.4;
                img_com_3.Opacity = 0.4;
                img_com_4.Opacity = 0.4;
                img_com_5.Opacity = 0.4;
                iRating_com = 1;
            }
            else
            {
                img_com_1.Opacity = 1;
                img_com_2.Opacity = 1;
                iRating_com = 2;
            }
        }
        private void img_com_3_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            if (img_com_3.Opacity == 1)
            {
                img_com_3.Opacity = 0.4;
                img_com_4.Opacity = 0.4;
                img_com_5.Opacity = 0.4;
                iRating_com = 2;
            }
            else
            {
                img_com_1.Opacity = 1;
                img_com_2.Opacity = 1;
                img_com_3.Opacity = 1;
                iRating_com = 3;
            }
        }

        private void img_com_4_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (img_com_4.Opacity == 1)
            {
                img_com_4.Opacity = 0.4;
                img_com_5.Opacity = 0.4;
                iRating_com = 3;
            }
            else
            {
                img_com_1.Opacity = 1;
                img_com_2.Opacity = 1;
                img_com_3.Opacity = 1;
                img_com_4.Opacity = 1;
                iRating_com = 4;
            }
        }

        private void img_com_5_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (img_com_5.Opacity == 1)
            {
                img_com_5.Opacity = 0.4;
                iRating_com = 4;
            }
            else
            {
                img_com_1.Opacity = 1;
                img_com_2.Opacity = 1;
                img_com_3.Opacity = 1;
                img_com_4.Opacity = 1;
                img_com_5.Opacity = 1;
                iRating_com = 5;
            }
        }

    }
}
