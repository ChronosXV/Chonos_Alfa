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
    public partial class _1_ABM : Form
    {
        public _1_ABM()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        
        private void _1_ABM_Load_1(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet66.tipoTelefonos' Puede moverla o quitarla según sea necesario.
            this.tipoTelefonosTableAdapter.Fill(this.chronosDataSet66.tipoTelefonos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet65.tipoDocumentos' Puede moverla o quitarla según sea necesario.
            this.tipoDocumentosTableAdapter.Fill(this.chronosDataSet65.tipoDocumentos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet64.convenios' Puede moverla o quitarla según sea necesario.
            this.conveniosTableAdapter.Fill(this.chronosDataSet64.convenios);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet63.puestos' Puede moverla o quitarla según sea necesario.
            this.puestosTableAdapter.Fill(this.chronosDataSet63.puestos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet62.departamentos' Puede moverla o quitarla según sea necesario.
            this.departamentosTableAdapter.Fill(this.chronosDataSet62.departamentos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet61.areas' Puede moverla o quitarla según sea necesario.
            this.areasTableAdapter.Fill(this.chronosDataSet61.areas);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet60.empresas' Puede moverla o quitarla según sea necesario.
            this.empresasTableAdapter.Fill(this.chronosDataSet60.empresas);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet59.pais' Puede moverla o quitarla según sea necesario.
            this.paisTableAdapter.Fill(this.chronosDataSet59.pais);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet58.provincias' Puede moverla o quitarla según sea necesario.
            this.provinciasTableAdapter.Fill(this.chronosDataSet58.provincias);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet57.localidades' Puede moverla o quitarla según sea necesario.
            this.localidadesTableAdapter.Fill(this.chronosDataSet57.localidades);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet56.barrios' Puede moverla o quitarla según sea necesario.
            this.barriosTableAdapter.Fill(this.chronosDataSet56.barrios);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet.provincia' Puede moverla o quitarla según sea necesario.

            conex = Procedimientos.Conexion();
            dateTimePicker1.Value = DateTime.Now;
            
        }

        private void _1_ABM_Resize(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbmPrincipal p = new AbmPrincipal();
            p.Show();
            this.Hide();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand insertar = new SqlCommand("Insert into chronos.dbo.empleados (legajoBejerman,nombre,apellido,idTipoDocumento,numDocumento,idTelefono,calle,numeroCalle,idBarrio,emailPersonal,emailLaboral,fechaIngreso,foto,idLocalidad,idPais,idArea,idDepartamento,idEmpresa,idPuesto,idConvenio,idProvincia,telefono) values (@legajoBejerman,@nombre,@apellido,@idTipoDocumento,@numDocumento,@idTelefono,@calle,@numeroCalle,@idBarrio,@emailPersonal,@emailLaboral,@fechaIngreso,@foto,@idLocalidad,@idPais,@idArea,@idDepartamento,@idEmpresa,@idPuesto,@idConvenio,@idProvincia,@telefono)",conex);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.InsertCommand = insertar;
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@legajoBejerman", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idTipoDocumento", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@numDocumento", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idTelefono", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@numeroCalle", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idBarrio", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@emailPersonal", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@emailLaboral", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@fechaIngreso", SqlDbType.DateTime));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@foto", SqlDbType.Image));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idLocalidad", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idPais", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idArea", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idPuesto", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idConvenio", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idProvincia", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar));

            try
            {
                conex.Open();
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el apellido del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el nombre del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox3.Text.Trim() == "")
                {
                    
                    MessageBox.Show("Ingrese el DNI del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
              
                else if(textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el E-mail personal del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(textBox5.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese la calle del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(textBox6.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese la n° de la calle del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                    else if(textBox10.Text.Trim() == "")
                {
                        MessageBox.Show("Ingrese la n° de telefono del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox8.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el legajo del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox9.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Email laboral del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                        
                    adaptador.InsertCommand.Parameters["@legajoBejerman"].Value = Convert.ToInt32(textBox8.Text);
                    adaptador.InsertCommand.Parameters["@nombre"].Value = textBox2.Text;
                    adaptador.InsertCommand.Parameters["@apellido"].Value = textBox1.Text;

                     
                    adaptador.InsertCommand.Parameters["@idTipoDocumento"].Value = comboBox10.SelectedValue;
                    if (Procedimientos.compararDNI(Convert.ToInt32(comboBox10.SelectedValue),textBox3.Text.Trim()) == 0)
                    {
                        MessageBox.Show("La cantidad de digitos ingresados no coinciden con el tipo de Documento seleccionado.\n Nota: DNI,DU 8 digitos y LC,LE 7 digitos.-", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning); 

                    }
                    else
                    {
                        adaptador.InsertCommand.Parameters["@numDocumento"].Value = Convert.ToInt32(textBox3.Text);
                    }
                    
                    adaptador.InsertCommand.Parameters["@idTelefono"].Value = comboBox11.SelectedValue;
                    adaptador.InsertCommand.Parameters["@calle"].Value = textBox5.Text;
                    adaptador.InsertCommand.Parameters["@numeroCalle"].Value = Convert.ToInt64(textBox6.Text);
                    adaptador.InsertCommand.Parameters["@idBarrio"].Value = comboBox2.SelectedValue;

                    if (Procedimientos.buscarCaracter(textBox4.Text) == 0)
                    {
                        MessageBox.Show("Debe ingresar un E-mail personal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        adaptador.InsertCommand.Parameters["@emailPersonal"].Value = textBox4.Text;
                    }


                    if (Procedimientos.buscarCaracter(textBox9.Text) == 0)
                    {
                        MessageBox.Show("Debe ingresar un E-mail laboral", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        adaptador.InsertCommand.Parameters["@emailLaboral"].Value = textBox9.Text;
                    }


                    adaptador.InsertCommand.Parameters["@fechaIngreso"].Value = dateTimePicker1.Text;
                    Procedimientos.Redimencion(pictureBox1.Image, 161, 131);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                 
                    System.IO.MemoryStream imag = new System.IO.MemoryStream();
                    pictureBox1.Image.Save(imag,System.Drawing.Imaging.ImageFormat.Jpeg);
                    Procedimientos.Redimencion(pictureBox1.Image, 161, 131);
                    adaptador.InsertCommand.Parameters["@foto"].Value = imag.GetBuffer();
                    

                    adaptador.InsertCommand.Parameters["@idLocalidad"].Value = comboBox1.SelectedValue;
                    adaptador.InsertCommand.Parameters["@idPais"].Value=comboBox4.SelectedValue;
                    adaptador.InsertCommand.Parameters["@idArea"].Value=comboBox6.SelectedValue;
                    adaptador.InsertCommand.Parameters["@idDepartamento"].Value=comboBox7.SelectedValue;
                    adaptador.InsertCommand.Parameters["@idEmpresa"].Value=comboBox5.SelectedValue;
                    adaptador.InsertCommand.Parameters["@idPuesto"].Value=comboBox8.SelectedValue;
                    adaptador.InsertCommand.Parameters["@idConvenio"].Value=comboBox9.SelectedValue;
                    adaptador.InsertCommand.Parameters["@idProvincia"].Value=comboBox3.SelectedValue;


                    if (Procedimientos.compararTelefono(Convert.ToInt16(comboBox11.SelectedValue), textBox10.Text.Trim()) == 0)
                    {
                        MessageBox.Show("Los N° ingresado  no coinciden con los digitos del Telefono seleccionado.\n Nota: Celulares 10 digitos, Fijos 11.-", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        adaptador.InsertCommand.Parameters["@telefono"].Value = textBox10.Text;
                    }

                    

                    if (adaptador.InsertCommand.ExecuteNonQuery()> 0)
                        {
                            MessageBox.Show("El empleado se ha registrado correctamente:", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "ejemplo@mail.com";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox10.Text = "";
                            textBox8.Text = "";
                            textBox9.Text= "ejemplo@mail.com";
                            comboBox1.SelectedIndex  = 0;
                            comboBox10.SelectedIndex = 0;
                            comboBox11.SelectedIndex = 0;
                            comboBox2.SelectedIndex  = 0;
                            comboBox3.SelectedIndex  = 0;
                            comboBox4.SelectedIndex  = 0;
                            comboBox5.SelectedIndex  = 0;
                            comboBox6.SelectedIndex  = 0;
                            comboBox7.SelectedIndex  = 0;
                            comboBox8.SelectedIndex  = 0;
                            comboBox9.SelectedIndex  = 0;
                            dateTimePicker1.Value = DateTime.Now;
                            pictureBox1.Image = MenuInicio.Properties.Resources.miniAvatar1;
                        
                        }
                        else 
                        {
                            MessageBox.Show("El empleado NO se ha  registrado, verifica la informacion ingresada o llame a su administrador", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                }
            }
            catch(SqlException ex)
            {
                 MessageBox.Show("Error al registrar el empleado" , " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                catch(OverflowException es)
            {
                MessageBox.Show("El numero ingresado no esta dentro de los parametros de Telefonos establecidos: "+es.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           finally
            {
                conex.Close();
            }

        }
        private void _1_ABM_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand select = new SqlCommand("select legajo,legajoBejerman,nombre,apellido,idTipoDocumento,numDocumento,idTelefono,calle,numeroCalle,idBarrio,emailPersonal,emailLaboral,fechaIngreso,fechaEgreso,resumenEntrevista,foto from chronos.dbo.empleados where numDocumento=@DNI", conex);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet data;
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@DNI", SqlDbType.Int));
           

            try
            {
                if (textBox3.Text =="")
                {
                    MessageBox.Show("Ingrese el DNI del empleado por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conex.Open();
                    adaptador.SelectCommand.Parameters["@DNI"].Value = textBox3.Text;
                    if (Convert.ToInt32 (adaptador.SelectCommand.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("El empleado no existe","INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //textBox3.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("El DNI ingresado ya se encuentra registrado", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //Data = new DataSet();
                        //adaptador.Fill(data, "empleados");
                        //DataRow fila = data.Tables["empleados"].Rows[0];
                        //textBox1.Text= fila.ItemArray[3].ToString();
                        //textBox2.Text = fila.ItemArray[2].ToString();
                        //comboBox10.SelectedValue = fila.ItemArray[4].ToString();
                        //textBox4.Text = fila.ItemArray[10].ToString();
                        // pictureBox1.Image = fila.ItemArray[15].ToString();
                        // comboBox2.SelectedValue = fila.ItemArray[9].ToString();
                        //textBox5.Text = fila.ItemArray[7].ToString();
                        // textBox6.Text = fila.ItemArray[8].ToString();
                        // comboBox1.SelectedValue = fila.ItemArray[16].ToString();
                        // comboBox3.SelectedValue = fila.ItemArray[23].ToString();
                        // comboBox4.SelectedValue = fila.ItemArray[17].ToString();
                        // dateTimePicker1.Value = Convert.ToDateTime(fila.ItemArray[12].ToString());
                        // comboBox5.SelectedValue = fila.ItemArray[20].ToString();
                        // comboBox6.SelectedValue = fila.ItemArray[18].ToString();
                        //comboBox7.SelectedValue = fila.ItemArray[19].ToString();
                        //comboBox8.SelectedValue = fila.ItemArray[21].ToString();
                        //comboBox9.SelectedValue = fila.ItemArray[22].ToString();

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al consultar el empleado:" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                catch (IndexOutOfRangeException es)
            {
                MessageBox.Show("El DNI ingresado ya se encuentra registrado "  /*es.Message*/, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conex.Close();
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }
        
        private void wqer(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Archivos JPG(*.jpg)|*.jpg";
            abrir.InitialDirectory = "C:/";
            if(abrir.ShowDialog()==DialogResult.OK)
            {
                String dire = abrir.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Bitmap foto = new Bitmap(dire);
                pictureBox1.Image = (Image)foto;
                


            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

        private void textBox10_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

  

       

       
    }
}
