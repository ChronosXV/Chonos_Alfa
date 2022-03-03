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
                
                comboBox3.SelectedValue = fila.ItemArray[2].ToString();
                comboBox2.SelectedValue = fila.ItemArray[8].ToString();
                comboBox8.SelectedValue = fila.ItemArray[5].ToString();
                comboBox6.SelectedValue = fila.ItemArray[7].ToString();
                comboBox5.SelectedValue = fila.ItemArray[12].ToString();
                comboBox7.SelectedValue = fila.ItemArray[11].ToString();
                comboBox9.SelectedValue = fila.ItemArray[8].ToString();
                dateTimePicker1.Text = fila.ItemArray[14].ToString();
                dateTimePicker2.Text = fila.ItemArray[15].ToString();
                //textBox2.Text = fila.ItemArray[2].ToString();
                //comboBox11.SelectedValue = fila.ItemArray[6];

                //textBox7.Text = fila.ItemArray[24].ToString();
                //comboBox10.SelectedValue = fila.ItemArray[4];
                //textBox3.Text = fila.ItemArray[5].ToString();
                //textBox4.Text = fila.ItemArray[10].ToString();
                //comboBox2.SelectedValue = fila.ItemArray[9];
                //textBox5.Text = fila.ItemArray[7].ToString();
                //textBox6.Text = fila.ItemArray[8].ToString();
                //comboBox1.SelectedValue = fila.ItemArray[16];
                //comboBox3.SelectedValue = fila.ItemArray[23];
                //comboBox4.SelectedValue = fila.ItemArray[17];
                //textBox8.Text = fila.ItemArray[1].ToString();
                
                //comboBox5.SelectedValue = fila.ItemArray[20];
                //comboBox6.SelectedValue = fila.ItemArray[18];
                //textBox9.Text = fila.ItemArray[11].ToString();
                //comboBox7.SelectedValue = fila.ItemArray[19];
                //comboBox8.SelectedValue = fila.ItemArray[21];
                //comboBox9.SelectedValue = fila.ItemArray[22];

                //textBox10.Enabled = true;
                //textBox2.Enabled = true;
                //textBox3.Enabled = true;
                //textBox4.Enabled = true;
                //textBox5.Enabled = true;
                //textBox6.Enabled = true;
                //textBox7.Enabled = true;
                //textBox8.Enabled = true;
                //textBox9.Enabled = true;
                //comboBox1.Enabled = true;
                //comboBox10.Enabled = true;
                //comboBox11.Enabled = true;
                //comboBox2.Enabled = true;
                //comboBox3.Enabled = true;
                //comboBox4.Enabled = true;
                //comboBox5.Enabled = true;
                //comboBox6.Enabled = true;
                //comboBox7.Enabled = true;
                //comboBox8.Enabled = true;
                //comboBox9.Enabled = true;
                //dateTimePicker1.Enabled = true;
                //pictureBox1.Enabled = true;
                //button6.Enabled = true;
                //button4.Enabled = true;


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
