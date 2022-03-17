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
        int legajoEmpleado = 0;
        int idMovimientoEmpleado = 0;
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
                idMovimientoEmpleado = Convert.ToInt32(fila.ItemArray[0]);
                legajoEmpleado = Convert.ToInt32(fila.ItemArray[1]);
                
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
                comboBox9.Enabled = true;
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
            try
            {
                DialogResult result = MessageBox.Show("Estas seguro de realizar la Actualizacion de datos", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    if (legajoEmpleado != Convert.ToInt32(comboBox1.SelectedValue))
                    {
                        MessageBox.Show("El legajo seleccionado es incorrecto, vuelva a consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    conex.Open();
                    SqlCommand update = new SqlCommand("UPDATE Chronos.dbo.movimientoEmpleados SET idPuesto = @idPuesto ,idDepartamento = @idDepartamento,idArea = @idArea,idSite = @idSite,idCelula = @idCelula,idJornada = @idJornada,idConvenio = @idConvenio,horarioEntrada = @horarioEntrada,horarioSalida = @horarioSalida,idEstado = @idEstado,motivoBaja = @motivoBaja,fechaHasta = @fechaHasta WHERE idMovimientoEmpleado = @idMovimientoEmpleado", conex);
                    SqlDataAdapter adaptador = new SqlDataAdapter();
                    adaptador.UpdateCommand = update;
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idMovimientoEmpleado", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idPuesto", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idArea", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idSite", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idCelula", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idJornada", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idConvenio", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@horarioEntrada", SqlDbType.VarChar));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@horarioSalida", SqlDbType.VarChar));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idEstado", SqlDbType.Int));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@motivoBaja", SqlDbType.VarChar));
                    adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@fechaHasta", SqlDbType.DateTime));

                    adaptador.UpdateCommand.Parameters["@idMovimientoEmpleado"].Value = idMovimientoEmpleado;
                    adaptador.UpdateCommand.Parameters["@idPuesto"].Value = comboBox3.SelectedValue;
                    adaptador.UpdateCommand.Parameters["@idDepartamento"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@idArea"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@idSite"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@idCelula"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@idJornada"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@idConvenio"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@horarioEntrada"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@horarioSalida"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@idEstado"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@motivoBaja"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@fechaHasta"].Value = textBox1.Text;




                    if (Convert.ToInt16(adaptador.UpdateCommand.ExecuteNonQuery()) >= 1)
                    {
                        MessageBox.Show("Las actualizaciones se realizaron correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // se limpian los campos

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
    }
}


