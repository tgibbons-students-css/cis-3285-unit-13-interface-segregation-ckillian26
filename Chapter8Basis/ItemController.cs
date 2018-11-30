using CrudInterfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8Basis
{
    public class ItemController
    {
        private readonly IRead<Item> reader;
        private readonly ISave<Item> saver;
        private readonly IDelete<Item> deleter;

        public ItemController(IRead<Item> orderReader, ISave<Item> orderSaver, IDelete<Item> orderDeleter)
        {
            reader = orderReader;
            saver = orderSaver;
            deleter = orderDeleter;
        }

        public void CreateOrder(Item order)
        {
            saver.Save(order);
            Console.WriteLine("CreateOrder: Saving order of " + order.product);
        }

        public Item GetSingleOrder(Guid identity)
        {
            Item ord = reader.ReadOne(identity);
            Console.WriteLine("GetSingleOrder: Saving order of " + ord.product);
            return ord;
        }

        public void UpdateOrder(Item order)
        {
            saver.Save(order);
            Console.WriteLine("UpdateOrder: Saving order of " + order.product);
        }

        public void DeleteOrder(Item order)
        {
            deleter.Delete(order);
            Console.WriteLine("DeleteOrder: Delete order of " + order.product);
        }
    }
}
