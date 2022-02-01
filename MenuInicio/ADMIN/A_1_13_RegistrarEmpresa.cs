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
    public partial class A_1_13_RegistrarEmpresa : Form
    {
        public A_1_13_RegistrarEmpresa()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        private void A_1_13_RegistrarEmpresa_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet26.pais' Puede moverla o quitarla según sea necesario.
            this.paisTableAdapter.Fill(this.chronosDataSet26.pais);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet25.localidades' Puede moverla o quitarla según sea necesario.
            this.localidadesTableAdapter.Fill(this.chronosDataSet25.localidades);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet17.barrios' Puede moverla o quitarla según sea necesario.
            this.barriosTableAdapter.Fill(this.chronosDataSet17.barrios);
            conex = Procedimientos.Conexion();
            dateTimePicker1.Value = DateTime.Now;

            
        }
        private void button1_Click(object sender, EventArgs e)
        {


            SqlDataAdapter adaptador,adaptador1;
            adaptador = new SqlDataAdapter();
            adaptador1 = new SqlDataAdapter();
            SqlCommand insert = new SqlCommand("INSERT INTO chronos.dbo.empresas (descripcion,cuit,inicioDeActividad,calle,numerCalle,razonSocial,idBarrio,estado,idlocalidad,idpais) VALUES(@descripcion,@cuit,@inicioDeActividad,@calle,@numeroCalle,@razonSocial,@idBarrio,@estado,@idlocalidad,@idpais)", conex);
            adaptador.InsertCommand = insert;

            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@descripcion",SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@cuit",SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@inicioDeActividad",SqlDbType.DateTime));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@calle",SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@numeroCalle",SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@razonSocial",SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idBarrio",SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idlocalidad", SqlDbType.Int));
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@idpais", SqlDbType.Int));

            SqlCommand select=new SqlCommand("SELECT COUNT(razonSocial) FROM chronos.dbo.empresas where razonSocial=@razonSocial",conex);
            adaptador1.SelectCommand=select;
            adaptador1.SelectCommand.Parameters.Add(new SqlParameter("@razonSocial",SqlDbType.VarChar));



            try 
            {
                conex.Open();
                
                if(textBox1.Text=="")
                {
                    MessageBox.Show("Ingrese un nombre","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                }
                else if(textBox2.Text=="")
                {
                    MessageBox.Show("Ingrese el cuit de la empresa", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                
                else if(textBox4.Text=="")
                {
                    MessageBox.Show("Ingrese la calle, por favor","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Ingrese la numeración de la empresa", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else 
                {
                    adaptador1.SelectCommand.Parameters["@razonSocial"].Value=textBox1.Text;
                    if (Convert.ToInt16(adaptador1.SelectCommand.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("El nombre de la empresa ya exite, verifique la informacion ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                    }
                    else 
                    {
                        adaptador.InsertCommand.Parameters["@descripcion"].Value = textBox6.Text;
                        adaptador.InsertCommand.Parameters["@cuit"].Value = Convert.ToInt32(textBox2.Text);
                        adaptador.InsertCommand.Parameters["@inicioDeActividad"].Value = dateTimePicker1.Text;
                        adaptador.InsertCommand.Parameters["@calle"].Value = textBox4.Text;
                        adaptador.InsertCommand.Parameters["@numeroCalle"].Value = Convert.ToInt16(textBox5.Text);
                        adaptador.InsertCommand.Parameters["@razonSocial"].Value = textBox1.Text;
                        adaptador.InsertCommand.Parameters["@idBarrio"].Value = Convert.ToInt32(comboBox1.SelectedValue);
                        adaptador.InsertCommand.Parameters["@estado"].Value = "Habilitar";
                        adaptador.InsertCommand.Parameters["@idlocalidad"].Value = Convert.ToInt32(comboBox2.SelectedValue);
                        adaptador.InsertCommand.Parameters["@idpais"].Value =Convert.ToInt32(comboBox3.SelectedValue);


                            try {
                                

                                if (adaptador.InsertCommand.ExecuteNonQuery()> 0)
                                    {
                                    MessageBox.Show("Se ha registrado correctamente la empresa", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    textBox1.Clear();
                                    textBox2.Clear();
                                    textBox4.Clear();
                                    textBox5.Clear();
                                    textBox6.Clear();
                                    comboBox1.SelectedIndex = 0;
                                    comboBox2.SelectedIndex = 0;
                                    comboBox3.SelectedIndex = 0;
                                    }
                                }
                                 catch(SqlException ex)
                                    {
                                        MessageBox.Show("ERRROR: "+ ex.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                            catch (FormatException ex)
                            {
                                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                                catch(OverflowException ex)
                                    {
                                        MessageBox.Show("Ha Superado el maximo de caracteres que lleva el Cuit, tienen que tener un maximo de 11 digitos ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                     }
                    }


                }


            }
        
            catch(SqlException ex)
            {
                MessageBox.Show("Error al registrar los datos"+ex.Message,"INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                conex.Close(); ;
            }

        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Procedimientos.SoloNumero(e);
           
        }
      
    }
}
