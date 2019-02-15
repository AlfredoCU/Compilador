using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManejoDeErrores
{
   public class TE
    {
        // Tabla de errores (Número de linea, Error, Solución del error, Descripción del error).
        public List<TablaErrores> TErrores = new List<TablaErrores>();
        public List<TablaErrores> TErroresEd = new List<TablaErrores>();

        public TE() { }

        public List<TablaErrores> TablaErrores
        {
            get { return TErrores; }
            set { TErrores = value; }
        }

        // Limpiar lista.
        public void ReiniciaLista()
        {
            TErrores.Clear();
            TErroresEd.Clear();
        }

        // Iniciar reconocimiento de errores.
        public void IniciaError(){
            TablaErrores te = new TablaErrores(0, "Valor incorrecto", "Escriba el valor aceptado por el tipo de variable", "Valor diferente al aceptado por el tipo");
            TErrores.Add(te);
            TablaErrores te1 = new TablaErrores(1, "Se espera un valor", "Escriba un valor para la variable ", "Se espera un valor despues de...");
            TErrores.Add(te1);
            TablaErrores te2 = new TablaErrores(2, "Error al abrir", "Revise la extencion del archivo o  la direccion del mismo", "Error al abrir el archivo");
            TErrores.Add(te2);
            TablaErrores te3 = new TablaErrores(3, "Error aritmetico", "Revise la operación que esta realizando", "Excepciones producidas durante operaciones aritméticas");
            TErrores.Add(te3);
            TablaErrores te4 = new TablaErrores(4, "Error dividir por cero ", "Escoja otro numero que no sea el 0 para dividir", "Posible incongruencia en divicion,o en cualquier operación");
            TErrores.Add(te4);
            TablaErrores te5 = new TablaErrores(5, "Error de conversion de tipo", "Verifique que los tipos de las variables sea el mismo ", "Se produce cuando tiene lugar un error en tiempo de ejecución en una conversión explícita de un tipo base a una interfaz o a un tipo derivado");
            TErrores.Add(te5);
            TablaErrores te6 = new TablaErrores(6, "Error referencia nula", "Revise que esta dando un valor ala variable", "Se produce al intentar hacer referencia a un objeto cuyo valor es null");
            TErrores.Add(te6);
            TablaErrores te7 = new TablaErrores(7, "Error de desbordamiento", "Asegurese del tamaño del resultado ", "Se produce cuando una operación aritmética en un contexto produce un desbordamiento");
            TErrores.Add(te7);
            TablaErrores te8 = new TablaErrores(8, "Error de Ambito", "Asegurese de que las llaves '{' tengan su contraparte '}' ", "Se produce cuando hay alguna llave sin cerrar, ambito incompleto");
            TErrores.Add(te8);
            TablaErrores te9 = new TablaErrores(9, "Sintaxis desconocida", "Asegurese de que la sintaxis sea correcta ", "Se produce cuando se desconoce la sintaxis de la sentencia");
            TErrores.Add(te9);
            TablaErrores te10 = new TablaErrores(10, "Sintaxis erronea", "Asegurese de que la sintaxis sea correcta, Verifique espacios ", "Se produce cuando la sintaxis de la sentencia contiene algun error");
            TErrores.Add(te10);
            // TablaErrores te11 = new TablaErrores(11, "Warning", "Asegurese de que las variables no esten repetidas ", "Se produce cuando más de una variable estan inicializadas con el mismo nombre");
            // TErrores.Add(te11);
        }

        // Retornar tabla de errores.
        public List<TablaErrores> LlamaTablaE()
        {
            return TErroresEd;
        }

        // Agragar elementos a la lista.
        public void addLista(int id,int nl)
        {
            foreach (var error in TErrores)
            {
                if (error.IdError == id)
                {
                    TablaErrores er = new TablaErrores();
                    er.DescripcionError = error.DescripcionError;
                    er.Solucion = error.Solucion;
                    er.Error = error.Error;
                    er.NumeroDeLinea = nl;
                    TErroresEd.Add(er);
                }
            }
        }

        // Agragar elementos a la lista.
        public void addLista(int id)
        {
            foreach (var error in TErrores)
            {
                if (error.IdError == id)
                {
                    TablaErrores er = new TablaErrores();
                    er.DescripcionError = error.DescripcionError;
                    er.Solucion = error.Solucion;
                    er.IdError = error.IdError;
                    TErroresEd.Add(er);
                }
            }
        }
    }
}