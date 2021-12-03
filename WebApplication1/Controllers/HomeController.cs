using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _appDbContext = new AppDbContext();

        public HomeController()
        {
            CamObserver.Start();
        }

        public ActionResult Index()
        {
            return Redirect("/index.html");
        }

        public JsonResult GetCams(int? id)
        {
            Cam[] result = null;

            if (id == null)
            {
                result = _appDbContext.Cams.ToArray();
            }
            else
            {
                result = _appDbContext.Cams.Where(x => x.Id == id).ToArray();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTasks()
        {
            Task[] tasks = _appDbContext.Tasks.ToArray();

            return Json(tasks, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmployees(int? id)
        {
            Employee[] result = null;

            if (id == null)
            {
                result = _appDbContext.Employees.ToArray();
            }
            else
            {
                result = _appDbContext.Employees.Where(x => x.Id == id).ToArray();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Login(string login, string password)
        {
            var user = _appDbContext.Employees.FirstOrDefault(x => x.Login == login && x.Password == password);

            if(user != null)
            {
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }

            
        }

        public JsonResult UpdateTask(int camId, bool isFull = true)
        {
            
            Task task = _appDbContext.Tasks.Where(x => x.EmployeeId == null && x.IsComplete == false && x.FinishDate == null && x.CamId == camId).FirstOrDefault();

            Cam cam = _appDbContext.Cams.First(x => x.Id == camId);

            if (isFull)
            {
                GeoCoordinate camCoord = new GeoCoordinate(cam.CoordX, cam.CoordY);

                Employee[] employees = _appDbContext.Employees.ToArray();

                Employee nearEmployee = null;
                double minDistance = double.MaxValue;

                foreach (Employee employee in employees)
                {        
                    GeoCoordinate employeeCoord = new GeoCoordinate(employee.CoordX, employee.CoordY);

                    if (camCoord.GetDistanceTo(employeeCoord) < minDistance)
                    {
                        nearEmployee = employee;
                        minDistance = camCoord.GetDistanceTo(employeeCoord);
                    }

                }

                task.EmployeeId = nearEmployee.Id;
                cam.InWork = true;

                _appDbContext.SaveChanges();

                return Json(nearEmployee, JsonRequestBehavior.AllowGet);
            }
            else
            {
                task.IsComplete = true;
                cam.IsFull = 0;

                _appDbContext.SaveChanges();

                return Json("OK", JsonRequestBehavior.AllowGet);
            }
        }

        private string GetActualCamImagePath(string camsFolder, int camId)
        {
            string[] allfiles = Directory.GetFiles(Path.Combine(camsFolder, camId.ToString()));

            TimeSpan minSpan = TimeSpan.FromDays(365);
            string actualPath = "";

            foreach (string filename in allfiles)
            {
                string timeStr = Path.GetFileNameWithoutExtension(filename).Substring(11).Replace('-', ':').Replace('_', ' ');

                var dateTime =  DateTime.Parse(timeStr);

                TimeSpan span = (DateTime.Now - dateTime).Duration();

                if(span < minSpan)
                {
                    minSpan = span;
                    actualPath = Path.GetFileName(filename);
                }
            }

            return actualPath;
        }
    }
}