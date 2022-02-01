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
    public partial class Z_1_ContenedorReUs : Form
    {
        private int childFormNumber = 0;

        public Z_1_ContenedorReUs()
        {
            InitializeComponent();
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A_1_9_RegistrarUsuario p = new A_1_9_RegistrarUsuario();
            p.MdiParent = this;
            p.Show();
        }
        private void montrarCascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        private void mostrarApiladasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void mostrarEnParaleloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        private void usuarioToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            A_1_10_EliminarUsuario p = new A_1_10_EliminarUsuario();
            p.MdiParent = this;
            p.Show();
        }
        private void Z_1_ContenedorReUs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void actualizarUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            A_1_9_1 p = new A_1_9_1();
            p.MdiParent = this;
            p.Show();
        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _02_Sesion_Administrador p = new _02_Sesion_Administrador();
            p.Show();
            this.Hide();
        }

        private void listaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A_1_9_2_1 p =new A_1_9_2_1();
            p.MdiParent = this;
            p.Show();
            
        }

        private void Z_1_ContenedorReUs_Load(object sender, EventArgs e)
        {

        }
    }
}
