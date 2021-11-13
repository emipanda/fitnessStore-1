using FitnessStore.Controllers;
using FitnessStore.Migrations;
using FitnessStore.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace FitnessStore.Data
{
    public class Dbinitalizer
    {
        private static object TotalPrice;
        private static object ordersItems;

        public static Order Order { get; private set; }
        public static object OrderItems { get; private set; }
        public static object OrdersItems { get; private set; }

        public static void Initialize(FitnessStoreContext context)
        {
            context.Database.EnsureCreated();
            if (context.Category.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category{Name = "Dietary supplement"},
                new Category{Name = "Clothing"},
                new Category{Name = "Fitness Equipment and Supplies"},
                new Category{Name = "Shoes"},
                new Category{Name = "Sports Accessories"}
            };


            foreach (Category c in categories)
            {
                context.Category.Add(c);
            }

            context.SaveChanges();
            var products = new Product[]
            {
                new Product{Name = "Physio Ball", Created = DateTime.Today,
                    Description = "Physical Ball was created with stability building and aerobic training in mind." + 
                                  "The physio balls are designed with dense rubber sides, to prevent explosion, to provide support" +
                                  "Great and long-lasting flexibility." +
                                  "The ball is suitable for home and professional use",
                    Price = 99,Category=categories[2]},

                new Product{Name ="Power Tube L2 Training Rubber Band", Created = DateTime.Today,
                    Description = "bla bla bla"
                    ,Price = 79,Category=categories[2] },

                      new Product{Name ="Men Gym Shorts with Inner Spandex Shorts", Created = DateTime.Today,
                                  Description = "A two-layered short composed of stretchable inner spandex and a quick-drying outer polyester short" +
                                                "It’s a comfortable fit short with a gartered waist, a drawstring waist rope, and a zippered pocket at the back" +
                                                "It has a towel holder slot that gives you easy access to your sweat towel while working out" +
                                                "These shorts complement the shape of your body that you worked hard for" +
                                                "Wide range of use: cycling, running, boxing, gym, basketball, etc" +
                                                "Inner Material: Spandex / Outer Material: Polyester / For Adult Men" +
                                                "For a list of sizes and measurements, please scroll down to the description area to find the sizing chart" +
                                                "Package Content:" +
                                                "1 x Men’s Gym Shorts" , Price = 32,Category=categories[4] },

                      

                         new Product{Name ="Mist Spray Water Bottle Sports Bottle", Created = DateTime.Today,
                                     Description = "Use this mist spray water to keep you energized when you are playing sports or working out" +
                                                    "Has a spray function that you can use to splash some to your ace without wasting too much water" +
                                                    "Secure lock that will not spill any water and keep out dust and dirt" +
                                                    "Size: 28.5cm length x 5 cm diameter" +
                                                    "740ML" +
                                                    "Material: Tritan" +
                                                    "Package Content:" +
                                                    "1 x Mist Spray Water Bottle Sports Bottle" , Price = 29,Category=categories[4] } };
            foreach(Product p in products)
            {
                context.Product.Add(p);
            }
            context.SaveChanges();
            var accounts = new Account[]
            {
                new Account{Username="adikue1231@gmail.com",Password="1234",Gender=(Gender)2,Name="Adi",BirthDate=new DateTime(1996,12,3), Registered = new DateTime(2021,10,3), Role =(Role)0, Cart= new Cart() },
                new Account{Username="emily@gmail.com",Password="1234",Gender=(Gender)2,Name="Emily ",BirthDate=new DateTime(1996,3,20), Registered =  new DateTime(2021,8,13), Role =(Role)0, Cart= new Cart() }
            };
            context.SaveChanges();
            foreach (Account a in accounts)
            {
                context.Account.Add(a);
            }


            context.SaveChanges();
            var orders = new Order[]
            {
                new Order{Country = "Israel", City = "Rishon Le Zion", Address = "Hertzel 12", ZipCode = "1828373" ,PhoneNumber = "0521111111", TotalPay= 1630, Delivery = (Delivery)0, OrderTime = new DateTime(2021,10,23) },
                new Order{Country = "Israel", City = "Givataim", Address = "Katsanelsson", ZipCode = "1874859" ,PhoneNumber = "0522222222", TotalPay= 1800, Delivery = (Delivery)1, OrderTime = new DateTime(2021,10,3)}
            };

            foreach (Order o in orders)

            {
                context.Order.Add(o);
            }
            context.SaveChanges();
            OrderItem[] orderItems = new OrderItem[]
     {
                new OrderItem{ Quantity=2, Product=products[0], Order=orders[0], TotalPrice=198 },
                new OrderItem{ Quantity=1, Product=products[1], Order=orders[0],TotalPrice=79 },
                new OrderItem{ Quantity=1, Product=products[7], Order=orders[1], TotalPrice=4545 },
                new OrderItem{ Quantity=3, Product=products[3], Order=orders[2], TotalPrice=47778 }


     };
            foreach (OrderItem oi in orderItems)

            {
                context.OrderItem.Add(oi);
            }

            context.SaveChanges();

            }         




            }
                
        }

    

