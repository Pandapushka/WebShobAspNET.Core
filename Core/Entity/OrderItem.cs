using Core.Entity;
using Core.Entity.BaseEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class OrderItem : BaseEntity
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Amount { get; set; }
        public OrderItem() 
        {

        }  
    }
}
