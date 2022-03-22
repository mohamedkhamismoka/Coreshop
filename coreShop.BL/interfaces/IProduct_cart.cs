using coreShop.BL.VM;
using coreShop.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.interfaces
{
    public interface IProduct_cart
    {
        int GETCount(int id);
        void create(Product_cart pc);
        void Delete(int card_id, int product_id);
        int[] GetProducts(int id);
        bool existin(int card_id,int product_id);
        IEnumerable<ProductVm> GEtSavaed(int cart_id);
        public void ChangeState(int product_id, int cart_id);
        public void changeQuantity(int product_id, int cart_id, int quantity);
        public IEnumerable<Product_cart> GetById(int cart_id);

        public int get_count_in_cart(int cart, int product);
    }
}
