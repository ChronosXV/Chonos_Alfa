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
    public partial class A_1_13_EliminarEmpresa : Form
    {
        public A_1_13_EliminarEmpresa()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        private void A_1_13_EliminarEmpresa_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet22.pais' Puede moverla o quitarla según sea necesario.
            this.paisTableAdapter.Fill(this.chronosDataSet22.pais);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet20.localidades' Puede moverla o quitarla según sea necesario.
            this.localidadesTableAdapter.Fill(this.chronosDataSet20.localidades);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet21.barrios' Puede moverla o quitarla según sea necesario.
            this.barriosTableAdapter.Fill(this.chronosDataSet21.barrios);

            conex = Procedimientos.Conexion();
            dateTimePicker1.Value = DateTime.Now;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();

            SqlCommand select = new SqlCommand("SELECT COUNT(razonSocial),idEmpresa,descripcion,cuit,inicioDeActividad,calle,numerCalle,razonSocial,idBarrio,estado,IdLocalidad,IdPais FROM chronos.dbo.empresas where razonSocial=@razonSocial group by idEmpresa,descripcion,cuit,inicioDeActividad,calle,numerCalle,razonSocial,idBarrio,estado,IdLocalidad,IdPais", conex);
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
                        
                       /* adaptador1.SelectCommand.Parameters["@idEmpresa"].Value = label10.Text;
                        adaptador1.SelectCommand.ExecuteNonQuery();
                        adaptador1.Fill(data1, "empresas");
                        DataRow fila1 = data1.Tables["empresas"].Rows[0];
                        
                        if(fila1[0].ToString()=="Deshabilitado")
                            {
                            MessageBox.Show("La empresa esta Deshabilitada, por favor verifique la informacion ingresada o contactese con el administrador", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                             }
                          else{*/
                        textBox6.Text = fila.ItemArray[2].ToString();
                        textBox2.Text = fila.ItemArray[3].ToString();
                        dateTimePicker1.Text = fila.ItemArray[4].ToString();
                        textBox4.Text = fila.ItemArray[5].ToString();
                        textBox5.Text = fila.ItemArray[6].ToString();
                        comboBox1.SelectedValue = fila.ItemArray[8].ToString();
                        comboBox2.SelectedValue = fila.ItemArray[9].ToString();
                        comboBox3.SelectedValue = fila.ItemArray[10].ToString();
                    //} 
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
            SqlCommand delete = new SqlCommand("DELETE FROM chronos.dbo.empresas where idEmpresa=@idEmpresa", conex);
            adaptador.DeleteCommand = delete;
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.Int));
            try
            {
                conex.Open();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Por favor ingrese un nombre", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (label10.Text == "")
                    {
                        MessageBox.Show("Primero consulte si la empresa existe o no", "IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                    }
                    else
                    {

                        if (MessageBox.Show("Desea Eliminar  definitivamente la Empresa ¿?", "INFORMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            adaptador.DeleteCommand.Parameters["@idEmpresa"].Value = Convert.ToInt16(label10.Text);

                            if (adaptador.DeleteCommand.ExecuteNonQuery() > 0)
                            {

                                MessageBox.Show("Se ha eliminado correctamente la Empresa", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                                textBox6.Text = "";
                                dateTimePicker1.Value = DateTime.Now;
                                comboBox1.SelectedIndex = 0;
                            }
                            else
                            {
                                MessageBox.Show("Error al Eliminar la Empresa, Comunicarse con el administrador", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Se cancelo la operacion", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }



                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al Eliminar la empresa: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conex.Close();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            SqlDataAdapter adaptador = new SqlDataAdapter();

            SqlDataAdapter adaptador1 = new SqlDataAdapter();
            DataSet data1 = new DataSet();

            SqlCommand modi = new SqlCommand("UPDATE Chronos.dbo.empresas SET estado=@estado where idEmpresa=@idEmpresa", conex);
            adaptador.UpdateCommand = modi;
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.Int));

            SqlCommand consulta = new SqlCommand("SELECT estado from chronos.dbo.empresas where idEmpresa=@idEmpresa", conex);
            adaptador1.SelectCommand = consulta;
            adaptador1.SelectCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.Int));





            try
            {
                conex.Open();


                if (label10.Text == "")
                {
                    MessageBox.Show("Primero consulte si la empresa existe o no", "IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                }
                else
                {
                    adaptador1.SelectCommand.Parameters["@idEmpresa"].Value = label10.Text;
                    adaptador1.SelectCommand.ExecuteNonQuery();
                    adaptador1.Fill(data1, "empresas");
                    DataRow fila1 = data1.Tables["empresas"].Rows[0];
                    

                    if (radioButton1.Checked && fila1[0].ToString() == "Deshabilitar")
                    {
                        MessageBox.Show("La empresa esta Deshabilitada, por favor verifique la informacion ingresada o contactese con el administrador", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (radioButton1.Checked && fila1[0].ToString() != "Deshabilitar")
                    {

                        adaptador.UpdateCommand.Parameters["@estado"].Value = "Deshabilitar";
                        adaptador.UpdateCommand.Parameters["@idEmpresa"].Value = label10.Text;

                        if (adaptador.UpdateCommand.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Se ha deshabilitado la Empresa", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("Ha ocurrido un inconveniente verificar en el administrador.", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (radioButton2.Checked && fila1[0].ToString() == "Habilitar")
                    {
                        MessageBox.Show("La Empresa ya esta Habilitada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (radioButton2.Checked && fila1[0].ToString() == "Deshabilitar")
                    {
                        adaptador.UpdateCommand.Parameters["@estado"].Value = "Habilitar";
                        adaptador.UpdateCommand.Parameters["@idEmpresa"].Value = label10.Text;

                        if (adaptador.UpdateCommand.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Se ha Habilitado la Empresa", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("Ha ocurrido un inconveniente verificar en el administrador.", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Error al Cambiar el Estado a la Empresa: " + ex.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conex.Close();
            }

        }
    }
}


/* lo deshabilita pero no lo habilita
 */