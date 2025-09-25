using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.ModelVM.Table;
using AutoMapper;
using Restaurnat.DAL.Entities;




namespace Restaurant.PL.Controllers
{
    public class TableController : Controller
    {
       
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;
        public TableController(ITableService tableService, IMapper mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                var tables = _tableService.GetAll();
                var vmList = _mapper.Map<List<GetTableVM>>(tables);
                return View(vmList);
            }
            catch (Exception ex)
            {
                return View("Error", ex); 
            }
        }
        public IActionResult Details(int id)
        {
            try
            {
                var table = _tableService.GetById(id);
                if (table == null)
                    return NotFound();

                var vm = _mapper.Map<GetTableVM>(table);
                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTableVM table)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(table);
                }
                var newTable = _mapper.Map<Table>(table);
                var (success, message) = _tableService.Create(newTable);
                if(!success)
                {
                    ModelState.AddModelError(string.Empty, message);
                    return View(table);
                }
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var table = _tableService.GetById(id);
                if (table == null)
                    return NotFound();
                var vm = _mapper.Map<UpdateTableVM>(table);
                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(UpdateTableVM table , int id)
        {
            try
            {
                if(id != table.restaurant_id)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return View(table);
                }
                var updatedTable = _mapper.Map<Table>(table);
                var success = _tableService.Update(updatedTable);
                if (!success)
                {
                    ModelState.AddModelError(string.Empty, "Update failed");
                    return View(table);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var table = _tableService.GetById(id);
                if (table == null)
                    return NotFound();
                var vm = _mapper.Map<GetTableVM>(table);
                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var success = _tableService.Delete(id);
                if (!success)
                {
                    return BadRequest("Delete failed");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}
