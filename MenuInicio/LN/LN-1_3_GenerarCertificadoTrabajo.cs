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
    public partial class ABM_3_GenerarCertificadoTrabajo : Form
    {
        public ABM_3_GenerarCertificadoTrabajo()
        {
            InitializeComponent();
            button1.Enabled = false;
        }
        SqlConnection conex;
        private void ABM_3_GenerarCertificadoTrabajo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet_Sueldos.sueldos' Puede moverla o quitarla según sea necesario.
            this.sueldosTableAdapter.Fill(this.chronosDataSet_Sueldos.sueldos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet82.puestos' Puede moverla o quitarla según sea necesario.
            this.puestosTableAdapter1.Fill(this.chronosDataSet82.puestos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet80.puestos' Puede moverla o quitarla según sea necesario.
            this.puestosTableAdapter.Fill(this.chronosDataSet80.puestos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet79.tipoDocumentos' Puede moverla o quitarla según sea necesario.
            this.tipoDocumentosTableAdapter.Fill(this.chronosDataSet79.tipoDocumentos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet78.tipoLicencias' Puede moverla o quitarla según sea necesario.
            this.tipoLicenciasTableAdapter.Fill(this.chronosDataSet78.tipoLicencias);
            conex = Procedimientos.Conexion();
            dateTimePicker1.Value = DateTime.Now;
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
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese el legajo del empleado por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    //comboBox2.Text = "Seleccionar";
                    textBox5.Text = "";
                    //comboBox3.Text = "Seleccionar";
                   
                }
                else
                {
                   
                    conex.Open();
                    adaptador.SelectCommand.Parameters["@legajoBeje"].Value = textBox1.Text;
                    if (Convert.ToInt32(adaptador.SelectCommand.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("El legajo ingresado no existe, verifique la informacion ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";

                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        //comboBox2.Text = "Seleccionar";
                        textBox5.Text = "";
                        //comboBox3.Text = "Seleccionar";
                       

                    }
                    else
                    {
                        button1.Enabled = true;

                        data = new DataSet();
                        adaptador.Fill(data, "empleados");
                        DataRow fila = data.Tables["empleados"].Rows[0];
                        textBox2.Text = "Marcelo Navarro";
                        textBox3.Text = "24675487";
                        textBox4.Text=fila.ItemArray[2].ToString()+','+" "+fila.ItemArray[3].ToString();
                        comboBox2.SelectedValue = fila.ItemArray[4].ToString();
                        textBox5.Text = fila.ItemArray[5].ToString();
                        comboBox3.SelectedValue = fila.ItemArray[21].ToString();
                        dateTimePicker2.Value = Convert.ToDateTime(fila.ItemArray[12].ToString());
                        comboBox1.SelectedValue= fila.ItemArray[0].ToString();
                        //textBox6.Text = comboBox1.Text.ToString();

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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImprimirCertifi_ABM_03_01 p = new ImprimirCertifi_ABM_03_01(textBox2.Text, textBox3.Text, textBox4.Text, comboBox2.Text, textBox5.Text,comboBox3.Text, dateTimePicker2.Text, comboBox1.Text/*textBox6.Text*/, dateTimePicker1.Text);
            p.Show();
        }

        private void ABM_3_GenerarCertificadoTrabajo_FormClosed(object sender, FormClosedEventArgs e)
        {
            AbmPrincipal q = new AbmPrincipal();
            q.Show();
            this.Hide();
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void puestosBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

      
    }
}
