using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace MenuInicio
{
    public partial class A_1_9_1 : Form
    {
        public A_1_9_1()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        SqlDataAdapter adaptador;
        SqlDataAdapter adaptador1 = new SqlDataAdapter();
        SqlDataAdapter adaptador2 = new SqlDataAdapter();
        DataSet data;
        private void A_1_9_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'chronosDataSet16.perfiles' Puede moverla o quitarla según sea necesario.
            this.perfilesTableAdapter.Fill(this.chronosDataSet16.perfiles);
            conex = Procedimientos.Conexion();


        }
        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand select = new SqlCommand("select usua.nombre 'NOMBRE',per.descripcion 'PERFIL' from chronos.dbo.usuarios AS usua inner join chronos.dbo.perfiles AS per on  usua.idPerfil=per.idPerfil where usua.nombre=@nombre GROUP BY usua.nombre,per.descripcion ", conex);
            adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));



            SqlCommand select1 = new SqlCommand("SELECT idUsuario FROM USUARIOS WHERE NOMBRE=@nom", conex);
            adaptador1.SelectCommand = select1;
            adaptador1.SelectCommand.Parameters.Add(new SqlParameter("@nom", SqlDbType.VarChar));

            SqlCommand select2 = new SqlCommand("SELECT COUNT(NOMBRE) FROM USUARIOS WHERE NOMBRE=@nom", conex);
            adaptador2.SelectCommand = select2;
            adaptador2.SelectCommand.Parameters.Add(new SqlParameter("@nom", SqlDbType.VarChar));


            try
            {
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el nombre del usuario por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conex.Open();
                    adaptador.SelectCommand.Parameters["@nombre"].Value = textBox1.Text;
                    adaptador2.SelectCommand.Parameters["@nom"].Value = textBox1.Text;

                    data = new DataSet();
                    adaptador.Fill(data, "usuarios");
                    //dataGridView1.DataSource = data;
                    //dataGridView1.DataMember = "usuarios";

                    DataSet data1 = new DataSet();
                    adaptador2.Fill(data1, "tabla1");
                    DataRow fila1 = data1.Tables["tabla1"].Rows[0];
                    int n = Convert.ToInt16(fila1.ItemArray[0].ToString());


                    adaptador.SelectCommand.ExecuteNonQuery();
                    adaptador2.SelectCommand.ExecuteNonQuery();

                    if (n == 0)
                    {
                        MessageBox.Show("El usuario no existe o esta dado de baja, verifique los datos ingresados ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";

                    }
                    else
                    {
                      
                        adaptador1.SelectCommand.Parameters["@nom"].Value = textBox1.Text;
                        adaptador1.SelectCommand.ExecuteNonQuery();
                        data = new DataSet();
                        adaptador1.Fill(data, "usuarios");

                        DataRow fila = data.Tables["usuarios"].Rows[0];

                        label3.Text = fila.ItemArray[0].ToString();

                        MessageBox.Show("El usuario esta activo, puede realizar la modificacion ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        button1.Enabled = true;
                        comboBox1.Enabled = true;

                        DataSet consulta_perfil = new DataSet();
                        adaptador.Fill(consulta_perfil, "usuarios");
                        DataRow consl = consulta_perfil.Tables["usuarios"].Rows[0];
                        adaptador.SelectCommand.ExecuteNonQuery();
                        textBox2.Text = consl.ItemArray[1].ToString();



                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al consultar el usuario:" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


            SqlCommand update = new SqlCommand("UPDATE USUARIOS SET NOMBRE=@NOMBRE,IDPERFIL=@PERFIL WHERE idUsuario=@idUsuario", conex);
            adaptador.UpdateCommand = update;

            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@NOMBRE", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@PERFIL", SqlDbType.Int));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));

            try
            {
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el nombre del usuario por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button1.Enabled = false;
                    comboBox1.Enabled = false;
                }
                else if (label3.Text.Trim() =="")
                {
                    MessageBox.Show("Consulte si existe el usuario", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    conex.Open();
                    adaptador.UpdateCommand.Parameters["@NOMBRE"].Value = textBox1.Text;
                    adaptador.UpdateCommand.Parameters["@PERFIL"].Value = comboBox1.SelectedValue;
                    adaptador.UpdateCommand.Parameters["@idUsuario"].Value = Convert.ToInt16(label3.Text);
                    int n = Convert.ToInt16(adaptador.UpdateCommand.ExecuteNonQuery());
                    if (n >= 1)
                    {
                        MessageBox.Show("Se han aplicados los cambios de manera correcta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        button1.Enabled = false;
                        comboBox1.Enabled = false;
                        comboBox1.SelectedIndex = 0;

                    }
                    else
                    {
                        MessageBox.Show("No se aplicaron los cambios, verifique que el usuario exista", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Error al realizar los cambios:", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conex.Close(); }
        }
        
        }
    }
