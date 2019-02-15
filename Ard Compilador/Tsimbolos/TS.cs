using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManejoDeErrores;

namespace Tsimbolos
{
    public  class TS
    {
        public List<TablaDeSimbolos> tablaSimbolos = new List<TablaDeSimbolos>();
        TE tablaErrores = new TE();

        public TS() { }

        public List<TablaDeSimbolos> TablaSimbolos
        {
            get { return tablaSimbolos; }
            set { tablaSimbolos = value; }
        }
      
        public void reinicialista()
        {
            tablaSimbolos.Clear();
        }

        public void inicialista()
        {
            // Comentarios.
            TablaDeSimbolos ts = new TablaDeSimbolos("<</","",-0,-0,-0,0,"Comentario","Inicio de un comentario de mas de una linea","");
            tablaSimbolos.Add(ts);
            TablaDeSimbolos ts1 = new TablaDeSimbolos("/>>", "", -0, -0, -0, 1, "Comentario", "Final de un comentario de mas de una linea", "");
            tablaSimbolos.Add(ts1);
            TablaDeSimbolos ts2 = new TablaDeSimbolos("<<", "", -0, -0, -0, 2, "Comentario", "Inicio de un comentario de una linea", "");
            tablaSimbolos.Add(ts2);
            TablaDeSimbolos ts3 = new TablaDeSimbolos(">>", "", -0, -0, -0, 3, "Comentario", "Final de un comentario de una linea", "");
            tablaSimbolos.Add(ts3);
            // Bloques.
            TablaDeSimbolos ts4 = new TablaDeSimbolos("{", "", -0, -0, -0, 4, "Bloque", "Inicio de un bloque", "");
            tablaSimbolos.Add(ts4);
            TablaDeSimbolos ts5 = new TablaDeSimbolos("}", "", -0, -0, -0, 5, "Bloque", "Final de un bloque", "");
            tablaSimbolos.Add(ts5);
            // Palabra reservada.
            TablaDeSimbolos ts6 = new TablaDeSimbolos("<#int", "", -0, -0, -0, 6, "Palabra reservada", "Número entero", "");
            tablaSimbolos.Add(ts6);
            TablaDeSimbolos ts7 = new TablaDeSimbolos("<#integer", "", -0, -0, -0, 7, "Palabra reservada", "Número entero", "");
            tablaSimbolos.Add(ts7);
            TablaDeSimbolos ts8 = new TablaDeSimbolos("<#double", "", -0, -0, -0, 8, "Palabra reservada", "Numero con decimales", "");
            tablaSimbolos.Add(ts8);
            TablaDeSimbolos ts9 = new TablaDeSimbolos("<#string", "", -0, -0, -0, 9, "Palabra reservada", "Cadena de caracteres", "");
            tablaSimbolos.Add(ts9);
            TablaDeSimbolos ts10 = new TablaDeSimbolos("<#bool", "", -0, -0, -0, 10, "Palabra reservada", "Booleano true o false", "");
            tablaSimbolos.Add(ts10);
            TablaDeSimbolos ts11 = new TablaDeSimbolos("<#boolean", "", -0, -0, -0, 11, "Palabra reservada", "Booleano true o false", "");
            tablaSimbolos.Add(ts11);
            // Asignación, posicionador, inidicador de texto y arreglos.
            TablaDeSimbolos ts12 = new TablaDeSimbolos(":", "", -0, -0, -0, 12, "Asignación", "Simbolo de asignacion", "");
            tablaSimbolos.Add(ts12);
            TablaDeSimbolos ts13 = new TablaDeSimbolos(";", "", -0, -0, -0, 13, "Posicionador", "Final de linea", "");
            tablaSimbolos.Add(ts13);
            TablaDeSimbolos ts14 = new TablaDeSimbolos("'", "", -0, -0, -0, 14, "Indicador de texto", "Inicio y final de un texto", "");
            tablaSimbolos.Add(ts14);
            TablaDeSimbolos ts15 = new TablaDeSimbolos("&/", "", -0, -0, -0, 15, "Posicionador", "Salto de linea en un texto", "");
            tablaSimbolos.Add(ts15);
            TablaDeSimbolos ts16 = new TablaDeSimbolos("[", "", -0, -0, -0, 16, "Arreglo", "Inicio de asignacion de un arreglo", "");
            tablaSimbolos.Add(ts16);
            TablaDeSimbolos ts17 = new TablaDeSimbolos("]", "", -0, -0, -0, 17, "Arreglo", "Final de asignacion de un arreglo", "");
            tablaSimbolos.Add(ts17);
            // Operador
            TablaDeSimbolos ts18 = new TablaDeSimbolos("+", "", -0, -0, -0, 18, "Operador", "Suma", "");
            tablaSimbolos.Add(ts18);
            //TablaDeSimbolos ts19 = new TablaDeSimbolos("+", "", -0, -0, -0, 19, "Concatenador", "Concatenador de elementos");
            //tablaSimbolos.Add(ts19);
            TablaDeSimbolos ts20 = new TablaDeSimbolos("-", "", -0, -0, -0, 20, "Operador", "Resta", "");
            tablaSimbolos.Add(ts20);
            TablaDeSimbolos ts21 = new TablaDeSimbolos("*", "", -0, -0, -0, 21, "Operador", "Multiplicacion", "");
            tablaSimbolos.Add(ts21);
            TablaDeSimbolos ts22 = new TablaDeSimbolos("/", "", -0, -0, -0, 22, "Operador", "Division", "");
            tablaSimbolos.Add(ts22);
            // Signos relacionador y comparador.
            TablaDeSimbolos ts23 = new TablaDeSimbolos("!", "", -0, -0, -0, 23, "Signo relacionador", "Negacion", "");
            tablaSimbolos.Add(ts23);
            TablaDeSimbolos ts24 = new TablaDeSimbolos(">", "", -0, -0, -0, 24, "Signo comparador", "Mayor que", "");
            tablaSimbolos.Add(ts24);
            TablaDeSimbolos ts25 = new TablaDeSimbolos("<", "", -0, -0, -0, 25, "Signo comparador", "Menor que", "");
            tablaSimbolos.Add(ts25);
            TablaDeSimbolos ts26 = new TablaDeSimbolos(">:", "", -0, -0, -0, 26, "Signo comparador", "Mayor o igual que", "");
            tablaSimbolos.Add(ts26);
            TablaDeSimbolos ts27 = new TablaDeSimbolos("<:", "", -0, -0, -0, 27, "Signo comparador", "Menor o igual que", "");
            tablaSimbolos.Add(ts27);
            TablaDeSimbolos ts28 = new TablaDeSimbolos("&", "", -0, -0, -0, 28, "Signo relacionador", "Expresion y (and)", "");
            tablaSimbolos.Add(ts28);
            TablaDeSimbolos ts29 = new TablaDeSimbolos("||", "", -0, -0, -0, 29, "Signo relacionador", "Expresion or", "");
            tablaSimbolos.Add(ts29);
            TablaDeSimbolos ts30 = new TablaDeSimbolos("::", "", -0, -0, -0, 30, "Signo comparador", "Expresion igual", "");
            tablaSimbolos.Add(ts30);
            TablaDeSimbolos ts31 = new TablaDeSimbolos("!:", "", -0, -0, -0, 31, "Signo comparador", "Expresion distinto", "");
            tablaSimbolos.Add(ts31);
            // Palabra reservada.
            TablaDeSimbolos ts32 = new TablaDeSimbolos("<<si_", "", -0, -0, -0, 32, "Palabra reservada", "Si tal condicion se cumple", "");
            tablaSimbolos.Add(ts32);
            TablaDeSimbolos ts33 = new TablaDeSimbolos("<<ysi_", "", -0, -0, -0, 33, "Palabra reservada", "Y si tal condicion se cumple en vez de la anterior", "");
            tablaSimbolos.Add(ts33);
            TablaDeSimbolos ts34 = new TablaDeSimbolos("<<sino", "", -0, -0, -0, 34, "Palabra reservada", "Si no se cumple la condicion", "");
            tablaSimbolos.Add(ts34);
            TablaDeSimbolos ts35 = new TablaDeSimbolos("#ncasd", "", -0, -0, -0, 35, "Palabra reservada", "Opciones (casos)", "");
            tablaSimbolos.Add(ts35);
            TablaDeSimbolos ts36 = new TablaDeSimbolos("casd", "", -0, -0, -0, 36, "Palabra reservada", "Caso", "");
            tablaSimbolos.Add(ts36);
            TablaDeSimbolos ts37 = new TablaDeSimbolos("fcasd", "", -0, -0, -0, 37, "Palabra reservada", "Final del caso", "");
            tablaSimbolos.Add(ts37);
            TablaDeSimbolos ts38 = new TablaDeSimbolos("#mintrs", "", -0, -0, -0, 38, "Palabra reservada", "Mientras", "");
            tablaSimbolos.Add(ts38);
            TablaDeSimbolos ts39 = new TablaDeSimbolos("#pr", "", -0, -0, -0, 39, "Palabra reservada", "For", "");
            tablaSimbolos.Add(ts39);
            TablaDeSimbolos ts40 = new TablaDeSimbolos("#prlist", "", -0, -0, -0, 40, "Palabra reservada", "Foreach", "");
            tablaSimbolos.Add(ts40);
            TablaDeSimbolos ts41 = new TablaDeSimbolos("#funcion", "", -0, -0, -0, 41, "Palabra reservada", "Expresion para determinar un metodo", "");
            tablaSimbolos.Add(ts41);
            TablaDeSimbolos ts42 = new TablaDeSimbolos("#try", "", -0, -0, -0, 42, "Palabra reservada", "Intenta realizar el codigo contenido", "");
            tablaSimbolos.Add(ts42);
            TablaDeSimbolos ts43 = new TablaDeSimbolos("#catch", "", -0, -0, -0, 43, "Palabra reservada", "Muestra una accion a seguir en caso de error", "");
            tablaSimbolos.Add(ts43);
            TablaDeSimbolos ts44 = new TablaDeSimbolos("#mostrar", "", -0, -0, -0, 44, "Palabra reservada", "Muestra en consola", "");
            tablaSimbolos.Add(ts44);
            TablaDeSimbolos ts45 = new TablaDeSimbolos("#leer", "", -0, -0, -0, 45, "Palabra reservada", "Pide en consola", "");
            tablaSimbolos.Add(ts45);
            TablaDeSimbolos ts46 = new TablaDeSimbolos("#ejc", "", -0, -0, -0, 46, "Palabra reservada", "Ejecuta setencia", "");
            tablaSimbolos.Add(ts46);
            TablaDeSimbolos ts47 = new TablaDeSimbolos("#clase", "", -0, -0, -0, 47, "Palabra reservada", "Clase", "");
            tablaSimbolos.Add(ts47);
            // Parametro y concatenador.
            TablaDeSimbolos ts48 = new TablaDeSimbolos("(", "", -0, -0, -0, 48, "Parametro", "Inicia peticion de parametro", "");
            tablaSimbolos.Add(ts48);
            TablaDeSimbolos ts49 = new TablaDeSimbolos(")", "", -0, -0, -0, 49, "Parametro", "Termina peticion de parametro", "");
            tablaSimbolos.Add(ts49);
            TablaDeSimbolos ts50 = new TablaDeSimbolos(",", "", -0, -0, -0, 50, "Concatenador", "Concatena variables", "");
            tablaSimbolos.Add(ts50);
            //---------------------------------------------Así deberian entrar los datos nuevos encontrados-------------------------------------------------
            //TablaDeSimbolos ts51 = new TablaDeSimbolos("", "", -0, -0, -0, 51, "Número", "Especifica un Numero");
            //tablaSimbolos.Add(ts51);
            //TablaDeSimbolos ts52 = new TablaDeSimbolos("", "", -0, -0, -0, 52, "Identificador", "Especifica una palabra que identifica una variable");
            //tablaSimbolos.Add(ts52);
            //----------------------------------------------------------------------------------------------------------------------------------------------
        }

