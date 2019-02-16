using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion1
{
    public class Node
    {
        private Node siguiente;
        private string simbolo;
        private string clase;
        public string ambito;
        public char tipoDato;
        public string Cadenapa;
        public Node() {
            
        }
        public virtual char dimetipo(Node tipo=null)
        {
            if (tipo.Simbolo == "int")
                return 'i';
            else if (tipo.Simbolo == "float")
                return 'f';
            else if (tipo.Simbolo == "char")
                return 'c';
            else if (tipo.Simbolo == "void")
                return 'v';
            else return 'v';

        }
        public virtual void validatipos(List<object> tabsim, List<string> errores)
        {

            if (siguiente != null) siguiente.validatipos(tabsim, errores);

        }

      

        public Node Siguiente { get => siguiente; set => siguiente = value; }
        public string Clase { get => clase; set => clase = value; }
        public string Simbolo { get => simbolo; set => simbolo = value; }
    }
    public class NoTerminal : Node
    {
        public int columna;
        public Node nodo;

        public NoTerminal(int c)
        {
            columna = c;
            nodo = new Node();
        }
    }
    public class Terminal : Node
    {
        public int columna;
        public Node nodo;

        public Terminal(string c)
        {
            nodo = new Node();
            nodo.Simbolo = c;
        }
    }
    public class Estado : Node
    {
        public int transicion;

        public Estado(int e) { transicion = e; }
    }
    public class Programa:Node
    {
        public Programa(ref Stack pilaSintactica)
        {
            pilaSintactica.Pop();
            Siguiente = (NoTerminal)pilaSintactica.Pop();
        }
    }
    
    public class Identificador : Node
    {
      
        public Identificador(string simbolo)
        {
            Simbolo = simbolo;
            Clase = "Id";         
        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            List<Elementotabla> simb = tabsim.Cast<Elementotabla>().ToList();

            List<Elementotabla> resultado = simb.Where(elem => elem.Id == Simbolo && elem.Ambito == ambito).ToList();

            if (resultado.Count == 0)
            {
                if(Simbolo!="print")
                    errores.Add("La variable " + Simbolo + " no existe en el contexto actual " + ambito);
            }
            else
            {
                tipoDato = resultado[0].Tipo;
            }
            if (Siguiente != null)
            {
                Siguiente.ambito = ambito;
                Siguiente.validatipos(tabsim, errores);
            }
        }
    }
    public class Tipo : Node
    {
        public Tipo(string simbolo)
        {
            Simbolo = simbolo;
            Clase = "Tipo";
        }

    }
    public class DefVar : Node
    {
        public Node tipo;
        public Node id;
        public Node lvar;
        public DefVar(ref Stack pila)
        {
            tipo = new Node();
            id = new Node();
            lvar = new Node();
            pila.Pop();//quita estado
            pila.Pop(); //quita  ;
            pila.Pop(); //quita estado estado
            lvar = (Node)pila.Pop(); //quita ListaVar
            pila.Pop(); //quita estado
            id = new Identificador(((Terminal)pila.Pop()).nodo.Simbolo); //quita Id

            pila.Pop(); //quita estado
            tipo = new Tipo(((Terminal)pila.Pop()).nodo.Simbolo); //quita tipo
            id.tipoDato = tipo.Simbolo[0];
        }
        public DefVar()
        {           
        }

        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            List<Elementotabla> simb = new List<Elementotabla>();
            simb = tabsim.Cast<Elementotabla>().ToList();
            
            List<Elementotabla> result = simb.Where(i => i.Id == id.Simbolo && i.Ambito == ambito).ToList();

            if (result.Count == 0)
            {
                tabsim.Add(new Elementotabla(id.Simbolo, tipo.Simbolo[0], ambito));
            }
            else
            {
                errores.Add("La variable " + id.Simbolo + " ya fue declarada dentro de " + ambito);
            }
            if (lvar != null)
            {
                DefVar aux = new DefVar();
                aux.tipo = tipo;
                //aux.Simbolo = lvar.Simbolo;
                aux.id = lvar;
                if (lvar.Siguiente != null)
                    aux.lvar = lvar.Siguiente;
                aux.ambito = ambito;
                aux.validatipos(tabsim, errores);


            }
            if (Siguiente != null)
            {
                Siguiente.ambito = ambito;
                Siguiente.validatipos(tabsim, errores);
            }
        }

    }
    public class DefFunc : Node
    {
        private Node tipo = new Node();
        private Node id = new Node();
        private Node parametros = new Node();
        private Node bloqueFunc = new Node();


        public DefFunc(ref Stack pila)
        {
            pila.Pop();//quita estado
            bloqueFunc = (Node)pila.Pop();//quita <bloqfunc> //aqui me quede
            pila.Pop();//quita estado
            pila.Pop();//quita )
            pila.Pop();//quita estado
            parametros = (Node)pila.Pop();//quita <parametros>
            pila.Pop();//quita estado
            pila.Pop();//quita (
            pila.Pop();//quita estado
            id = new Identificador(((Terminal)pila.Pop()).nodo.Simbolo);//quita id
            pila.Pop();//quita estado
            tipo = new Tipo(((Terminal)pila.Pop()).nodo.Simbolo);//quita el tipo
            id.tipoDato = tipo.Simbolo[0];
        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            tipoDato = dimetipo(tipo);
            ambito = id.Simbolo;

            if (parametros != null)
            {
                parametros.ambito = ambito;
                parametros.validatipos(tabsim, errores);
                Cadenapa = parametros.Cadenapa;
            }

            //find tipo 
            

            if (!existefunc(tabsim, id.Simbolo,ambito,Cadenapa,errores))
            {
                tabsim.Add(new Elementotabla(id.Simbolo, tipoDato, ambito, Cadenapa));
            }
            else
                errores.Add("La funcion " + id.Simbolo + " ya existe");

            Cadenapa = "";
            if (bloqueFunc != null)
            {
                bloqueFunc.ambito = ambito;
                bloqueFunc.validatipos(tabsim, errores);
            }
            ambito = "";
            if (Siguiente != null) Siguiente.validatipos(tabsim, errores);

        }
        public bool existefunc(List<object> tabsim, string id, string ambito, string cadenapa, List<string> errores)
        {
            bool existe = false;
            List<Elementotabla> simb = new List<Elementotabla>();

            simb = tabsim.Cast<Elementotabla>().ToList();

            Elementotabla r = simb.FirstOrDefault(s => s.Id == id);

            if (r != null)
            {
                existe = true;
                if (r.Stpara == cadenapa)
                {
                    return true;
                }
                else
                {
                    errores.Add("los parametros de la funcion " + id + " son incorrectos");
                }
            }

            //if (!existe) errores.Add("la funcion " + id + " no existe");
            return false;
        }
    }
    public class Parametros : Node
    {
        private Node tipo = new Node();
        private Node id = new Node();
        private Node listaParams = new Node();

        public Parametros(ref Stack pila)
        {

            pila.Pop();//quita estado

            listaParams = (Node)pila.Pop();//quita la lista de aprametros
            pila.Pop();//quita estado
            id = new Identificador(((Terminal)pila.Pop()).nodo.Simbolo);//quita el id
            pila.Pop(); //quita estado

            tipo = new Tipo(((Terminal)pila.Pop()).nodo.Simbolo);//quita el tipo
            id.tipoDato = tipo.Simbolo[0];
        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            tipoDato = dimetipo(tipo);
            if (!Existe(tabsim, id.Simbolo, ambito,errores))
            {
                tabsim.Add(new Elementotabla(id.Simbolo, tipoDato, ambito));
            }
            else
                errores.Add("la variable " + id.Simbolo + " ya fue declarada");
            Cadenapa += tipo.Simbolo[0];
            if (listaParams != null)
            {
                listaParams.ambito = ambito;
                listaParams.validatipos(tabsim, errores);
                Cadenapa += listaParams.Cadenapa;
            }
            
            if (Siguiente != null)
            {
                Siguiente.ambito = ambito;
                Siguiente.validatipos(tabsim, errores);
            }
        }
        public bool Existe(List<object> tabsim, string id, string ambito, List<string> errores)
        {
            List<Elementotabla> simb = new List<Elementotabla>();

            simb = tabsim.Cast<Elementotabla>().ToList();

            Elementotabla r = simb.FirstOrDefault(s => s.Id == id);

            if (r != null)
            {
                return true;
            }

            return false;
        }

    }
    public class Asignacion : Node
    {
        Node id = new Node();
        Node expresion = new Node();
        public Asignacion(ref Stack pila)//<Sentencia> ::= id = <Expresion> ;
        {
            pila.Pop();
            pila.Pop();//quita la ;
            pila.Pop();
            expresion = (Node)pila.Pop();//quita expresion
            pila.Pop();
            pila.Pop();//quita =
            pila.Pop();
            id = new Identificador(((Terminal)pila.Pop()).nodo.Simbolo);//quita id
        }

        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            id.ambito = ambito;
            id.validatipos(tabsim, errores);
            expresion.ambito = ambito;
            expresion.validatipos(tabsim, errores);
            

            //Buscar el tipo de dato de
            List<Elementotabla> simb = tabsim.Cast<Elementotabla>().ToList();
            List<Elementotabla> r = tabsim.Cast<Elementotabla>().ToList();

            r = simb.Where(elemento => elemento.Id == id.Simbolo && elemento.Ambito == ambito).ToList();

            if (r.Count > 0)
            {
                id.tipoDato = r[0].Tipo;

                if (id.tipoDato == 'c' && expresion.tipoDato == 'c')
                {
                    tipoDato = 'c';
                }
                else
                {
                    if (id.tipoDato == 'i' && expresion.tipoDato == 'i')
                    {
                        tipoDato = 'i';
                    }
                    else
                    {
                        if (id.tipoDato == 'f' && expresion.tipoDato == 'f')
                        {
                            tipoDato = 'f';
                        }
                        else
                        {
                            tipoDato = 'e';
                            errores.Add("El tipo de dato de " + id.Simbolo + " en la funcion " + ambito + " es diferente al de la expresion ");

                        }
                    }
                }
            }
            if (expresion.Siguiente != null)
            {
                expresion.ambito = ambito;
                expresion.Siguiente.validatipos(tabsim, errores);
            }
            if (Siguiente != null)
            {
                Siguiente.ambito = ambito;
                Siguiente.validatipos(tabsim, errores);
            }

        }

    }
    public class If : Node
    {
        Node expresion = new Node();
        Node sentenciabloque = new Node();
        Node otro = new Node();

        public If(ref Stack pila)
        {
            pila.Pop();
            otro = (Node)pila.Pop();//quita otro
            pila.Pop();
            sentenciabloque = (Node)pila.Pop();//quita sentencia bloque
            pila.Pop();
            pila.Pop(); //quita )
            pila.Pop();
            expresion = (Node)pila.Pop(); //quita expresion
            pila.Pop();
            pila.Pop(); //quita (
            pila.Pop();
            pila.Pop(); //quita if
        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            otro.ambito = ambito;
            otro.validatipos(tabsim, errores);
            expresion.ambito = ambito;
            expresion.validatipos(tabsim, errores);
            sentenciabloque.ambito = ambito;
            sentenciabloque.validatipos(tabsim, errores);
        }
    }
    public class While : Node
    {
        Node expresion = new Node();
        Node bloque = new Node();

        public While(ref Stack pila)
        {
            pila.Pop();
            bloque = (Node)pila.Pop();//quita bloque
            pila.Pop();
            pila.Pop(); //quita )
            pila.Pop();
            expresion = (Node)pila.Pop(); //quita expresion
            pila.Pop();
            pila.Pop(); //quita (
            pila.Pop();
            pila.Pop(); //quita while
        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            bloque.ambito = ambito;
            expresion.ambito = ambito;

            bloque.validatipos(tabsim, errores);
            expresion.validatipos(tabsim, errores);
        }
    }
    public class DoWhile : Node
    {
        Node bloque = new Node();
        Node expresion = new Node();

        public DoWhile(ref Stack pila)
        {
            pila.Pop();
            pila.Pop();//quita ;
            pila.Pop();
            pila.Pop();//quita )
            pila.Pop();
            expresion = (Node)pila.Pop();//quita exprecion
            pila.Pop();
            pila.Pop();//quita (
            pila.Pop();
            pila.Pop();//quita el while
            pila.Pop();
            bloque = (Node)pila.Pop(); //quita bloque
            pila.Pop();
            pila.Pop();//quita do
        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            bloque.ambito = ambito;
            expresion.ambito = ambito;

            bloque.validatipos(tabsim, errores);
            expresion.validatipos(tabsim, errores);
        }
    }
    public class For : Node
    {
        Node senbloque = new Node();
        Node expresion1 = new Node();
        Node expresion2 = new Node();
        Node expresion3 = new Node();
        Node id = new Node();

        public For(ref Stack pila)
        {
            pila.Pop();
            senbloque = (Node)pila.Pop();//quita senteciabloque
            pila.Pop();
            expresion3 = (Node)pila.Pop();//quita expresion
            pila.Pop();
            pila.Pop();//quita ;
            pila.Pop();
            expresion2 = (Node)pila.Pop();//quita expresion
            pila.Pop();
            expresion1 = (Node)pila.Pop();//quita expresion
            pila.Pop();
            pila.Pop();//quita =
            pila.Pop();
            id = new Identificador(((Terminal)pila.Pop()).nodo.Simbolo);//quita id
            pila.Pop();
            pila.Pop();//quita for
        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            senbloque.ambito = ambito;
            expresion1.ambito = ambito;
            expresion2.ambito = ambito;
            expresion3.ambito = ambito;

            senbloque.validatipos(tabsim, errores);
            expresion1.validatipos(tabsim, errores);
            expresion2.validatipos(tabsim, errores);
            expresion3.validatipos(tabsim, errores);
        }
    }
    public class Return : Node
    {
        Node expresion = new Node();

        public Return(ref Stack pila)
        {
            pila.Pop();
            pila.Pop();//quita ;
            pila.Pop();
            expresion = (Node)pila.Pop();//quita exprecion
            pila.Pop();
            pila.Pop();//quita return
        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            List<Elementotabla> simb = tabsim.Cast<Elementotabla>().ToList();

            expresion.ambito = ambito;
            expresion.validatipos(tabsim, errores);

            List<Elementotabla> result = simb.Where(i => i.Id == ambito && i.Ambito == ambito).ToList();
            if (result.Count > 0)
            {
                if (result[0].Tipo != expresion.tipoDato)
                {
                    errores.Add("La funcion " + ambito + " retorna un valor diferente al declarado");
                }
            }
        }
    }
    public class Constante : Node
    {
        public Constante(string _simbolo)
        {
            Simbolo = _simbolo;
            Clase = "cons";
        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            if (Simbolo.Contains("."))
            {
                tipoDato = 'f';
            }
            else
            {
                tipoDato = 'i';
            }
        }
        public override char dimetipo(Node tipo=null)
        {            
            if (Simbolo.Contains("."))
            {
                return 'f';
            }
            else
            {
                return 'i';
            }           
        }
    }
    public class LlamadaFunc : Node
    {
        Node id = new Node();
        Node argumentos = new Node();

        public LlamadaFunc(ref Stack pila)
        {
            Clase = "fun";
            pila.Pop();
            pila.Pop();//quita )
            pila.Pop();
            argumentos = (Node)pila.Pop();//quita exprecion
            pila.Pop();
            pila.Pop();//quita (
            pila.Pop();
            id = new Identificador(((Terminal)pila.Pop()).nodo.Simbolo);//quita id
        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            Node aux = new Node();
            aux.ambito = ambito;
            tipoDato = buscartipo(tabsim, id.Simbolo);
            aux = argumentos;
            string cadena = "";
            while (aux != null)
            {
                char tipo2;                                
                tipo2 = buscartipo2(tabsim, aux.Simbolo, ambito);
                cadena += tipo2;
                aux = aux.Siguiente;
            }



            if (argumentos != null)
            {
                argumentos.ambito = ambito;
                argumentos.validatipos(tabsim, errores);
            }
            if (id.Simbolo == "print")
                id.validatipos(tabsim, errores);
            else
            {
                //Console.WriteLine("entra a ver si existe la funcion");
                if (Existe(tabsim, id.Simbolo, ambito, cadena, errores))
                {
                    id.ambito = id.Simbolo;
                    id.validatipos(tabsim, errores);

                }
            }
            if (Siguiente != null)
            {
                Siguiente.ambito = ambito;
                Siguiente.validatipos(tabsim, errores);
            }


        }

        private bool Existe(List<object> tabsim, string simbolo, string ambito, string cadena, List<string> errores)
        {
            List<Elementotabla> simb = tabsim.Cast<Elementotabla>().ToList();

            List<Elementotabla> result = simb.Where(i => i.Id == simbolo).ToList();

            if (result.Count > 0)
            {
                List<Elementotabla> func = result.Where(i => i.Stpara.Length == cadena.Length).ToList();
                if (func.Count > 0)
                {
                    if (func[0].Stpara == cadena)
                    {
                        return true;
                    }
                    else
                    {
                        errores.Add("La funcion " + simbolo + " no contiene los mismos tipos datos como parametros que en su declaracion dentro de la funcion " + ambito);
                    }
                }
                else
                {
                    errores.Add("La funcion " + simbolo + " contiene diferente numero de parametros que en su declaracion dentro de la funcion" + ambito);
                }
            }
            else
            {
                errores.Add("La funcion " + simbolo + " no existe");
            }
            return false;
        }

        private char buscartipo2(List<object> tabsim, string simbolo, string ambito)
        {
            List<Elementotabla> simb = tabsim.Cast<Elementotabla>().ToList();
            List<Elementotabla> result = simb.Where(elemento => elemento.Id == simbolo && elemento.Ambito == ambito).ToList();
            char tipodato = 'e';
            if (result.Count > 0)
                tipodato = result[0].Tipo;
            if (tipodato == 'e')
            {
                if (simbolo.Contains(".") && float.TryParse(simbolo, out float s))
                {
                    tipodato = 'f';
                }
                else if (Int32.TryParse(simbolo, out int t))
                {
                    tipodato = 'i';
                }
            }

            return tipodato;
        }

        private char buscartipo(List<object> tabsim, string simbolo)
        {
            List<Elementotabla> simb = tabsim.Cast<Elementotabla>().ToList();

            List<Elementotabla> result = simb.Where(elemento => elemento.Id == simbolo).ToList();
            char tipodato = 'e';
            if (result.Count > 0)
                tipodato = result[0].Tipo;

            return tipodato;
        }

    }
    public class Operacion1 : Node
    {
        Node der = new Node();

        public Operacion1(ref Stack pila)
        {
            pila.Pop();
            der = (Node)pila.Pop();//quita exprsion
            pila.Pop();
            Simbolo = ((Terminal)pila.Pop()).nodo.Simbolo;//quita el operador
        }

        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            der.ambito = ambito;
            der.validatipos(tabsim, errores);

            tipoDato = der.tipoDato;
            if (der.Siguiente != null)
            {
                der.Siguiente.ambito = ambito;
                der.Siguiente.validatipos(tabsim, errores);
            }
            if (Siguiente!=null)
            {
                Siguiente.ambito = ambito;
                Siguiente.validatipos(tabsim, errores);
            }
        }
    }
    public class Operacion2 : Node
    {
        Node der = new Node();
        Node izq = new Node();
        public Operacion2(ref Stack pila)
        {
            pila.Pop();
            der = (Node)pila.Pop();//quita exprsion
            pila.Pop();
            Simbolo = ((Terminal)pila.Pop()).nodo.Simbolo;//quita el operador
            pila.Pop();
            izq = (Node)pila.Pop();//quita expresion

        }
        public override void validatipos(List<object> tabsim, List<string> errores)
        {
            der.ambito = ambito;
            izq.ambito = ambito;

            der.validatipos(tabsim, errores);
            izq.validatipos(tabsim, errores);

            if (der.tipoDato == 'c' && izq.tipoDato == 'c')
            {
                tipoDato = 'c';
            }
            else
            {
                if (der.tipoDato == 'i' && izq.tipoDato == 'i')
                {
                    tipoDato = 'i';
                }
                else
                {
                    if (der.tipoDato == 'f' && izq.tipoDato == 'f')
                    {
                        tipoDato = 'f';
                    }
                    else
                    {
                        tipoDato = 'e';
                        errores.Add("No se pueden realizar operaciones con tipos de datos distintos");

                    }
                }
            }
            if (izq.Siguiente != null)
            {
                izq.Siguiente.ambito = ambito;
                izq.Siguiente.validatipos(tabsim, errores);
            }
            if (der.Siguiente != null)
            {
                der.Siguiente.ambito = ambito;
                der.Siguiente.validatipos(tabsim, errores);
            }
            if (Siguiente != null)
            {
                Siguiente.ambito = ambito;
                Siguiente.validatipos(tabsim, errores);
            }
        }
    }
    public class Elementotabla
    {

        private string id;
        private char tipo;
        private string ambito;
        private string stpara;

        public string Id { get => id; set => id = value; }
        public char Tipo { get => tipo; set => tipo = value; }
        public string Ambito { get => ambito; set => ambito = value; }
        public string Stpara { get => stpara; set => stpara = value; }

        public Elementotabla(string _id, char _tipo, string _ambito, string _stpara)
        {
            Id = _id;
            Tipo = _tipo;
            Ambito = _ambito;
            Stpara = _stpara;
        }
        public Elementotabla(string _id, char _tipo, string _ambito)
        {
            Id = _id;
            Tipo = _tipo;
            Ambito = _ambito;
            Stpara = "";
        }
    }

    public class Semantico
    {
        private List<object> simbolos;
        private List<string> errores;

        public List<object> Simbolos { get => simbolos; set => simbolos = value; }
        public List<string> Errores { get => errores; set => errores = value; }

        public Semantico()
        {
            simbolos = new List<object>();
            errores = new List<string>();
        }

        public void RevisaSemantica(Node Raiz)
        {
            if (Raiz.GetType() == typeof(DefFunc))
            {
                DefFunc start = (DefFunc)Raiz;
            }
        }
    }
}