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
    public partial class Inicio : Form
    {
        int tam;
        Point posi;
        Boolean movi;





        public Inicio()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            if (tam == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                tam = 1;
            }
            else if (tam == 1)
            {
                this.WindowState = FormWindowState.Normal;
                tam = 0;
            }

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            posi = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            movi = true;
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (movi == true)
            {
                Location = new Point(Cursor.Position.X - posi.X, Cursor.Position.Y - posi.Y);
            }
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            movi = false;

        }
        private void button4_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text == "" & textBox2.Text == ""))
            {
                MessageBox.Show("Ingrese usuario y Contraseña");

            }
            else if (textBox1.Text != "" & textBox2.Text == "")
            {
                MessageBox.Show("Ingrese una clave por favor");
            }
            else if (textBox2.Text != "" & textBox1.Text == "")
            {
                MessageBox.Show("Ingrese un usuario");
            }
            else
            {
                

                SqlCommand comando;
                SqlDataAdapter adaptador;
                SqlDataAdapter adaptador2 = new SqlDataAdapter();
                DataSet data;
                

                string Nombre = null;
                string Clave = null;
                string cambioClave1="True";

                Nombre = textBox1.Text;
                Clave = textBox2.Text;

                SqlConnection conexio = Procedimientos.Conexion();
                conexio.Open();

                 comando = new SqlCommand("SELECT idUsuario,nombre,CONVERT(VARCHAR(50),DECRYPTBYPASSPHRASE('Cambio',clave)),idPerfil,cambio_clave,estado  FROM [Chronos].[dbo].[usuarios] WHERE nombre = '"+ Nombre  +"'" , conexio);
                 adaptador = new SqlDataAdapter(comando);

                 SqlCommand select = new SqlCommand("SELECT COUNT(nombre) FROM [Chronos].[dbo].[usuarios]  WHERE nombre=@nombre1", conexio);
                 adaptador2.SelectCommand = select;
                 adaptador2.SelectCommand.Parameters.Add(new SqlParameter("@nombre1",SqlDbType.VarChar));
                
                 data = new DataSet();
                 adaptador.Fill(data,"usuario");

                 DataRow fila;
                //FALTA HACER LAS VALIDACIONES DE QUE SI LA CLAVE NO ES LA MISMA QUE ESTA INGRESANDO
                 try
                 {
                     fila = data.Tables["usuario"].Rows[0];
                     string estado = "Deshabilitado";

                     adaptador2.SelectCommand.Parameters["@nombre1"].Value = textBox1.Text;
                     if (Convert.ToInt16(adaptador2.SelectCommand.ExecuteScalar()) == 0)
                     {
                         MessageBox.Show("EL usuario no existe, verifique la informacion ingresada","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                         textBox1.Text = "";
                         textBox2.Text = "";
 
                     }
                     else if (Convert.ToInt16(adaptador2.SelectCommand.ExecuteScalar()) >= 1)
                     {
                         if (Clave != fila.ItemArray[2].ToString())
                         { 
                             MessageBox.Show("La clave ingresa no es correcta","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                         }
                         else
                         {
                             if (estado == fila.ItemArray[5].ToString())
                             {
                                 MessageBox.Show("El usuario esta Deshabilitado, contactarse con el Administrador del sistema", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                 textBox1.Text = "";
                                 textBox2.Text = "";
                             }
                             else
                             {
                                 if (Nombre == fila.ItemArray[1].ToString() && Clave == fila.ItemArray[2].ToString())
                                 {

                                     if (cambioClave1 == fila.ItemArray[4].ToString())
                                     {
                                         cambioClave p = new cambioClave();
                                         p.TxBox.Text = textBox1.Text;
                                         p.Show();
                                         this.Hide();
                                     }
                                     else
                                     {
                                         if (fila.ItemArray[3].ToString() == "1")
                                         {
                                             _02_Sesion_Administrador g = new _02_Sesion_Administrador();
                                             g.Show();
                                             this.Hide();
                                         }
                                         else
                                             if (fila.ItemArray[3].ToString() != "1")
                                             {
                                                 AbmPrincipal l = new AbmPrincipal();
                                                 l.Show();
                                                 this.Hide();

                                             }

                                     }
                                 }

                         }
                     }
                    

                     }
                 }
                 catch (IndexOutOfRangeException)
                 {
                     MessageBox.Show("Usuario o Clave incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     textBox1.Text = "";
                     textBox2.Text = "";
                 }
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
  }
}


