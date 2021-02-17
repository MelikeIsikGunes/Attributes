using System;

namespace Delegates   //Delegate-Elçi
{
    public delegate void MyDelegate(); //void olan ve parametre almayan metotlara elçilik yapıyor
    public delegate void MyDelegate2(string text); //void olan ve 1tane string parametresi olan metotlara elçilik yapıyor
    public delegate int MyDelegate3(int number1, int number2); //int döndüren ve 2tane int parametresi olan metorlara elçilik yapıyor
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert;
            myDelegate -= customerManager.SendMessage;
            myDelegate();
            //yapılacak işleri sıraya koyup sonra çalıştırabiliriz.

            Console.WriteLine("--------------");
            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;
            myDelegate2("Hello"); //aynı parametreyi iki operasyon için de göndermemiz gerekiyor. Kısıt

            Console.WriteLine("--------------");
            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            myDelegate3 += matematik.Carp;
            var sonuc = myDelegate3(2,3); //en son return edilen delege çalışır
            Console.WriteLine(sonuc);
        }

        public class CustomerManager
        {
            public void SendMessage()
            {
                Console.WriteLine("Hello!");
            }
            public void ShowAlert()
            {
                Console.WriteLine("Be careful!");
            }

            public void SendMessage2(string message)
            {
                Console.WriteLine(message);
            }
            public void ShowAlert2(string alert)
            {
                Console.WriteLine(alert);
            }
        }
        public class Matematik
        {
            public int Topla(int sayi1, int sayi2)
            {
                return sayi1 + sayi2;
            }
            public int Carp(int sayi1, int sayi2)
            {
                return sayi1 * sayi2;
            }
        }
    }
}
