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
using Microsoft.Reporting.WinForms;

//Falta hacer imprimir

namespace MenuInicio
{
    public partial class A_1_9_2_1 : Form
    {
        public A_1_9_2_1()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        SqlDataAdapter adaptador = new SqlDataAdapter();
        DataSet data = new DataSet();

        SqlDataAdapter adaptador2 = new SqlDataAdapter();
        DataSet data2 = new DataSet();
        private void A_1_9_2_1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ChronosDataSet42.usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.ChronosDataSet42.usuarios);
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet40.usuarios' Puede moverla o quitarla según sea necesario.
            conex = Procedimientos.Conexion();


            //this.reportViewer1.RefreshReport();
        }

            
            
            
        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand consulta = new SqlCommand("Select nombre as Nombre, estado as 'Estado de Usuario' from chronos.dbo.usuarios where estado=@estado", conex);
            adaptador.SelectCommand = consulta;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar));

            SqlCommand consulta2 = new SqlCommand("Select nombre as Nombre, estado as 'Estado de Usuario'  from chronos.dbo.usuarios", conex);
            adaptador2.SelectCommand = consulta2;

           

            try 
            {
                conex.Open();
                
                 if (radioButton1.Checked)
                {
                    data.Clear();
                    data2.Clear();

                    adaptador.SelectCommand.Parameters["@estado"].Value="Activo";
                    adaptador.SelectCommand.ExecuteNonQuery();
                    
                    adaptador.Fill(data,"usuarios");
                    dataGridView1.DataSource = data;
                    dataGridView1.DataMember = "usuarios";
                    dataGridView1.Visible=true;

                                        
                }
                else if(radioButton2.Checked)
                {
                    data.Clear();
                    data2.Clear();
                    adaptador.SelectCommand.Parameters["@estado"].Value="Deshabilitado";
                    adaptador.SelectCommand.ExecuteNonQuery();

                    adaptador.Fill(data,"usuarios");
                    dataGridView1.DataSource = data;
                    dataGridView1.DataMember = "usuarios";
                    dataGridView1.Visible=true;
                }
                else 
                {
                    data.Clear();
                    data2.Clear();

                    adaptador2.SelectCommand.ExecuteNonQuery();
                    adaptador2.Fill(data2,"usuarios");
                    dataGridView1.DataSource = data2;
                    dataGridView1.DataMember = "usuarios";
                    dataGridView1.Visible=true;
                   
                }
 
            }
            catch (SqlException ex) { 
                MessageBox.Show("Error al Consultar: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            finally
            {
                conex.Close();
            }
        }
       }

      

        
    }
