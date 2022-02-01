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
    public partial class ConsultarEmpleado : Form
    {
        public ConsultarEmpleado()
        {
            InitializeComponent();

            textBox10.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            comboBox1.Enabled = false;
            comboBox10.Enabled = false;
            comboBox11.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;
            comboBox8.Enabled = false;
            comboBox9.Enabled = false;
            dateTimePicker1.Enabled = false;
            pictureBox1.Enabled = false;
            button6.Enabled = false;
            button4.Enabled = false;
        }
        SqlConnection conex;
       
        private void ConsultarEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet77.convenios' Puede moverla o quitarla según sea necesario.
            this.conveniosTableAdapter.Fill(this.chronosDataSet77.convenios);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet76.areas' Puede moverla o quitarla según sea necesario.
            this.areasTableAdapter.Fill(this.chronosDataSet76.areas);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet75.puestos' Puede moverla o quitarla según sea necesario.
            this.puestosTableAdapter.Fill(this.chronosDataSet75.puestos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet74.empresas' Puede moverla o quitarla según sea necesario.
            this.empresasTableAdapter.Fill(this.chronosDataSet74.empresas);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet73.departamentos' Puede moverla o quitarla según sea necesario.
            this.departamentosTableAdapter.Fill(this.chronosDataSet73.departamentos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet72.provincias' Puede moverla o quitarla según sea necesario.
            this.provinciasTableAdapter.Fill(this.chronosDataSet72.provincias);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet71.pais' Puede moverla o quitarla según sea necesario.
            this.paisTableAdapter.Fill(this.chronosDataSet71.pais);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet70.localidades' Puede moverla o quitarla según sea necesario.
            this.localidadesTableAdapter.Fill(this.chronosDataSet70.localidades);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet69.tipoDocumentos' Puede moverla o quitarla según sea necesario.
            this.tipoDocumentosTableAdapter.Fill(this.chronosDataSet69.tipoDocumentos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet68.tipoTelefonos' Puede moverla o quitarla según sea necesario.
            this.tipoTelefonosTableAdapter.Fill(this.chronosDataSet68.tipoTelefonos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet67.barrios' Puede moverla o quitarla según sea necesario.
            this.barriosTableAdapter.Fill(this.chronosDataSet67.barrios);
            conex = Procedimientos.Conexion();
            dateTimePicker1.Value = DateTime.Now;
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            AbmPrincipal p = new AbmPrincipal();
            p.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand select = new SqlCommand("select * from chronos.dbo.empleados where legajoBejerman=@legajoBeje", conex);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet data;
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@legajoBeje", SqlDbType.Int));


            try
            {
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el legajo del empleado por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                   

                    conex.Open();
                    adaptador.SelectCommand.Parameters["@legajoBeje"].Value = textBox1.Text;
                    if (Convert.ToInt32(adaptador.SelectCommand.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("El legajo ingresado no existe, verifique la informacion ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";

                    }
                    else
                    {
                        textBox10.Enabled = true;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        textBox5.Enabled = true;
                        textBox6.Enabled = true;
                        textBox7.Enabled = true;
                        textBox8.Enabled = true;
                        textBox9.Enabled = true;
                        comboBox1.Enabled = true;
                        comboBox10.Enabled = true;
                        comboBox11.Enabled = true;
                        comboBox2.Enabled = true;
                        comboBox3.Enabled = true;
                        comboBox4.Enabled = true;
                        comboBox5.Enabled = true;
                        comboBox6.Enabled = true;
                        comboBox7.Enabled = true;
                        comboBox8.Enabled = true;
                        comboBox9.Enabled = true;
                        dateTimePicker1.Enabled = true;
                        pictureBox1.Enabled = true;
                        button6.Enabled = true;
                        button4.Enabled = true;

                        data = new DataSet();
                        adaptador.Fill(data, "empleados");
                        DataRow fila = data.Tables["empleados"].Rows[0];
                        byte[] imagen = new byte[0];
                        imagen = (byte[])fila["foto"];
                        System.IO.MemoryStream img = new System.IO.MemoryStream(imagen);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = System.Drawing.Bitmap.FromStream(img);
                        

                        label26.Text = fila.ItemArray[0].ToString();
                        textBox10.Text=fila.ItemArray[3].ToString();
                        textBox2.Text = fila.ItemArray[2].ToString();
                        comboBox11.SelectedValue=fila.ItemArray[6];
                        
                        textBox7.Text=fila.ItemArray[24].ToString();
                        comboBox10.SelectedValue = fila.ItemArray[4];
                        textBox3.Text=fila.ItemArray[5].ToString();
                        textBox4.Text = fila.ItemArray[10].ToString();
                        comboBox2.SelectedValue = fila.ItemArray[9];
                        textBox5.Text=fila.ItemArray[7].ToString();
                        textBox6.Text = fila.ItemArray[8].ToString();
                        comboBox1.SelectedValue = fila.ItemArray[16];
                        comboBox3.SelectedValue = fila.ItemArray[23];
                        comboBox4.SelectedValue = fila.ItemArray[17];
                        textBox8.Text = fila.ItemArray[1].ToString();
                        dateTimePicker1.Text = fila.ItemArray[12].ToString();
                        comboBox5.SelectedValue = fila.ItemArray[20];
                        comboBox6.SelectedValue = fila.ItemArray[18];
                        textBox9.Text = fila.ItemArray[11].ToString();
                        comboBox7.SelectedValue = fila.ItemArray[19];
                        comboBox8.SelectedValue = fila.ItemArray[21];
                        comboBox9.SelectedValue = fila.ItemArray[22];
                    }
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

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Archivos JPG(*.jpg)|*.jpg";
            abrir.InitialDirectory = "C:/";
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                String dire = abrir.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Bitmap foto = new Bitmap(dire);
                pictureBox1.Image = (Image)foto;



            }
        }
        //me falta terminar, estoy probando con SP directamente en SQL
        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult result = MessageBox.Show("Estas seguro de realizar la Actualizacion de datos", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    conex.Open();
                    SqlCommand update = new SqlCommand("UPDATE Chronos.dbo.empleados SET legajoBejerman = @legajoBejerman,nombre = @nombre,apellido = @apellido,idTipoDocumento = @idTipoDocumento,numDocumento = @numDocumento,idTelefono = @idTelefono,calle = @calle,numeroCalle = @numeroCalle,idBarrio = @idBarrio,emailPersonal = @emailPersonal,emailLaboral = @emailLaboral,fechaIngreso = @fechaIngreso,foto = @foto,idLocalidad = @idLocalidad,idPais = @idPais,idArea = @idArea,idDepartamento = @idDepartamento,idEmpresa = @idEmpresa,idPuesto = @idPuesto,idConvenio = @idConvenio,idProvincia = @idProvincia,telefono = @telefono WHERE legajo=@legajo", conex);
                    SqlDataAdapter adaptador = new SqlDataAdapter();
                    adaptador.UpdateCommand = update;
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@legajoBejerman", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idTipoDocumento", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@numDocumento", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idTelefono", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@numeroCalle", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idBarrio", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@emailPersonal", SqlDbType.VarChar));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@emailLaboral", SqlDbType.VarChar));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@fechaIngreso", SqlDbType.DateTime));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@foto", SqlDbType.Image));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idLocalidad", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idPais", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idArea", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idPuesto", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idConvenio", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idProvincia", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@legajo", SqlDbType.Int));


                    if (textBox10.Text.Trim() == "")
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
                    else if (textBox4.Text.Trim() == "")
                    {
                        MessageBox.Show("Ingrese el E-mail personal del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (textBox5.Text.Trim() == "")
                    {
                        MessageBox.Show("Ingrese la calle del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (textBox6.Text.Trim() == "")
                    {
                        MessageBox.Show("Ingrese la n° de la calle del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (textBox7.Text.Trim() == "")
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
                        adaptador.UpdateCommand.Parameters["@legajoBejerman"].Value = Convert.ToInt32(textBox8.Text);
                        adaptador.UpdateCommand.Parameters["@nombre"].Value = textBox2.Text;
                        adaptador.UpdateCommand.Parameters["@apellido"].Value = textBox10.Text;
                        adaptador.UpdateCommand.Parameters["@idTipoDocumento"].Value = comboBox10.SelectedValue;

                        if (Procedimientos.compararDNI(Convert.ToInt32(comboBox10.SelectedValue), textBox3.Text.Trim()) == 0)
                        {
                            MessageBox.Show("La cantidad de digitos ingresados no coinciden con el tipo de documento seleccionado.\n Nota: DNI,DU 8 digitos y LC,LE 7 digitos.-", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            adaptador.UpdateCommand.Parameters["@numDocumento"].Value = Convert.ToInt32(textBox3.Text);
                        }
                        adaptador.UpdateCommand.Parameters["@idTelefono"].Value = comboBox11.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@calle"].Value = textBox5.Text;
                        adaptador.UpdateCommand.Parameters["@numeroCalle"].Value = Convert.ToInt64(textBox6.Text);
                        adaptador.UpdateCommand.Parameters["@idBarrio"].Value = comboBox2.SelectedValue;
                        if (Procedimientos.buscarCaracter(textBox4.Text) == 0)
                        {
                            MessageBox.Show("Debe ingresar un E-mail personal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            adaptador.UpdateCommand.Parameters["@emailPersonal"].Value = textBox4.Text;
                        }

                        if (Procedimientos.buscarCaracter(textBox4.Text) == 0)
                        {
                            MessageBox.Show("Debe ingresar un E-mail Laborar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            adaptador.UpdateCommand.Parameters["@emailLaboral"].Value = textBox9.Text;
                        }

                        adaptador.UpdateCommand.Parameters["@fechaIngreso"].Value = dateTimePicker1.Text;

                        Procedimientos.Redimencion(pictureBox1.Image, 161, 131);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        System.IO.MemoryStream imag = new System.IO.MemoryStream();
                        pictureBox1.Image.Save(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
                        adaptador.UpdateCommand.Parameters["@foto"].Value = imag.GetBuffer();
                        adaptador.UpdateCommand.Parameters["@idLocalidad"].Value = comboBox1.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@idPais"].Value = comboBox4.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@idArea"].Value = comboBox6.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@idDepartamento"].Value = comboBox7.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@idEmpresa"].Value = comboBox5.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@idPuesto"].Value = comboBox8.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@idConvenio"].Value = comboBox9.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@idProvincia"].Value = comboBox3.SelectedValue;

                        if (Procedimientos.compararTelefono(Convert.ToInt32(comboBox11.SelectedValue), textBox7.Text.Trim()) == 0)
                        {
                            MessageBox.Show("Los N° ingresado  no coinciden con los digitos del Telefono seleccionado.\n Nota: Celulares 10 digitos, Fijos 11.- ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            adaptador.UpdateCommand.Parameters["@telefono"].Value = Convert.ToInt64(textBox7.Text);
                        }

                        if (Procedimientos.buscarCaracter(textBox4.Text) == 0)
                        {
                            MessageBox.Show("Debe ingresar el E-mail personal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            adaptador.UpdateCommand.Parameters["@emailPersonal"].Value = textBox4.Text;
                        }

                        if (Procedimientos.buscarCaracter(textBox4.Text) == 0)
                        {
                            MessageBox.Show("Debe ingresar el E-mail personal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            adaptador.UpdateCommand.Parameters["@emailLaboral"].Value = textBox9.Text;
                        }

                        adaptador.UpdateCommand.Parameters["@legajo"].Value = Convert.ToInt32(label26.Text);


                        if (adaptador.UpdateCommand.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Sean actualizado los datos correctamente: ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            label26.Text = "";
                            textBox1.Text = "";
                            textBox10.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "exemplo@mail.com";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox9.Text = "exemplo@mail.com";
                            comboBox1.SelectedIndex = 0;
                            comboBox10.SelectedIndex = 0;
                            comboBox11.SelectedIndex = 0;
                            comboBox2.SelectedIndex = 0;
                            comboBox3.SelectedIndex = 0;
                            comboBox4.SelectedIndex = 0;
                            comboBox5.SelectedIndex = 0;
                            comboBox6.SelectedIndex = 0;
                            comboBox7.SelectedIndex = 0;
                            comboBox8.SelectedIndex = 0;
                            comboBox9.SelectedIndex = 0;
                            dateTimePicker1.Value = DateTime.Now;
                            pictureBox1.Image = MenuInicio.Properties.Resources.miniAvatar1;

                            textBox10.Enabled = false;
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            textBox5.Enabled = false;
                            textBox6.Enabled = false;
                            textBox7.Enabled = false;
                            textBox8.Enabled = false;
                            textBox9.Enabled = false;
                            comboBox1.Enabled = false;
                            comboBox10.Enabled = false;
                            comboBox11.Enabled = false;
                            comboBox2.Enabled = false;
                            comboBox3.Enabled = false;
                            comboBox4.Enabled = false;
                            comboBox5.Enabled = false;
                            comboBox6.Enabled = false;
                            comboBox7.Enabled = false;
                            comboBox8.Enabled = false;
                            comboBox9.Enabled = false;
                            dateTimePicker1.Enabled = false;
                            pictureBox1.Enabled = false;
                            button6.Enabled = false;
                            button4.Enabled = false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se logro actualizar la informacion " + ex.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conex.Close();
            }

}

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            CapturarFormulario();

            
        }


        private void CapturarFormulario()
        {

            Size s = this.Size;

            Bitmap bmp = new Bitmap(s.Width, s.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics imagen = Graphics.FromImage(bmp);
            imagen.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s, CopyPixelOperation.SourceCopy);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }















    }
}
