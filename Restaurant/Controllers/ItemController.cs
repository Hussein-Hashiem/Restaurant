using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.ModelVM.Item;
using AutoMapper;

namespace Restaurant.PL.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var items = _itemService.GetAll();
            return View(items); 
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var item = _itemService.GetById(id);
            if (item == null) return NotFound();
            var vm = _mapper.Map<GetItemVM>(item);
            return View(vm);
        }
    }
}
