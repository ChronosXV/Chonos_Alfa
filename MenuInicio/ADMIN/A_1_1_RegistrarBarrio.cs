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
    public partial class A_1_1_RegistrarBarrio : Form
    {
        public A_1_1_RegistrarBarrio()
        {
            InitializeComponent();
        }
        SqlConnection conexion;
        SqlCommand insert;
        DataSet data = new DataSet();
        SqlDataAdapter adaptador = new SqlDataAdapter();
        private void A_1_1_RegistrarBarrio_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet18.localidades' Puede moverla o quitarla según sea necesario.
            this.localidadesTableAdapter1.Fill(this.chronosDataSet18.localidades);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet14.localidades' Puede moverla o quitarla según sea necesario.
            this.localidadesTableAdapter.Fill(this.chronosDataSet14.localidades);

            textBox2.Visible = false;
            label3.Visible = false;
            button7.Visible = false;
            button4.Visible = false;
            dataGridView1.Visible = false;

            conexion = Procedimientos.Conexion();
         
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            insert = new SqlCommand("insert into barrios (descripcion,idLocalidad) values (@descripcion,@idLocalidad)", conexion);
            adaptador.InsertCommand = insert;
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idLocalidad", SqlDbType.Int));
            SqlCommand consulta = new SqlCommand(" SELECT COUNT(descripcion) FROM chronos.dbo.barrios where descripcion=@des and idlocalidad=@idlocalidad", conexion);
            adaptador.SelectCommand = consulta;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@des",SqlDbType.VarChar));
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@idlocalidad",SqlDbType.Int));
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un Barrio por favor","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    conexion.Open();
                    adaptador.SelectCommand.Parameters["@des"].Value = textBox1.Text;
                    adaptador.SelectCommand.Parameters["@idlocalidad"].Value = comboBox1.SelectedValue;
                    int n = Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar());
                    if (n >= 1)
                    {
                        MessageBox.Show("El Barrio ya existe en esa Localidad","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        textBox1.Text = "";
                    }
                    else
                    {
                        adaptador.InsertCommand.Parameters["@descripcion"].Value = textBox1.Text;
                        adaptador.InsertCommand.Parameters["@idLocalidad"].Value = comboBox1.SelectedValue;
                        
                        adaptador.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Los datos se ingresaron correctamente","Informacion",MessageBoxButtons.OK);
                        textBox1.Text = "";
                    }
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show("No se pudieron registrar los datos:" + excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
                {
              conexion.Close();
                }
            textBox2.Text = "";
            
        }
        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand select = new SqlCommand("SELECT B.descripcion AS BARRIO, L.descripcion AS LOCALIDAD FROM chronos.dbo.barrios AS B, dbo.localidades AS L WHERE B.idLocalidad = L.idLocaclidad  and L.idLocaclidad=@IdLoc", conexion);
            conexion.Open();
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@IdLoc", SqlDbType.Int));
            adaptador.SelectCommand.Parameters["@IdLoc"].Value = comboBox1.SelectedValue;
            adaptador.Fill(data,"barrio");
            dataGridView1.DataSource = data;
            dataGridView1.DataMember = "barrio";
            try 
            {
                dataGridView1.Visible = true;
                adaptador.SelectCommand.ExecuteNonQuery();
                data.Clear();
                adaptador.Fill(data,"barrio");
            }
            catch(SqlException er)
            {
                MessageBox.Show("Error: " + er.Message.ToString(),"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }

            textBox2.Text = "";
           
        }
        private void A_1_1_RegistrarBarrio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand eliminar = new SqlCommand("DELETE FROM Chronos.dbo.barrios WHERE descripcion=@Descrip and idLocalidad=@Locati", conexion);
            adaptador.DeleteCommand = eliminar;
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@Descrip", SqlDbType.VarChar));
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@Locati",SqlDbType.Int));

            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un Barrio por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conexion.Open();
                    adaptador.DeleteCommand.Parameters["@Descrip"].Value = textBox1.Text;
                    adaptador.DeleteCommand.Parameters["@Locati"].Value = comboBox1.SelectedValue;
                    if (adaptador.DeleteCommand.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("El Barrio no Existe en esa Localidad", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("El elemento seleccionado se ha eliminado", "Informacion", MessageBoxButtons.OK);
                        textBox1.Text = "";
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Eliminar " + ex.Message.ToString(),"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conexion.Close(); }

            textBox2.Text = "";
            this.label3.Visible = false;
            this.textBox2.Visible = false;
            this.button4.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand actualizar = new SqlCommand(" UPDATE Chronos.dbo.barrios SET descripcion=@Descrip1 where descripcion=@Descrip", conexion);
            adaptador.UpdateCommand = actualizar;

            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@Descrip", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@Descrip1", SqlDbType.VarChar));
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un Barrio por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox2.Text == "") { MessageBox.Show("Ingrese la modificacion del  Barrio por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    conexion.Open();
                    adaptador.UpdateCommand.Parameters["@Descrip"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@Descrip1"].Value = textBox2.Text;
                     adaptador.UpdateCommand.ExecuteNonQuery();
                     MessageBox.Show("Se han aplicados los cambios", "Informacion", MessageBoxButtons.OK);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al realizar los cambios:" + ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conexion.Close(); }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button6.Visible = false;
            button5.Visible = false;
            button4.Visible = true;
            textBox2.Visible = true;
            label3.Visible = true;
            button7.Visible = true;
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            _02_Sesion_Administrador r = new _02_Sesion_Administrador();
            r.Show();
            this.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button6.Visible = true;
            button5.Visible = true;

            textBox2.Visible = false;
            button4.Visible = false;
            label3.Visible = false;
            button7.Visible = false;
            textBox1.Text = "";
        }
      }
    }

