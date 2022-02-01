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
    public partial class A_1_13_1_RegistrarEmpresa : Form
    {
        public A_1_13_1_RegistrarEmpresa()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        
        
        private void A_1_13_1_RegistrarEmpresa_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet24.localidades' Puede moverla o quitarla según sea necesario.
            this.localidadesTableAdapter.Fill(this.chronosDataSet24.localidades);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet23.pais' Puede moverla o quitarla según sea necesario.
            this.paisTableAdapter.Fill(this.chronosDataSet23.pais);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet19.barrios' Puede moverla o quitarla según sea necesario.
            this.barriosTableAdapter.Fill(this.chronosDataSet19.barrios);
            conex = Procedimientos.Conexion();
            dateTimePicker1.Value =  DateTime.Now;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            SqlCommand select = new SqlCommand("SELECT COUNT(razonSocial),idEmpresa,descripcion,cuit,inicioDeActividad,calle,numerCalle,razonSocial,idBarrio FROM chronos.dbo.empresas where razonSocial=@razonSocial group by idEmpresa,descripcion,cuit,inicioDeActividad,calle,numerCalle,razonSocial,idBarrio", conex);
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@razonSocial", SqlDbType.VarChar));
            try
            {
                conex.Open();

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un nombre", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    adaptador.SelectCommand.Parameters["@razonSocial"].Value = textBox1.Text;
                    if (Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("La empresa no existe, por favor verifique la informacion ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Clear();
                    }
                    else
                    {
                        adaptador.SelectCommand.ExecuteNonQuery();
                        DataSet data = new DataSet();
                        adaptador.Fill(data, "empresas");
                        DataRow fila;
                        fila = data.Tables["empresas"].Rows[0];
                        label10.Text = fila.ItemArray[1].ToString();
                        textBox6.Text = fila.ItemArray[2].ToString();
                        textBox2.Text = fila.ItemArray[3].ToString();
                        dateTimePicker1.Text = fila.ItemArray[4].ToString();
                        textBox4.Text = fila.ItemArray[5].ToString();
                        textBox5.Text = fila.ItemArray[6].ToString();
                        comboBox1.SelectedValue = fila.ItemArray[8].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conex.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            

            
            
            SqlDataAdapter adaptador = new SqlDataAdapter();
            SqlCommand update = new SqlCommand("UPDATE chronos.dbo.empresas set descripcion=@descripcion,cuit=@cuit,inicioDeActividad=@inicioDeActividad,calle=@calle,numerCalle=@numerCalle,razonSocial=@razonSocial,idBarrio=@idBarrio,idlocalidad=@idlocalidad, idpais=@idpais   WHERE idEmpresa=@idEmpresa", conex);
            adaptador.UpdateCommand = update;
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@cuit", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@inicioDeActividad", SqlDbType.DateTime));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@numerCalle", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@razonSocial", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idBarrio", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idlocalidad", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idpais", SqlDbType.Int));

            try 
            {
                conex.Open();

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un nombre", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                   
                    if (label10.Text =="")
                        {
                            MessageBox.Show("Primero consulte si la empresa existe o no", "IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Clear();
                        }
                        else
                        {
                            adaptador.UpdateCommand.Parameters["@Idempresa"].Value = Convert.ToInt32(label10.Text);
                            adaptador.UpdateCommand.Parameters["@descripcion"].Value = textBox6.Text;
                            adaptador.UpdateCommand.Parameters["@cuit"].Value = Convert.ToInt32(textBox2.Text);
                            adaptador.UpdateCommand.Parameters["@inicioDeActividad"].Value = dateTimePicker1.Value;
                            adaptador.UpdateCommand.Parameters["@calle"].Value = textBox4.Text;
                            adaptador.UpdateCommand.Parameters["@numerCalle"].Value =Convert.ToInt32(textBox5.Text);
                            adaptador.UpdateCommand.Parameters["@razonSocial"].Value = textBox1.Text;
                            adaptador.UpdateCommand.Parameters["@Idbarrio"].Value = comboBox1.SelectedValue;
                            adaptador.UpdateCommand.Parameters["@idlocalidad"].Value = comboBox2.SelectedValue;
                            adaptador.UpdateCommand.Parameters["@idpais"].Value = comboBox3.SelectedValue;
                            adaptador.UpdateCommand.ExecuteNonQuery();
                            MessageBox.Show("Los cambios se aplicaron correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            comboBox1.SelectedIndex = 0;
                            comboBox2.SelectedIndex = 0;
                            comboBox3.SelectedIndex = 0;
                        }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conex.Close();
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

    }
}
