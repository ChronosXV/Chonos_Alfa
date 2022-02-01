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
    public partial class LN_4_Gene_Reporte_Licencias : Form
    {
        public LN_4_Gene_Reporte_Licencias()
        {
            InitializeComponent();
            

        }
        SqlConnection conex = Procedimientos.Conexion();
        String cadena = "";
        SqlDataAdapter adaptador = new SqlDataAdapter();
        DataSet data = new DataSet();
        private void button5_Click(object sender, EventArgs e)
        {
            
            SqlCommand consulta = new SqlCommand("SELECT EMPLE.legajo as Legajo,EMPLE.nombre as Nombre,EMPLE.apellido as Apellido,EMPRE.razonSocial AS Empresa,SIT.nombre AS Sucursal,PUES.descripcion AS Puesto,EMPLE.fechaIngreso AS [Fecha Ingreso],DATEDIFF(MM,EMPLE.fechaIngreso,GETDATE())/12 AS Antiguedad,LIC.descripcion AS Licencia,CERT.fechaDesde AS [Fecha Desde Licencia],CERT.fechaHasta AS [Fecha Hasta Licencia]FROM [dbo].[empleados] EMPLE INNER JOIN [dbo].[empresas] EMPRE ON EMPLE.idEmpresa=EMPRE.idEmpresa INNER JOIN [dbo].[site] SIT ON EMPRE.IdEmpresa=SIT.IdEmpresa INNER JOIN [dbo].[puestos] PUES ON EMPLE.IdPuesto=PUES.IdPuesto INNER JOIN [dbo].[certificados] CERT ON EMPLE.legajo= CERT.legajo INNER JOIN [dbo].[tipoLicencias] LIC ON CERT.idTipolicencia =LIC.idTipoLicencia WHERE CAST(CERT.fechaDesde AS DATE) BETWEEN @FechaDesde AND @FechaHasta", conex);
            adaptador.SelectCommand = consulta;
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@FechaDesde", SqlDbType.VarChar));
            adaptador.SelectCommand.Parameters.Add(new SqlParameter("@FechaHasta", SqlDbType.VarChar));

            data.Clear();
            
            try
            {
                conex.Open();
                adaptador.SelectCommand.Parameters["@FechaDesde"].Value = dateTimePicker1.Text;
                adaptador.SelectCommand.Parameters["@FechaHasta"].Value = dateTimePicker2.Text;
                String FechaDesde = dateTimePicker1.Text.ToString();
                String FechaHasta = dateTimePicker2.Text.ToString();
                adaptador.SelectCommand.ExecuteNonQuery();
                adaptador.Fill(data, "Empleado");
                dataGridView1.DataSource = data;
                dataGridView1.DataMember = "Empleado";

                if (adaptador.SelectCommand.ExecuteScalar() != null)
                {
                    cadena = "SELECT EMPLE.legajo as Legajo,EMPLE.nombre as Nombre,EMPLE.apellido as Apellido,EMPRE.razonSocial AS Empresa,SIT.nombre AS Sucursal,PUES.descripcion AS Puesto,EMPLE.fechaIngreso AS[Fecha Ingreso], DATEDIFF(MM, EMPLE.fechaIngreso, GETDATE())/ 12 AS Antiguedad, LIC.descripcion AS Licencia,CERT.fechaDesde AS[Fecha Desde Licencia], CERT.fechaHasta AS[Fecha Hasta Licencia]FROM[dbo].[empleados] EMPLE INNER JOIN[dbo].[empresas] EMPRE ON EMPLE.idEmpresa = EMPRE.idEmpresa INNER JOIN[dbo].[site] SIT ON EMPRE.IdEmpresa=SIT.IdEmpresa INNER JOIN[dbo].[puestos] PUES ON EMPLE.IdPuesto=PUES.IdPuesto INNER JOIN[dbo].[certificados] CERT ON EMPLE.legajo= CERT.legajo INNER JOIN[dbo].[tipoLicencias] LIC ON CERT.idTipolicencia =LIC.idTipoLicencia WHERE CAST(CERT.fechaDesde AS DATE) BETWEEN " + "'" + FechaDesde + "'" + " AND " + "'" + FechaHasta + "'";
                }

                else
                {
                    
                }
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la informacion: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conex.Close();
            }


        }

        private void LN_4_Gene_Reporte_Licencias_Load_1(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }
        // aca le pasamos el parametro al reporte que imprime 
        private void button1_Click(object sender, EventArgs e)
        {
            if (cadena == "")
            {
                MessageBox.Show("Error al cargar la informacion: No hay datos disponibles para imprimir. Realice nuevamente la consulta. ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Imprime_LN_4_Gen_Repor p = new Imprime_LN_4_Gen_Repor(cadena);
                p.Show();
            }
          
        }
    }
}
