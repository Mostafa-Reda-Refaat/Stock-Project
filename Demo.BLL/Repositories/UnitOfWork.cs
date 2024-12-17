using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly StockDbContext _context;

		public IItemRepository ItemRepository { get; set; }
		public IStoreRepository StoreRepository { get; set; }
		public IItemStockRepository ItemStockRepository { get; set; }

		public UnitOfWork(StockDbContext context)
        {
			_context = context;
			ItemRepository = new ItemRepository(context);
			StoreRepository = new StoreRepository(context);
			ItemStockRepository = new ItemStockRepository(context);
		}

        public int Complete()
		{
			return _context.SaveChanges();
		}
	}
}
