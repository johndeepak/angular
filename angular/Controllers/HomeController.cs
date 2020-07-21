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
                    List <Mypractice> Emp = Obj.Mypractices.ToList();  
                    return Json(Emp, JsonRequestBehavior.AllowGet);  
                }  
            }  
            /// <summary>  
            /// Get Data With Id  
            /// </summary>  
            /// <param name="Id"></param>  
            /// <returns></returns>  
        public JsonResult Get_EmployeeById(string Id) {  
                using(praticeEntities Obj = new praticeEntities()) {  
                    int EmpId = int.Parse(Id);  
                    return Json(Obj.Mypractices.Find(EmpId), JsonRequestBehavior.AllowGet);  
                }  
            }  
            /// <summary>  
            /// Insert New Data  
            /// </summary>  
            /// <param name="Employe"></param>  
            /// <returns></returns>  
        public string Insert_Employee(Mypractice Employe) {  
                if (Employe != null) {  
                    using(praticeEntities Obj = new praticeEntities()) {  
                        Obj.Mypractices.Add(Employe);  
                        Obj.SaveChanges();  
                        return "Data Added Successfully";  
                    }  
                } else {  
                    return "Data Not Inserted! Try Again";  
                }  
            }  
            /// <summary>  
            /// Delete Data Information  
            /// </summary>  
            /// <param name="Emp"></param>  
            /// <returns></returns>  
        public string Delete_Employee(Mypractice Emp) {  
                if (Emp != null) {  
                    using(praticeEntities Obj = new praticeEntities()) {  
                        var Emp_ = Obj.Entry(Emp);  
                        if (Emp_.State == System.Data.Entity.EntityState.Detached) {  
                            Obj.Mypractices.Attach(Emp);  
                            Obj.Mypractices.Remove(Emp);  
                        }  
                        Obj.SaveChanges();  
                        return "Data Deleted Successfully";  
                    }  
                } else {  
                    return "Data Not Deleted! Try Again";  
                }  
            }  
            /// <summary>  
            /// Update Data Information  
            /// </summary>  
            /// <param name="Emp"></param>  
            /// <returns></returns>  
        public string Update_Employee(Mypractice Emp) {  
            if (Emp != null) {  
                using(praticeEntities Obj = new praticeEntities()) {  
                    var Emp_ = Obj.Entry(Emp);
                    Mypractice EmpObj = Obj.Mypractices.Where(x => x.orderId == Emp.orderId).FirstOrDefault();  
                    EmpObj.Ordernumber = Emp.Ordernumber;  
                    EmpObj.Customername = Emp.Customername;  
                  
                    Obj.SaveChanges();  
                    return "Data Updated Successfully";  
                }  
            } else {  
                return "Data Not Updated! Try Again";  
            }  
        }  
    }  
}  
   