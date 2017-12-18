using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClaus
{
    public interface IDataBase
    {
        //Qui si definiscono i metodi del database

        bool UpdateOrder(Order order);

        bool UpdateUser(User user);

        IEnumerable<Order> GetAllOrder();

        User GetUser(User user);

        Order GetOrder(string id);


    }
}
