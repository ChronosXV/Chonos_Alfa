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
    public partial class A_1_12_RegistrarArea : Form
    {
        public A_1_12_RegistrarArea()
        {
            InitializeComponent();
        }
        SqlConnection conex;
        SqlDataAdapter adaptador=new SqlDataAdapter();
        SqlDataAdapter adaptador2 = new SqlDataAdapter();
        DataSet data = new DataSet();
        private void A_1_12_RegistrarArea_Load(object sender, EventArgs e)
        {
            conex = Procedimientos.Conexion();

            textBox2.Visible = false;
            label3.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            dataGridView1.Visible = false;
        }
        private void A_1_12_RegistrarArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            _02_Sesion_Administrador p = new _02_Sesion_Administrador();
            p.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand select = new SqlCommand("select COUNT(descripcion) from chronos.dbo.areas where descripcion=@descrip ", conex);
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@descrip", SqlDbType.VarChar));

            SqlCommand insert = new SqlCommand("INSERT INTO Chronos.dbo.areas (descripcion) VALUES (@descri)", conex);
            adaptador.InsertCommand = insert;
            adaptador.InsertCommand.Parameters.Add(new SqlParameter("@descri", SqlDbType.VarChar));


            try
            {
                conex.Open();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Por favor ingrese un area", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    adaptador.SelectCommand.Parameters["@descrip"].Value = textBox1.Text;
                    if (Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar()) >= 1)
                    {
                        MessageBox.Show("El area ya esta registrada, por favor verifique la informacion ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "";
                    }
                    else
                    {
                        adaptador.InsertCommand.Parameters["@descri"].Value = textBox1.Text;
                        if (Convert.ToInt16(adaptador.InsertCommand.ExecuteNonQuery()) >= 1)
                        {
                            MessageBox.Show("Los datos ingresados fueron registrador correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Text = "";
                        }
                    }

                }
            }
            catch (SqlException ez)
            {
                MessageBox.Show("Error al hacer la registracion:" + ez.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conex.Close();
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand select = new SqlCommand("select descripcion as 'AREA' from chronos.dbo.areas  ", conex);
            adaptador.SelectCommand = select;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@descrip", SqlDbType.VarChar));

            SqlCommand select2 = new SqlCommand("select COUNT(descripcion)  as 'AREA' from chronos.dbo.areas where descripcion=@descrip1 ", conex);
            adaptador2.SelectCommand = select2;
            adaptador2.SelectCommand.Parameters.Add(new SqlParameter("@descrip1", SqlDbType.VarChar));

            conex.Open();
            adaptador.SelectCommand.Parameters["@descrip"].Value = textBox1.Text;
            adaptador.Fill(data, "areas");
            dataGridView1.DataSource = data;
            dataGridView1.DataMember = "areas";
            dataGridView1.Visible = true;
            conex.Close();


            //try 
            //{
                
            //    //if (textBox1.Text == "")
            //    //{
            //    //    MessageBox.Show("Ingrese una area por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //}
            //    else 
            //    {
            //            conex.Open();
            //            adaptador.SelectCommand.Parameters["@descrip"].Value = textBox1.Text;
            //            adaptador2.SelectCommand.Parameters["@descrip1"].Value = textBox1.Text;

            //            if (Convert.ToInt16(adaptador2.SelectCommand.ExecuteScalar()) < 1)
            //            {
            //                MessageBox.Show("El area no existe, puede registrarla", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //            {
            //                adaptador.Fill(data, "areas");
            //                dataGridView1.DataSource = data;
            //                dataGridView1.DataMember = "areas";
            //                dataGridView1.Visible = true;
                            

            //            }
            //    }
            //}
            //catch(SqlException ex)
            //{
            //    MessageBox.Show("Error al Consultar:" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    conex.Close();
            //}

        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand eliminar = new SqlCommand("DELETE AREAS WHERE descripcion=@descri",conex);
            adaptador.DeleteCommand = eliminar;
            adaptador.DeleteCommand.Parameters.Add(new SqlParameter("@descri", SqlDbType.VarChar));

            SqlCommand select2 = new SqlCommand("select COUNT(descripcion) 'AREA' from chronos.dbo.areas where descripcion=@descrip1 ", conex);
            adaptador2.SelectCommand = select2;
            adaptador2.SelectCommand.Parameters.Add(new SqlParameter("@descrip1", SqlDbType.VarChar));

            

            try 
            {
                conex.Open();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese un Area", "INFOMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    adaptador2.SelectCommand.Parameters["@descrip1"].Value = textBox1.Text;
                    if (Convert.ToInt16(adaptador2.SelectCommand.ExecuteScalar())==0)
                    {
                        MessageBox.Show("El Area no existe, verifique la informacion ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text="";
                    }
                    else 
                    {
                        adaptador.DeleteCommand.Parameters["@descri"].Value = textBox1.Text;
                        adaptador.DeleteCommand.ExecuteNonQuery();
                        MessageBox.Show("Se ha Eliminadado el Area indicada","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        dataGridView1.Visible = false;
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error al eliminar:"+ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {



            
            SqlCommand select2 = new SqlCommand("select COUNT(descripcion), idArea from chronos.dbo.areas where descripcion=@descrip1 group by idArea ", conex);
            adaptador2.SelectCommand = select2;
            adaptador2.SelectCommand.Parameters.Add(new SqlParameter("@descrip1", SqlDbType.VarChar));

            SqlCommand update = new SqlCommand("update Chronos.dbo.areas  set descripcion=@descrip1 where idArea=@id", conex);
            adaptador.UpdateCommand = update;

            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@descrip1", SqlDbType.VarChar));
            adaptador.UpdateCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));

            SqlDataAdapter adaptador3 = new SqlDataAdapter();

            SqlCommand select3 = new SqlCommand("select COUNT(descripcion) from chronos.dbo.areas where descripcion=@descri2 ", conex);
            adaptador3.SelectCommand = select3;
            adaptador3.SelectCommand.Parameters.Add(new SqlParameter("@descri2", SqlDbType.VarChar));
            try 
            {
                conex.Open();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese un Area", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox2.Text == "") 
                {
                    MessageBox.Show("Ingrese el nuevo nombre del area", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    adaptador2.SelectCommand.Parameters["@descrip1"].Value = textBox1.Text;
                    if (Convert.ToInt16(adaptador2.SelectCommand.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("El Area no existe, verifique la informacion ingresada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    else 
                   
                    {

                        adaptador3.SelectCommand.Parameters["@descri2"].Value = textBox2.Text;
                        if(Convert.ToInt16(adaptador3.SelectCommand.ExecuteScalar())>=1)
                        {
                            MessageBox.Show("El nombre del Area ya existe, por favor ingrese otro nombre","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            textBox2.Text = "";
                        }
                        else{
                        data = new DataSet();
                        adaptador2.Fill(data, "areas1");
                        DataRow fila = data.Tables["areas1"].Rows[0];
                        label1.Text = fila.ItemArray[1].ToString();

                            adaptador.UpdateCommand.Parameters["@descrip1"].Value=textBox2.Text;
                            adaptador.UpdateCommand.Parameters["@id"].Value = Convert.ToInt16(label1.Text);
                            adaptador.UpdateCommand.ExecuteNonQuery();
                            MessageBox.Show("Los cambios se han realizados correctamente","INFORMCION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                            textBox1.Text = "";
                            textBox2.Text = "";
                        }
 
                    }
 
                }

            }
            catch(SqlException ex) 
            {
                MessageBox.Show("Error al Actualizar los datos"+ex.Message,"INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                conex.Close();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            label3.Visible = true;
            button5.Visible = true;
            button7.Visible = true;

            button1.Visible = false;
            button2.Visible = false;
            button6.Visible = false;
            button4.Visible = false;
            button3.Visible = false;
            dataGridView1.Visible = false;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button6.Visible = true;
            button4.Visible = true;

            textBox2.Visible = false;
            button5.Visible = false;
            label3.Visible = false;
            button7.Visible = false;
            textBox1.Text = "";
        }
    }
}
