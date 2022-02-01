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
    public partial class A_1_14_RegistrarSite : Form
    {
        public A_1_14_RegistrarSite()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        private void A_1_14_RegistrarSite_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet90.empresas' Puede moverla o quitarla según sea necesario.
            this.empresasTableAdapter.Fill(this.chronosDataSet90.empresas);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet37.provincias' Puede moverla o quitarla según sea necesario.
            this.provinciasTableAdapter.Fill(this.chronosDataSet37.provincias);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet31.departamentos' Puede moverla o quitarla según sea necesario.
            this.departamentosTableAdapter.Fill(this.chronosDataSet31.departamentos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet30.areas' Puede moverla o quitarla según sea necesario.
            this.areasTableAdapter.Fill(this.chronosDataSet30.areas);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet29.barrios' Puede moverla o quitarla según sea necesario.
            this.barriosTableAdapter.Fill(this.chronosDataSet29.barrios);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet28.pais' Puede moverla o quitarla según sea necesario.
            this.paisTableAdapter.Fill(this.chronosDataSet28.pais);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet27.localidades' Puede moverla o quitarla según sea necesario.
            this.localidadesTableAdapter.Fill(this.chronosDataSet27.localidades);

            conex = Procedimientos.Conexion();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            //SqlCommand select = new SqlCommand("select * from chronos.dba.site where nombre=@nombre ",conex);
            //adaptador.SelectCommand = select;
            //adaptador.SelectCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));

            SqlCommand insert = new SqlCommand("INSERT INTO chronos.dbo.site (descripcion,calle,numeroCalle,idBarrio,idDepartamento,idProvincia,idArea,nombre,estado,idLocalidad,IdEmpresa,IdPais) values (@descripcion,@calle,@numeroCalle,@idBarrio,@idDepartamento,@idProvincia,@idArea,@nombre,@estado,@idLocalidad,@IdEmpresa,@IdPais)", conex);
            adaptador.InsertCommand = insert;
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@calle", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@numeroCalle", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idBarrio", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idProvincia", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idArea", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idLocalidad", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@IdEmpresa", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@IdPais", SqlDbType.Int));
            

            try 
            {
                conex.Open();
                if (label3.Text !="1"|| label3.Text=="")
                {
                    MessageBox.Show("Consulte si existe el site", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    adaptador.InsertCommand.Parameters["@descripcion"].Value = textBox6.Text;
                    adaptador.InsertCommand.Parameters["@calle"].Value = textBox4.Text;
                    adaptador.InsertCommand.Parameters["@numeroCalle"].Value = Convert.ToInt32(textBox5.Text);
                    adaptador.InsertCommand.Parameters["@idBarrio"].Value = comboBox1.SelectedValue;
                    adaptador.InsertCommand.Parameters["@idDepartamento"].Value = comboBox5.SelectedValue;
                    adaptador.InsertCommand.Parameters["@idProvincia"].Value = comboBox6.SelectedValue;
                    adaptador.InsertCommand.Parameters["@idArea"].Value = comboBox4.SelectedValue;
                    adaptador.InsertCommand.Parameters["@nombre"].Value = textBox1.Text;
                    adaptador.InsertCommand.Parameters["@estado"].Value = "Habilitar";
                    adaptador.InsertCommand.Parameters["@idLocalidad"].Value = comboBox2.SelectedValue;
                    adaptador.InsertCommand.Parameters["@IdEmpresa"].Value = comboBox7.SelectedValue;
                    adaptador.InsertCommand.Parameters["@IdPais"].Value = comboBox3.SelectedValue; ;

                    if (adaptador.InsertCommand.ExecuteNonQuery() >= 1)
                    {
                        MessageBox.Show("Se ha registrado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        textBox6.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox1.Clear();
                        comboBox1.SelectedIndex = 0;
                        comboBox5.SelectedIndex = 0;
                        comboBox2.SelectedIndex = 0;
                        comboBox3.SelectedIndex = 0;
                        comboBox4.SelectedIndex = 0;
                        comboBox6.SelectedIndex = 0;
                        comboBox7.SelectedIndex = 0;

                    }
                    else
                    {
                        MessageBox.Show(" No se ha registrado la informacion ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR al registar los datos: "+ex.Message,"INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            finally
            {
                conex.Close();
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            SqlCommand select = new SqlCommand("select * from chronos.dbo.site where nombre=@nombre ", conex);
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));

            int p = 0;
            try
            {
                conex.Open();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un nombre", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    p = 1;
                    label3.Text = Convert.ToString(p);

                    adaptador.SelectCommand.Parameters["@nombre"].Value = textBox1.Text;
                    if (Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar()) >= 1)
                    {
                        MessageBox.Show("Ya existe un site con ese nombre, verifique la informacion ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        MessageBox.Show("El site no existe, puede registrarlo ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al ingresar el site: "+ ex.Message,"ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }

       

     
    }
}
