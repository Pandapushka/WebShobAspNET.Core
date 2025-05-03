using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CartDTO
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemDTO> Items { get; set; }

        public int Amount
        {
            get
            {
                return Items.Sum(x => x.Amount);
            }
        }

        public decimal Cost
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
        }
        public CartDTO()
        {
            Id = Guid.NewGuid();
        }
    }
}
