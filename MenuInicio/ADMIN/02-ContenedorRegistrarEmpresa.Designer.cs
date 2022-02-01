namespace MenuInicio
{
    partial class _02_ContenedorRegistrarEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_02_ContenedorRegistrarEmpresa));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.registrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshabilitarHabilitarEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarCascadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.registrarToolStripMenuItem,
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
            // registrarToolStripMenuItem
            // 
            this.registrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarEmpresaToolStripMenuItem});
            this.registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            this.registrarToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.registrarToolStripMenuItem.Text = "Registrar";
            // 
            // registrarEmpresaToolStripMenuItem
            // 
            this.registrarEmpresaToolStripMenuItem.Name = "registrarEmpresaToolStripMenuItem";
            this.registrarEmpresaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.registrarEmpresaToolStripMenuItem.Text = "Registrar Empresa";
            this.registrarEmpresaToolStripMenuItem.Click += new System.EventHandler(this.registrarEmpresaToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarEmpresaToolStripMenuItem,
            this.deshabilitarHabilitarEmpresaToolStripMenuItem});
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.modificarToolStripMenuItem.Text = "Modificar";
            // 
            // actualizarEmpresaToolStripMenuItem
            // 
            this.actualizarEmpresaToolStripMenuItem.Name = "actualizarEmpresaToolStripMenuItem";
            this.actualizarEmpresaToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.actualizarEmpresaToolStripMenuItem.Text = "Actualizar Empresa";
            this.actualizarEmpresaToolStripMenuItem.Click += new System.EventHandler(this.actualizarEmpresaToolStripMenuItem_Click);
            // 
            // deshabilitarHabilitarEmpresaToolStripMenuItem
            // 
            this.deshabilitarHabilitarEmpresaToolStripMenuItem.Name = "deshabilitarHabilitarEmpresaToolStripMenuItem";
            this.deshabilitarHabilitarEmpresaToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.deshabilitarHabilitarEmpresaToolStripMenuItem.Text = "Deshab - Hab Empresa";
            this.deshabilitarHabilitarEmpresaToolStripMenuItem.Click += new System.EventHandler(this.deshabilitarHabilitarEmpresaToolStripMenuItem_Click);
            // 
            // ventanaToolStripMenuItem
            // 
            this.ventanaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarCascadaToolStripMenuItem,
            this.mostrarHorizontalToolStripMenuItem,
            this.mostrarEnParaleloToolStripMenuItem});
            this.ventanaToolStripMenuItem.Name = "ventanaToolStripMenuItem";
            this.ventanaToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.ventanaToolStripMenuItem.Text = "Ventana";
            // 
            // mostrarCascadaToolStripMenuItem
            // 
            this.mostrarCascadaToolStripMenuItem.Name = "mostrarCascadaToolStripMenuItem";
            this.mostrarCascadaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.mostrarCascadaToolStripMenuItem.Text = "&Cascada";
            this.mostrarCascadaToolStripMenuItem.Click += new System.EventHandler(this.mostrarCascadaToolStripMenuItem_Click);
            // 
            // mostrarHorizontalToolStripMenuItem
            // 
            this.mostrarHorizontalToolStripMenuItem.Name = "mostrarHorizontalToolStripMenuItem";
            this.mostrarHorizontalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.mostrarHorizontalToolStripMenuItem.Text = "Mosaico &vertical";
            this.mostrarHorizontalToolStripMenuItem.Click += new System.EventHandler(this.mostrarHorizontalToolStripMenuItem_Click);
            // 
            // mostrarEnParaleloToolStripMenuItem
            // 
            this.mostrarEnParaleloToolStripMenuItem.Name = "mostrarEnParaleloToolStripMenuItem";
            this.mostrarEnParaleloToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.mostrarEnParaleloToolStripMenuItem.Text = "Mosaico &horizontal";
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
            // _02_ContenedorRegistrarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 468);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "_02_ContenedorRegistrarEmpresa";
            this.Text = "Registrar Empresa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this._02_ContenedorRegistrarEmpresa_FormClosed);
            this.Load += new System.EventHandler(this._02_ContenedorRegistrarEmpresa_Load);
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
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarCascadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarEnParaleloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deshabilitarHabilitarEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regresarToolStripMenuItem;
    }
}



