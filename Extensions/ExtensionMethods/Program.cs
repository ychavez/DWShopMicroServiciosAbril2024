using ExtensionMethods.Extensions;

namespace ExtensionMethods
{
    internal class Program
    {

      
        static void Main(string[] args)
        {
            var numero = 1.HacerDoble().HacerDoble();
            Console.WriteLine(numero);

            Console.WriteLine("Yael"
                .AgregarSaludo()
                .AgregarFecha());
           
            Console.WriteLine("Carlos"
                .AgregarSaludo().AgregarFecha(DateTime.UtcNow));

            Console.WriteLine("Luis".AgregarSaludo().AgregarSaludo().AgregarSaludo());
        }
    }

   
}
