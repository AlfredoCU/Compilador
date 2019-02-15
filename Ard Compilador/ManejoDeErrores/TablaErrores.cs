using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManejoDeErrores
{
    public class TablaErrores
    {
        // Tabla de errores (Número de linea, Error, Solución del error, Descripción del error).
        private int idError;
        private int numLineaError;
        private string error;
        private string solucionError;
        private string descripError;

        public TablaErrores() { }

        public TablaErrores(int idError, int numLineaError, string error, string solucionError, string descripError)
        {
            this.idError = idError;
            this.numLineaError = numLineaError;
            this.error = error;
            this.solucionError = solucionError;
            this.descripError = descripError;
        }

        public TablaErrores(int idError, string error, string solucionError, string descripError)
        {
            this.idError = idError;
            this.error = error;
            this.solucionError = solucionError;
            this.descripError = descripError;
        }

        public int IdError
        {
            get { return idError; }
            set { idError = value; }
        }

        public int NumeroDeLinea
        {
            get { return numLineaError; }
            set { numLineaError = value; }
        }

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        public string Solucion
        {
            get { return solucionError; }
            set { solucionError = value; }
        }

        public string DescripcionError
        {
            get { return descripError; }
            set { descripError = value; }
        }
    }
}