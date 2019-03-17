namespace CompEd
{
    partial class Ide
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ide));
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGuardarComo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCerrarProyecto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPreferencias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiColorFuente = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiColorConsola = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFormato = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAcercaArdCompilador = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tsMenuSec = new System.Windows.Forms.ToolStrip();
            this.tsbtnAbrir = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.tsmiAnalizadorLexico = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAnalizadorSintactico = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAnalizadorSemantico = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManejadorDeErrores = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.gbSimbolos = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbErrores = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.gbCodigoConsola = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PagCodigo = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.msMenu.SuspendLayout();
            this.tsMenuSec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbSimbolos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.gbCodigoConsola.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("msMenu.BackgroundImage")));
            this.msMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiArchivo,
            this.tsmiHerramientas,
            this.tsmiAcercaDe});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.msMenu.Size = new System.Drawing.Size(1252, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "Ménu";
            // 
            // tsmiArchivo
            // 
            this.tsmiArchivo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tsmiArchivo.BackgroundImage = global::CompEd.Properties.Resources.Screenshot___24_09_2013___09_53_44_p_m;
            this.tsmiArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbrir,
            this.tsmiNuevo,
            this.tsmiGuardar,
            this.tsmiGuardarComo,
            this.tsmiCerrarProyecto,
            this.tsmiSalir});
            this.tsmiArchivo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiArchivo.ForeColor = System.Drawing.Color.LightGray;
            this.tsmiArchivo.Image = ((System.Drawing.Image)(resources.GetObject("tsmiArchivo.Image")));
            this.tsmiArchivo.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsmiArchivo.Name = "tsmiArchivo";
            this.tsmiArchivo.Size = new System.Drawing.Size(85, 22);
            this.tsmiArchivo.Text = "Archivo";
            // 
            // tsmiAbrir
            // 
            this.tsmiAbrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsmiAbrir.BackgroundImage = global::CompEd.Properties.Resources.Screenshot___24_09_2013___09_53_44_p_m;
            this.tsmiAbrir.ForeColor = System.Drawing.Color.White;
            this.tsmiAbrir.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAbrir.Image")));
            this.tsmiAbrir.Name = "tsmiAbrir";
            this.tsmiAbrir.Size = new System.Drawing.Size(178, 22);
            this.tsmiAbrir.Text = "Abrir";
            this.tsmiAbrir.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // tsmiNuevo
            // 
            this.tsmiNuevo.BackgroundImage = global::CompEd.Properties.Resources.Screenshot___24_09_2013___09_53_44_p_m;
            this.tsmiNuevo.ForeColor = System.Drawing.Color.White;
            this.tsmiNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsmiNuevo.Image")));
            this.tsmiNuevo.Name = "tsmiNuevo";
            this.tsmiNuevo.Size = new System.Drawing.Size(178, 22);
            this.tsmiNuevo.Text = "Nuevo";
            this.tsmiNuevo.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // tsmiGuardar
            // 
            this.tsmiGuardar.BackgroundImage = global::CompEd.Properties.Resources.Screenshot___24_09_2013___09_53_44_p_m;
            this.tsmiGuardar.ForeColor = System.Drawing.Color.White;
            this.tsmiGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsmiGuardar.Image")));
            this.tsmiGuardar.Name = "tsmiGuardar";
            this.tsmiGuardar.Size = new System.Drawing.Size(178, 22);
            this.tsmiGuardar.Text = "Guardar";
            this.tsmiGuardar.Click += new System.EventHandler(this.guardarToolStripMenuItem1_Click);
            // 
            // tsmiGuardarComo
            // 
            this.tsmiGuardarComo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsmiGuardarComo.BackgroundImage = global::CompEd.Properties.Resources.Screenshot___24_09_2013___09_53_44_p_m;
            this.tsmiGuardarComo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsmiGuardarComo.ForeColor = System.Drawing.Color.White;
            this.tsmiGuardarComo.Image = ((System.Drawing.Image)(resources.GetObject("tsmiGuardarComo.Image")));
            this.tsmiGuardarComo.Name = "tsmiGuardarComo";
            this.tsmiGuardarComo.Size = new System.Drawing.Size(178, 22);
            this.tsmiGuardarComo.Text = "Guardar como";
            this.tsmiGuardarComo.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // tsmiCerrarProyecto
            // 
            this.tsmiCerrarProyecto.BackgroundImage = global::CompEd.Properties.Resources.Screenshot___24_09_2013___09_53_44_p_m;
            this.tsmiCerrarProyecto.ForeColor = System.Drawing.Color.White;
            this.tsmiCerrarProyecto.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCerrarProyecto.Image")));
            this.tsmiCerrarProyecto.Name = "tsmiCerrarProyecto";
            this.tsmiCerrarProyecto.Size = new System.Drawing.Size(178, 22);
            this.tsmiCerrarProyecto.Text = "Cerrar proyecto";
            this.tsmiCerrarProyecto.Click += new System.EventHandler(this.cerrarProyectoToolStripMenuItem_Click);
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsmiSalir.BackgroundImage = global::CompEd.Properties.Resources.Screenshot___24_09_2013___09_53_44_p_m;
            this.tsmiSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsmiSalir.ForeColor = System.Drawing.Color.White;
            this.tsmiSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSalir.Image")));
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.Size = new System.Drawing.Size(178, 22);
            this.tsmiSalir.Text = "Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tsmiHerramientas
            // 
            this.tsmiHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPreferencias});
            this.tsmiHerramientas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiHerramientas.ForeColor = System.Drawing.Color.LightGray;
            this.tsmiHerramientas.Image = ((System.Drawing.Image)(resources.GetObject("tsmiHerramientas.Image")));
            this.tsmiHerramientas.Name = "tsmiHerramientas";
            this.tsmiHerramientas.Size = new System.Drawing.Size(121, 22);
            this.tsmiHerramientas.Text = "Herramientas";
            // 
            // tsmiPreferencias
            // 
            this.tsmiPreferencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsmiPreferencias.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsmiPreferencias.BackgroundImage")));
            this.tsmiPreferencias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiColorFuente,
            this.tsmiColorConsola,
            this.tsmiFormato});
            this.tsmiPreferencias.ForeColor = System.Drawing.Color.White;
            this.tsmiPreferencias.Image = ((System.Drawing.Image)(resources.GetObject("tsmiPreferencias.Image")));
            this.tsmiPreferencias.Name = "tsmiPreferencias";
            this.tsmiPreferencias.Size = new System.Drawing.Size(153, 22);
            this.tsmiPreferencias.Text = "Preferencias";
            // 
            // tsmiColorFuente
            // 
            this.tsmiColorFuente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsmiColorFuente.BackgroundImage")));
            this.tsmiColorFuente.ForeColor = System.Drawing.Color.White;
            this.tsmiColorFuente.Image = ((System.Drawing.Image)(resources.GetObject("tsmiColorFuente.Image")));
            this.tsmiColorFuente.Name = "tsmiColorFuente";
            this.tsmiColorFuente.Size = new System.Drawing.Size(194, 22);
            this.tsmiColorFuente.Text = "Color de la fuente";
            this.tsmiColorFuente.Click += new System.EventHandler(this.colorDeLaFuenteToolStripMenuItem_Click);
            // 
            // tsmiColorConsola
            // 
            this.tsmiColorConsola.BackgroundImage = global::CompEd.Properties.Resources.Screenshot___24_09_2013___09_53_44_p_m;
            this.tsmiColorConsola.ForeColor = System.Drawing.Color.White;
            this.tsmiColorConsola.Image = ((System.Drawing.Image)(resources.GetObject("tsmiColorConsola.Image")));
            this.tsmiColorConsola.Name = "tsmiColorConsola";
            this.tsmiColorConsola.Size = new System.Drawing.Size(194, 22);
            this.tsmiColorConsola.Text = "Color de consola";
            this.tsmiColorConsola.Click += new System.EventHandler(this.colorDeConsolaToolStripMenuItem_Click);
            // 
            // tsmiFormato
            // 
            this.tsmiFormato.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsmiFormato.BackgroundImage")));
            this.tsmiFormato.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsmiFormato.ForeColor = System.Drawing.Color.White;
            this.tsmiFormato.Image = ((System.Drawing.Image)(resources.GetObject("tsmiFormato.Image")));
            this.tsmiFormato.Name = "tsmiFormato";
            this.tsmiFormato.Size = new System.Drawing.Size(194, 22);
            this.tsmiFormato.Text = "Formato";
            this.tsmiFormato.Click += new System.EventHandler(this.formatoToolStripMenuItem_Click);
            // 
            // tsmiAcercaDe
            // 
            this.tsmiAcercaDe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAcercaArdCompilador});
            this.tsmiAcercaDe.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiAcercaDe.ForeColor = System.Drawing.Color.LightGray;
            this.tsmiAcercaDe.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAcercaDe.Image")));
            this.tsmiAcercaDe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiAcercaDe.Name = "tsmiAcercaDe";
            this.tsmiAcercaDe.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiAcercaDe.Size = new System.Drawing.Size(103, 22);
            this.tsmiAcercaDe.Text = "Acerca de";
            // 
            // tsmiAcercaArdCompilador
            // 
            this.tsmiAcercaArdCompilador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsmiAcercaArdCompilador.BackgroundImage = global::CompEd.Properties.Resources.Screenshot___24_09_2013___09_53_44_p_m;
            this.tsmiAcercaArdCompilador.ForeColor = System.Drawing.Color.White;
            this.tsmiAcercaArdCompilador.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAcercaArdCompilador.Image")));
            this.tsmiAcercaArdCompilador.Name = "tsmiAcercaArdCompilador";
            this.tsmiAcercaArdCompilador.Size = new System.Drawing.Size(252, 22);
            this.tsmiAcercaArdCompilador.Text = "Acerca de Ard Compilador";
            this.tsmiAcercaArdCompilador.Click += new System.EventHandler(this.acercaDeCompEdToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Bienvenido a CompEd# v1";
            this.notifyIcon1.BalloonTipTitle = "Hello World";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CompEd#";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // tsMenuSec
            // 
            this.tsMenuSec.BackColor = System.Drawing.Color.White;
            this.tsMenuSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsMenuSec.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAbrir,
            this.tsbtnNuevo,
            this.tsbtnGuardar,
            this.toolStripSeparator4,
            this.toolStripButton5});
            this.tsMenuSec.Location = new System.Drawing.Point(0, 24);
            this.tsMenuSec.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.tsMenuSec.Name = "tsMenuSec";
            this.tsMenuSec.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsMenuSec.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsMenuSec.Size = new System.Drawing.Size(1252, 25);
            this.tsMenuSec.TabIndex = 2;
            this.tsMenuSec.Text = "toolStrip2";
            // 
            // tsbtnAbrir
            // 
            this.tsbtnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAbrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAbrir.Image")));
            this.tsbtnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAbrir.Name = "tsbtnAbrir";
            this.tsbtnAbrir.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAbrir.Text = "Abrir archivo";
            this.tsbtnAbrir.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // tsbtnNuevo
            // 
            this.tsbtnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNuevo.Image")));
            this.tsbtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNuevo.Name = "tsbtnNuevo";
            this.tsbtnNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbtnNuevo.Text = "Nuevo";
            this.tsbtnNuevo.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // tsbtnGuardar
            // 
            this.tsbtnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardar.Image")));
            this.tsbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardar.Name = "tsbtnGuardar";
            this.tsbtnGuardar.Size = new System.Drawing.Size(23, 22);
            this.tsbtnGuardar.Text = "Guardar";
            this.tsbtnGuardar.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Compilar";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // tsmiAnalizadorLexico
            // 
            this.tsmiAnalizadorLexico.Name = "tsmiAnalizadorLexico";
            this.tsmiAnalizadorLexico.Size = new System.Drawing.Size(32, 19);
            // 
            // tsmiAnalizadorSintactico
            // 
            this.tsmiAnalizadorSintactico.Name = "tsmiAnalizadorSintactico";
            this.tsmiAnalizadorSintactico.Size = new System.Drawing.Size(32, 19);
            // 
            // tsmiAnalizadorSemantico
            // 
            this.tsmiAnalizadorSemantico.Name = "tsmiAnalizadorSemantico";
            this.tsmiAnalizadorSemantico.Size = new System.Drawing.Size(32, 19);
            // 
            // tsmiManejadorDeErrores
            // 
            this.tsmiManejadorDeErrores.Name = "tsmiManejadorDeErrores";
            this.tsmiManejadorDeErrores.Size = new System.Drawing.Size(32, 19);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbSimbolos
            // 
            this.gbSimbolos.Controls.Add(this.dataGridView1);
            this.gbSimbolos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSimbolos.Location = new System.Drawing.Point(940, 59);
            this.gbSimbolos.Name = "gbSimbolos";
            this.gbSimbolos.Size = new System.Drawing.Size(300, 601);
            this.gbSimbolos.TabIndex = 9;
            this.gbSimbolos.TabStop = false;
            this.gbSimbolos.Text = "Tabla de Simbolos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.Size = new System.Drawing.Size(294, 579);
            this.dataGridView1.TabIndex = 7;
            // 
            // gbErrores
            // 
            this.gbErrores.Controls.Add(this.dataGridView2);
            this.gbErrores.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbErrores.Location = new System.Drawing.Point(12, 518);
            this.gbErrores.Name = "gbErrores";
            this.gbErrores.Size = new System.Drawing.Size(910, 142);
            this.gbErrores.TabIndex = 10;
            this.gbErrores.TabStop = false;
            this.gbErrores.Text = "Errores...";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(904, 120);
            this.dataGridView2.TabIndex = 11;
            // 
            // gbCodigoConsola
            // 
            this.gbCodigoConsola.Controls.Add(this.tabControl1);
            this.gbCodigoConsola.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCodigoConsola.Location = new System.Drawing.Point(12, 59);
            this.gbCodigoConsola.Name = "gbCodigoConsola";
            this.gbCodigoConsola.Size = new System.Drawing.Size(910, 453);
            this.gbCodigoConsola.TabIndex = 11;
            this.gbCodigoConsola.TabStop = false;
            this.gbCodigoConsola.Text = "<<#";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(898, 428);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.PagCodigo);
            this.tabPage1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(890, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Código";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PagCodigo
            // 
            this.PagCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PagCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PagCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagCodigo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PagCodigo.ForeColor = System.Drawing.Color.White;
            this.PagCodigo.Location = new System.Drawing.Point(3, 3);
            this.PagCodigo.Name = "PagCodigo";
            this.PagCodigo.Size = new System.Drawing.Size(880, 388);
            this.PagCodigo.TabIndex = 0;
            this.PagCodigo.Text = "{\n  <</ Escriba su código aqui. />>\n}";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(890, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consola";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.SlateGray;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(880, 388);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = ">>>";
            // 
            // Ide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1252, 672);
            this.Controls.Add(this.gbCodigoConsola);
            this.Controls.Add(this.gbErrores);
            this.Controls.Add(this.gbSimbolos);
            this.Controls.Add(this.tsMenuSec);
            this.Controls.Add(this.msMenu);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "Ide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ard Compilador 2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ide_FormClosing);
            this.Load += new System.EventHandler(this.Ide_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.tsMenuSec.ResumeLayout(false);
            this.tsMenuSec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbSimbolos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.gbCodigoConsola.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiArchivo;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbrir;
        private System.Windows.Forms.ToolStripMenuItem tsmiGuardarComo;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem tsmiHerramientas;
        private System.Windows.Forms.ToolStripMenuItem tsmiPreferencias;
        private System.Windows.Forms.ToolStripMenuItem tsmiAcercaDe;
        private System.Windows.Forms.ToolStripMenuItem tsmiAcercaArdCompilador;
        private System.Windows.Forms.ToolStrip tsMenuSec;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem tsmiAnalizadorLexico;
        private System.Windows.Forms.ToolStripMenuItem tsmiAnalizadorSintactico;
        private System.Windows.Forms.ToolStripMenuItem tsmiAnalizadorSemantico;
        private System.Windows.Forms.ToolStripMenuItem tsmiManejadorDeErrores;
        private System.Windows.Forms.ToolStripButton tsbtnAbrir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem tsmiGuardar;
        private System.Windows.Forms.ToolStripMenuItem tsmiNuevo;
        private System.Windows.Forms.ToolStripButton tsbtnNuevo;
        private System.Windows.Forms.ToolStripMenuItem tsmiCerrarProyecto;
        private System.Windows.Forms.ToolStripMenuItem tsmiColorFuente;
        private System.Windows.Forms.ToolStripMenuItem tsmiFormato;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem tsmiColorConsola;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.GroupBox gbErrores;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox gbSimbolos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox gbCodigoConsola;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox PagCodigo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}