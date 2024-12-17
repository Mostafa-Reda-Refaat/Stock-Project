using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entities
{
	public class Item : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public double Price { get; set; }
		public List<ItemStock> ItemStocks { get; set; }

	}
}
