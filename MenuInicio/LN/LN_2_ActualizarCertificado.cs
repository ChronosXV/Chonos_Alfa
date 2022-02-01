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
    public partial class LN_2_ActualizarCertificado : Form
    {
        public LN_2_ActualizarCertificado()
        {
            InitializeComponent();
        }
        SqlConnection conex;

        private void LN_2_ActualizarCertificado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet89.certificados' Puede moverla o quitarla según sea necesario.
            this.certificadosTableAdapter1.Fill(this.chronosDataSet89.certificados);
            // TODO: esta línea de código carga datos en la tabla 'legajo_Certificado.certificados' Puede moverla o quitarla según sea necesario.
            this.certificadosTableAdapter.Fill(this.legajo_Certificado.certificados);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet87.tipoLicencias' Puede moverla o quitarla según sea necesario.
            this.tipoLicenciasTableAdapter.Fill(this.chronosDataSet87.tipoLicencias);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet85.empleados' Puede moverla o quitarla según sea necesario.
            this.empleadosTableAdapter.Fill(this.chronosDataSet85.empleados);
            conex = Procedimientos.Conexion();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            //Se habilitan los campos
            comboBox2.Enabled = false;
            comboBox5.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            button1.Enabled = false;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                SqlCommand select = new SqlCommand("select * from chronos.dbo.certificados WHERE legajo =@Legajo_Cert AND idTipolicencia=@TipoLicencia AND idCertificado=@idCertificado", conex);
                SqlDataAdapter adaptador = new SqlDataAdapter();
                DataSet data;
                adaptador.SelectCommand = select;
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@Legajo_Cert", SqlDbType.Int));
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@TipoLicencia", SqlDbType.Int));
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@idCertificado", SqlDbType.Int));
                try
                {
                    if (comboBox1.SelectedValue.ToString() == "")
                    {
                        MessageBox.Show("Selecciones un Legajo por favor....", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        conex.Open();
                        adaptador.SelectCommand.Parameters["@Legajo_Cert"].Value = comboBox1.SelectedValue;
                        adaptador.SelectCommand.Parameters["@TipoLicencia"].Value = comboBox3.SelectedValue;
                        adaptador.SelectCommand.Parameters["@idCertificado"].Value = comboBox4.SelectedValue;
                        data = new DataSet();
                        adaptador.Fill(data, "certificados");
                        DataRow fila = data.Tables["certificados"].Rows[0];

                        //Se habilitan los campos
                        comboBox2.Enabled = true;
                        comboBox5.Enabled = true;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        textBox5.Enabled = true;
                        dateTimePicker1.Enabled = true;
                        dateTimePicker2.Enabled = true;
                        button1.Enabled = true;
                        button3.Enabled = true;


                        // Cargamos los campos con la informacion que estan en la base de datos
                        comboBox2.SelectedValue = fila.ItemArray[7];
                        comboBox5.SelectedValue = fila.ItemArray[6];
                        textBox1.Text = fila.ItemArray[1].ToString();
                        textBox2.Text = fila.ItemArray[2].ToString();
                        textBox3.Text = fila.ItemArray[3].ToString();
                        textBox4.Text = fila.ItemArray[4].ToString();
                        textBox5.Text = fila.ItemArray[5].ToString();
                        dateTimePicker1.Text = fila.ItemArray[8].ToString();
                        dateTimePicker2.Text = fila.ItemArray[9].ToString();





                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al consultar el empleado:" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conex.Close();
                }
            }
        }
        //string Legajo_Cert = null;
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            conex = Procedimientos.Conexion();
            if (comboBox1.SelectedIndex != -1)
            {
                // Se crea query para traer el legajo del comboBox1 y pasarlo al ComboBox3
                SqlCommand select = new SqlCommand("SELECT DISTINCT T.descripcion, C.idTipolicencia FROM [dbo].[certificados] C INNER JOIN[dbo].[tipoLicencias] T ON C.idTipolicencia = T.idTipoLicencia WHERE C.legajo =@Legajo_Cert", conex);
                SqlDataAdapter adaptador = new SqlDataAdapter();
                SqlDataReader reader;
                DataTable data1;
                adaptador.SelectCommand = select;
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@Legajo_Cert", SqlDbType.Int));

                //Se abre conexion y se utiliza la query de arriba
                conex.Open();
                adaptador.SelectCommand.Parameters["@Legajo_Cert"].Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                reader = adaptador.SelectCommand.ExecuteReader();
                data1 = new DataTable();
                data1.Columns.Add("descripcion");
                data1.Columns.Add("idTipolicencia");
                data1.Load(reader);
                comboBox3.DisplayMember = "descripcion";
                comboBox3.ValueMember = "idTipolicencia";
                comboBox3.DataSource = data1;
                conex.Close();
            }

        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {

            conex = Procedimientos.Conexion();
            if (comboBox3.SelectedIndex != -1)
            {

                //Se crea query para traer el legajo del comboBox1 y pasarlo al ComboBox3
                SqlCommand select = new SqlCommand("SELECT RIGHT('0000'+LTRIM(idCertificado),4) as IdCertificado FROM [dbo].[certificados] WHERE legajo =@Legajo_Cert AND idTipolicencia=@TipoLicencia", conex);
                SqlDataAdapter adaptador = new SqlDataAdapter();
                SqlDataReader reader;
                DataTable data1;
                adaptador.SelectCommand = select;
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@Legajo_Cert", SqlDbType.Int));
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@TipoLicencia", SqlDbType.Int));

                //Se abre conexion y se utiliza la query de arriba
                conex.Open();
                adaptador.SelectCommand.Parameters["@Legajo_Cert"].Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                adaptador.SelectCommand.Parameters["@TipoLicencia"].Value = Convert.ToInt32(comboBox3.SelectedValue.ToString());
                reader = adaptador.SelectCommand.ExecuteReader();
                data1 = new DataTable();
                //data1.Columns.Add("descripcion");
                data1.Columns.Add("idCertificado");
                data1.Load(reader);


                comboBox4.DisplayMember = "idCertificado";
                comboBox4.ValueMember = "idCertificado";
                comboBox4.DataSource = data1;
                conex.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataSet data = new DataSet();
            SqlCommand update = new SqlCommand("Update dbo.certificados SET numCertificado=@numCertificado,clinica=@clinica,nombreMedico=@nombreMedico,numMatricula=@numMatricula,diagnostico=@diagnostico,legajo=@legajo,idTipolicencia=@idTipolicencia,fechaDesde=@fechaDesde,fechaHasta=@fechaHasta WHERE idCertificado=@idCertificado", conex);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.UpdateCommand = update;
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@numCertificado", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@clinica", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@nombreMedico", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@numMatricula", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@diagnostico", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@legajo", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idTipolicencia", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@fechaDesde", SqlDbType.DateTime));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@fechaHasta", SqlDbType.DateTime));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idCertificado", SqlDbType.Int));


            try
            {
                conex.Open();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un Nº de Certificado", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Ingrese la institucion", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Ingrese el Medico", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Ingrese el N° de Matricula", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else //Nota: editar todo los parametros ya que el codigo es de otro requerimiento.-
                {
                    DialogResult resultado = MessageBox.Show("Esta seguro de realizar la actualizacion de los datos¿? ", "INFORMACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.OK)
                    {
                        adaptador.UpdateCommand.Parameters["@numCertificado"].Value = textBox1.Text;
                        adaptador.UpdateCommand.Parameters["@clinica"].Value = textBox2.Text;
                        adaptador.UpdateCommand.Parameters["@nombreMedico"].Value = textBox3.Text;
                        adaptador.UpdateCommand.Parameters["@numMatricula"].Value = textBox4.Text;
                        adaptador.UpdateCommand.Parameters["@diagnostico"].Value = textBox5.Text;
                        adaptador.UpdateCommand.Parameters["@legajo"].Value = comboBox5.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@idTipolicencia"].Value = comboBox2.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@fechaDesde"].Value = dateTimePicker1.Text;
                        adaptador.UpdateCommand.Parameters["@fechaHasta"].Value = dateTimePicker2.Text;
                        adaptador.UpdateCommand.Parameters["@idCertificado"].Value = Convert.ToInt16(comboBox4.SelectedValue);

                        if (Convert.ToInt16(adaptador.UpdateCommand.ExecuteNonQuery()) >= 1)
                        {
                            MessageBox.Show("Las actualizacion se realizaron correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dateTimePicker1.Value = DateTime.Now;
                            dateTimePicker2.Value = DateTime.Now;

                            // se limpian los campos
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            comboBox2.SelectedIndex = 0;
                            comboBox5.SelectedIndex = 0;
                            dateTimePicker1.Value = DateTime.Now;
                            dateTimePicker2.Value = DateTime.Now;

                            //Se Desabilitan los campos
                            comboBox2.Enabled = false;
                            comboBox5.Enabled = false;
                            textBox1.Enabled = false;
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            textBox5.Enabled = false;
                            dateTimePicker1.Enabled = false;
                            dateTimePicker2.Enabled = false;
                            button1.Enabled = false;
                           


                        }
                        else
                        {
                            MessageBox.Show("La actualizacion fue rechazada, consulte con el administrador! ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Se encontro una excepcion no controlada, consulte con el administrador!", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 3 || comboBox2.SelectedIndex == 0)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox3.Text = "";
                textBox4.Enabled = true;
                textBox4.Text = "";
                textBox5.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox5.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                button1.Enabled = true;

            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox3.Text = "No requerido";
                textBox4.Enabled = false;
                textBox4.Text = "0000";
                textBox5.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox5.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                button1.Enabled = true;

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            SqlCommand delete = new SqlCommand("DELETE FROM  dbo.certificados  WHERE idCertificado=@idCertificado", conex);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.DeleteCommand = delete;
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@idCertificado", SqlDbType.Int));

            try
            {
                conex.Open();
                DialogResult resultado = MessageBox.Show("Esta seguro que desea eliminar los datos? ", "INFORMACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.OK)
                {
                    adaptador.DeleteCommand.Parameters["@idCertificado"].Value = Convert.ToInt16(comboBox4.SelectedValue);

                    if (Convert.ToInt16(adaptador.DeleteCommand.ExecuteNonQuery()) >= 1)
                    {
                        MessageBox.Show("Los datos se eliminaron correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker2.Value = DateTime.Now;

                        // se limpian los campos
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        comboBox2.SelectedIndex = 0;
                        comboBox5.SelectedIndex = 0;
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker2.Value = DateTime.Now;
                        //Se Desabilitan los campos
                        comboBox2.Enabled = false;
                        comboBox5.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox5.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        button1.Enabled = false;
                        this.certificadosTableAdapter.Fill(this.legajo_Certificado.certificados);




                    }
                    else
                    {
                        MessageBox.Show("La eliminacion de datos fue rechazada, consulte con el administrador! ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Se encontro una excepcion no controlada, consulte con el administrador!", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea cancelar los datos ingresados", "ADVERTENCIA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                // se limpian los campos
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                            
                //Se Desabilitan los campos
                comboBox2.Enabled = false;
                comboBox5.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                button1.Enabled = false;
                
            }
        }

  
    }
}
