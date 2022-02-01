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
    public partial class A_1_6_RegistrarJornada : Form
    {
        public A_1_6_RegistrarJornada()
        {
            InitializeComponent();
        }
         SqlConnection conex;
        SqlCommand comando;
        DataSet data;
        SqlDataAdapter adaptador = new SqlDataAdapter();
        private void A_1_6_RegistrarJornada_Load(object sender, EventArgs e)
        {
             textBox2.Visible = false;
            button5.Visible = false;
            label3.Visible = false;
            button7.Visible = false;
            dataGridView1.Visible = false;

            conex = Procedimientos.Conexion();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            comando = new SqlCommand("insert into chronos.dbo.jornadas (descripcion) values (@descripcion)", conex);
            SqlCommand consulta = new SqlCommand("select count(descripcion) from chronos.dbo.jornadas where descripcion=@des", conex);
            adaptador.SelectCommand = consulta;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@des", SqlDbType.VarChar));
            adaptador.InsertCommand = comando;
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar));
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese una Jornada por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conex.Open();

                    adaptador.SelectCommand.Parameters["@des"].Value = textBox1.Text;
                    int n = Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar());
                    if (n >= 1)
                    {
                        MessageBox.Show("La Jornada ya Existe, verifique la informacion ingresada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (SqlException ex) { MessageBox.Show("Error al Ingresar: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conex.Close(); }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
               try
            {
                dataGridView1.Visible = true;
                conex.Open();
                SqlCommand select = new SqlCommand("SELECT descripcion as JORNADA FROM chronos.dbo.jornadas ", conex);
                adaptador.SelectCommand = select;
                data = new DataSet();
                adaptador.Fill(data, "Jornadas");
                dataGridView1.DataSource = data;
                dataGridView1.DataMember = "Jornadas";


                adaptador.SelectCommand.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Consultar:" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }
        

        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            SqlCommand eliminar = new SqlCommand("DELETE FROM Chronos.dbo.jornadas WHERE descripcion=@Descrip", conex);
            adaptador.DeleteCommand = eliminar;
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@Descrip", SqlDbType.VarChar));

            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese una Jornada por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conex.Open();
                    adaptador.DeleteCommand.Parameters["@Descrip"].Value = textBox1.Text;
                    if (adaptador.DeleteCommand.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("La Jornada no Existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("El elemento seleccionado se ha eliminado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Eliminar:" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }

        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            //button3.Visible = false;
            button6.Visible = false;
            button4.Visible = false;

            textBox2.Visible = true;
            button5.Visible = true;
            label3.Visible = true;
            button7.Visible = true;

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            _02_Sesion_Administrador p = new _02_Sesion_Administrador();
            p.Show();
            this.Hide();
        }
        private void button7_Click_1(object sender, EventArgs e)
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
        private void button5_Click_1(object sender, EventArgs e)
        {
            SqlCommand actualizar = new SqlCommand(" UPDATE Chronos.dbo.jornadas SET descripcion=@Descrip1 where descripcion=@Descrip", conex);
            adaptador.UpdateCommand = actualizar;

            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@Descrip", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@Descrip1", SqlDbType.VarChar));

            SqlCommand consulta = new SqlCommand("select count(descripcion) from chronos.dbo.jornadas where descripcion=@des", conex);
            adaptador.SelectCommand = consulta;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@des", SqlDbType.VarChar));
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese una Jornadas por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox2.Text == "") { MessageBox.Show("Ingrese la Jornada a modificada por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {

                    conex.Open();
                    adaptador.SelectCommand.Parameters["@des"].Value = textBox1.Text;
                    int n = Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar());
                    if (n < 1)
                    {
                        MessageBox.Show("La Jornada no Existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    else
                    {
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
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al realizar los cambios: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }
        }
        private void A_1_6_RegistrarJornada_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
