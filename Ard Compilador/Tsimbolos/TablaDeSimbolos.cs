using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tsimbolos
{
   public class TablaDeSimbolos
    {
        private string simbolo;
        private string valor;
        private int numLinea;
        private int tamaño;
        private int ambito;
        private int idSimbolo;
        private string tipoVar;
        private string tipo;
        private string descripcion;

        public TablaDeSimbolos() { }

        public TablaDeSimbolos(string simbolo, string valor, int nunlinea, int tamaño, int ambito, int idSimbolo, string tipo, string descripcion, string tipoVar)
        {
            this.simbolo = simbolo;
            this.valor = valor;
            this.numLinea = nunlinea;
            this.tamaño = tamaño;
            this.ambito = ambito;
            this.idSimbolo = idSimbolo;
            this.tipo = tipo;
            this.descripcion = descripcion;
            this.tipoVar = tipoVar;
        }

        public int IdSimbolo
        {
            get { return idSimbolo; }
            set { idSimbolo = value; }
        }

        public string Simbolo
        {
            get { return simbolo; }
            set { simbolo = value; }
        }

       public string TipoVar
        {
            get { return tipoVar; }
            set { tipoVar = value; }
        }

        public int NumeroLinea
        {
            get { return numLinea; }
            set { numLinea = value; }
        }

        public int Ambito
        {
            get { return ambito; }
            set { ambito = value; }
        }

        public int Tamaño
        {
            get { return tamaño; }
            set { tamaño = value; }
        }

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}