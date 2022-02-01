using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuInicio
{
    public partial class ImprimirCertifi_ABM_03_01 : Form
    {
        public ImprimirCertifi_ABM_03_01(String a, String b, String c, String d, String e, String f, String g, String k, String j)
        {
            try
            {
                InitializeComponent();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = "MenuInicio.ImprirCertificadoTrabajo.rdlc";

                Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[9];
                p[0] = new Microsoft.Reporting.WinForms.ReportParameter("GrtRRHH", a);
                p[1] = new Microsoft.Reporting.WinForms.ReportParameter("DniRRHH", b);
                p[2] = new Microsoft.Reporting.WinForms.ReportParameter("Empleado", c);
                p[3] = new Microsoft.Reporting.WinForms.ReportParameter("TipoDni", d);
                p[4] = new Microsoft.Reporting.WinForms.ReportParameter("NumDNI", e);
                p[5] = new Microsoft.Reporting.WinForms.ReportParameter("Puesto", f);
                p[6] = new Microsoft.Reporting.WinForms.ReportParameter("Fecha", g);
                p[7] = new Microsoft.Reporting.WinForms.ReportParameter("SueldoEmpleado", k);
                p[8] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", j);


                reportViewer1.LocalReport.SetParameters(p);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al imprimir: "+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
