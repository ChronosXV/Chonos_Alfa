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
    public partial class A_1_5_RegistrarConvenio : Form
    {
        public A_1_5_RegistrarConvenio()
        {
            InitializeComponent();
           
        }
        SqlConnection conex;
        DataSet data;
        SqlDataAdapter adaptador = new SqlDataAdapter();
        private void A_1_5_RegistrarConvenio_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet13.categorias' Puede moverla o quitarla según sea necesario.
            this.categoriasTableAdapter.Fill(this.chronosDataSet13.categorias);

            conex = Procedimientos.Conexion();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
                       
            try 
            {
                conex.Open();
                SqlCommand consulta=new SqlCommand("SELECT descripcion as CONVENIO,horasSemanales AS 'HORAS SEMANALES',sueldoBasico AS 'SUELDO BASICO' FROM chronos.dbo.convenios ",conex);
                adaptador.SelectCommand= consulta;
                data=new DataSet();
                adaptador.Fill(data,"convenio");
                dataGridView1.DataSource = data;
                dataGridView1.DataMember ="convenio";
                dataGridView1.Visible = true;

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error al Consultar: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conex.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand insert = new SqlCommand("INSERT INTO chronos.dbo.convenios (descripcion,horasSemanales,sueldoBasico) VALUES(@des,@hora,@sueldo)", conex);
            adaptador.InsertCommand = insert;
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@des",SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@hora", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@sueldo", SqlDbType.Int));

            SqlCommand consultar = new SqlCommand("SELECT COUNT(descripcion) FROM Chronos.dbo.convenios where descripcion=@ces", conex);
            adaptador.SelectCommand = consultar;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@ces",SqlDbType.VarChar));


            try 
            {
                conex.Open();
                if (textBox1.Text == "") { MessageBox.Show("Ingrese el Convenio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else if (textBox2.Text == "") { MessageBox.Show("Ingrese las Horas Semanales ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
              else 
                {
                    adaptador.SelectCommand.Parameters["@ces"].Value=textBox1.Text;
                    int n = Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar());
                    if ( n>= 1) 
                    {
                        MessageBox.Show("El Convenio ya existe, por favor corrobore los datos ingresados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        //Error el formato no es el correcto @sueldo

                        adaptador.InsertCommand.Parameters["@des"].Value=textBox1.Text;
                        adaptador.InsertCommand.Parameters["@hora"].Value = Convert.ToInt64(textBox2.Text);
                        adaptador.InsertCommand.Parameters["@sueldo"].Value = Convert.ToInt64(textBox3.Text);
                        adaptador.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Los datos se han ingresados correctamente", "Informacion", MessageBoxButtons.OK);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error al agregar el Convenio: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand eliminar=new SqlCommand("DELETE FROM chronos.dbo.convenios WHERE descripcion=@des",conex);
                adaptador.DeleteCommand=eliminar;
                adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@des",SqlDbType.VarChar));
            try 
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un conveio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conex.Open();
                    adaptador.DeleteCommand.Parameters["@des"].Value = this.textBox1.Text;
                    if (adaptador.DeleteCommand.ExecuteNonQuery() >= 1)
                    {
                        MessageBox.Show("El Convenio se ha eliminado", "Informacion", MessageBoxButtons.OK);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("El convenio no existe, por favor verifique los datos ingresados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }

                }

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error al Eliminar: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{conex.Close();}
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
            button4.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            ACEPTAR.Visible = true;
            label6.Visible = true;
            label5.Visible = true;
            label4.Visible = true;

            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            button6.Visible = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            _02_Sesion_Administrador p=new _02_Sesion_Administrador();
            p.Show();
            this.Hide();
        }
        private void A_1_5_RegistrarConvenio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand modificar = new SqlCommand("UPDATE  chronos.dbo.convenios  SET descripcion=@des,horasSemanales=@horas,sueldoBasico=@sueldo WHERE descripcion=@ces ", conex);
            adaptador.UpdateCommand = modificar;
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@des", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@horas", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@sueldo", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@ces", SqlDbType.VarChar));

            SqlCommand consultar = new SqlCommand("SELECT COUNT(descripcion) FROM Chronos.dbo.convenios where descripcion=@ces", conex);
            adaptador.SelectCommand = consultar;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@ces", SqlDbType.VarChar));
            try 
            {
                conex.Open();
                adaptador.SelectCommand.Parameters["@ces"].Value = textBox1.Text;
                int n = Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar());
                if (!(n >= 1))
                {
                    MessageBox.Show("El Convenio no existe, por favor corrobore los datos ingresados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else 
                {

                    adaptador.UpdateCommand.Parameters["@ces"].Value =textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@des"].Value=textBox6.Text;
                    adaptador.UpdateCommand.Parameters["@horas"].Value = Convert.ToDouble(textBox5.Text);
                    adaptador.UpdateCommand.Parameters["@sueldo"].Value = Convert.ToDouble(textBox4.Text);
                    adaptador.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Los datos se han modificado", "Informacion", MessageBoxButtons.OK);
                    textBox1.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                    textBox4.Text = "";
                }
 
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error al modificar los datos: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            button1.Visible = true;
            button3.Visible = true;
            button5.Visible = true;
            button4.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            ACEPTAR.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label4.Visible = false;

            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button6.Visible = false;

        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }
    }
}
