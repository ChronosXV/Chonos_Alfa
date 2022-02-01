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
    public partial class A_1_4_RegistrarPais : Form
    {
        public A_1_4_RegistrarPais()
        {
            InitializeComponent();
        }

        SqlConnection conex;
        SqlCommand comando;
        DataSet data;
        SqlDataAdapter adaptador = new SqlDataAdapter();
        private void A_1_4_RegistrarPais_Load(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            button5.Visible = false;
            label3.Visible = false;
            button7.Visible = false;
            dataGridView1.Visible = false;

            conex = Procedimientos.Conexion();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            comando = new SqlCommand("insert into chronos.dbo.pais (descripcion) values (@descripcion)", conex);
            SqlCommand consulta = new SqlCommand("select count(descripcion) from chronos.dbo.pais where descripcion=@des", conex);
            adaptador.SelectCommand = consulta;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@des",SqlDbType.VarChar));
            adaptador.InsertCommand = comando;
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar));
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese una Pais por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conex.Open();
                   
                    adaptador.SelectCommand.Parameters["@des"].Value = textBox1.Text;
                    int n=Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar());
                    if ( n>=1)
                    {
                        MessageBox.Show("El Pais ya Existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                    }
                    else
                    {

                        adaptador.InsertCommand.Parameters["@descripcion"].Value = textBox1.Text;
                        adaptador.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Se ha registrado correctamente", "Informacion", MessageBoxButtons.OK);
                        textBox1.Text = "";
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al ingresar los datos: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            _02_Sesion_Administrador p = new _02_Sesion_Administrador();
            p.Show();
            this.Hide();
        }
        private void A_1_4_RegistrarPais_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.Visible = true;
                conex.Open();
                SqlCommand select = new SqlCommand("SELECT descripcion as Pais  FROM chronos.dbo.pais ", conex);
                adaptador.SelectCommand = select;
                data = new DataSet();
                adaptador.Fill(data, "Pais");
                dataGridView1.DataSource = data;
                dataGridView1.DataMember = "Pais";


                adaptador.SelectCommand.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Consultar: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand eliminar = new SqlCommand("DELETE FROM Chronos.dbo.pais WHERE descripcion=@Descrip", conex);
            adaptador.DeleteCommand = eliminar;
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@Descrip", SqlDbType.VarChar));

            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un Pais por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conex.Open();
                    adaptador.DeleteCommand.Parameters["@Descrip"].Value = textBox1.Text;
                    if (adaptador.DeleteCommand.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("El Pais no Existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("El elemento seleccionado se ha eliminado", "Informacion", MessageBoxButtons.OK);
                        textBox1.Text = "";
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error al Eliminar: " + ex.Message,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button6.Visible = false;
            button4.Visible = false;

            textBox2.Visible = true;
            button5.Visible = true;
            label3.Visible = true;
            button7.Visible = true;
         }
        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand actualizar = new SqlCommand(" UPDATE Chronos.dbo.pais SET descripcion=@Descrip1 where descripcion=@Descrip", conex);
            adaptador.UpdateCommand = actualizar;

            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@Descrip", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@Descrip1", SqlDbType.VarChar));
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un Pais por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox2.Text == "") { MessageBox.Show("Ingrese el Pais modificado por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else{
                    conex.Open();
                    adaptador.UpdateCommand.Parameters["@Descrip"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@Descrip1"].Value = textBox2.Text;
                    adaptador.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Se han aplicados los cambios", "Informacion", MessageBoxButtons.OK);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button6.Visible = true;
                    button4.Visible = true;
                    textBox2.Visible = false;
                    button5.Visible = false;
                    label3.Visible = false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al realizar los cambios: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button6.Visible = true;
            button4.Visible = true;

            textBox2.Visible = false;
            button5.Visible = false;
            label3.Visible = false;
            button7.Visible = false;
            textBox1.Text = "";
        }
    }
}