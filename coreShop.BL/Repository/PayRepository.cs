using coreShop.BL.interfaces;
using coreShop.DAL.Database;
using coreShop.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.Repository
{
    public class PayRepository : IPAy
    {
        private readonly DataContext data;

        public PayRepository(DataContext Data)
        {
            data = Data;
        }
        public void create(Pay pay)
        {
          data.pays.Add(pay);
            data.SaveChanges();
        }
    }
}