        // Retorna la tabla de simbolos.
        public List<TablaDeSimbolos> LlamaTabla()
        {
            return tablaSimbolos;
        }

        // Añadir elementos en la lista.
        public void AñadirObj(TablaDeSimbolos Ts )
        {
            tablaSimbolos.Add(Ts);
        }

        //  Compara las palabras AL.
        public bool CompararAL(string argsplit)
        {
            bool bandera = false;
            foreach (var palabra in tablaSimbolos)
            {
                if (palabra.Simbolo == argsplit)
                {
                    bandera = true;
                    break;
                }
                else
                {
                    bandera = false;
                }
            }
            return bandera;
        }

        // Revisa palabras duplicadas.
        public bool RevisarDuplicados()
        {
            bool flag = false;
            foreach (var sent1 in tablaSimbolos)
            {
                foreach (var sent2 in tablaSimbolos)
                {
                    if (sent1.IdSimbolo == sent2.IdSimbolo)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        // Comparar Semtantica.
        public void compararALSemantica()
        {
            foreach (var palabra in tablaSimbolos)
            {
                foreach (var palabra2 in tablaSimbolos)
                {
                    if (palabra.Simbolo == palabra2.Simbolo)
                    {
                        palabra2.TipoVar = palabra.TipoVar;
                    }
                }    
            }
        }

        // Comparar Al Ref.
        public int compararALRef(string argsplit)
        {
            int id = 0 ;
            foreach (var palabra in tablaSimbolos)
            {
                if (palabra.Simbolo == argsplit)
                {
                    id = palabra.IdSimbolo;
                    break;
                }
                else
                {
                    id = 0;
                }
            }
            return id;
        }

        // Número de linea.
        public int ContLineas ()
        {
            int numid = 0;
            foreach (var nlinea in tablaSimbolos)
            {
                numid = numid + 1;
            }
            return numid-1;
        }
    }
}