using AutoMapper;
using FoodForestMVC.Contacts;
using FoodForestMVC.Data;
using FoodForestMVC.Models;
using FoodForestMVC.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodForestMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmployeeRepository _employeeRepository;
        public readonly IMapper _mapper;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository(new ApplicationDbContext());
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<Employee, EmployeeVM>().ReverseMap());
            _mapper = new Mapper(config);
        }
        public EmployeeController(IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            //var employees = _employeeRepository.FindAll();
            //var model = _mapper.Map<IEnumerable<EmployeeVM>>(GetAllEmployees());
            return View(GetAllEmployees());
        }
        IEnumerable<EmployeeVM> GetAllEmployees()
        {
            var model= _employeeRepository.FindAll().ToList<Employee>();
            return _mapper.Map<List<EmployeeVM>>(model);

        }
        // GET: Employee/Create
        public ActionResult AddorEdit(int id = 0)
        {
            EmployeeVM model = new EmployeeVM();
            if( id !=0)
            {
              model=  _mapper.Map<EmployeeVM>(_employeeRepository.FindById(id));
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddorEdit(EmployeeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                { 
                    if (model.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        model.ImagePath = "~/AppFiles/EmployeePhoto/" + fileName;
                        model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/EmployeePhoto/"), fileName));
                    }
               

                    var employee = _mapper.Map<Employee>(model);
                    var isSuccess = _employeeRepository.Create(employee);
                    if (!isSuccess)
                    { 
                        return Json(new { success = false, message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
                    }
                    return Json(new { success = true, html =GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployees()), message = "Submitted Successfully" },JsonRequestBehavior.AllowGet); 
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public  ActionResult Delete(int id)
        {
            try
            {
                var employee = _employeeRepository.FindById(id); 
                var isSuccess = _employeeRepository.Delete(employee);
                if (!isSuccess)
                {
                    return Json(new { success = false, message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployees()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}