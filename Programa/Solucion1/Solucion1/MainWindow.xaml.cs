using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Solucion1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelClass Context;
        string reglas;
        string[] TablaLR;
        public MainWindow()
        {
            InitializeComponent();
            Context = new ModelClass();
            this.DataContext = Context;
            reglas = string.Empty;
            Context.Tabla = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\TablaLR.txt");
            Context.GetTabla(Context.Tabla);
            Context.Reglas = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Producciones.txt");
            Context.GetRules(Context.Reglas);
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            SetTextFromFile();
        }
        private void clearBoxes_Click(object sender, RoutedEventArgs e)
        {
            cleanData();
        }
        private void btn_move_Click(object sender, RoutedEventArgs e)
        {
            string textFromTbox = string.Empty;

            textFromTbox = tbx_First.Text;

            if (Context.WordsElements.Count > 0)
                Context.WordsElements.Clear();
            if (Context.Messages != string.Empty)
                Context.Messages = string.Empty;
            try
            {
                Context.ProcessString(textFromTbox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ex.InnerException + ex.ToString(), "Un error ha ocurrido", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            

            tbx_First.SelectAll();
            tbx_First.Copy();
            tbx_Second.Clear();
            tbx_Second.Paste();
                        
        }
        public void SetTextFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
			openFileDialog.Filter = "Text files (*.txt)|*.txt";
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() == true)
            {
                tbx_First.Text = File.ReadAllText(openFileDialog.FileName);
                MessageBox.Show("Se cargo el codigo fuente", "Informacion");
            }
        }
        internal void cleanData()
        {
            tbx_First.Clear();
            tbx_Second.Clear();
            Context.WordsElements.Clear();
            Context.ALexico = new Lexico();
            tbx_messages.Clear();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Title = "Seleccione archivo con la Tabla LR";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    Context.Tabla = File.ReadAllLines(openFileDialog.FileName);
                    Context.GetTabla(Context.Tabla);
                    MessageBox.Show("Se cargo la tabla LR", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El archivo no tiene el formato correcto", "Se ha producido un error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    Context.Reglas = File.ReadAllText(openFileDialog.FileName);
                    Context.GetRules(Context.Reglas);
                    MessageBox.Show("Se cargaron las Reglas de Produccion", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El archivo no tiene el formato correcto", "Se ha producido un error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
    public class ModelClass : ViewModelBase
    {
        private ObservableCollection<WordsCollection> wordsElements;
        private string messages;
        private string reglas;
        private string[] tabla;


        public ModelClass()
        {
            WordsElements = new ObservableCollection<WordsCollection>();
            ALexico = new Lexico();
            //ASintactico = new Sintactico();
            Messages = string.Empty;
        }
        internal Rule[] GetRules(string text)
        {
            Rule[] data = new Rule[51];
            string[] Lines = text.Split('\n');
            int index = 0;
            foreach (string line in Lines)
            {
                string l = line.Trim();

                string[] cols = l.Split('\t');

                Rule rule = new Rule() { Id = Int32.Parse(cols[0]), TotalProductions = Int32.Parse(cols[1]), RuleName = cols[2] };
                data[index] = rule;
                index++;
            }
            return data;
        }
        internal int[,] GetTabla(string[] lines)
        {
            int[,] table = new int[108, 46];
                
            for (int index = 0; index < lines.Length; index++)
            {
                lines[index] = lines[index].Trim();
                string[] cols = lines[index].Split('\t');
                int[] intcols = cols.Select(s => Int32.Parse(s)).ToArray();
                for (int index1 = 0; index1 < intcols.Length; index1++)
                {
                    table[index, index1] = intcols[index1];
                }
            }
            return table;
        }
        public ObservableCollection<WordsCollection> WordsElements
        {
            get => wordsElements;
            set
            {
                wordsElements = value;
                OnPropertyChanged("WordsElements");
            }
        }

        public string Messages { get => messages;
            set
            {
                messages = value;
                OnPropertyChanged("Messages");
            }
        }
        internal Lexico ALexico { get; set; }
        internal Sintactico ASintactico { get; set; }
       
        public string Reglas { get => reglas; set => reglas = value; }
        public string[] Tabla { get => tabla; set => tabla = value; }

        public void ProcessString(string text)
        {
            ASintactico = new Sintactico(GetTabla(Tabla),GetRules(Reglas));
            Messages += "Iniciando Analisis .... " + Environment.NewLine;
            //Seccion del lexico para analizar todos los simbolos
            ALexico.ClearText();
            ALexico.setText(text);
            wordsElements.Clear();
            while (true)
            {
                WordsCollection newSymbol;
                newSymbol = ALexico.sigSimbolo();
                if (newSymbol.Word != "$")
                    wordsElements.Add(newSymbol);
                else
                {
                    wordsElements.Add(newSymbol);
                    break;
                }
            }
            //Seccion del Sintactico. Interiormente tiene otro lexico.
            ASintactico.InitializeLexico(text);
            WordsCollection result = ASintactico.Analiza();
            if (result != null)
            {
                if(result.ErrorSintactico)
                    Messages += "Error en simbolo: " + result.Word + " Linea número: " + result.LineId;
                if (result.ErrorSemantico)
                {
                    foreach (string txt in result.Errores)
                    {
                        Messages += txt + Environment.NewLine;
                    }
                }
            }
            else
            {
                Messages += "Codigo es correcto" + Environment.NewLine;
            }

            Messages += " Analisis Terminado" + Environment.NewLine;
        }
    }
    public class WordsCollection : ViewModelBase
    {
        private string word;
        private string dataType;
        private int typeId;
        private string dataCategory;
        private List<string> errores;
        private bool errorSemantico;
        private bool errorSintactico;
        private int symbolId;
        private int lineId;
        public WordsCollection()
        {
            Word = string.Empty;
            dataType = string.Empty;
            Errores = new List<string>();
            ErrorSemantico = false;
            ErrorSintactico = false;
        }

        public string Word
        {
            get => word;
            set
            {
                word = value;
                OnPropertyChanged("Word");
            }
        }
        public string DataType
        {
            get => dataType;
            set
            {
                dataType = value;
                OnPropertyChanged("DataType");
            }
        }

        public int TypeId { get => typeId;
            set
            {
                typeId = value;
                OnPropertyChanged("TypeId");
            }
        }

        public string DataCategory { get => dataCategory;
            set
            {
                dataCategory = value;
                OnPropertyChanged("DataCategory");
            }
        }
        public int SymbolId { get => symbolId; set => symbolId = value; }
        public int LineId { get => lineId; set => lineId = value; }
        public bool ErrorSemantico { get => errorSemantico; set => errorSemantico = value; }
        public bool ErrorSintactico { get => errorSintactico; set => errorSintactico = value; }
        public List<string> Errores { get => errores; set => errores = value; }
    }
}
