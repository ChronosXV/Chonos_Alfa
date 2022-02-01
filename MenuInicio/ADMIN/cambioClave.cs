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
using System.Data.Sql;

namespace MenuInicio
{
    public partial class cambioClave : Form
    {
        public cambioClave()
        {
            InitializeComponent();
        }
        SqlConnection conex = Procedimientos.Conexion();
        SqlDataAdapter adaptador = new SqlDataAdapter();
        DataSet data = new DataSet();
        private void cambioClave_Load(object sender, EventArgs e)
        {
            conex.Open();
        }
        private void cambioClave_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Inicio p = new Inicio();
            p.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand update = new SqlCommand("UPDATE usuarios SET clave=ENCRYPTBYPASSPHRASE('Cambio',@clave),cambio_clave=@cambioClave WHERE nombre=@nombre and Convert(varchar(50),DECRYPTBYPASSPHRASE('Cambio',clave))=@claveVieja", conex);
            adaptador.UpdateCommand = update;
            adaptador.UpdateCommand.Parameters.Add("@clave",SqlDbType.VarChar );
            adaptador.UpdateCommand.Parameters.Add("@cambioClave",SqlDbType.VarChar);
            adaptador.UpdateCommand.Parameters.Add("@nombre",SqlDbType.VarChar);
            adaptador.UpdateCommand.Parameters.Add("@claveVieja", SqlDbType.VarChar);
            try 
            { 
                if(textBox2.Text.Trim()=="")
                {
                    MessageBox.Show("Ingrese la Clave actual por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(textBox3.Text.Trim()=="")
                {
                    MessageBox.Show("Ingrese una Clave Nueva por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese nuevamete la Clave nueva por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else 
                {
                   
                    string H= "False";
                    adaptador.UpdateCommand.Parameters["@clave"].Value = textBox3.Text;
                    adaptador.UpdateCommand.Parameters["@cambioClave"].Value = H;
                    adaptador.UpdateCommand.Parameters["@nombre"].Value = TxBox.Text;
                    adaptador.UpdateCommand.Parameters["@claveVieja"].Value = textBox2.Text;
                    if (textBox3.Text == textBox1.Text)
                    {
                        adaptador.UpdateCommand.ExecuteNonQuery();
                        MessageBox.Show("Se han aplicados los cambios", "Informacion", MessageBoxButtons.OK);
                        
                        Inicio p = new Inicio();
                        p.Show();
                        this.Hide();
                    }
                    else
                    {
                       MessageBox.Show("Las Claves no coiciden, Ingresen nuevamente las claves", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       textBox3.Text = "";
                       textBox1.Text = "";
                       textBox2.Text = "";
                     }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error al realizar los cambios: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();

            }
        }
    }
}
