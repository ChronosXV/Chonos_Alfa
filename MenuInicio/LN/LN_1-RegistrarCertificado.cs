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
    public partial class LN_1_RegistrarCertificado : Form
    {
        public LN_1_RegistrarCertificado()
        {
            InitializeComponent();
        }
         
        SqlConnection conex;
        


        private void LN_1_RegistrarCertificado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet84.tipoLicencias' Puede moverla o quitarla según sea necesario.
            this.tipoLicenciasTableAdapter2.Fill(this.chronosDataSet84.tipoLicencias);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet83.tipoLicencias' Puede moverla o quitarla según sea necesario.
            this.tipoLicenciasTableAdapter1.Fill(this.chronosDataSet83.tipoLicencias);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet81.empleados' Puede moverla o quitarla según sea necesario.

            this.empleadosTableAdapter.Fill(this.chronosDataSet81.empleados);
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            conex = Procedimientos.Conexion();
            //label10.Text = "0";
            //comboBox2.Text = "Seleccione un Certificado...";
            //comboBox1.Text = "N° de Legajo...";
        }
        //esta sentencia me parece mas a la consulta que al registrar, hacer de nuevo el insert
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand select = new SqlCommand("select Distinct numCertificado from chronos.dbo.certificados where numCertificado=@numCerti", conex);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet data;
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@numCerti", SqlDbType.Int));


            try
            {
                conex.Open();
                adaptador.SelectCommand.Parameters["@numCerti"].Value = textBox1.Text;
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el N° de certificado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToInt32(adaptador.SelectCommand.ExecuteScalar()) != 0)
                {
                        MessageBox.Show("El certificado ya existe, verifique la informacion ingresa", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = 0;
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker2.Value = DateTime.Now;


                    
                    

                }
                else if (textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el hospital o institucion que lo atendio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox3.Text.Trim() == "" && (comboBox2.SelectedIndex==0 || comboBox2.SelectedIndex == 3))
                {
                    MessageBox.Show("Ingrese el nombre del medico que lo atendio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox4.Text.Trim() == "" && (comboBox2.SelectedIndex == 0 || comboBox2.SelectedIndex == 3))
                {
                    MessageBox.Show("Ingrese el N° de matricula del medico", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
                else if (textBox5.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el diagnostico reseteado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else 
                {

                    SqlCommand insertar = new SqlCommand("Insert into chronos.dbo.certificados (numCertificado,clinica,nombreMedico,numMatricula,diagnostico,legajo,idTipoLicencia,fechaDesde,fechaHasta) values (@numCertificado,@clinica,@nombreMedico,@numMatricula,@diagnostico,@legajo,@idTipoLicencia,@fechaDesde,@fechaHasta)", conex);//DATEDIFF( hh,@fechaDesde,@fechaHasta)
                    SqlDataAdapter adaptador1 = new SqlDataAdapter();
                    adaptador1.InsertCommand = insertar;
                    adaptador1.InsertCommand.Parameters.Add(new SqlParameter("@numCertificado", SqlDbType.Int));
                    adaptador1.InsertCommand.Parameters.Add(new SqlParameter("@clinica", SqlDbType.VarChar));
                    adaptador1.InsertCommand.Parameters.Add(new SqlParameter("@nombreMedico", SqlDbType.VarChar));
                    adaptador1.InsertCommand.Parameters.Add(new SqlParameter("@numMatricula", SqlDbType.Int));
                    adaptador1.InsertCommand.Parameters.Add(new SqlParameter("@diagnostico", SqlDbType.VarChar));
                    adaptador1.InsertCommand.Parameters.Add(new SqlParameter("@legajo", SqlDbType.Int));
                    adaptador1.InsertCommand.Parameters.Add(new SqlParameter("@idTipoLicencia",SqlDbType.Int));
                    adaptador1.InsertCommand.Parameters.Add(new SqlParameter("@fechaDesde", SqlDbType.DateTime));
                    adaptador1.InsertCommand.Parameters.Add(new SqlParameter("@fechaHasta", SqlDbType.DateTime));
                    //adaptador1.InsertCommand.Parameters.Add(new SqlParameter("@horasReposo", SqlDbType.Int));

                    try 
                    {
                        adaptador1.InsertCommand.Parameters["@numCertificado"].Value = Convert.ToInt32(textBox1.Text);
                        adaptador1.InsertCommand.Parameters["@clinica"].Value = textBox2.Text;
                        adaptador1.InsertCommand.Parameters["@nombreMedico"].Value = textBox3.Text;
                        adaptador1.InsertCommand.Parameters["@numMatricula"].Value = Convert.ToInt32(textBox4.Text);
                        adaptador1.InsertCommand.Parameters["@diagnostico"].Value = textBox5.Text;
                        adaptador1.InsertCommand.Parameters["@legajo"].Value = Convert.ToInt32(comboBox1.SelectedValue);
                        adaptador1.InsertCommand.Parameters["@idTipoLicencia"].Value = Convert.ToInt32(comboBox2.SelectedValue);
                        adaptador1.InsertCommand.Parameters["@fechaDesde"].Value = dateTimePicker2.Text;
                        adaptador1.InsertCommand.Parameters["@fechaHasta"].Value = dateTimePicker1.Text;

                        //string a = "DATEDIFF( hh,@fechaDesde,@fechaHasta)";
                        ////"DATEDIFF( hh,@fechaDesde,@fechaHasta)"
                        ////ver si anda posible erro
                        //adaptador1.InsertCommand.Parameters["@horasReposo"].Value =Convert.ToInt16( a) ;


                        if(adaptador1.InsertCommand.ExecuteNonQuery()>0)
                        {
                            MessageBox.Show("El empleado se ha registrado correctamente:", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            comboBox1.SelectedIndex = 0;
                            comboBox2.SelectedIndex= 0;
                            dateTimePicker1.Value = DateTime.Now;
                            dateTimePicker2.Value = DateTime.Now;
                            
                            //Se desabilitan los controles
                            textBox1.Enabled = false;
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;
                            textBox3.Text = "No requerido";
                            textBox4.Enabled = false;
                            textBox4.Text = "0000";
                            textBox5.Enabled = false;
                            comboBox1.Enabled = false;
                            dateTimePicker1.Enabled = false;
                            dateTimePicker2.Enabled = false;
                            button1.Enabled = false;
                            button2.Enabled = false;

                        }
                    }
                    catch( Exception er)
                    {
                        MessageBox.Show("Error al registrar el certificado: " + er.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el Certificado" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }

        
        }
        
          private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

        private void LN_1_RegistrarCertificado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("Seguro que desea cancelar los datos ingresados", "ADVERTENCIA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result==DialogResult.OK)
            {

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                
                //Se desabilitan los controles
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox3.Text = "No requerido";
                textBox4.Enabled = false;
                textBox4.Text = "0000";
                textBox5.Enabled = false;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;

            }
        }

        private void ABM_3_GenerarCertificadoTrabajo_FormClosed(object sender, FormClosingEventArgs e)
        {
            AbmPrincipal p = new AbmPrincipal();
            p.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
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
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }
    }
}
