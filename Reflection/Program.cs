using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2,3);
            //Console.WriteLine( dortIslem.Topla2());
            //Console.WriteLine(dortIslem.Topla(3,4)); 

            var tip = typeof(DortIslem); //tipini aldık

            DortIslem dortIslem = (DortIslem)Activator.CreateInstance(tip,6,7); //new'leme hareketi gibi
            //Console.WriteLine(dortIslem.Topla(4,5));
            //Console.WriteLine(dortIslem.Topla2());

            var instance = Activator.CreateInstance(tip, 6, 5);
            MethodInfo methodInfo = instance.GetType().GetMethod("Topla2"); //parametre yok diye null
            Console.WriteLine(methodInfo.Invoke(instance, null) );
            //GetMethod ile istediğimiz metoda ulaşıyoruz, Invoke ile onu çalıştırıyoruz.

            Console.WriteLine("---------------------");
            var metodlar = tip.GetMethods(); //bu classın metotlarına ulaşıyoruz(liste şeklinde)
            foreach (var info in metodlar)
            {
                Console.WriteLine("Metod adı: {0}", info.Name);
                foreach (var parametreInfo in info.GetParameters())  // metodun parametrelerini görebilmek için
                {
                    Console.WriteLine("Parametre adı: {0}", parametreInfo.Name);
                }

                foreach (var attribute in info.GetCustomAttributes()) // metodun attributelerini görebilmek için
                {
                    Console.WriteLine("Attribute adı: {0}", attribute.GetType().Name);
                }
            }


        }  
    }

    public class DortIslem
    {
        int _sayi1;
        int _sayi2;
        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public DortIslem()
        {

        }
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }

        [MetodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
    }

    public class MetodNameAttribute : Attribute
    {
        public MetodNameAttribute(string name)
        {
             
        }
    }
}
