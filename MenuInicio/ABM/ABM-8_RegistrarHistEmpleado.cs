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
    public partial class ABM_8_RegistrarHistEmpleado : Form
    {
        public ABM_8_RegistrarHistEmpleado()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        private void ABM_8_RegistrarHistEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'movimientoEmpleados_DataSet.movimientoEmpleados' Puede moverla o quitarla según sea necesario.
            this.movimientoEmpleadosTableAdapter.Fill(this.movimientoEmpleados_DataSet.movimientoEmpleados);
            // TODO: esta línea de código carga datos en la tabla 'jornada_DataSet.jornadas' Puede moverla o quitarla según sea necesario.
            this.jornadasTableAdapter.Fill(this.jornada_DataSet.jornadas);
            // TODO: esta línea de código carga datos en la tabla 'celula_DataSet.celulas' Puede moverla o quitarla según sea necesario.
            this.celulasTableAdapter.Fill(this.celula_DataSet.celulas);
            // TODO: esta línea de código carga datos en la tabla 'usuario_DataSet.usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.usuario_DataSet.usuarios);
            // TODO: esta línea de código carga datos en la tabla 'estado_DataSet.estados' Puede moverla o quitarla según sea necesario.
            this.estadosTableAdapter.Fill(this.estado_DataSet.estados);
            // TODO: esta línea de código carga datos en la tabla 'convenio_DataSet.convenios' Puede moverla o quitarla según sea necesario.
            this.conveniosTableAdapter.Fill(this.convenio_DataSet.convenios);
            // TODO: esta línea de código carga datos en la tabla 'site_DataSet.site' Puede moverla o quitarla según sea necesario.
            this.siteTableAdapter.Fill(this.site_DataSet.site);
            // TODO: esta línea de código carga datos en la tabla 'empresa_DataSet.empresas' Puede moverla o quitarla según sea necesario.
            this.empresasTableAdapter.Fill(this.empresa_DataSet.empresas);
            // TODO: esta línea de código carga datos en la tabla 'empleados_DataSet.empleados' Puede moverla o quitarla según sea necesario.
            this.empleadosTableAdapter2.Fill(this.empleados_DataSet.empleados);
            // TODO: esta línea de código carga datos en la tabla 'puesto_DataSet1.puestos' Puede moverla o quitarla según sea necesario.
            this.puestosTableAdapter1.Fill(this.puesto_DataSet1.puestos);


            // TODO: esta línea de código carga datos en la tabla 'dS_TablaEmpleado1.empleados' Puede moverla o quitarla según sea necesario.
            this.empleadosTableAdapter1.Fill(this.dS_TablaEmpleado1.empleados);
            // TODO: esta línea de código carga datos en la tabla 'dS_TablaEmpleado1.empleados' Puede moverla o quitarla según sea necesario.
            this.empleadosTableAdapter1.Fill(this.dS_TablaEmpleado1.empleados);
            // TODO: esta línea de código carga datos en la tabla 'dS_TablaEmpleado1.empleados' Puede moverla o quitarla según sea necesario.
            this.empleadosTableAdapter1.Fill(this.dS_TablaEmpleado1.empleados);
            conex = Procedimientos.Conexion();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
                     
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand select = new SqlCommand("SELECT A.idMovimientoEmpleado,A.legajo,idPuesto,idDepartamento,idArea,idSite,idCelula,idJornada,idConvenio,horarioEntrada,horarioSalida,idUsuario,idEstado,motivoBaja,fechaDesde,fechaHasta FROM movimientoEmpleados AS A INNER JOIN ( SELECT legajo,MAX(idMovimientoEmpleado) AS idMovimientoEmpleado FROM movimientoEmpleados WHERE idEstado NOT IN (2,-1) AND legajo = @legajo GROUP BY legajo) AS B ON A.legajo=B.legajo AND A.idMovimientoEmpleado=B.idMovimientoEmpleado", conex);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet data;
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@legajo", SqlDbType.Int));


            try
            {
                conex.Open();
                adaptador.SelectCommand.Parameters["@legajo"].Value = comboBox1.SelectedValue;
                
                data = new DataSet();
                adaptador.Fill(data, "MovimientoEmpleado");
                DataRow fila = data.Tables["MovimientoEmpleado"].Rows[0];
                
                comboBox3.SelectedValue = fila.ItemArray[2].ToString(); //Puesto
                comboBox2.SelectedValue = fila.ItemArray[8].ToString(); //Convenio
                comboBox8.SelectedValue = fila.ItemArray[5].ToString(); //Site
                comboBox6.SelectedValue = fila.ItemArray[7].ToString(); //Jornada
                comboBox5.SelectedValue = fila.ItemArray[12].ToString(); //Estado
                comboBox7.SelectedValue = fila.ItemArray[11].ToString(); //Usuario
                comboBox9.SelectedValue = fila.ItemArray[6].ToString(); //Celula
                dateTimePicker1.Text = fila.ItemArray[14].ToString(); //Fecha desde
                dateTimePicker2.Text = fila.ItemArray[15].ToString(); //Fecha hasta
                textBox1.Text = fila.ItemArray[13].ToString(); 

                //Se setean los horarios cuando del sistema vengan valores nulls
                if (fila.ItemArray[9].ToString() == "")//Hora Entrada
                {
                    dateTimePicker3.Text = "00:00:00";
                }
                else
                {
                    dateTimePicker3.Text = fila.ItemArray[9].ToString();
                }
                if (fila.ItemArray[10].ToString() == "")//Hora Salida
                {
                    dateTimePicker4.Text = "00:00:00";
                }
                else
                {
                    dateTimePicker4.Text = fila.ItemArray[10].ToString();
                }



                //Ver para Actualizacion
                //if (fila.ItemArray[15].ToString() == "")
                //{
                //    MessageBox.Show("ERROR");
                //    dateTimePicker2.Text = DateTime.Now.AddDays(5).ToString(); //
                //}



                comboBox3.Enabled = true;
                comboBox2.Enabled = true;
                comboBox8.Enabled = true;
                comboBox6.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
                dateTimePicker4.Enabled = true;
                textBox1.Enabled = true;
                button1.Enabled = true;
                


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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //Boton de Actualizar
        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show(dateTimePicker3.Text);
            //try
            //{
            //    DialogResult result = MessageBox.Show("Estas seguro de realizar la Actualizacion de datos", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    if (result == DialogResult.OK)
            //    {
            //        conex.Open();
            //        SqlCommand update = new SqlCommand("UPDATE Chronos.dbo.empleados SET legajoBejerman = @legajoBejerman,nombre = @nombre,apellido = @apellido,idTipoDocumento = @idTipoDocumento,numDocumento = @numDocumento,idTelefono = @idTelefono,calle = @calle,numeroCalle = @numeroCalle,idBarrio = @idBarrio,emailPersonal = @emailPersonal,emailLaboral = @emailLaboral,fechaIngreso = @fechaIngreso,foto = @foto,idLocalidad = @idLocalidad,idPais = @idPais,idArea = @idArea,idDepartamento = @idDepartamento,idEmpresa = @idEmpresa,idPuesto = @idPuesto,idConvenio = @idConvenio,idProvincia = @idProvincia,telefono = @telefono WHERE legajo=@legajo", conex);
            //        SqlDataAdapter adaptador = new SqlDataAdapter();
            //        adaptador.UpdateCommand = update;
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@legajoBejerman", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idTipoDocumento", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@numDocumento", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idTelefono", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@numeroCalle", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idBarrio", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@emailPersonal", SqlDbType.VarChar));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@emailLaboral", SqlDbType.VarChar));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@fechaIngreso", SqlDbType.DateTime));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@foto", SqlDbType.Image));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idLocalidad", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idPais", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idArea", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idPuesto", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idConvenio", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idProvincia", SqlDbType.Int));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar));
            //        adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@legajo", SqlDbType.Int));


            //        if (textBox10.Text.Trim() == "")
            //        {
            //            MessageBox.Show("Ingrese el apellido del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else if (textBox2.Text.Trim() == "")
            //        {
            //            MessageBox.Show("Ingrese el nombre del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else if (textBox3.Text.Trim() == "")
            //        {
            //            MessageBox.Show("Ingrese el DNI del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else if (textBox4.Text.Trim() == "")
            //        {
            //            MessageBox.Show("Ingrese el E-mail personal del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else if (textBox5.Text.Trim() == "")
            //        {
            //            MessageBox.Show("Ingrese la calle del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else if (textBox6.Text.Trim() == "")
            //        {
            //            MessageBox.Show("Ingrese la n° de la calle del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else if (textBox7.Text.Trim() == "")
            //        {
            //            MessageBox.Show("Ingrese la n° de telefono del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else if (textBox8.Text.Trim() == "")
            //        {
            //            MessageBox.Show("Ingrese el legajo del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else if (textBox9.Text.Trim() == "")
            //        {
            //            MessageBox.Show("Ingrese el Email laboral del empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else
            //        {
            //            adaptador.UpdateCommand.Parameters["@legajoBejerman"].Value = Convert.ToInt32(textBox8.Text);
            //            adaptador.UpdateCommand.Parameters["@nombre"].Value = textBox2.Text;
            //            adaptador.UpdateCommand.Parameters["@apellido"].Value = textBox10.Text;
            //            adaptador.UpdateCommand.Parameters["@idTipoDocumento"].Value = comboBox10.SelectedValue;

            //            if (Procedimientos.compararDNI(Convert.ToInt32(comboBox10.SelectedValue), textBox3.Text.Trim()) == 0)
            //            {
            //                MessageBox.Show("La cantidad de digitos ingresados no coinciden con el tipo de documento seleccionado.\n Nota: DNI,DU 8 digitos y LC,LE 7 digitos.-", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //            }
            //            else
            //            {
            //                adaptador.UpdateCommand.Parameters["@numDocumento"].Value = Convert.ToInt32(textBox3.Text);
            //            }
            //            adaptador.UpdateCommand.Parameters["@idTelefono"].Value = comboBox11.SelectedValue;
            //            adaptador.UpdateCommand.Parameters["@calle"].Value = textBox5.Text;
            //            adaptador.UpdateCommand.Parameters["@numeroCalle"].Value = Convert.ToInt64(textBox6.Text);
            //            adaptador.UpdateCommand.Parameters["@idBarrio"].Value = comboBox2.SelectedValue;
            //            if (Procedimientos.buscarCaracter(textBox4.Text) == 0)
            //            {
            //                MessageBox.Show("Debe ingresar un E-mail personal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //            }
            //            else
            //            {
            //                adaptador.UpdateCommand.Parameters["@emailPersonal"].Value = textBox4.Text;
            //            }

            //            if (Procedimientos.buscarCaracter(textBox4.Text) == 0)
            //            {
            //                MessageBox.Show("Debe ingresar un E-mail Laborar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //            }
            //            else
            //            {
            //                adaptador.UpdateCommand.Parameters["@emailLaboral"].Value = textBox9.Text;
            //            }

            //            adaptador.UpdateCommand.Parameters["@fechaIngreso"].Value = dateTimePicker1.Text;

            //            Procedimientos.Redimencion(pictureBox1.Image, 161, 131);
            //            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //            System.IO.MemoryStream imag = new System.IO.MemoryStream();
            //            pictureBox1.Image.Save(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            //            adaptador.UpdateCommand.Parameters["@foto"].Value = imag.GetBuffer();
            //            adaptador.UpdateCommand.Parameters["@idLocalidad"].Value = comboBox1.SelectedValue;
            //            adaptador.UpdateCommand.Parameters["@idPais"].Value = comboBox4.SelectedValue;
            //            adaptador.UpdateCommand.Parameters["@idArea"].Value = comboBox6.SelectedValue;
            //            adaptador.UpdateCommand.Parameters["@idDepartamento"].Value = comboBox7.SelectedValue;
            //            adaptador.UpdateCommand.Parameters["@idEmpresa"].Value = comboBox5.SelectedValue;
            //            adaptador.UpdateCommand.Parameters["@idPuesto"].Value = comboBox8.SelectedValue;
            //            adaptador.UpdateCommand.Parameters["@idConvenio"].Value = comboBox9.SelectedValue;
            //            adaptador.UpdateCommand.Parameters["@idProvincia"].Value = comboBox3.SelectedValue;

            //            if (Procedimientos.compararTelefono(Convert.ToInt32(comboBox11.SelectedValue), textBox7.Text.Trim()) == 0)
            //            {
            //                MessageBox.Show("Los N° ingresado  no coinciden con los digitos del Telefono seleccionado.\n Nota: Celulares 10 digitos, Fijos 11.- ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //            }
            //            else
            //            {
            //                adaptador.UpdateCommand.Parameters["@telefono"].Value = Convert.ToInt64(textBox7.Text);
            //            }

            //            if (Procedimientos.buscarCaracter(textBox4.Text) == 0)
            //            {
            //                MessageBox.Show("Debe ingresar el E-mail personal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //            }
            //            else
            //            {
            //                adaptador.UpdateCommand.Parameters["@emailPersonal"].Value = textBox4.Text;
            //            }

            //            if (Procedimientos.buscarCaracter(textBox4.Text) == 0)
            //            {
            //                MessageBox.Show("Debe ingresar el E-mail personal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //            }
            //            else
            //            {
            //                adaptador.UpdateCommand.Parameters["@emailLaboral"].Value = textBox9.Text;
            //            }

            //            adaptador.UpdateCommand.Parameters["@legajo"].Value = Convert.ToInt32(label26.Text);


            //            if (adaptador.UpdateCommand.ExecuteNonQuery() > 0)
            //            {
            //                MessageBox.Show("Sean actualizado los datos correctamente: ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                label26.Text = "";
            //                textBox1.Text = "";
            //                textBox10.Text = "";
            //                textBox2.Text = "";
            //                textBox3.Text = "";
            //                textBox4.Text = "exemplo@mail.com";
            //                textBox5.Text = "";
            //                textBox6.Text = "";
            //                textBox7.Text = "";
            //                textBox8.Text = "";
            //                textBox9.Text = "exemplo@mail.com";
            //                comboBox1.SelectedIndex = 0;
            //                comboBox10.SelectedIndex = 0;
            //                comboBox11.SelectedIndex = 0;
            //                comboBox2.SelectedIndex = 0;
            //                comboBox3.SelectedIndex = 0;
            //                comboBox4.SelectedIndex = 0;
            //                comboBox5.SelectedIndex = 0;
            //                comboBox6.SelectedIndex = 0;
            //                comboBox7.SelectedIndex = 0;
            //                comboBox8.SelectedIndex = 0;
            //                comboBox9.SelectedIndex = 0;
            //                dateTimePicker1.Value = DateTime.Now;
            //                pictureBox1.Image = MenuInicio.Properties.Resources.miniAvatar1;

            //                textBox10.Enabled = false;
            //                textBox2.Enabled = false;
            //                textBox3.Enabled = false;
            //                textBox4.Enabled = false;
            //                textBox5.Enabled = false;
            //                textBox6.Enabled = false;
            //                textBox7.Enabled = false;
            //                textBox8.Enabled = false;
            //                textBox9.Enabled = false;
            //                comboBox1.Enabled = false;
            //                comboBox10.Enabled = false;
            //                comboBox11.Enabled = false;
            //                comboBox2.Enabled = false;
            //                comboBox3.Enabled = false;
            //                comboBox4.Enabled = false;
            //                comboBox5.Enabled = false;
            //                comboBox6.Enabled = false;
            //                comboBox7.Enabled = false;
            //                comboBox8.Enabled = false;
            //                comboBox9.Enabled = false;
            //                dateTimePicker1.Enabled = false;
            //                pictureBox1.Enabled = false;
            //                button6.Enabled = false;
            //                button4.Enabled = false;
            //            }
            //        }
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show("No se logro actualizar la informacion " + ex.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //finally
            //{
            //    conex.Close();
            //}
        }





        // ABRIMOS LA IMAGEN DEL EMPLEADO
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog abrir = new OpenFileDialog();
        //    abrir.Filter = "Archivos JPG(*.jpg)|*.jpg";
        //    abrir.InitialDirectory = "C:/";
        //    if(abrir.ShowDialog()==DialogResult.OK)
        //    {
        //        String dire = abrir.FileName;
        //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //        Bitmap foto = new Bitmap(dire);
        //        pictureBox1.Image = (Image)foto;



        //    }
        //}



    }
}
