﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Events //bir delegedir
{
    public delegate void StockControl();
    public class Product
    {
        int _stock;
        public Product(int stock)
        {
            _stock = stock;
        }
        public event StockControl StockControlEvent; //event tanımlıyoruz
        public string ProductName { get; set; }
        public int Stock
        {
            get  { return _stock; }
            set
            {
                _stock = value;
                if(value<=15 && StockControlEvent!=null)
                {
                    StockControlEvent();
                }
            }
        
        }

        public void Sell(int amount)
        {
            Stock -= amount; //kaç satış yapıldıysa stoktan düş
            Console.WriteLine("{1} Stock amount : {0}", Stock,ProductName);
        }
    }
}
