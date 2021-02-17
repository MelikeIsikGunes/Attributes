using System;

namespace Attributes
{
    //Nesnelere veya bu nesnelerin özelliklerine, metotlarına anlam katmak için Attribute'lerden yararlanırız.
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer {Id=1, LastName="Işık Güneş", Age=24 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.AddNew(customer);
        }
    }

    [ToTable("Customers")] //Customer classı Db'de Customers tablosuna denk gelir
    [ToTable("tblCustomers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]  //FirstName girmek zorunda olsun diye Attribute ekliyoruz
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }

    class CustomerDal
    {
        [Obsolete("Don't use Add, instead use AddNew Method")] //Obsolete Hazır Attribute'dir.
        //Başka programcıları bilgilendirmek için. Obsolete-Eski
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!",
                customer.Id,customer.FirstName,customer.LastName,customer.Age);
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!",
                customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }

    //AttributeTargets.All olunca aşağısındaki attribute'yi herkese kullanabilirsin(property,method,class).
    //AttributeTargets.Property yaparsan sadece propertylerde kullanabilirsin.
    //AttributeTargets.Property | AttributeTargets.Field -- ikisinde de kullanabilmek için | işareti kullanılır.

    [AttributeUsage(AttributeTargets.Property)]
    class RequiredPropertyAttribute :Attribute
    {

    }

    //AllowMultiple = true -- Attribute'yi birden fazla kullanabilmek için

    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    class ToTableAttribute:Attribute
    {
        string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }

}
