using coreShop.BL.VM;
using coreShop.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);

        void create(Product product);
        void update(Product product);
        void delete(int id);
        public List<Product> Getspecial(int[] ids);

        public void decrement(List<int> id, List<int> quantity);
    }
}
