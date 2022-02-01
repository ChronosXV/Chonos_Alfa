namespace MenuInicio
{
    partial class A_1_14_RegistrarSite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_1_14_RegistrarSite));
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.paisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chronosDataSet28 = new MenuInicio.DATASET.ChronosDataSet28();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.localidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chronosDataSet27 = new MenuInicio.DATASET.ChronosDataSet27();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.barriosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chronosDataSet29 = new MenuInicio.DATASET.ChronosDataSet29();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Consultar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Registrar = new System.Windows.Forms.Button();
            this.localidadesTableAdapter = new MenuInicio.DATASET.ChronosDataSet27TableAdapters.localidadesTableAdapter();
            this.paisTableAdapter = new MenuInicio.DATASET.ChronosDataSet28TableAdapters.paisTableAdapter();
            this.barriosTableAdapter = new MenuInicio.DATASET.ChronosDataSet29TableAdapters.barriosTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.areasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chronosDataSet30 = new MenuInicio.DATASET.ChronosDataSet30();
            this.areasTableAdapter = new MenuInicio.DATASET.ChronosDataSet30TableAdapters.areasTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.departamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chronosDataSet31 = new MenuInicio.DATASET.ChronosDataSet31();
            this.departamentosTableAdapter = new MenuInicio.DATASET.ChronosDataSet31TableAdapters.departamentosTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.provinciasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chronosDataSet37 = new MenuInicio.DATASET.ChronosDataSet37();
            this.label14 = new System.Windows.Forms.Label();
            this.provinciasTableAdapter = new MenuInicio.DATASET.ChronosDataSet37TableAdapters.provinciasTableAdapter();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chronosDataSet90 = new MenuInicio.DATASET.ChronosDataSet90();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresasTableAdapter = new MenuInicio.DATASET.ChronosDataSet90TableAdapters.empresasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.paisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barriosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departamentosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox3.DataSource = this.paisBindingSource;
            this.comboBox3.DisplayMember = "descripcion";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(460, 312);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(94, 21);
            this.comboBox3.TabIndex = 124;
            this.comboBox3.ValueMember = "idPais";
            // 
            // paisBindingSource
            // 
            this.paisBindingSource.DataMember = "pais";
            this.paisBindingSource.DataSource = this.chronosDataSet28;
            // 
            // chronosDataSet28
            // 
            this.chronosDataSet28.DataSetName = "DATASET.ChronosDataSet28";
            this.chronosDataSet28.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label12.Location = new System.Drawing.Point(425, 314);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 15);
            this.label12.TabIndex = 123;
            this.label12.Text = "Pais";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox2.DataSource = this.localidadesBindingSource;
            this.comboBox2.DisplayMember = "descripcion";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(142, 312);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(94, 21);
            this.comboBox2.TabIndex = 122;
            this.comboBox2.ValueMember = "idLocaclidad";
            // 
            // localidadesBindingSource
            // 
            this.localidadesBindingSource.DataMember = "localidades";
            this.localidadesBindingSource.DataSource = this.chronosDataSet27;
            // 
            // chronosDataSet27
            // 
            this.chronosDataSet27.DataSetName = "DATASET.ChronosDataSet27";
            this.chronosDataSet27.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label11.Location = new System.Drawing.Point(68, 314);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 121;
            this.label11.Text = "Localidad";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.DataSource = this.barriosBindingSource;
            this.comboBox1.DisplayMember = "descripcion";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(312, 265);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(91, 21);
            this.comboBox1.TabIndex = 120;
            this.comboBox1.ValueMember = "idBarrio";
            // 
            // barriosBindingSource
            // 
            this.barriosBindingSource.DataMember = "barrios";
            this.barriosBindingSource.DataSource = this.chronosDataSet29;
            // 
            // chronosDataSet29
            // 
            this.chronosDataSet29.DataSetName = "DATASET.ChronosDataSet29";
            this.chronosDataSet29.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label8.Location = new System.Drawing.Point(249, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 119;
            this.label8.Text = "Barrio";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox5.Location = new System.Drawing.Point(460, 269);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(39, 20);
            this.textBox5.TabIndex = 118;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox4.Location = new System.Drawing.Point(145, 266);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(91, 20);
            this.textBox4.TabIndex = 117;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label6.Location = new System.Drawing.Point(433, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 15);
            this.label6.TabIndex = 116;
            this.label6.Text = "N°";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label5.Location = new System.Drawing.Point(68, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 115;
            this.label5.Text = "Calle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label4.Location = new System.Drawing.Point(12, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 114;
            this.label4.Text = "DOMICILIO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MenuInicio.Properties.Resources.Rojo_Sin_fondo1;
            this.pictureBox1.Location = new System.Drawing.Point(623, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 125;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(188, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 137;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(146, 97);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(293, 61);
            this.textBox6.TabIndex = 135;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label9.Location = new System.Drawing.Point(58, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 134;
            this.label9.Text = "Descripcion";
            // 
            // Consultar
            // 
            this.Consultar.BackColor = System.Drawing.SystemColors.Control;
            this.Consultar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Consultar.Location = new System.Drawing.Point(319, 53);
            this.Consultar.Name = "Consultar";
            this.Consultar.Size = new System.Drawing.Size(84, 23);
            this.Consultar.TabIndex = 133;
            this.Consultar.Text = "Consultar";
            this.Consultar.UseVisualStyleBackColor = false;
            this.Consultar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label7.Location = new System.Drawing.Point(12, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 132;
            this.label7.Text = "DATOS";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 20);
            this.textBox1.TabIndex = 130;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label13.Location = new System.Drawing.Point(58, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 15);
            this.label13.TabIndex = 126;
            this.label13.Text = "Nombre";
            // 
            // Registrar
            // 
            this.Registrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Registrar.BackColor = System.Drawing.SystemColors.Control;
            this.Registrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.Registrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Registrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Registrar.Location = new System.Drawing.Point(142, 367);
            this.Registrar.Name = "Registrar";
            this.Registrar.Size = new System.Drawing.Size(84, 23);
            this.Registrar.TabIndex = 138;
            this.Registrar.Text = "Registrar";
            this.Registrar.UseVisualStyleBackColor = false;
            this.Registrar.Click += new System.EventHandler(this.button2_Click);
            // 
            // localidadesTableAdapter
            // 
            this.localidadesTableAdapter.ClearBeforeFill = true;
            // 
            // paisTableAdapter
            // 
            this.paisTableAdapter.ClearBeforeFill = true;
            // 
            // barriosTableAdapter
            // 
            this.barriosTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label1.Location = new System.Drawing.Point(500, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 139;
            this.label1.Text = "Area";
            // 
            // comboBox4
            // 
            this.comboBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox4.DataSource = this.areasBindingSource;
            this.comboBox4.DisplayMember = "descripcion";
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(560, 183);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(130, 21);
            this.comboBox4.TabIndex = 140;
            this.comboBox4.ValueMember = "idArea";
            // 
            // areasBindingSource
            // 
            this.areasBindingSource.DataMember = "areas";
            this.areasBindingSource.DataSource = this.chronosDataSet30;
            // 
            // chronosDataSet30
            // 
            this.chronosDataSet30.DataSetName = "DATASET.ChronosDataSet30";
            this.chronosDataSet30.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // areasTableAdapter
            // 
            this.areasTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label2.Location = new System.Drawing.Point(249, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 142;
            this.label2.Text = "Departamento";
            // 
            // comboBox5
            // 
            this.comboBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox5.DataSource = this.departamentosBindingSource;
            this.comboBox5.DisplayMember = "descripcion";
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(336, 185);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(130, 21);
            this.comboBox5.TabIndex = 143;
            this.comboBox5.ValueMember = "idDepartamento";
            // 
            // departamentosBindingSource
            // 
            this.departamentosBindingSource.DataMember = "departamentos";
            this.departamentosBindingSource.DataSource = this.chronosDataSet31;
            // 
            // chronosDataSet31
            // 
            this.chronosDataSet31.DataSetName = "DATASET.ChronosDataSet31";
            this.chronosDataSet31.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // departamentosTableAdapter
            // 
            this.departamentosTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 144;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // comboBox6
            // 
            this.comboBox6.DataSource = this.provinciasBindingSource;
            this.comboBox6.DisplayMember = "descripcion";
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(312, 312);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(94, 21);
            this.comboBox6.TabIndex = 145;
            this.comboBox6.ValueMember = "idProvincia";
            // 
            // provinciasBindingSource
            // 
            this.provinciasBindingSource.DataMember = "provincias";
            this.provinciasBindingSource.DataSource = this.chronosDataSet37;
            // 
            // chronosDataSet37
            // 
            this.chronosDataSet37.DataSetName = "DATASET.ChronosDataSet37";
            this.chronosDataSet37.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label14.Location = new System.Drawing.Point(249, 314);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 15);
            this.label14.TabIndex = 146;
            this.label14.Text = "Provincia";
            // 
            // provinciasTableAdapter
            // 
            this.provinciasTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox7
            // 
            this.comboBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox7.DataSource = this.empresasBindingSource;
            this.comboBox7.DisplayMember = "razonSocial";
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(145, 183);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(91, 21);
            this.comboBox7.TabIndex = 148;
            this.comboBox7.ValueMember = "idEmpresa";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label15.Location = new System.Drawing.Point(58, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 15);
            this.label15.TabIndex = 147;
            this.label15.Text = "Empresa";
            // 
            // chronosDataSet90
            // 
            this.chronosDataSet90.DataSetName = "DATASET.ChronosDataSet90";
            this.chronosDataSet90.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataMember = "empresas";
            this.empresasBindingSource.DataSource = this.chronosDataSet90;
            // 
            // empresasTableAdapter
            // 
            this.empresasTableAdapter.ClearBeforeFill = true;
            // 
            // A_1_14_RegistrarSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MenuInicio.Properties.Resources.Fondo_Gris1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(922, 479);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Registrar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Consultar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(938, 518);
            this.Name = "A_1_14_RegistrarSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Site";
            this.Load += new System.EventHandler(this.A_1_14_RegistrarSite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barriosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departamentosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chronosDataSet90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Consultar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Registrar;
        private DATASET.ChronosDataSet27 chronosDataSet27;
        private System.Windows.Forms.BindingSource localidadesBindingSource;
        private DATASET.ChronosDataSet27TableAdapters.localidadesTableAdapter localidadesTableAdapter;
        private DATASET.ChronosDataSet28 chronosDataSet28;
        private System.Windows.Forms.BindingSource paisBindingSource;
        private DATASET.ChronosDataSet28TableAdapters.paisTableAdapter paisTableAdapter;
        private DATASET.ChronosDataSet29 chronosDataSet29;
        private System.Windows.Forms.BindingSource barriosBindingSource;
        private DATASET.ChronosDataSet29TableAdapters.barriosTableAdapter barriosTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox4;
        private DATASET.ChronosDataSet30 chronosDataSet30;
        private System.Windows.Forms.BindingSource areasBindingSource;
        private DATASET.ChronosDataSet30TableAdapters.areasTableAdapter areasTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox5;
        private DATASET.ChronosDataSet31 chronosDataSet31;
        private System.Windows.Forms.BindingSource departamentosBindingSource;
        private DATASET.ChronosDataSet31TableAdapters.departamentosTableAdapter departamentosTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label14;
        private DATASET.ChronosDataSet37 chronosDataSet37;
        private System.Windows.Forms.BindingSource provinciasBindingSource;
        private DATASET.ChronosDataSet37TableAdapters.provinciasTableAdapter provinciasTableAdapter;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label15;
        private DATASET.ChronosDataSet90 chronosDataSet90;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private DATASET.ChronosDataSet90TableAdapters.empresasTableAdapter empresasTableAdapter;
    }
}