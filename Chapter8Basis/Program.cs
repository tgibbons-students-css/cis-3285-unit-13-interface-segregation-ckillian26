using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CrudImplementations;
using Model;

namespace Chapter8Basis
{
    class Program
    {
        static void Main(string[] args)
        {

            Order order = new Order();
            order.product = "Vector Robot";
            order.amount = 300;

            Item item = new Item();
            item.product = "Robot";
            item.cost = 400;
        
            Console.WriteLine("=========CreateSeparateServices=========");
            OrderController sep = CreateSeparateServices();
           //sep.CreateOrder(order);
           //sep.DeleteOrder(order);

            Console.WriteLine("=========CreateSingleService=========");
            OrderController sing = CreateSingleService();
           //sing.CreateOrder(order);
           //sing.DeleteOrder(order);

            Console.WriteLine("=========GenericController<Order>=========");
            GenericController<Order> generic = CreateGenericServices();
           // generic.CreateEntity(order);
            // generic.DeleteEntity(order);

            Console.WriteLine("=========GenericController<Order>=========");
            GenericController<Item> genericItem = CreateGenericItemServices();
            //genericItem.CreateEntity(item);
           // genericItem.DeleteEntity(item);

            Console.WriteLine("=========CreateSingleService=========");
            ItemController single = CreateSingleServices();
            single.CreateOrder(item);
            single.DeleteOrder(item);


            Console.WriteLine("Hit any key to quit");
            Console.ReadKey();
        }

        static OrderController CreateSeparateServices()
        {
            var reader = new Reader<Order>();
            var saver = new Saver<Order>();
            var deleter = new Deleter<Order>();
            return new OrderController(reader, saver, deleter);
        }

        static OrderController CreateSingleService()
        {
            var crud = new Crud<Order>();
            return new OrderController(crud, crud, crud);
        }
        static ItemController CreateSingleServices()
        {
            var crud = new Crud<Item>();
            return new ItemController(crud, crud, crud);
        }

        static GenericController<Order> CreateGenericServices()
        {
            var reader = new Reader<Order>();
            var saver = new Saver<Order>();
            var deleter = new Deleter<Order>();
            // This must be declared using reflection...
            GenericController<Order> ctl = (GenericController<Order>)Activator.CreateInstance(typeof(GenericController<Order>), reader, saver, deleter);
            //This does not work 
            //GenericController<Order> ctl = new GenericController(reader, saver, deleter);
            return ctl;
        }

        static GenericController<Item> CreateGenericItemServices()
        {
            var reader = new Reader<Item>();
            var saver = new Saver<Item>();
            var deleter = new Deleter<Item>();
            // This must be declared using reflection...
            GenericController<Item> ctl = (GenericController<Item>)Activator.CreateInstance(typeof(GenericController<Item>), reader, saver, deleter);
            return ctl;
        }

    }
}
