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
    public partial class A_1_3_RegistrarProvincia : Form
    {
        public A_1_3_RegistrarProvincia()
        {
            InitializeComponent();
        }

        SqlConnection conex;
        SqlCommand comando;
        DataSet data;
        SqlDataAdapter adaptador = new SqlDataAdapter();
        private void A_1_3_RegistrarProvincia_Load(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            button5.Visible = false;
            label3.Visible = false;
            button7.Visible = false;
            dataGridView1.Visible = false;
           
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet12.pais' Puede moverla o quitarla según sea necesario.
            this.paisTableAdapter.Fill(this.chronosDataSet12.pais);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet11.pais' Puede moverla o quitarla según sea necesario.
            conex = Procedimientos.Conexion();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            comando = new SqlCommand("insert into chronos.dbo.provincia (descripcion,idPais) values (@descripcion,@idPais)", conex);
            adaptador.InsertCommand = comando;
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idPais", SqlDbType.Int));
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese una Provincia por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conex.Open();
                    adaptador.InsertCommand.Parameters["@descripcion"].Value = textBox1.Text;
                    adaptador.InsertCommand.Parameters["@idPais"].Value = comboBox1.SelectedValue;
                    adaptador.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Se ha registrado correctamente", "Informacion", MessageBoxButtons.OK);
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
        private void button3_Click(object sender, EventArgs e)
        {
         
            try
            {
                    dataGridView1.Visible = true;
                    conex.Open();
                    SqlCommand select = new SqlCommand("SELECT provi.descripcion As Provincia,pais.descripcion As Pais from chronos.dbo.provincia as provi, chronos.dbo.pais as pais where pais.idPais=@idPro", conex);
                    adaptador.SelectCommand = select;
                    adaptador.SelectCommand.Parameters.Add(new SqlParameter("@idPro", SqlDbType.Int));
                    adaptador.SelectCommand.Parameters["@idPro"].Value = comboBox1.SelectedValue;
                    data = new DataSet();
                    adaptador.Fill(data, "provincia");
                    dataGridView1.DataSource = data;
                    dataGridView1.DataMember = "provincia";
                    adaptador.SelectCommand.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Consultar:" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _02_Sesion_Administrador p = new _02_Sesion_Administrador();
            p.Show();
            this.Hide();
        }
        private void A_1_3_RegistrarProvincia_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
            SqlCommand eliminar = new SqlCommand("DELETE FROM Chronos.dbo.provincia WHERE descripcion=@Descrip and idPais=@IdProv", conex);
            conex.Open();
            adaptador.DeleteCommand = eliminar;
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@Descrip", SqlDbType.VarChar));
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@IdProv", SqlDbType.Int));
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese una Provincia ");
                }
                else
                {
                    adaptador.DeleteCommand.Parameters["@Descrip"].Value = textBox1.Text;
                    adaptador.DeleteCommand.Parameters["@IdProv"].Value = comboBox1.SelectedValue;
                    if (adaptador.DeleteCommand.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("La Provincia no Existe en ese Pais", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Se a eliminado correctamente la Provincia", "Informacion", MessageBoxButtons.OK);
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
            SqlCommand modificar = new SqlCommand("UPDATE chronos.dbo.provincia SET descripcion=@descrip  where descripcion=@desco1 and idpais=@idpais", conex);
             adaptador.UpdateCommand = modificar;
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@descrip", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@desco1", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idpais", SqlDbType.Int));
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese una Provincia ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox2.Text == "") { MessageBox.Show("Ingrese la Provincia a modificada por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else{
                    conex.Open();
                    adaptador.UpdateCommand.Parameters["@desco1"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@descrip"].Value = textBox2.Text;
                    adaptador.UpdateCommand.Parameters["@idpais"].Value = comboBox1.SelectedValue;
                    if (adaptador.UpdateCommand.ExecuteNonQuery() == 0) 
                    {
                        MessageBox.Show("La Provincia no pertenece a ese Pais", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                    }
                    else
                        MessageBox.Show("Se modifico el la Provincia", "Informacion", MessageBoxButtons.OK);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en Actualizar los Datos: " + ex.Message, "Informacion", MessageBoxButtons.OK);
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
            button7.Visible = true;
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
