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
    public partial class A_1_14_2_ActualizarSite : Form
    {
        public A_1_14_2_ActualizarSite()
        {
            InitializeComponent();
        }
        SqlConnection conex;

        private void A_1_14_2_ActualizarSite_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet92.site' Puede moverla o quitarla según sea necesario.
            this.siteTableAdapter.Fill(this.chronosDataSet92.site);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet91.empresas' Puede moverla o quitarla según sea necesario.
            this.empresasTableAdapter.Fill(this.chronosDataSet91.empresas);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet54.pais' Puede moverla o quitarla según sea necesario.
            this.paisTableAdapter.Fill(this.chronosDataSet54.pais);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet53.provincias' Puede moverla o quitarla según sea necesario.
            this.provinciasTableAdapter.Fill(this.chronosDataSet53.provincias);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet52.localidades' Puede moverla o quitarla según sea necesario.
            this.localidadesTableAdapter.Fill(this.chronosDataSet52.localidades);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet51.barrios' Puede moverla o quitarla según sea necesario.
            this.barriosTableAdapter.Fill(this.chronosDataSet51.barrios);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet50.areas' Puede moverla o quitarla según sea necesario.
            this.areasTableAdapter.Fill(this.chronosDataSet50.areas);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet49.departamentos' Puede moverla o quitarla según sea necesario.
            this.departamentosTableAdapter.Fill(this.chronosDataSet49.departamentos);


            conex = Procedimientos.Conexion();
        }

        private void Consultar_Click(object sender, EventArgs e)
        {

            SqlDataAdapter adaptador = new SqlDataAdapter();
            SqlCommand select = new SqlCommand("select * from chronos.dbo.site where idSite=@idSite ", conex);
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@idSite", SqlDbType.Int));


            try
            {

                conex.Open();
                adaptador.SelectCommand.Parameters["@idSite"].Value = comboBox8.SelectedValue;
                DataSet data = new DataSet();
                adaptador.Fill(data, "site");
                DataRow fila;
                fila = data.Tables["site"].Rows[0];
                if (Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar()) >= 1)
                {
                    label3.Text = fila.ItemArray[0].ToString();
                    textBox6.Text = fila.ItemArray[1].ToString();
                    textBox4.Text = fila.ItemArray[2].ToString();
                    textBox5.Text = fila.ItemArray[3].ToString();
                    comboBox1.SelectedValue = fila.ItemArray[4].ToString();
                    comboBox5.SelectedValue = fila.ItemArray[5].ToString();
                    comboBox6.SelectedValue = fila.ItemArray[6].ToString();
                    comboBox4.SelectedValue = fila.ItemArray[7].ToString();
                    textBox1.Text = fila.ItemArray[8].ToString();
                    comboBox2.SelectedValue = fila.ItemArray[10].ToString();
                    comboBox3.SelectedValue = fila.ItemArray[11].ToString();
                    comboBox7.SelectedValue = fila.ItemArray[12].ToString();

                }
                else
                {
                    MessageBox.Show("El site no existe, verifique la informacion ingresada ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el site: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
        }
        private void Actualizar_Click(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            SqlCommand update = new SqlCommand("update Chronos.dbo.site  set descripcion=@descri,calle=@calle,numeroCalle=@nunCalle,idBarrio=@barrio,idDepartamento=@depart,idProvincia=@provi,idArea=@area,nombre=@nomi,idLocalidad=@loc,idPais=@pais,IdEmpresa=@IdEmpresa where idSite=@site", conex);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.UpdateCommand = update;
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@descri", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@nunCalle", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@barrio", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@depart", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@provi", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@area", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@nomi", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@loc", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@pais", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@IdEmpresa", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@site", SqlDbType.Int));


            try
            {
                conex.Open();
                if (label3.Text == "")
                {
                    MessageBox.Show("Seleccione/Consulte un Site. ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    DialogResult resultado = MessageBox.Show("Esta seguro de realizar la actualizacion de los datos¿? ", "INFORMACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.OK)
                    {
                        adaptador.UpdateCommand.Parameters["@descri"].Value = textBox6.Text;
                        adaptador.UpdateCommand.Parameters["@calle"].Value = textBox4.Text;
                        adaptador.UpdateCommand.Parameters["@nunCalle"].Value = textBox5.Text;
                        adaptador.UpdateCommand.Parameters["@barrio"].Value = comboBox1.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@depart"].Value = comboBox5.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@provi"].Value = comboBox6.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@area"].Value = comboBox4.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@nomi"].Value = textBox1.Text;
                        adaptador.UpdateCommand.Parameters["@loc"].Value = comboBox2.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@pais"].Value = comboBox3.SelectedValue;
                        adaptador.UpdateCommand.Parameters["@site"].Value = Convert.ToInt32(label3.Text);
                        adaptador.UpdateCommand.Parameters["@IdEmpresa"].Value = comboBox7.SelectedValue;

                        if (Convert.ToInt16(adaptador.UpdateCommand.ExecuteScalar()) != 1)
                        {
                            MessageBox.Show("El cambio quedo realizado.", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.siteTableAdapter.Fill(this.chronosDataSet92.site);

                            label3.Text = "";
                            textBox6.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            comboBox1.SelectedIndex = 0;
                            comboBox5.SelectedIndex = 0;
                            comboBox6.SelectedIndex = 0;
                            comboBox4.SelectedIndex = 0;
                            textBox1.Text = "";
                            comboBox2.SelectedIndex = 0;
                            comboBox3.SelectedIndex = 0;
                            comboBox7.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("El cambio no pudo realizarse, contacte con el administrador.", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }




                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actulizar los datos: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Procedimientos.SoloLetras(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }
    }
}