using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Entities;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Demo.PL.Controllers
{
	public class StoreController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
            _mapper = mapper;
        }

		public IActionResult Index()
		{
			var stores = _unitOfWork.StoreRepository.GetAll();
			var mappedStores = _mapper.Map<IEnumerable<Store>, IEnumerable<StoreViewModel>>(stores);

            return View(mappedStores);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(StoreViewModel storeVM)
		{
			if(ModelState.IsValid)
			{
				var store = _mapper.Map<StoreViewModel, Store>(storeVM);
                _unitOfWork.StoreRepository.Add(store);
				_unitOfWork.Complete();
				return RedirectToAction(nameof(Index));
			}
			return View(storeVM);
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id is null)
				return BadRequest();

			var store = _unitOfWork.StoreRepository.GetById(id);
			if(store is null)
				return NotFound();

			var storeVM = _mapper.Map<Store, StoreViewModel>(store);


            return View(storeVM);
		}
		[HttpPost]
		public IActionResult Edit(StoreViewModel storeVM, [FromRoute] int id)
		{
			if(id != storeVM.Id)
				return BadRequest();

			if (ModelState.IsValid)
			{
				var store = _mapper.Map<StoreViewModel, Store>(storeVM);
                _unitOfWork.StoreRepository.Update(store);
				_unitOfWork.Complete();
				return RedirectToAction(nameof(Index));
			}
			return View(storeVM);
		}

		public IActionResult Delete(int? id)
		{
			if (id is null)
				return BadRequest();

			var store = _unitOfWork.StoreRepository.GetById(id);

			if (store is null)
				return NotFound();

			_unitOfWork.StoreRepository.Delete(store);
			_unitOfWork.Complete();
			return RedirectToAction(nameof(Index));
		}

	}
}
