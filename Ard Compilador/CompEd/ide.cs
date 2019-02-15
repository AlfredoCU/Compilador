using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions; // Expresiones regulares.
using Tsimbolos;
using ManejoDeErrores;

namespace CompEd
{
    public partial class Ide : Form
    {
        int cantLineas = 0;
        string nomArchivo;
        TS tablaSimbolos = new TS();
        TE tablaErrores = new TE();

        public Ide()
        {
            InitializeComponent();
        }

        private void Ide_Load(object sender, EventArgs e)
        {
            tablaErrores.IniciaError();
            tablaSimbolos.inicialista();
            tabControl1.Visible = false;
            PagCodigo.Select();
            PagCodigo.DetectUrls = true;
            // Área de notificación
            notifyIcon1.Text = "Ard Compilador";
            notifyIcon1.BalloonTipTitle = "Hola Mundo";
            notifyIcon1.BalloonTipText = "Bienvenido a Ard Compilador 2018";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            this.Click += new EventHandler(notifyIcon1_Click);
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(3000);
        }

        // Este método es para bloquear el botón de salir del Form.
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ClassStyle |= 0x200;
                return parms;
            }
        }

        // MÉNU 1.

        // Archivo.
        // Abrir.
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        // Nuevo.
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
        }

        // Guardar.
        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            guardaArchivo2(nomArchivo);
        }

        // Guardar como.
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardaArchivo();
        }

        // Cerrar proyecto.
        private void cerrarProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
        }

        // Salir.
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // Herramientas.
        // Color de la fuente.
        private void colorDeLaFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cl = colorDialog1.ShowDialog();
            if (cl == System.Windows.Forms.DialogResult.OK)
            {
                // Esto para una parte del texto.
                PagCodigo.ForeColor = colorDialog1.Color;
            }
        }

        // Color de la consola.
        private void colorDeConsolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cl = colorDialog1.ShowDialog();
            if (cl == System.Windows.Forms.DialogResult.OK)
            {
                // Esto para una parte del texto.
                PagCodigo.BackColor = colorDialog1.Color;
            }
        }

        // Formato de letra.
        private void formatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = fontDialog1.ShowDialog();
            if (fm == DialogResult.OK)
            {
                // Esto para una parte del texto
                PagCodigo.Font = fontDialog1.Font;
            }
        }

        // Acerca de.
        // Acerca de Ard Compilador.
        private void acercaDeCompEdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "Este sistema esta creado por ArdComputer. \n\nVersión: 2.0";
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Ventanas.
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            this.Activate();
        }

        // Salida.
        private void Ide_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Desea cerrar Ard Compilador?", "Cerrar Compilador", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogo == DialogResult.OK) {
                System.Windows.Forms.Application.Exit();
            }
            else { 
                e.Cancel = true;
            }
        }

        // MÉNU 2.

        // Abrir.
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        // Nuevo.
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
        }

        // Guardar.
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            guardaArchivo2(nomArchivo);
        }

        // Correr programa.
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            guardaArchivo2(nomArchivo);
            tablaSimbolos.reinicialista();
            tablaErrores.ReiniciaLista();
            tablaErrores.IniciaError();
            tablaSimbolos.inicialista();
            LeerArchivoAL(nomArchivo);
            string[] sent = uneSentencias();
            tablaSimbolos.compararALSemantica();

            if (tablaSimbolos.RevisarDuplicados())
            {
                tablaErrores.addLista(11);
            }

            AnalizadorS(sent);
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = tablaSimbolos.LlamaTabla();
            dataGridView2.DataSource = tablaErrores.LlamaTablaE();
            System.Media.SystemSounds.Asterisk.Play();
        }

        // Mostrar los datos en las tablas.
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = tablaSimbolos.LlamaTabla();
            dataGridView2.DataSource = tablaErrores.LlamaTablaE();
        }

        // MÉTODOS DE ARCHIVOS.

        // Abrir el archivo.
        public void AbrirArchivo()
        {
            try {
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Title = "CompEd#   Abrir Archivo   ";
                ofd.ShowDialog();
                // ofd.Filter = "Archivos ed#(*.ed)|*.ed";
                if (File.Exists(ofd.FileName))
                {
                    using (Stream stream = ofd.OpenFile())
                    {
                        // MessageBox.Show("archivo encontrado:  "+ofd.FileName);
                        LeerArchivo(ofd.FileName);
                        nomArchivo = ofd.FileName;
                        // txt_direccion.Text =ofd.FileName;
                        tabControl1.Visible = true;
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("El archivo no se abrio correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tablaErrores.addLista(2);
            }
        }

        // Leer el archivo.
        public void LeerArchivo(string nomarchivo)
        {
            StreamReader reader = new StreamReader(nomarchivo, System.Text.Encoding.Default);
            string texto;
            texto = reader.ReadToEnd();
            reader.Close();
            PagCodigo.Text = texto;
        }

        // Revisar archivo existente.
        public bool RevisaArchivoExiste(string nomarchivo)
        {
            bool existe;
            if (File.Exists(nomarchivo))
            {
                existe = true;
            }
            else
            {
                existe = false;
            }
            return existe;
        }

        // Guardar el archivo.
        public void GuardaArchivo()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Archivos ed|*.ed";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFile.FileName))
                {
                    // Para sobrescribir el texto.
                    StreamWriter codigonuevo = File.CreateText(saveFile.FileName);
                    codigonuevo.Write(PagCodigo.Text);
                    codigonuevo.Flush();
                    codigonuevo.Close();
                    nomArchivo = saveFile.FileName;
                    // txt_direccion.Text = saveFile.FileName;
                }
                else
                {
                    // El archivo no extiste.
                    StreamWriter codigonuevo = File.CreateText(saveFile.FileName);
                    codigonuevo.Write(PagCodigo.Text);
                    codigonuevo.Write("\n \n <</ Archivo creado el: " + DateTime.Now.ToString() + " />> \n ");   
                    codigonuevo.Flush();
                    codigonuevo.Close();
                    nomArchivo = saveFile.FileName;
                    // txt_direccion.Text = saveFile.FileName;
                }
            }
        }

        // Guardar el archivo.
        public void guardaArchivo2(string nomarchivo)
        {
            try
            {
                if (nomarchivo == null)
                {
                    GuardaArchivo();
                }
                else
                {
                    // El archivo nuevo.
                    StreamWriter codigonuevo = File.CreateText(nomarchivo);
                    codigonuevo.Write(PagCodigo.Text);
                    codigonuevo.Flush();
                    codigonuevo.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Leer el archivo AL.
        public void LeerArchivoAL(string nomarchivo)
        {
            int contadorAmbitoI =0;
            int contadorAmbitoF = 0;
            int ambito = 0;
            try
            {
                StreamReader reader = new StreamReader(nomarchivo);
                string[] PalabrasSeparadas;
                string read;
                int numeroDeLineas = 0;
                PagCodigo.Select(0, PagCodigo.SelectionStart);

                while (reader != null)
                {
                    numeroDeLineas = numeroDeLineas + 1;
                    read = reader.ReadLine();
                    if (reader.EndOfStream)
                    {
                        break;
                    }
                    else
                    {
                        PalabrasSeparadas = read.Split(' ');
                        foreach (var palabra in PalabrasSeparadas)
                        {
                            // Medición del ambito.
                            if (palabra == "{")
                            {
                                contadorAmbitoI = contadorAmbitoI + 1;
                            }
                            if (palabra == "}")
                            {
                                contadorAmbitoF = contadorAmbitoF + 1;
                            }
                            ambito = contadorAmbitoI;

                            // Se manda a comparar la palabra con la tabla de simbolos.
                            if (tablaSimbolos.CompararAL(palabra.ToString()) && palabra != null)
                            {                             
                                TablaDeSimbolos objnuevo = new TablaDeSimbolos(palabra, "", numeroDeLineas, -0, ambito, tablaSimbolos.compararALRef(palabra.ToString()), "palabra nueva", "palabra que coincide con la Tabla de simbolos", "");
                                tablaSimbolos.AñadirObj(objnuevo);
                                PagCodigo.SelectionStart = PagCodigo.Find(palabra);
                                PagCodigo.SelectionColor = Color.DodgerBlue;
                            }
                            // De no estar en la tabla de simbolos se agrega a un campo nuevo.
                            else
                            {
                                // Sentencia que revisa los dos texbox.
                                if (Regex.IsMatch(palabra, @"[a-zA-Z]") && palabra != null) 
                                {
                                    TablaDeSimbolos objnuevo = new TablaDeSimbolos(palabra, "", numeroDeLineas, -0, ambito, tablaSimbolos.ContLineas() + 1, "palabra nueva", "palabra que no coincide con la Tabla de simbolos,pero no se considera error","");
                                    tablaSimbolos.AñadirObj(objnuevo);
                                }
                                else if (Regex.IsMatch(palabra, @"\d{1}|\d{2}|\d{3}|\d{4}|\d{5}") && palabra != null)
                                {
                                    TablaDeSimbolos objnuevo = new TablaDeSimbolos(palabra, palabra, numeroDeLineas, -0, ambito, tablaSimbolos.ContLineas() + 1, "numero nuevo", "numero","");
                                    tablaSimbolos.AñadirObj(objnuevo);
                                    PagCodigo.SelectionStart = PagCodigo.Find(palabra);
                                    PagCodigo.SelectionColor = Color.Aquamarine;
                                }
                                else
                                {
                                    // System.Windows.Forms.MessageBox.Show("Error en la expresion \n no cumple con un formato correcto ");
                                }
                              }
                        } // Fin del análisis léxico.
                    }
                    PalabrasSeparadas = null;
                    cantLineas = numeroDeLineas;
                }

                if (contadorAmbitoF != contadorAmbitoI)
                {
                    tablaErrores.addLista(8);
                }
                reader.Close();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("El archivo no se abrio correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tablaErrores.addLista(2);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo leer el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ANALIZADORES.

        public string[] uneSentencias (){
            string sentencia = null;
            string[] sentencias = new string[cantLineas];
            int bandera = 0;
            string tipoV = "";

            // Une los token de cada linea.
            for (int i = 1; i < cantLineas; i++)
            {
                foreach (var token in tablaSimbolos.LlamaTabla())
                {
                    if (token.NumeroLinea == i && token != null)
                    {
                        if (bandera == 0 && Regex.IsMatch(token.Simbolo, @"(<#int|<#integer|<#double|<#bool|<#string|<#real|<#boolean)$"))
                        {
                            token.TipoVar = token.Simbolo;
                            tipoV = token.Simbolo;
                        }
                        if (bandera != 0)
                        {
                            sentencia = sentencia + " " + token.Simbolo.ToString();
                            token.TipoVar = tipoV;
                        }
                        else
                        {
                            sentencia = sentencia + token.Simbolo.ToString();
                            bandera = 1;
                        }
                    }
                }
                sentencias[i] = sentencia;
                sentencia = null;
                bandera = 0;
                tipoV = "";
            }
            return sentencias;
        }

        // Analizador sintatico.
        public void AnalizadorS(string[] sentencias)
        {
           for (int i = 1; i < sentencias.Length; i++)
           {
                // Expresiones regualares.
                if (sentencias[i] != null)
                {
                    if (Regex.IsMatch(sentencias[i], @"^<#int|<#integer\s+[a-z](1,15)(\s+:\s+\d(0,32000))*;$"))
                    {
                        MessageBox.Show("Esto es una sentencia int", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Parte semantica.
                        string[] separaNum;
                        separaNum = sentencias[i].Split(' ');
                        try {
                            int num ;
                            num = int.Parse(separaNum[3]);
                            MessageBox.Show("Es un número entero", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } catch (FormatException) {
                            MessageBox.Show("No es un número entero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tablaErrores.addLista(0,i);
                        } catch (IndexOutOfRangeException) {
                            tablaErrores.addLista(10, i);
                            MessageBox.Show("Error de escritura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else if (Regex.IsMatch(sentencias[i], @"^<#double|<#real\s+[a-z](1,15)(\s+:\s+\d(0,32000))*;$"))
                    {
                        MessageBox.Show("Esto es una sentencia double", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Parte semantica.
                        string[] separaNum;
                        separaNum = sentencias[i].Split(' ');
                        try {
                            double num;
                            num = double.Parse(separaNum[3]);
                            MessageBox.Show("Es un número double", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } catch (FormatException) {
                            tablaErrores.addLista(0,i);
                            MessageBox.Show("No es un número double", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } catch(IndexOutOfRangeException) {
                            tablaErrores.addLista(10, i);
                            MessageBox.Show("Error de escritura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else if (Regex.IsMatch(sentencias[i], @"^<#string|<#texto\s+[a-z](1,15)(\s+:\s+[a-z](1,15)')*;$"))
                    {
                        MessageBox.Show("Es una sentencia string", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"^<#bool|<#boolean\s+[a-z](1,15)(\s+:\s+(true|false))*;$"))
                    {
                        MessageBox.Show("Es una sentencia bool", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Parte semantica.
                        string[] separavar;
                        separavar = sentencias[i].Split(' ');
                        try {
                            bool var;
                            var = bool.Parse(separavar[3]);
                            MessageBox.Show("Es una variable bool", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } catch (FormatException) {
                            MessageBox.Show("No es una variable bool", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tablaErrores.addLista(0, i);
                        }
                    }

                    else if (Regex.IsMatch(sentencias[i], @"<<*.*>>$"))
                    {
                        MessageBox.Show("Esto es un comentario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"[a-z]\s+:\s[a-z]|(\w)*\s\+\s(\w)*|\d(0,32000)*\s;$"))
                    {
                        MessageBox.Show("Esto es una sentecia de asignación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Parte semantica.
                        string tpv1 = "";
                        string tpv2 = "";
                        string tpv3 = "";
                        string[] separaVar;
                        separaVar = sentencias[i].Split(' ');
                        // Asignación del tipo monto : num1 + num2 ;
                        if (Regex.IsMatch(sentencias[i], @"[a-z]\s+:\s(\w)*\s\+\s(\w)*\s;$"))
                        {
                            foreach (var token in tablaSimbolos.LlamaTabla())
                            {
                                if (token.Simbolo == separaVar [0])
                                {
                                    tpv1 = token.TipoVar;
                                }
                                if (token.Simbolo == separaVar[2])
                                {
                                    tpv2 = token.TipoVar;
                                }
                                if (token.Simbolo == separaVar[4])
                                {
                                    tpv3 = token.TipoVar;
                                }
                            } // Fin del foreach.
                            if (tpv1 == tpv2 && tpv2 == tpv3 && tpv1 != "")
                            {
                                MessageBox.Show("El tipo de las variables son el mismo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        // Asignación del tipo monto : num1 - num2 ;
                        if (Regex.IsMatch(sentencias[i], @"[a-z]\s+:\s(\w)*\s\-\s(\w)*\s;$"))
                        {
                            foreach (var token in tablaSimbolos.LlamaTabla())
                            {
                                if (token.Simbolo == separaVar[0])
                                {
                                    tpv1 = token.TipoVar;
                                }
                                if (token.Simbolo == separaVar[2])
                                {
                                    tpv2 = token.TipoVar;
                                }
                                if (token.Simbolo == separaVar[4])
                                {
                                    tpv3 = token.TipoVar;
                                }
                            } // Fin del foreach.
                            if (tpv1 == tpv2 && tpv2 == tpv3 && tpv1 != "")
                            {
                                MessageBox.Show("El tipo de las variables son el mismo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        // Asignación del tipo monto : num1 / num2 ;
                        if (Regex.IsMatch(sentencias[i], @"[a-z]\s+:\s(\w)*\s\/\s(\w)*\s;$"))
                        {
                            foreach (var token in tablaSimbolos.LlamaTabla())
                            {
                                if (token.Simbolo == separaVar[0])
                                {
                                    tpv1 = token.TipoVar;
                                }
                                if (token.Simbolo == separaVar[2])
                                {
                                    tpv2 = token.TipoVar;
                                }
                                if (token.Simbolo == separaVar[4])
                                {
                                    tpv3 = token.TipoVar;
                                }
                            } // Fin del foreach.
                            if (tpv1 == tpv2 && tpv2 == tpv3 && tpv1 != "")
                            {
                                MessageBox.Show("El tipo de las variables son el mismo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        // Asignación del tipo monto : num1 * num2 ;
                        if (Regex.IsMatch(sentencias[i], @"[a-z]\s+:\s(\w)*\s\*\s(\w)*\s;$"))
                        {
                            foreach (var token in tablaSimbolos.LlamaTabla())
                            {
                                if (token.Simbolo == separaVar[0])
                                {
                                    tpv1 = token.TipoVar;
                                }
                                if (token.Simbolo == separaVar[2])
                                {
                                    tpv2 = token.TipoVar;
                                }
                                if (token.Simbolo == separaVar[4])
                                {
                                    tpv3 = token.TipoVar;
                                }
                            } // Fin del foreach.
                            if (tpv1 == tpv2 && tpv2 == tpv3 && tpv1 != "")
                            {
                                MessageBox.Show("El tipo de las variables son el mismo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    else if (Regex.IsMatch(sentencias[i], @"^{$"))
                    {
                        MessageBox.Show("Inicio de ambito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"^}$"))
                    {
                        MessageBox.Show("Fin de ambito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"<<si_\s\(\s+\w+\s(<|>|<:|>:|::|!:)\s\w+\s\)\s\{$"))//--
                    {
                        MessageBox.Show("Comienzo de if", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"<<ysi_\s\(\s+\w+\s(<|>|<:|>:|::|!:)\s\w+\s\)\s\{$"))//--
                    {
                        MessageBox.Show("Comienzo de else if", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"<<sino\s*\{$"))//--
                    {
                        MessageBox.Show("Comienzo de else", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"#ncasd\s\(\s\w+\s(<|>|<:|>:|::|!:)\s\w+\s\)\s\{$"))//--
                    {
                        MessageBox.Show("Comienzo del switch", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"casd\s\(\s(\w+|\d+)\s\)\s{$"))//--
                    {
                        MessageBox.Show("Comienzo de case", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"fcasd\s;$"))//--
                    {
                        MessageBox.Show("Break del case", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"#mintrs\s\(\s\w+\s(<|>|<:|>:|::|!:)\s\w+\s\)\s{$"))
                    {
                        MessageBox.Show("Inicio de un while", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (Regex.IsMatch(sentencias[i], @"#mostrar\s\(\s(\w*)|'\w*'\)\s;$"))
                    {
                        MessageBox.Show("Mostrar por pantalla \n" + sentencias[i]);
                    }

                    else
                    {
                        if (sentencias[i] != null)
                        {
                            tablaErrores.addLista(9, i);
                        }
                    }
                }
            }
        }
    }
}