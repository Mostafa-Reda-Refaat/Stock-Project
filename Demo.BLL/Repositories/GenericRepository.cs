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
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly StockDbContext _context;

		public GenericRepository(StockDbContext context)
        {
			_context = context;
		}
		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
			//_context.SaveChanges();
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
			//_context.SaveChanges();
		}

		public IEnumerable<T> GetAll()
			=> _context.Set<T>().ToList();

		public T GetById(int? id)
			=> _context.Set<T>().Find(id);

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
			//_context.SaveChanges();
		}
	}
}
