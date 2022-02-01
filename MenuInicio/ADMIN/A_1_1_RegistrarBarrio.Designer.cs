namespace MenuInicio
{
    partial class A_1_1_RegistrarBarrio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_1_1_RegistrarBarrio));
            this.chronosDataSet5 = new MenuInicio.DATASET.ChronosDataSet5();
            this.localidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.localidadesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.chronosDataSet18 = new MenuInicio.DATASET.ChronosDataSet18();
            this.localidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chronosDataSet14 = new MenuInicio.DATASET.ChronosDataSet14();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chronosDataSet7 = new MenuInicio.DATASET.ChronosDataSet7();
            this.chronosDataSet8 = new MenuInicio.DATASET.ChronosDataSet8();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chronosDataSet10 = new MenuInicio.DATASET.ChronosDataSet10();
            this.chronosDataSet9 = new MenuInicio.DATASET.ChronosDataSet9();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button7 = new System.Windows.Forms.Button();
            this.localidadesTableAdapter = new MenuInicio.DATASET.ChronosDataSet14TableAdapters.localidadesTableAdapter();
            this.localidadesTableAdapter1 = new MenuInicio.DATASET.ChronosDataSet18TableAdapters.localidadesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet9)).BeginInit();
            this.SuspendLayout();
            // 
            // chronosDataSet5
            // 
            this.chronosDataSet5.DataSetName = "DATASET.ChronosDataSet5";
            this.chronosDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // localidadBindingSource
            // 
            this.localidadBindingSource.DataMember = "localidad";
            this.localidadBindingSource.DataSource = this.chronosDataSet5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MenuInicio.Properties.Resources.Rojo_Sin_fondo1;
            this.pictureBox1.Location = new System.Drawing.Point(14, 256);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 27);
            this.button2.TabIndex = 21;
            this.button2.Text = "Registrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(13, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "LOCALIDAD";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.localidadesBindingSource1;
            this.comboBox1.DisplayMember = "descripcion";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(99, 95);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.ValueMember = "idLocaclidad";
            // 
            // localidadesBindingSource1
            // 
            this.localidadesBindingSource1.DataMember = "localidades";
            this.localidadesBindingSource1.DataSource = this.chronosDataSet18;
            // 
            // chronosDataSet18
            // 
            this.chronosDataSet18.DataSetName = "DATASET.ChronosDataSet18";
            this.chronosDataSet18.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // localidadesBindingSource
            // 
            this.localidadesBindingSource.DataMember = "localidades";
            this.localidadesBindingSource.DataSource = this.chronosDataSet14;
            // 
            // chronosDataSet14
            // 
            this.chronosDataSet14.DataSetName = "DATASET.ChronosDataSet14";
            this.chronosDataSet14.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "BARRIO";
            // 
            // chronosDataSet7
            // 
            this.chronosDataSet7.DataSetName = "DATASET.ChronosDataSet7";
            this.chronosDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chronosDataSet8
            // 
            this.chronosDataSet8.DataSetName = "DATASET.ChronosDataSet8";
            this.chronosDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 509);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(323, 60);
            this.dataGridView1.TabIndex = 25;
            // 
            // chronosDataSet10
            // 
            this.chronosDataSet10.DataSetName = "DATASET.ChronosDataSet10";
            this.chronosDataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chronosDataSet9
            // 
            this.chronosDataSet9.DataSetName = "DATASET.ChronosDataSet9";
            this.chronosDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 27);
            this.button1.TabIndex = 26;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 209);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 27);
            this.button3.TabIndex = 27;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(331, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 27);
            this.button4.TabIndex = 28;
            this.button4.Text = "ACEPTAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(331, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(77, 22);
            this.textBox2.TabIndex = 29;
            this.textBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(226, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "NUEVO BARRIO";
            this.label3.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(99, 209);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 27);
            this.button5.TabIndex = 33;
            this.button5.Text = "Modificar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(317, 223);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(77, 27);
            this.button6.TabIndex = 34;
            this.button6.Text = "Regresar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(414, -1);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1736, 1114);
            this.webBrowser1.TabIndex = 35;
            this.webBrowser1.Url = new System.Uri("https://maps.hehttps://www.google.com.ar/maps/@-31.3003398,-64.2857262,15.25z?hl=" +
        "es-419", System.UriKind.Absolute);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(248, 92);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(77, 27);
            this.button7.TabIndex = 36;
            this.button7.Text = "CANCELAR";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // localidadesTableAdapter
            // 
            this.localidadesTableAdapter.ClearBeforeFill = true;
            // 
            // localidadesTableAdapter1
            // 
            this.localidadesTableAdapter1.ClearBeforeFill = true;
            // 
            // A_1_1_RegistrarBarrio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MenuInicio.Properties.Resources.Fondo_Gris1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(922, 505);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(938, 622);
            this.Name = "A_1_1_RegistrarBarrio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.A_1_1_RegistrarBarrio_FormClosed);
            this.Load += new System.EventHandler(this.A_1_1_RegistrarBarrio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DATASET.ChronosDataSet5 chronosDataSet5;
        private System.Windows.Forms.BindingSource localidadBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private DATASET.ChronosDataSet7 chronosDataSet7;
        private DATASET.ChronosDataSet8 chronosDataSet8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DATASET.ChronosDataSet9 chronosDataSet9;
        private DATASET.ChronosDataSet10 chronosDataSet10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button7;
        private DATASET.ChronosDataSet14 chronosDataSet14;
        private System.Windows.Forms.BindingSource localidadesBindingSource;
        private DATASET.ChronosDataSet14TableAdapters.localidadesTableAdapter localidadesTableAdapter;
        private DATASET.ChronosDataSet18 chronosDataSet18;
        private System.Windows.Forms.BindingSource localidadesBindingSource1;
        private DATASET.ChronosDataSet18TableAdapters.localidadesTableAdapter localidadesTableAdapter1;
    }
}