using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Entities;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
	public class ItemStockController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemStockController(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
            _mapper = mapper;
        }

		
		public IActionResult Increase(ItemStockViewModel itemStockVM) 
		{
			ViewBag.Itemes = _unitOfWork.ItemRepository.GetAll();
			ViewBag.Stores = _unitOfWork.StoreRepository.GetAll();

			return View(itemStockVM);
		}
		[HttpPost]
		public IActionResult Increase(int itemId, int storeId, int quantity) 
		{
			var itemStock = _unitOfWork.ItemStockRepository.GetAll();
			var stock = itemStock.FirstOrDefault(s => s.ItemId  == itemId && s.StoreId == storeId);

			if (stock != null)
			{
				stock.Quantity += quantity;
				_unitOfWork.ItemStockRepository.Update(stock);
				_unitOfWork.Complete();
				
				var mappedStock = _mapper.Map<ItemStock, ItemStockViewModel>(stock);
				return RedirectToAction("Increase", mappedStock);
			}
			else
			{
				ItemStock newItemStock = new ItemStock
				{
					ItemId = itemId,
					StoreId = storeId,
					Quantity = quantity
				};
				_unitOfWork.ItemStockRepository.Add(newItemStock);
				_unitOfWork.Complete();

                var mappedStock = _mapper.Map<ItemStock, ItemStockViewModel>(newItemStock);
                return RedirectToAction("Increase", mappedStock);
            }

        }


        [HttpGet]
        public  IActionResult GetQuantity(int storeId, int itemId)
        {
            var itemStock = _unitOfWork.ItemStockRepository.GetAll();
            var stock = itemStock.FirstOrDefault(s => s.ItemId == itemId && s.StoreId == storeId);

            if (stock != null)
            {
                return Json(new { quantity = stock.Quantity });
            }
            else
            {
                return Json(new { quantity = 0 });
            }
        }



    }
}
