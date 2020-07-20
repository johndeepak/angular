using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace angular.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

         public JsonResult Get_AllEmployee() {  
                using(praticeEntities Obj = new praticeEntities()) {  
                    List <praticejoin> Emp = Obj.praticejoins.ToList();  
                    return Json(Emp, JsonRequestBehavior.AllowGet);  
                }  
            }  
            /// <summary>  
            /// Get praticejoin With Id  
            /// </summary>  
            /// <param name="Id"></param>  
            /// <returns></returns>  
        public JsonResult Get_EmployeeById(string Id) {  
                using(praticeEntities Obj = new praticeEntities()) {  
                    int EmpId = int.Parse(Id);  
                    return Json(Obj.praticejoins.Find(EmpId), JsonRequestBehavior.AllowGet);  
                }  
            }  
            /// <summary>  
            /// Insert New praticejoin  
            /// </summary>  
            /// <param name="Employe"></param>  
            /// <returns></returns>  
        public string Insert_Employee(praticejoin Employe) {  
                if (Employe != null) {  
                    using(praticeEntities Obj = new praticeEntities()) {  
                        Obj.praticejoins.Add(Employe);  
                        Obj.SaveChanges();  
                        return "praticejoin Added Successfully";  
                    }  
                } else {  
                    return "praticejoin Not Inserted! Try Again";  
                }  
            }  
            /// <summary>  
            /// Delete praticejoin Information  
            /// </summary>  
            /// <param name="Emp"></param>  
            /// <returns></returns>  
        public string Delete_Employee(praticejoin Emp) {  
                if (Emp != null) {  
                    using(praticeEntities Obj = new praticeEntities()) {  
                        var Emp_ = Obj.Entry(Emp);  
                        if (Emp_.State == System.Data.Entity.EntityState.Detached) {  
                            Obj.praticejoins.Attach(Emp);  
                            Obj.praticejoins.Remove(Emp);  
                        }  
                        Obj.SaveChanges();  
                        return "praticejoin Deleted Successfully";  
                    }  
                } else {  
                    return "praticejoin Not Deleted! Try Again";  
                }  
            }  
            /// <summary>  
            /// Update praticejoin Information  
            /// </summary>  
            /// <param name="Emp"></param>  
            /// <returns></returns>  
        public string Update_Employee(praticejoin Emp) {  
            if (Emp != null) {  
                using(praticeEntities Obj = new praticeEntities()) {  
                    var Emp_ = Obj.Entry(Emp);  
                    praticejoin EmpObj = Obj.praticejoins.Where(x => x.Id == Emp.Id).FirstOrDefault();  
                    EmpObj.OrderNumber = Emp.OrderNumber;  
                    EmpObj.OrderDate = Emp.OrderDate;  
                    EmpObj.CustomerId = Emp.CustomerId;  
                    Obj.SaveChanges();  
                    return "praticejoin Updated Successfully";  
                }  
            } else {  
                return "praticejoin Not Updated! Try Again";  
            }  
        }  
    }  
}  
   