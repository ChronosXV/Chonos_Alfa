using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MenuInicio
{
    public partial class A_1_9_RegistrarUsuario : Form
    {
        public A_1_9_RegistrarUsuario()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        SqlCommand comando;
        SqlDataAdapter adaptador = new SqlDataAdapter();
        private void A_1_9_RegistrarUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet16.perfiles' Puede moverla o quitarla según sea necesario.
            this.perfilesTableAdapter.Fill(this.chronosDataSet16.perfiles);
            conex = Procedimientos.Conexion();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            comando = new SqlCommand("insert into chronos.dbo.usuarios (nombre,clave,idperfil,cambio_clave,estado) values (@nombre,ENCRYPTBYPASSPHRASE('Cambio',@clave),@idperfil,@Cclave,@estado)", conex);
            SqlCommand consulta = new SqlCommand("select count(nombre) from chronos.dbo.usuarios where nombre=@nom", conex);
            adaptador.SelectCommand = consulta;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@nom", SqlDbType.VarChar));
            adaptador.InsertCommand = comando;
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@clave", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idperfil", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@Cclave", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar));
            try
            {
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el ID del usuario por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox3.Text.Trim()== "") { MessageBox.Show("Ingrese una clave por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    conex.Open();

                    adaptador.SelectCommand.Parameters["@nom"].Value = textBox1.Text;
                    int n = Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar());
                    if (n >= 1)
                    {
                        MessageBox.Show("El ID ya Existe, verifique la informacion ingresada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox3.Text = "";
                        
                    }
                    else
                    {
                        bool cambio=checkBox1.Checked;

                        string g= "Activo";
                        adaptador.InsertCommand.Parameters["@nombre"].Value =  textBox1.Text;
                        adaptador.InsertCommand.Parameters["@clave"].Value =   textBox3.Text;
                        adaptador.InsertCommand.Parameters["@idperfil"].Value = comboBox1.SelectedValue;
                        adaptador.InsertCommand.Parameters["@Cclave"].Value = Convert.ToString(cambio);
                        adaptador.InsertCommand.Parameters["@estado"].Value = g;
                        adaptador.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Se ha registrado correctamente", "Informacion", MessageBoxButtons.OK);
                        textBox1.Text = "";
                        textBox3.Text = "";
                        checkBox1.Checked=false;
                    }

                }

            }
            catch (SqlException ex) { MessageBox.Show("Error al agregar los datos: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conex.Close(); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }
        private void button6_Click(object sender, EventArgs e)
        {
            _02_Sesion_Administrador p = new _02_Sesion_Administrador();
            p.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
