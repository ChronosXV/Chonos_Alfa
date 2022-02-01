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
    public partial class Imprime_LN_4_Gen_Repor : Form
    {
        string sql;
        public Imprime_LN_4_Gen_Repor(String cadena)
        {
            InitializeComponent();
            sql = cadena;

        }
        private void Imprime_LN_4_Gen_Repor_Load(object sender, EventArgs e)
        {
            DataSet det = new DataSet();
            det = Report_DataSet(sql);
            if (det.Tables[0].Rows.Count - 1 > 0)
            {
                LN.Imprime_RPT_LN_4 reporte = new LN.Imprime_RPT_LN_4();
                reporte.SetDataSource(det.Tables[0]);
                crystalReportViewer1.ReportSource = reporte;
            }
            else
            {
                MessageBox.Show("No se recupero informacion para imprimir. ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        SqlConnection conex = Procedimientos.Conexion();

        public DataSet Report_DataSet(String a)
        {
            SqlCommand cons = new SqlCommand(a, conex);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            LN.Imprimir_DataSet_LN4 data = new LN.Imprimir_DataSet_LN4();

            conex.Open();
            adaptador.SelectCommand = cons;
            adaptador.SelectCommand.ExecuteNonQuery();
            adaptador.Fill(data, "Reporte_Licencias");
            
            conex.Close();
            
            return data;

        }

      

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
