namespace MenuInicio
{
    partial class Z_1_ContenedorReUs
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Z_1_ContenedorReUs));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.registarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Z_1_ContenedorRegistrarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarUsuarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.montrarCascadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarApiladasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarEnParaleloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regresarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.ventanaToolStripMenuItem,
            this.regresarToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.ventanaToolStripMenuItem;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(785, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // registarToolStripMenuItem
            // 
            this.registarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Z_1_ContenedorRegistrarUsuario,
            this.listaDeUsuariosToolStripMenuItem});
            this.registarToolStripMenuItem.Name = "registarToolStripMenuItem";
            this.registarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.registarToolStripMenuItem.Text = "Registar";
            // 
            // Z_1_ContenedorRegistrarUsuario
            // 
            this.Z_1_ContenedorRegistrarUsuario.Name = "Z_1_ContenedorRegistrarUsuario";
            this.Z_1_ContenedorRegistrarUsuario.Size = new System.Drawing.Size(163, 22);
            this.Z_1_ContenedorRegistrarUsuario.Text = "Registrar Usuario";
            this.Z_1_ContenedorRegistrarUsuario.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // listaDeUsuariosToolStripMenuItem
            // 
            this.listaDeUsuariosToolStripMenuItem.Name = "listaDeUsuariosToolStripMenuItem";
            this.listaDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.listaDeUsuariosToolStripMenuItem.Text = "Lista de Usuarios";
            this.listaDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.listaDeUsuariosToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem3,
            this.actualizarUsuarioToolStripMenuItem1});
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.modificarToolStripMenuItem.Text = "Modificar";
            // 
            // usuarioToolStripMenuItem3
            // 
            this.usuarioToolStripMenuItem3.Name = "usuarioToolStripMenuItem3";
            this.usuarioToolStripMenuItem3.Size = new System.Drawing.Size(229, 22);
            this.usuarioToolStripMenuItem3.Text = "Habilitar-Deshabilitar Usuario";
            this.usuarioToolStripMenuItem3.Click += new System.EventHandler(this.usuarioToolStripMenuItem3_Click);
            // 
            // actualizarUsuarioToolStripMenuItem1
            // 
            this.actualizarUsuarioToolStripMenuItem1.Name = "actualizarUsuarioToolStripMenuItem1";
            this.actualizarUsuarioToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.actualizarUsuarioToolStripMenuItem1.Text = "Actualizar Usuario";
            this.actualizarUsuarioToolStripMenuItem1.Click += new System.EventHandler(this.actualizarUsuarioToolStripMenuItem1_Click);
            // 
            // ventanaToolStripMenuItem
            // 
            this.ventanaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.montrarCascadaToolStripMenuItem,
            this.mostrarApiladasToolStripMenuItem,
            this.mostrarEnParaleloToolStripMenuItem});
            this.ventanaToolStripMenuItem.Name = "ventanaToolStripMenuItem";
            this.ventanaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ventanaToolStripMenuItem.Text = "Ventana";
            // 
            // montrarCascadaToolStripMenuItem
            // 
            this.montrarCascadaToolStripMenuItem.Name = "montrarCascadaToolStripMenuItem";
            this.montrarCascadaToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.montrarCascadaToolStripMenuItem.Text = "Montrar Cascada";
            this.montrarCascadaToolStripMenuItem.Click += new System.EventHandler(this.montrarCascadaToolStripMenuItem_Click);
            // 
            // mostrarApiladasToolStripMenuItem
            // 
            this.mostrarApiladasToolStripMenuItem.Name = "mostrarApiladasToolStripMenuItem";
            this.mostrarApiladasToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.mostrarApiladasToolStripMenuItem.Text = "Mostrar Apiladas";
            this.mostrarApiladasToolStripMenuItem.Click += new System.EventHandler(this.mostrarApiladasToolStripMenuItem_Click);
            // 
            // mostrarEnParaleloToolStripMenuItem
            // 
            this.mostrarEnParaleloToolStripMenuItem.Name = "mostrarEnParaleloToolStripMenuItem";
            this.mostrarEnParaleloToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.mostrarEnParaleloToolStripMenuItem.Text = "Mostrar en Paralelo";
            this.mostrarEnParaleloToolStripMenuItem.Click += new System.EventHandler(this.mostrarEnParaleloToolStripMenuItem_Click);
            // 
            // regresarToolStripMenuItem
            // 
            this.regresarToolStripMenuItem.Name = "regresarToolStripMenuItem";
            this.regresarToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.regresarToolStripMenuItem.Text = "Regresar";
            this.regresarToolStripMenuItem.Click += new System.EventHandler(this.regresarToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 446);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(785, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // Z_1_ContenedorReUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(785, 468);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Z_1_ContenedorReUs";
            this.Text = "Registrar Usuario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Z_1_ContenedorReUs_FormClosed);
            this.Load += new System.EventHandler(this.Z_1_ContenedorReUs_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem registarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Z_1_ContenedorRegistrarUsuario;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ventanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem montrarCascadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarApiladasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarEnParaleloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarUsuarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listaDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regresarToolStripMenuItem;
    }
}



