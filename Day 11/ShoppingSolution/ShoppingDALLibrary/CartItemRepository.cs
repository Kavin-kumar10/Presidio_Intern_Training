using ExceptionHandling;
using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int,CartItem>
    {
        public override CartItem Delete(int key)
        {
            CartItem cartitem = GetByKey(key);
            if (cartitem != null) { items.Remove(cartitem); };
            return cartitem;
            throw new ItemNotFoundException();
        }

        public override CartItem GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new ItemNotFoundException();
        }

        public override CartItem Update(CartItem item)
        {
            CartItem cartitem = GetByKey(item.Id);
            if (cartitem != null)
            {
                cartitem = item;
                return cartitem;
            }
            throw new ItemNotFoundException();
        }

    }
}
