using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GenericsFunc
{
    public static class Funcs
    {
        #region Genericos
        //void Run()
        //{

        //    Funcion<Hermano>();
        //}

        public static string Funcion<T>() where T : Persona
        {
            T serVivo;
            return "serVivo.Apellido;";
        }



        public class Extraterrestre
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }

        }

        public class Mascota : MiGenerico
        {
            public int NumeroDePatas { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
        }


        public class Hermano : Persona
        {
            public int NumeroDePeleas { get; set; }
        }

        public class Persona : MiGenerico
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
        }

        public interface MiGenerico
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }

        }
        #endregion

        public static void RunTest()
        {

            var charLetra = (string x) => x.First();

            charLetra += FindFirstNonRepeatingCharNoLinq;
            charLetra += PrimerNoRepetidoFunc;

            imprimr(EjecutarFuncion("HolalH", charLetra));

            imprimr(EjecutarFuncion("HolalH", x => x.First()));

        }

        public static char EjecutarFuncion(string palabra, Func<string, char> func)
        {
            return func(palabra);
        }

        public static bool IsPalindrome(string word)
        {
            var wordArray = word.ToCharArray();
            var reversedWord = wordArray.Reverse().ToArray();
            var reversedWordString = new string(reversedWord);
            return word == reversedWordString;
        }

        public static char FindFirstNonRepeatingCharNoLinq(string word)
        {
            var wordArray = word.ToCharArray();
            for (int i = 0; i < wordArray.Length; i++)
            {
                var currentChar = wordArray[i];
                var isRepeated = false;
                for (int j = 0; j < wordArray.Length; j++)
                {
                    if (i != j && currentChar == wordArray[j])
                    {
                        isRepeated = true;
                        break;
                    }
                }
                if (!isRepeated)
                {
                    return currentChar;
                }
            }
            return ' ';
        }

        public static Predicate<int> siempreTrue = (s) => 1 == 1;
        public static Action<char> imprimr => s => Console.WriteLine(s);

        public static Func<string, char> PrimerNoRepetidoFunc
            = (word) =>
            {
                var wordArray = word.ToCharArray();

             
                for (int i = 0; i < wordArray.Length; i++)
                {
                    var currentChar = wordArray[i];
                    var isRepeated = false;
                    for (int j = 0; j < wordArray.Length; j++)
                    {
                        if (i != j && currentChar == wordArray[j])
                        {
                            isRepeated = true;
                            break;
                        }
                    }
                    if (!isRepeated)
                    {
                        return currentChar;
                    }
                }
                return ' ';

            };


    }

}
