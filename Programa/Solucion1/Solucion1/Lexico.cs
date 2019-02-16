using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion1
{
    class Lexico
    {
        private string cadena;
        private WordsCollection simbolo;
        private int estado;
        private int indice;
        private char c;
        private bool continua;
        private int idSimbolo;
        private int idLinea;
        public Lexico() {
            c = ' ';
            estado = 0;
            indice = -1;
            //tipo = string.Empty;
            simbolo = new WordsCollection();
            idSimbolo = 1;
            idLinea = 1;
        }

        public void setText(string texto)
        {
            cadena = texto + "$";
            indice = -1;
        }
        public void ClearText()
        {
            cadena = string.Empty;
        }

        public void sigEstado(int e)
        {
            estado = e;
            simbolo.Word += c;
        }

        public WordsCollection sigSimbolo()
        {
            continua = true;
            estado = 0;
            simbolo = new WordsCollection();

            try
            {
                while (continua)
                {
                    indice++;
                    c = sigChar(indice);

                    switch (estado)
                    {
                        case 0:
                            if (c == ' ' || c == '\n' || c == '\t')
                            {
                                continua = true; //ignorar
                                if (c == '\n' || c == '\r')
                                    idLinea++;
                            }

                            else if (Char.IsLetter(c) || c == '_')
                            {
                                sigEstado(1); //Identificador
                            }
                            else if (Char.IsDigit(c))
                            {
                                sigEstado(2); //numero
                            }
                            else if (isOpRelac(c))
                            {
                                //simbolo.Word += c;
                                sigEstado(3); //operador relacional <= o >=
                            }
                            else if (isOpMul(c))
                            {
                                //simbolo.Word += c;
                                sigEstado(4); // * o /
                            }
                            else if (isOpAdic(c))
                            {
                                //simbolo.Word += c;
                                sigEstado(5); // + o -
                            }
                            else if (isParent(c))
                            {
                                //simbolo.Word += c;
                                sigEstado(6); // ( o )
                            }
                            else if (isPyC(c))
                            {

                                sigEstado(7); // ;
                            }
                            else if (isLlave(c))
                            {

                                sigEstado(8); //
                            }
                            else if (isOpAND(c))
                            {

                                sigEstado(9); //&&
                            }
                            else if (isOpOR(c))
                            {

                                sigEstado(10); //
                            }
                            else if (isOpAsig(c))
                            {

                                sigEstado(11); // =
                            }
                            else if (c == '!')
                            {
                                sigEstado(17);
                            }
                            else if (c == ',')
                            {
                                sigEstado(18);
                            }
                            else if (c == '$')
                            {
                                simbolo.Word += c;
                                simbolo.TypeId = 24;
                                simbolo.DataCategory = "Fin Cadena";
                                simbolo.DataType = "$";
                                continua = false;
                            }

                            break;
                        case 1:
                            if (isPalabraR(simbolo.Word))
                            {
                                if (!Char.IsLetterOrDigit(c)) aceptacion(4);  // 4 -> palabra reservada
                                else
                                {
                                    //simbolo.Word += c;
                                    sigEstado(1);
                                }
                            }else if (isTipoDato(simbolo.Word))
                            {
                                if (!Char.IsLetterOrDigit(c)) aceptacion(5);  // 5 -> tipo de dato
                                else
                                {
                                  //  simbolo.Word += c;
                                    sigEstado(1);
                                }
                            }
                            else if (Char.IsLetterOrDigit(c) || c == '_')
                            {
                                //simbolo.Word += c;
                                sigEstado(1);
                            }
                            else
                                aceptacion(estado);  // 1 -> identificador
                            break;
                        case 2:
                            if (Char.IsDigit(c))
                            {
                                //simbolo.Word += c;
                                sigEstado(2); // 23234 int
                            }
                            else if (c == '.')
                            {
                                //simbolo.Word += c;
                                sigEstado(12); // 3.34 real
                            }
                            else aceptacion(2); // 2 -> entero
                            break;
                        case 3:
                            if (isOpAsig(c)) sigEstado(20); // <= <= relacional
                            else aceptacion(estado); // < > 3 -> relacional
                            break;
                        case 4:
                            if (isOpAsig(c)) sigEstado(19); // *= /=  13 -> asignacion
                            else aceptacion(14);  // * /  14 -> op mult
                            break;
                        case 5:
                            if (isOpAsig(c)) sigEstado(19); // += -= 13 -> asignacion
                            else aceptacion(15);  // + - 15 -> op suma
                            break;
                        case 6:
                            aceptacion(6); // ( ) 6 -> parentesis
                            break;
                        case 7:
                            aceptacion(7); //; 7 -> punto y coma
                            break;
                        case 8:
                            aceptacion(8); // { } 8 -> llaves
                            break;
                        case 9:
                            if (isOpAND(c))
                            {
                                //simbolo.Word += c;
                                sigEstado(13);
                            }
                            break;
                        case 10:
                            if (isOpOR(c))
                            {
                                //simbolo.Word += c;
                                sigEstado(14);
                            }
                            break;
                        case 11:
                            if (isOpAsig(c))
                            {
                                //simbolo.Word += c;
                                sigEstado(16);
                            }
                            else aceptacion(13); // = 13 -> asignacion
                            
                            break;
                        case 12:
                            if (Char.IsDigit(c))
                            {
                                //simbolo.Word += c;
                                sigEstado(2); // 2.4442
                            }
                            else aceptacion(estado); // 2 -> entero
                            break;
                        case 13:
                            aceptacion(9); // && 9 -> AND
                            break;
                        case 14:
                            aceptacion(10); // || 10 -> OR
                            break;
                        case 15:
                            if (isOpAsig(c))
                            {
                                //simbolo.Word += c;
                                sigEstado(16);
                            }
                            else aceptacion(13); // = 13 -> asignacion
                            break;
                        case 16:
                            aceptacion(12); // == 12 -> op igualdad
                            break;
                        case 17:
                            if (isOpAsig(c))
                            {
                                sigEstado(16);
                            }
                            else aceptacion(16);
                            break;
                        case 18:
                            aceptacion(11);
                            break;
                        case 19:
                            aceptacion(13);                          
                            break;
                        case 20:
                            aceptacion(3);
                            break;


                    }
                }
                return simbolo;
            }
            catch (Exception ex) {
                throw new Exception("Error " + ex.Message);
            }
        }
        #region CheckChars
        private char sigChar(int indice)
        {
            return cadena.ElementAt(indice);
        }
        //Functions to determine char type
        public bool isOpAsig(char x)
        {
            return x == '=';
        }
        public bool isOpAdic(char x)
        {
            return (x == '+' || x == '-');
        }
        public bool isOpMul(char x)
        {
            return (x == '*' || x == '/');
        }

        public bool isParent(char x)
        {
            return (x == '(' || x == ')');
        }

        public bool isPyC(char x)
        {
            return x == ';';
        }

        public bool isOpRelac(char x)
        {
            return (x == '>' || x == '<');
        }

        public bool isOpAND(char x)
        {
            return x == '&';
        }

        public bool isOpOR(char x)
        {
            return x == '|';
        }

        public bool isLlave(char x)
        {
            return (x == '{' || x == '}');
        }

        public bool isPalabraR(string x)
        {
            return ("while".Equals(x) || "do".Equals(x) || "if".Equals(x) || "else".Equals(x) || "for".Equals(x) || "return".Equals(x) || "true".Equals(x) || "false".Equals(x) || "switch".Equals(x));
        }

        public bool isTipoDato(string x)
        {
            return ("int".Equals(x) || "double".Equals(x) || "float".Equals(x) || "bool".Equals(x) || "string".Equals(x) || "char".Equals(x));
        }
        #endregion
        public void aceptacion(int e)
        {
            continua = false;
            indice--;
            
            simbolo.SymbolId = idSimbolo;
            idSimbolo++;
            simbolo.LineId = idLinea;
            //Switch de estados de aceptacion
            switch (e)
            {
                case 1:
                    simbolo.DataCategory = "Identificador";
                    simbolo.TypeId = 0;
                    simbolo.DataType = "Id";
                    break;
                case 2:
                    simbolo.DataCategory = "Numero";
                    simbolo.TypeId = 1;
                    simbolo.DataType = "Constante";
                    break;
                case 3:
                    simbolo.DataCategory = "Operacion Relacional";
                    simbolo.TypeId = 5;
                    simbolo.DataType = "opRelac";
                    break;
                case 4:
                    simbolo.DataCategory = "Palabra Reservada";
                    switch (simbolo.Word)
                    {
                        case "if":
                            simbolo.TypeId = 17;
                            simbolo.DataType = "if";
                            break;
                        case "while":
                            simbolo.TypeId = 18;
                            simbolo.DataType = "while";
                            break;
                        case "do":
                            simbolo.TypeId = 19;
                            simbolo.DataType = "do";
                            break;
                        case "for":
                            simbolo.TypeId = 20;
                            simbolo.DataType = "for";
                            break;
                        case "return":
                            simbolo.TypeId = 22;
                            simbolo.DataType = "return";
                            break;
                        case "else":
                            simbolo.TypeId = 23;
                            simbolo.DataType = "else";
                            break;
                        default:
                            simbolo.TypeId = 25;
                            simbolo.DataType = string.Empty;
                            break;
                    }
                    break;
                case 5:
                    simbolo.DataCategory = "Tipo de Dato";
                    simbolo.TypeId = 2;
                    simbolo.DataType = "tipo";
                    break;
                case 6:
                    simbolo.DataCategory = "Parentesis";
                    if (simbolo.Word == "(")
                    {
                        simbolo.TypeId = 12;
                        simbolo.DataType = "(";
                    }
                    else if (simbolo.Word == ")")
                    {
                        simbolo.TypeId = 13;
                        simbolo.DataType = ")";
                    }
                    break;
                case 7:
                    simbolo.DataCategory = "Punto y Coma";
                    simbolo.TypeId = 10;
                    simbolo.DataType = ";";
                    break;
                case 8:
                    simbolo.DataCategory = "Llaves";
                    if (simbolo.Word == "{")
                    {
                        simbolo.TypeId = 14;
                        simbolo.DataType = "{";
                    }
                    else if (simbolo.Word == "}")
                    {
                        simbolo.TypeId = 15;
                        simbolo.DataType = "}";
                    }
                    break;
                case 9:
                    simbolo.DataCategory = "Operador Logico";
                    simbolo.TypeId = 7;
                    simbolo.DataType = "opAnd";
                    break;
                case 10:
                    simbolo.DataCategory = "Operador Logico";
                    simbolo.TypeId = 6;
                    simbolo.DataType = "opOr";
                    break;
                case 11:
                    simbolo.DataCategory = "Coma";
                    simbolo.TypeId = 11;
                    simbolo.DataType = ";";
                    break;
                case 12:
                    simbolo.DataCategory = "Igualdad";
                    simbolo.TypeId = 9;
                    simbolo.DataType = "igualdad";
                    break;
                case 13:
                    simbolo.DataCategory = "Operador de Asignacion";
                    if (simbolo.Word == "=")
                    {
                        simbolo.TypeId = 16;
                        simbolo.DataType = "=";
                    }
                    break;
                case 14:
                    simbolo.DataCategory = "Operador Aritmetico";
                    simbolo.TypeId = 4;
                    simbolo.DataType = "opMul";
                    break;
                case 15:
                    simbolo.DataCategory = "Operador Aritmetico";
                    simbolo.TypeId = 3;
                    simbolo.DataType = "opSuma";
                    break;
                case 16:
                    simbolo.DataCategory = "Operador Logico";
                    simbolo.TypeId = 8;
                    simbolo.DataType = "opNot";
                    break;
            }
        }
        
    }

}
