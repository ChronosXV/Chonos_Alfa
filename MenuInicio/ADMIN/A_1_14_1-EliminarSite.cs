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
    public partial class A_1_14_1_EliminarSite : Form
    {
        public A_1_14_1_EliminarSite()
        {
            InitializeComponent();
        }
        SqlConnection conex;

        private void A_1_14_1_EliminarSite_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet38.pais' Puede moverla o quitarla según sea necesario.
            this.paisTableAdapter.Fill(this.chronosDataSet38.pais);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet36.areas' Puede moverla o quitarla según sea necesario.
            this.areasTableAdapter.Fill(this.chronosDataSet36.areas);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet35.departamentos' Puede moverla o quitarla según sea necesario.
            this.departamentosTableAdapter.Fill(this.chronosDataSet35.departamentos);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet34.provincias' Puede moverla o quitarla según sea necesario.
            this.provinciasTableAdapter.Fill(this.chronosDataSet34.provincias);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet33.localidades' Puede moverla o quitarla según sea necesario.
            this.localidadesTableAdapter.Fill(this.chronosDataSet33.localidades);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet32.barrios' Puede moverla o quitarla según sea necesario.
            this.barriosTableAdapter.Fill(this.chronosDataSet32.barrios);
            conex = Procedimientos.Conexion();
        }

        private void Consultar_Click(object sender, EventArgs e)
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
                    if (Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar())< 1)
                    {
                        MessageBox.Show("El site no existe, verifique la informacion ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";

                    }
                    else 
                    {
                        DataSet data = new DataSet();
                        adaptador.Fill(data, "sites");
                        DataRow fila;
                        fila = data.Tables["sites"].Rows[0];

                        if (fila.ItemArray[9].ToString() == "Deshabilitado")
                        {
                            MessageBox.Show("Se ha encontrado al Site y su estado es Deshabilitado", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            textBox6.Text = fila.ItemArray[1].ToString();
                            comboBox5.SelectedValue = fila.ItemArray[5].ToString();
                            comboBox4.SelectedValue = fila.ItemArray[7].ToString();
                            textBox4.Text = fila.ItemArray[2].ToString();
                            comboBox1.SelectedValue = fila.ItemArray[3].ToString();
                            textBox5.Text = fila.ItemArray[3].ToString();
                            comboBox2.SelectedValue = fila.ItemArray[3].ToString();
                            comboBox6.SelectedValue = fila.ItemArray[6].ToString();
                            comboBox3.SelectedValue = fila.ItemArray[11].ToString();

                        }
                        else 
                        {
                            MessageBox.Show("Se ha encontrado al Site y su estado es Habilitado", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            textBox6.Text = fila.ItemArray[1].ToString();
                            comboBox5.SelectedValue = fila.ItemArray[5].ToString();
                            comboBox4.SelectedValue = fila.ItemArray[7].ToString();
                            textBox4.Text = fila.ItemArray[2].ToString();
                            comboBox1.SelectedValue = fila.ItemArray[3].ToString();
                            textBox5.Text = fila.ItemArray[3].ToString();
                            comboBox2.SelectedValue = fila.ItemArray[3].ToString();
                            comboBox6.SelectedValue = fila.ItemArray[6].ToString();
                            comboBox3.SelectedValue = fila.ItemArray[11].ToString();

                        }


                        
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

        private void Registrar_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet  data=new DataSet();
            SqlCommand select=new SqlCommand("Select * from chronos.dbo.site WHERE nombre=@nombre",conex);
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
            
            
            
            SqlCommand update = new SqlCommand("update chrone.dbo.site (estado set @estado) where idSite=@idSite ",conex);
            adaptador.UpdateCommand = update;
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idSite", SqlDbType.VarChar));


            try
            {
                conex.Open();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese un Site, por favor", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox1.Text != "")
                {
                    adaptador.SelectCommand.Parameters["@nombre"].Value = textBox1.Text;

                    if (Convert.ToInt32( adaptador.SelectCommand.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("El Site no existe, ingrese un nuevo Site y consulte", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                    }
                    else if(label3.Text=="")
                    {
                        MessageBox.Show("Consulte si el Site existe", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        adaptador.Fill(data, "site");
                        DataRow fila1 = data.Tables["site"].Rows[0];
                        string estado = fila1.ItemArray[9].ToString();

                        if (estado == "Habilitar" && radioButton2.Checked)
                        {
                            MessageBox.Show("El Site ya se encuentra habilitado", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (estado == "Habilitar" && radioButton1.Checked)
                        {
                            DialogResult resultado = MessageBox.Show("El usuario se encuentra habilitado, desea Deshabilitarlo ", "INFORMACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            if (resultado == DialogResult.OK)
                            {
                                string D = "Deshabilitado";
                                adaptador.UpdateCommand.Parameters["@estado"].Value = D;
                                adaptador.UpdateCommand.Parameters["@idsite"].Value = label3.Text;
                                adaptador.UpdateCommand.ExecuteNonQuery();
                                MessageBox.Show("El Usuario a quedado Deshabilitado", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBox1.Text = "";
                            }
                            else
                                MessageBox.Show("Se ha cancelado la Deshabilitacion del usuario", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (estado == "Deshabilitado" && radioButton1.Checked)
                        {

                            MessageBox.Show("El Site ya se encuentra Deshabilitado ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else if (estado == "Deshabilitado" && radioButton2.Checked)
                        {
                            DialogResult resultado = MessageBox.Show("El site se encuentra Deshabilitado, desea Habilitarlo ", "INFORMACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            if (resultado == DialogResult.OK)
                            {
                                string A = "Activo";
                                adaptador.UpdateCommand.Parameters["@estado"].Value = A;
                                adaptador.UpdateCommand.Parameters["@idsite"].Value = label3.Text;
                                adaptador.UpdateCommand.ExecuteNonQuery();
                                textBox1.Text = "";
                                MessageBox.Show("El Usuario a quedado Habilitado", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Se ha cancelado la habilitacion del usuario", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (radioButton3.Checked)
                        {
                            DialogResult resultado = MessageBox.Show("El site se encuentra Deshabilitado, desea Habilitarlo ", "INFORMACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            if (resultado == DialogResult.OK)
                            {
                                SqlCommand delete = new SqlCommand("Delete from chronos.dbo.site where idsite=@idsite", conex);
                                adaptador.DeleteCommand = delete;
                                adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@idSite", SqlDbType.VarChar));

                                adaptador.DeleteCommand.Parameters["@idsite"].Value = label3.Text;

                                if (adaptador.DeleteCommand.ExecuteNonQuery() >= 1)
                                {
                                    MessageBox.Show("Se ha Eliminado el site", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else

                                    MessageBox.Show("Se ha No se pudo Eliminar el site", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                    }
                }
            }


            catch (SqlException ex)
            {
                MessageBox.Show("Error al Cambiar el estado: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
        }

    }
}
