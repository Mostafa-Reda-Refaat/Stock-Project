using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Entities;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
	public class ItemController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemController(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
		{
			var items = _unitOfWork.ItemRepository.GetAll();
			var mappedItem = _mapper.Map <IEnumerable<Item>,IEnumerable<ItemViewModel>> (items);

            return View(mappedItem);
		}

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ItemViewModel itemVM)
        {
            if (ModelState.IsValid)
            {
				var item = _mapper.Map <ItemViewModel, Item> (itemVM);
                _unitOfWork.ItemRepository.Add(item);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(itemVM);
        }

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id is null)
				return BadRequest();

			var item = _unitOfWork.ItemRepository.GetById(id);
			if (item is null)
				return NotFound();

			var itemVM = _mapper.Map<Item, ItemViewModel>(item);


            return View(itemVM);
		}
		[HttpPost]
		public IActionResult Edit(ItemViewModel itemVM, [FromRoute] int id)
		{
			if (id != itemVM.Id)
				return BadRequest();

			if (ModelState.IsValid)
			{
				var item = _mapper.Map<ItemViewModel, Item>(itemVM);
                _unitOfWork.ItemRepository.Update(item);
				_unitOfWork.Complete();
				return RedirectToAction(nameof(Index));
			}
			return View(itemVM);
		}

		public IActionResult Delete(int? id)
		{
			if (id is null)
				return BadRequest();

			var item = _unitOfWork.ItemRepository.GetById(id);

			if (item is null)
				return NotFound();

			_unitOfWork.ItemRepository.Delete(item);
			_unitOfWork.Complete();
			return RedirectToAction(nameof(Index));
		}



	}
}
