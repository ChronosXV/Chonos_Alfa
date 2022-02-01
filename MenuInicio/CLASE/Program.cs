using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MenuInicio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ABM_8_RegistrarHistEmpleado()); //Inicio()ABM_6_RegistrarSueldoBejerman() LN_2_ActualizarCertificado()
        }
    }
}
//-LN_4_Gene_Reporte_Licencias()-PruebaActualizar_Certificado LN_2_ActualizarCertificado LN_1_RegistrarCertificado