using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
	public interface IUnitOfWork
	{
        public IItemRepository ItemRepository { get; set; }
        public IStoreRepository StoreRepository { get; set; }
        public IItemStockRepository ItemStockRepository { get; set; }

        public int Complete();
	}
}
