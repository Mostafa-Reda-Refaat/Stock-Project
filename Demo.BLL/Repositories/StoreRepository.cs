using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
	public class StoreRepository : GenericRepository<Store>, IStoreRepository
	{
        public StoreRepository(StockDbContext context) : base(context)
        {
            
        }




    }
}
