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
    public partial class CuadroEmegernte1 : Form
    {
        Point punt;
        Boolean movi;

        public CuadroEmegernte1()
        {
            InitializeComponent();
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
        private void CuadroEmegernte1_MouseUp(object sender, MouseEventArgs e)
        {
          
           
        }

        private void CuadroEmegernte1_Load(object sender, EventArgs e)
        {
           
        }

        private void CuadroEmegernte1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void CuadroEmegernte1_MouseClick(object sender, MouseEventArgs e)
        {

        }

       
        private void CuadroEmegernte1_MouseLeave(object sender, EventArgs e)
        {
           

            
        }

        private void CuadroEmegernte1_MouseDown(object sender, MouseEventArgs e)
        {
            movi = true;
            punt = new Point(Cursor.Position.X-Location.X,Cursor.Position.Y-Location.Y);
           
        }

        private void CuadroEmegernte1_MouseMove(object sender, MouseEventArgs e)
        {
            if (movi == true)
            {
                Location = new Point(Cursor.Position.X - punt.X, Cursor.Position.Y - punt.Y);
            }
        }

        private void CuadroEmegernte1_MouseUp_1(object sender, MouseEventArgs e)
        {
            movi = false;
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Activate();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

       
       

       
      

        
    }
}
