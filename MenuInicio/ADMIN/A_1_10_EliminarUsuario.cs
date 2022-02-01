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
    public partial class A_1_10_EliminarUsuario : Form
    {
        public A_1_10_EliminarUsuario()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        DataSet data = new DataSet();
        SqlDataAdapter adaptador = new SqlDataAdapter();
        SqlDataAdapter adaptador1 = new SqlDataAdapter();
        SqlDataAdapter adaptador2 = new SqlDataAdapter();
        private void A_1_10_EliminarUsuario_Load(object sender, EventArgs e)
        {
            conex = Procedimientos.Conexion();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand select = new SqlCommand("select usua.nombre 'NOMBRE',per.descripcion 'PERFIL', usua.estado 'ESTADO' from chronos.dbo.usuarios AS usua inner join chronos.dbo.perfiles AS per on  usua.idPerfil=per.idPerfil where usua.nombre=@nombre GROUP BY usua.nombre,per.descripcion,usua.estado ", conex);
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
                    //adaptador.SelectCommand.Parameters["@nombre"].Value = textBox1.Text;
                    adaptador2.SelectCommand.Parameters["@nom"].Value = textBox1.Text;

                    //data = new DataSet();
                    //adaptador.Fill(data, "usuarios");
                    //dataGridView1.DataSource = data;
                    //dataGridView1.DataMember = "usuarios";

                    DataSet data1 = new DataSet();
                    adaptador2.Fill(data1,"tabla1");
                    DataRow fila1 = data1.Tables["tabla1"].Rows[0];
                    int n = Convert.ToInt16(fila1.ItemArray[0].ToString());

                    
                    

                    //adaptador.SelectCommand.ExecuteNonQuery();
                    adaptador2.SelectCommand.ExecuteNonQuery();
                   
                    if (n == 0)
                    {
                        MessageBox.Show("El usuario no existe, verifique los datos ingresados ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                        
                    }
                    else
                    {
                        adaptador.SelectCommand.Parameters["@nombre"].Value = textBox1.Text;
                        data = new DataSet();
                        adaptador.Fill(data, "usuarios");
                        dataGridView1.DataSource = data;
                        dataGridView1.DataMember = "usuarios";
                        adaptador.SelectCommand.ExecuteNonQuery();
                        
                        adaptador1.SelectCommand.Parameters["@nom"].Value = textBox1.Text;
                        adaptador1.SelectCommand.ExecuteNonQuery();
                        data = new DataSet();
                        adaptador1.Fill(data, "usuarios");

                        DataRow fila = data.Tables["usuarios"].Rows[0];

                        label3.Text = fila.ItemArray[0].ToString();

                        button1.Enabled = true;
                        radioButton1.Enabled = true;
                        radioButton2.Enabled = true;
                    }
                    
                }
            }
                catch(SqlException ex)            
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

            SqlCommand consul = new SqlCommand("SELECT estado from chronos.dbo.usuarios where idUsuario=@idUsuario1",conex);
            adaptador.SelectCommand = consul;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@idUsuario1",SqlDbType.Int));

            SqlCommand update = new SqlCommand("UPDATE chronos.dbo.usuarios set estado=@estado where idUsuario=@idUsuario",conex);
            adaptador.UpdateCommand = update;
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));

            try
            {
                if (textBox1.Text.Trim() == "" )
                {
                    MessageBox.Show("Ingrese el usuario por favor ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                conex.Open();
                adaptador.SelectCommand.Parameters["@idUsuario1"].Value = Convert.ToInt16(label3.Text);
                adaptador.SelectCommand.ExecuteNonQuery();
                data = new DataSet();
                adaptador.Fill(data, "usuarios");
                DataRow fila1 = data.Tables["usuarios"].Rows[0];
                string estado = fila1.ItemArray[0].ToString();
               

             
         
                    if(estado=="Deshabilitado" && radioButton1.Checked)
                {
                    MessageBox.Show("El usuario ya se encuentra Deshabilitado ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (estado == "Deshabilitado"  && radioButton2.Checked)
                    {

                        DialogResult resultado= MessageBox.Show("El usuario se encuentra Deshabilitado, desea Habilitarlo ", "INFORMACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (resultado == DialogResult.OK)
                            {
                                 string A="Activo";
                                 adaptador.UpdateCommand.Parameters["@estado"].Value=A;
                                 adaptador.UpdateCommand.Parameters["@idUsuario"].Value = label3.Text;
                                 adaptador.UpdateCommand.ExecuteNonQuery();
                                 textBox1.Text = "";
                                 label3.Text = "";
                            MessageBox.Show("El Usuario a quedado Habilitado", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // se limpia el dataGridView y se desabilitan los controles del update 
                            SqlCommand select = new SqlCommand("select usua.nombre 'NOMBRE',per.descripcion 'PERFIL', usua.estado 'ESTADO' from chronos.dbo.usuarios AS usua inner join chronos.dbo.perfiles AS per on  usua.idPerfil=per.idPerfil where usua.nombre=@nombre GROUP BY usua.nombre,per.descripcion,usua.estado ", conex);
                            adaptador = new SqlDataAdapter();
                            adaptador.SelectCommand = select;
                            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
                            adaptador.SelectCommand.Parameters["@nombre"].Value = textBox1.Text;
                            DataSet data1 = new DataSet();

                            adaptador.Fill(data1, "usuarios");
                            dataGridView1.DataSource = data1;
                            dataGridView1.DataMember = "usuarios";
                            adaptador.SelectCommand.ExecuteNonQuery();
                            button1.Enabled = false;
                            radioButton1.Enabled = false;
                            radioButton2.Enabled = false;

                        }
                        else
                            MessageBox.Show("Se ha cancelado la habilitacion del usuario","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);


                    }
                else if(estado=="Activo" && radioButton1.Checked)
                {
                    DialogResult resultado = MessageBox.Show("El usuario se encuentra Activo, desea Deshabilitarlo ", "INFORMACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.OK)
                             {
                                 string D = "Deshabilitado";
                                 adaptador.UpdateCommand.Parameters["@estado"].Value = D;
                                 adaptador.UpdateCommand.Parameters["@idUsuario"].Value = label3.Text;
                                 adaptador.UpdateCommand.ExecuteNonQuery(); 
                                 textBox1.Text = "";
                                 label3.Text = "";
                                 MessageBox.Show("El Usuario a quedado Deshabilitado", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // se limpia el dataGridView y se desabilitan los controles del update 
                            SqlCommand select = new SqlCommand("select usua.nombre 'NOMBRE',per.descripcion 'PERFIL', usua.estado 'ESTADO' from chronos.dbo.usuarios AS usua inner join chronos.dbo.perfiles AS per on  usua.idPerfil=per.idPerfil where usua.nombre=@nombre GROUP BY usua.nombre,per.descripcion,usua.estado ", conex);
                            adaptador = new SqlDataAdapter();
                            adaptador.SelectCommand = select;
                            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
                            adaptador.SelectCommand.Parameters["@nombre"].Value = textBox1.Text;
                            DataSet data1 = new DataSet();

                            adaptador.Fill(data1, "usuarios");
                            dataGridView1.DataSource = data1;
                            dataGridView1.DataMember = "usuarios";
                            adaptador.SelectCommand.ExecuteNonQuery();
                            button1.Enabled = false;
                            radioButton1.Enabled = false;
                            radioButton2.Enabled = false;

                        }
                        else
                        MessageBox.Show("Se ha cancelado la Deshabilitacion del usuario", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else //if (estado == "Activo" && radioButton2.Checked)
                {
                    MessageBox.Show("El usuario ya se encuentra Habilitado ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    

                }



            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error al Cambiar el estado: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                conex.Close();
            }

           



        }
        }
}
