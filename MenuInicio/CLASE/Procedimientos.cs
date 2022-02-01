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
    class Procedimientos
    {
        public static void SoloNumero(KeyPressEventArgs ex) 
        {
            if (!(char.IsDigit(ex.KeyChar)) && (ex.KeyChar != (char)Keys.Space) && (ex.KeyChar != (char)Keys.Back))
            {
                ex.Handled = true;

            }
            else
               
                ex.Handled = false;
           

        }
        public static void SoloLetras(KeyPressEventArgs ex)
        {
            if((char.IsDigit(ex.KeyChar) && (ex.KeyChar!=(char)Keys.Space) && (ex.KeyChar!=(char)Keys.Back)))
            {
                ex.Handled = true;
            }
            else
                ex.Handled = false;
        }
        public static SqlConnection Conexion()
        {
            SqlConnection conex = new SqlConnection("Data Source=ARCBAVA01;Initial Catalog=Chronos;Integrated Security=True");
            return conex;
            
        }
        public static void contCaraccter(string a)
        {
            int b=Convert.ToInt32(a.Length);
            if(b>11)
            {
                MessageBox.Show("A superado el n° maximo de caractares, debe ingresar 11 digitos","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        
            }
        public static int buscarCaracter(string a)

    {
        int f = 0;
        if (a.IndexOf("@") > 0)
        {
            f = 1;
           //MessageBox.Show("Debe ingresar un E-mail","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        return f;
       


    }
        public static int compararDNI(int a, string c)
        {
            SqlConnection conex = Conexion();
            SqlCommand selec = new SqlCommand("SELECT  idtipodoc,tipoDoc,descripcion,qDigitos FROM CHRONOS.DBO.tipoDocumentos where idtipodoc=@a", conex);
            
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = selec;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@a", SqlDbType.Int));
            adaptador.SelectCommand.Parameters["@a"].Value = a;
           
            conex.Open();
            adaptador.SelectCommand.ExecuteNonQuery();
            
            DataSet data = new DataSet();
            adaptador.Fill(data, "DNI");
            DataRow fila;
            fila = data.Tables["DNI"].Rows[0];
            int n =Convert.ToInt16(c.Length);
            int h = 1;

            if (a == Convert.ToInt32(fila.ItemArray[0].ToString()) && n == Convert.ToInt16(fila.ItemArray[3].ToString()))
            {
                
            }
            else
            {
                
                //int f = Convert.ToInt32(fila.ItemArray[0].ToString());
                h = 0;
                
            }
            
            conex.Close();
            return h;
          }
        public static int compararTelefono(int a, string c)
        {
            SqlConnection conex = Conexion();
            SqlCommand selec = new SqlCommand("SELECT  idTelefono,descripcion,qdigito FROM CHRONOS.DBO.tipoTelefonos where idTelefono=@a", conex);

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = selec;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@a", SqlDbType.Int));
            adaptador.SelectCommand.Parameters["@a"].Value = a;

            conex.Open();
            adaptador.SelectCommand.ExecuteNonQuery();

            DataSet data = new DataSet();
            adaptador.Fill(data, "Telefonos");
            DataRow fila;
            fila = data.Tables["Telefonos"].Rows[0];
            int n = c.Length; 
            int h = 1;

            if (a == Convert.ToInt32(fila.ItemArray[0].ToString()) && n == Convert.ToInt32(fila.ItemArray[2].ToString()))
            {

            }
            else
            {
                h = 0;
            }

            conex.Close();
            return h;
        }
        public static Bitmap Redimencion(Image imagen, int width, int height) 
        {
            var Radio=Math.Max((double)width/imagen.Width,(double)height/imagen.Height);
            var NuevoAncho = (int)(imagen.Width * Radio);
            var NuevoAlto= (int)(imagen.Height * Radio);

            var ImangenRedimencionada = new Bitmap(NuevoAncho, NuevoAlto);
            Graphics.FromImage(ImangenRedimencionada).DrawImage(imagen, 0, 0, NuevoAncho, NuevoAlto);
            Bitmap imangeFinal = new Bitmap(ImangenRedimencionada);
            return imangeFinal;


        }

    }
}
