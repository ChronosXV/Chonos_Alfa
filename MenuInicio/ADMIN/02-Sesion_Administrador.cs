using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuInicio
{
    public partial class _02_Sesion_Administrador : Form
    {
        public _02_Sesion_Administrador()
        {
            InitializeComponent();
        }
        private void _02_Sesion_Administrador_Load(object sender, EventArgs e)
        {

        }
        private void _02_Sesion_Administrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            A_1_1_RegistrarBarrio p = new A_1_1_RegistrarBarrio();
            p.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            A_1_2_RegistrarLocalidad p = new A_1_2_RegistrarLocalidad();
            p.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            A_1_3_RegistrarProvincia p = new A_1_3_RegistrarProvincia();
            p.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            A_1_4_RegistrarPais p = new A_1_4_RegistrarPais();
            p.Show();
            this.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            A_1_5_RegistrarConvenio P = new A_1_5_RegistrarConvenio();
            P.Show();
            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            A_1_6_RegistrarLicencia p = new A_1_6_RegistrarLicencia();
            p.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            A_1_6_RegistrarJornada p = new A_1_6_RegistrarJornada();
            p.Show();
            this.Hide();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            A_1_8_RegistrarPuesto p = new A_1_8_RegistrarPuesto();
            p.Show();
            this.Hide();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            Z_1_ContenedorReUs p = new Z_1_ContenedorReUs();
            p.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            A_1_11_RegistrarPerfil p = new A_1_11_RegistrarPerfil();
            p.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            A_1_12_RegistrarArea p = new A_1_12_RegistrarArea();
            p.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _02_ContenedorRegistrarEmpresa p = new _02_ContenedorRegistrarEmpresa();
            p.Show();
            this.Hide();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            _03_ContenedorRegistrarSite p = new _03_ContenedorRegistrarSite();
            p.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            A_1_15_RegistrarDepartamento p = new A_1_15_RegistrarDepartamento();
            p.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Inicio p = new Inicio();
            p.Show();
            this.Hide();
        }

       

       
    }
}
