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
    public partial class A_1_2_RegistrarLocalidad : Form
    {
        public A_1_2_RegistrarLocalidad()
        {
            InitializeComponent();


        }
        SqlConnection conex;
        SqlCommand comando;
        DataSet data;
        SqlDataAdapter adaptador = new SqlDataAdapter();
        private void A_1_2_RegistrarLocalidad_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet15.provincias' Puede moverla o quitarla según sea necesario.
            this.provinciasTableAdapter.Fill(this.chronosDataSet15.provincias);
            textBox2.Visible = false;
            button5.Visible = false;
            label3.Visible = false;
            button7.Visible=false;
            dataGridView1.Visible = false;

            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet6.provincia' Puede moverla o quitarla según sea necesario.
            conex = Procedimientos.Conexion();
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            comando = new SqlCommand("insert into localidades (descripcion,idProvincia) values (@descripcion,@idProvincia)", conex);
            adaptador.InsertCommand = comando;
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idProvincia", SqlDbType.Int));

            SqlCommand consulta = new SqlCommand("SELECT count(descripcion) from chronos.dbo.localidades where descripcion=@des and idprovincia=@idProvincia", conex);
            adaptador.SelectCommand = consulta;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@des",SqlDbType.VarChar));
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@idProvincia", SqlDbType.Int));

            
            
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese una Localidad por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conex.Open();
                    adaptador.SelectCommand.Parameters["@des"].Value = textBox1.Text;
                    adaptador.SelectCommand.Parameters["@idProvincia"].Value = comboBox1.SelectedValue;

                    int n = Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar());
                    if (n >= 1)
                    {
                        MessageBox.Show("La localidad ya existe en esa Provincia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                    }
                    else
                    {
                        adaptador.InsertCommand.Parameters["@descripcion"].Value = textBox1.Text;
                        adaptador.InsertCommand.Parameters["@idProvincia"].Value = comboBox1.SelectedValue;
                        adaptador.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Se ha registrado correctamente", "Informacion", MessageBoxButtons.OK);
                        textBox1.Text = "";

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Insertar: " + ex.Message,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           _02_Sesion_Administrador r = new _02_Sesion_Administrador();
            r.Show();
            this.Hide();

        }
        private void A_1_2_RegistrarLocalidad_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                dataGridView1.Visible = true;
                conex.Open();
                SqlCommand select = new SqlCommand("SELECT L.descripcion as Localidad, P.descripcion as Provincia FROM chronos.dbo.localidades as L, chronos.dbo.provincias as P where p.idProvincia=l.IdProvincia and p.idProvincia=@idPro", conex);
                adaptador.SelectCommand = select;
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@idPro", SqlDbType.Int));
                adaptador.SelectCommand.Parameters["@idPro"].Value = comboBox1.SelectedValue;
                data = new DataSet();
                adaptador.Fill(data, "Localidad");
                dataGridView1.DataSource = data;
                dataGridView1.DataMember = "Localidad";


                adaptador.SelectCommand.ExecuteNonQuery();
               
              }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Consultar:" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }

        }
        private void button4_Click(object sender, EventArgs e)
        {

            SqlCommand eliminar = new SqlCommand("DELETE FROM Chronos.dbo.localidades WHERE descripcion=@Descrip and idProvincia=@IdProv", conex);
            conex.Open();
            adaptador.DeleteCommand = eliminar;
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@Descrip", SqlDbType.VarChar));
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@IdProv", SqlDbType.Int));

            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese una Localidad ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    adaptador.DeleteCommand.Parameters["@Descrip"].Value = textBox1.Text;
                    adaptador.DeleteCommand.Parameters["@IdProv"].Value = comboBox1.SelectedValue;
                    if (adaptador.DeleteCommand.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("La Localidad no Existe en esa provincia","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    else 
                    {
                        MessageBox.Show("Se a eliminado correctamente la Localidad", "Informacion", MessageBoxButtons.OK);
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Error al Eliminar: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();


            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand modificar = new SqlCommand("UPDATE chronos.dbo.localidades SET descripcion=@descrip  where descripcion=@desco1 and idProvincia=@idprov", conex);
            conex.Open();
            adaptador.UpdateCommand = modificar;
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@descrip", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@desco1", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idprov", SqlDbType.Int));

            try 
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese una Localidad ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox2.Text == "") { MessageBox.Show("Ingrese la Localidad a modificar por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                adaptador.UpdateCommand.Parameters["@desco1"].Value = textBox1.Text;
                adaptador.UpdateCommand.Parameters["@descrip"].Value = textBox2.Text;
                adaptador.UpdateCommand.Parameters["@idprov"].Value = comboBox1.SelectedValue;
                if (adaptador.UpdateCommand.ExecuteNonQuery() == 0) 
                    {
                        MessageBox.Show("La Localidad no pertenece a esa Provincia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                    }
                else
                    MessageBox.Show("Se modifico el la localidad", "Informacion", MessageBoxButtons.OK);
                }
            }

            
            catch(SqlException ex)
            {
                MessageBox.Show("Error en Actualizar los Datos" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
        
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
            button7.Visible=true;
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
            button7.Visible=false;
            textBox1.Text = "";
        }
    }
}
