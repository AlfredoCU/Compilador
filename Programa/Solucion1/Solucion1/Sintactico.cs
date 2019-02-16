using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion1
{
    class Sintactico
    {
        private int[,] tablaLR;
        private Rule[] rules;
        private Lexico aLexico;
        private Stack pila;
        private Semantico aSemantico;

        public Sintactico(int [,]LR,Rule[] rs)
        {
            TablaLR = LR;
            Rules = rs;
            ALexico = new Lexico();
            ASemantico = new Semantico();
            ColaSintactica = new Stack();
        }
        public void InitializeLexico(string t)
        {
            ALexico.ClearText();
            ALexico.setText(t);
        }
        public WordsCollection Analiza()
        {
            WordsCollection currentSymbol = new WordsCollection();  //Simbolo Actual obtenido del 
            int x = 0;  //Fila
            int y = 0;  //Columna
            int r = 0;  //Resultado (regla, desplazamiento o aceptacion)
            Estado fila = new Estado(0);

            int pops = 0;   //Cantidad de elementos que produce la regla
            bool error = false; //Bandera que detiene el ciclo
            bool newSymbol = true;  //Decide si se necesita un nuevo simbolo del Lexico o no

            //Inicializa cola
            ColaSintactica.Push(new Estado(0));
            Node Root = new Node();

            //Ciclo que ejecuta el analisis sintactico
            while (!error)
            {
                if(newSymbol)
                    currentSymbol = ALexico.sigSimbolo();
                //x = (int)pila.Peek();
                x = ((Estado)pila.Peek()).transicion;
                y = currentSymbol.TypeId;

                r = TablaLR[x, y];
                Node nodo = new Node();
                nodo = null;

                if (r > 0)
                {
                    //Desplazamiento
                    //pila.Push(currentSymbol);
                    pila.Push(new Terminal(currentSymbol.Word));
                    //pila.Push(r);
                    pila.Push(new Estado(r));
                    newSymbol = true;
                }
                else if (r < 0)
                {
                    //Regla
                    r = Math.Abs(r) - 1;
                    if (r == 0)
                    {
                        //Cadena Aceptada
                        break;
                    }
                    // Obtencion de la cantidad de POPs a realizar en la cola.
                    
                    switch (r)
                    {

                        //case 1:  //<programa> ::= <Definiciones> 
                        //nodo=new  programa(pila);
                        //			break;

                        case 3://<Definiciones> ::= <Definicion> <Definiciones>
                        case 16://<DefLocales> ::= <DefLocal> <DefLocales> 	
                        case 20://<Sentencias> ::= <Sentencia> <Sentencias>
                        case 32://<Argumentos> ::= <Expresion> <ListaArgumentos> 
                            pila.Pop();//quita estado
                            Node aux = (Node) pila.Pop();//quita <definiciones>
                            pila.Pop();//quita estado
                            nodo = (Node)pila.Pop();//quita <definicion>
                            if(nodo!=null)
                                nodo.Siguiente = aux;
                            break;
                        case 1:
                        case 4://<Definicion> ::= <DefVar>
                        case 5://<Definicion> ::= <DefFunc> 
                        case 17://<DefLocal> ::= <DefVar> 
                        case 18://<DefLocal> ::= <Sentencia> 
                        case 35://<Atomo> ::= <LlamadaFunc> 
                        case 39://<SentenciaBloque> ::= <Sentencia> 
                        case 40://<SentenciaBloque> ::= <Bloque> 
                        case 50://<Expresion> ::= <Atomo>
                            pila.Pop();//quita estado
                            nodo = (Node)pila.Pop();//quita defvar
                            break;

                        case 6:// <DefVar> ::= tipo id <ListaVar> ;
                            nodo = new DefVar(ref pila);

                            break;

                        case 8:  //<ListaVar> ::= , id <ListaVar>
                            pila.Pop();//quita estado
                            Node lvar = ((Node)pila.Pop());
                            pila.Pop();//quita estado
                            nodo = new Identificador(((Terminal)pila.Pop()).nodo.Simbolo);//quita id
                            nodo.Siguiente = lvar;
                            pila.Pop();//quita estado
                            pila.Pop();//quita la coma
                            break;

                        case 9://<DefFunc> ::= tipo id ( <Parametros> ) <BloqFunc>
                            nodo = new DefFunc(ref pila);
                            break;

                        case 11://<Parametros> ::= tipo id <ListaParam>
                            nodo = new Parametros(ref pila);
                            break;

                        case 13://<ListaParam> ::= , tipo id <ListaParam>
                            nodo = new Parametros(ref pila);
                            pila.Pop();//quita estado;
                            pila.Pop();//quita la coma
                            break;

                        case 14://<BloqFunc> ::= { <DefLocales> }
                        case 30://<Bloque> ::= { <Sentencias> } 
                        case 41://<Expresion> ::= ( <Expresion> ) 
                            pila.Pop();//quita estado
                            pila.Pop();//quita }
                            pila.Pop();//quita estado
                            nodo = ((Node)pila.Pop());//quita <deflocales> o <sentencias>
                            pila.Pop();
                            pila.Pop();//quita la {
                            break;

                        case 21: //<Sentencia> ::= id = <Expresion> ;
                            nodo = new Asignacion(ref pila);
                            break;

                        case 22://<Sentencia> ::= if ( <Expresion> ) <SentenciaBloque> <Otro>
                            nodo = new If(ref pila);
                            break;

                        case 23://<Sentencia> ::= while ( <Expresion> ) <Bloque> 
                            nodo = new While(ref pila);
                            break;

                        case 24://<Sentencia> ::= do <Bloque> while ( <Expresion> ) ;
                            nodo = new DoWhile(ref pila);
                            break;

                        case 25://<Sentencia> ::= for id = <Expresion> : <Expresion> : <Expresion> <SentenciaBloque>
                            nodo = new For(ref pila);
                            break;

                        case 26://<Sentencia> ::= return <Expresion> ;
                            nodo = new Return(ref pila);
                            break;

                        case 27://<Sentencia> ::= <LlamadaFunc> ; 
                            pila.Pop();
                            pila.Pop();//quita ;
                            pila.Pop();
                            nodo = ((Node)pila.Pop());//quita llamadafunc
                            break;

                        case 29://<Otro> ::= else <SentenciaBloque> 
                            pila.Pop();
                            nodo = ((Node)pila.Pop());//quita sentencia bloque
                            pila.Pop();
                            pila.Pop();//quita el else
                            break;

                        case 34:// <ListaArgumentos> ::= , <Expresion> <ListaArgumentos> 

                            pila.Pop();
                            aux = ((Node)pila.Pop());//quita la lsta de argumentos
                            pila.Pop();
                            nodo = ((Node)pila.Pop());//quita expresion
                            pila.Pop();
                            pila.Pop();//quita la ,
                            nodo.Siguiente = aux;
                            break;

                        case 36:
                            pila.Pop();
                            nodo = new Identificador(((Terminal)pila.Pop()).nodo.Simbolo);
                            break;

                        case 37:
                            pila.Pop();
                            nodo = new Constante(((Terminal)pila.Pop()).nodo.Simbolo);
                            break;
                        case 38:
                            nodo = new LlamadaFunc(ref pila);
                            break;
                        //R42 < Expresion > ::= opSuma < Expresion >
                        //R43 < Expresion > ::= opNot < Expresion >
                        case 42:
                        case 43:
                            nodo = new Operacion1(ref pila);
                            break;
                        //R44 < Expresion > ::= < Expresion > opMul < Expresion >
                        //R45 < Expresion > ::= < Expresion > opSuma < Expresion >
                        //R46 < Expresion > ::= < Expresion > opRelac < Expresion >
                        //R47 < Expresion > ::= < Expresion > opIgualdad < Expresion >
                        //R48 < Expresion > ::= < Expresion > opAnd < Expresion >
                        //R49 < Expresion > ::= < Expresion > opOr < Expresion >
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                            nodo = new Operacion2(ref pila);
                            break;
                     
                        //aqui cae R2,R7,R10,R12,R15,R19,R28,R31,R33,
                        default:
                            pops = Rules.ElementAt(r).TotalProductions;

                            if (pops > 0)
                            {
                                while (pops > 0)
                                {
                                    pila.Pop();
                                    pila.Pop();
                                    pops--;
                                }
                            }
                            break;
                    }
                    //x = (int)pila.Peek();
                    x = ((Estado)pila.Peek()).transicion; //((Estado)pila.Peek()).numestado;

                    y = rules.ElementAt(r).Id; //columna= idreglas[regla];
                    NoTerminal nt = new NoTerminal(y); //NoTerminal NT =new NoTerminal(idreglas[regla]);
                    //nt.nodo = nodo;
                    //pila.Push(rules.ElementAt(r).Id);
                    pila.Push(nodo);

                    r = tablaLR[x, y]; //transicion = tabla[fila][columna];
                    //pila.Push(r);
                    pila.Push(new Estado(r));
                    newSymbol = false;
                    Root = nodo;
                }
                else
                    //Error
                    error = true;
            }

            Root.validatipos(ASemantico.Simbolos, ASemantico.Errores);
            if (error)
            {
                currentSymbol.ErrorSintactico = true;
            }
            if (ASemantico.Errores.Count > 0)
            {
                currentSymbol.ErrorSemantico = true;
                currentSymbol.Errores = ASemantico.Errores;
                error = true;
            }
            

            return error ? currentSymbol : null;
        }
        public int[,] TablaLR { get => tablaLR; set => tablaLR = value; }
        internal Rule[] Rules { get => rules; set => rules = value; }
        internal Lexico ALexico { get => aLexico; set => aLexico = value; }
        public Stack ColaSintactica { get => pila; set => pila = value; }
        public Semantico ASemantico { get => aSemantico; set => aSemantico = value; }
    }

    class Rule
    {
        private int id;
        private int totalProductions;
        private string ruleName;
        public Rule()
        {
            RuleName = string.Empty;
        }

        public int Id { get => id; set => id = value; }
        public int TotalProductions { get => totalProductions; set => totalProductions = value; }
        public string RuleName { get => ruleName; set => ruleName = value; }
    }
}
