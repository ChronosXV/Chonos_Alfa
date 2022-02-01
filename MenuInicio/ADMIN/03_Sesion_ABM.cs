using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MenuInicio
{
    public partial class AbmPrincipal : Form
    {
        public AbmPrincipal()
        {
            InitializeComponent();
            botonn = this.Width - button1.Width;

        }
        int botonn;
        private void _03_Sesion_Usuario1_Load(object sender, EventArgs e)
        {
          


        }

        private void _03_Sesion_Usuario1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _1_ABM Q = new _1_ABM();
            Q.Show();
            this.Hide();
            

           
            

        }

        private void _03_Sesion_Usuario1_Resize(object sender, EventArgs e)
        {
            button1.Width = this.Width - botonn;
            button2.Width = this.Width - botonn;
            //button3.Width = this.Width - botonn;
            button4.Width = this.Width - botonn;
            button7.Width = this.Width - botonn;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button1.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.CadetBlue;

            button6.Visible = true;
            button6.FlatAppearance.BorderSize = 1;
            button6.FlatAppearance.BorderColor = Color.CadetBlue;

            button2.ForeColor = Color.Gray;
            //button3.ForeColor = Color.Gray;
            button4.ForeColor = Color.Gray;

            button7.FlatAppearance.BorderSize = 1;
            button7.FlatAppearance.BorderColor = Color.CadetBlue;
            button7.ForeColor = Color.Black;

            button9.Visible = false;
            button8.Visible = false;
            button3.Visible = false;


            button2.ForeColor = Color.Gray;
            button2.FlatAppearance.BorderSize = 0;
            
            //button3.ForeColor = Color.Gray;
            //button3.FlatAppearance.BorderSize = 0;

            button4.ForeColor = Color.Gray;
            button4.FlatAppearance.BorderSize = 0;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button6.Visible = false;



            button8.Visible = true;
            button8.FlatAppearance.BorderSize = 1;
            button8.FlatAppearance.BorderColor = Color.CadetBlue;
           
            button9.Visible = true;
            button9.FlatAppearance.BorderSize = 1;
            button9.FlatAppearance.BorderColor = Color.CadetBlue;
            
            button3.Visible = true;
            button3.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderColor = Color.CadetBlue;
           
            button2.FlatAppearance.BorderSize = 1;
            button2.FlatAppearance.BorderColor = Color.CadetBlue;
            button2.ForeColor = Color.Black;


            button7.ForeColor = Color.Gray;
            button7.FlatAppearance.BorderSize = 0;
            
            //button3.ForeColor = Color.Gray;
            //button3.FlatAppearance.BorderSize = 0;

            button4.ForeColor = Color.Gray;
            button4.FlatAppearance.BorderSize = 0;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ABM_3_GenerarCertificadoTrabajo Q = new ABM_3_GenerarCertificadoTrabajo();
            Q.Show();
            this.Hide();

            button9.Visible = false;
            button8.Visible = false;
           
            button7.ForeColor = Color.Gray;
            button7.FlatAppearance.BorderSize = 0;

            button2.ForeColor = Color.Gray;
            button2.FlatAppearance.BorderSize = 0;
            
            button1.Visible = false;
            button6.Visible = false;

            button3.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderColor = Color.CadetBlue;
            button3.ForeColor = Color.Black;

            button4.ForeColor = Color.Gray;
            button4.FlatAppearance.BorderSize = 0;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Gray;
            button2.FlatAppearance.BorderSize = 0;

            //button3.ForeColor = Color.Gray;
            //button3.FlatAppearance.BorderSize = 0;

            button4.ForeColor = Color.Gray;
            button4.FlatAppearance.BorderSize = 0;


            button1.Visible = false;
            button6.Visible = false;

            button9.Visible = false;
            button8.Visible = false;
            button3.Visible = false;

            button4.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderColor = Color.CadetBlue;
            button4.ForeColor = Color.Black;
        }

        private void _03_Sesion_Usuario1_MouseClick(object sender, MouseEventArgs e)
        {

            button7.ForeColor = Color.Black;
            button7.FlatAppearance.BorderSize = 0;

            //button3.ForeColor = Color.Black;
            //button3.FlatAppearance.BorderSize = 0;

            button4.ForeColor = Color.Black;
            button4.FlatAppearance.BorderSize = 0;

            button2.ForeColor = Color.Black;
            button2.FlatAppearance.BorderSize = 0;

            button1.Visible = false;
            button6.Visible = false;

            button9.Visible = false;
            button8.Visible = false;
            button3.Visible = false;



        }

        private void button6_Click(object sender, EventArgs e)
        {
            ConsultarEmpleado p = new ConsultarEmpleado();
            p.Show();
            this.Hide();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LN_1_RegistrarCertificado p = new LN_1_RegistrarCertificado();
            p.Show();
            this.Hide();
        }
    }
}