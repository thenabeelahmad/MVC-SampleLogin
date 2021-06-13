using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient; 


namespace MVC_LoginDemo.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        DBManager dm = new DBManager();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            string tf1 = frm[0];
            string tf2 = frm[1];
            string q = " select upass from tbl_demologin where uname='"+ tf1 +"' ";
            DataTable dt = new DataTable();
            dt = dm.ReadBulkData(q);
                
            if (dt.Rows.Count > 0)
            {
                String pas = dt.Rows[0][0].ToString();
            
                if (pas == tf2)
                {
                    Session["user"] = tf1;
                    ViewBag.user = Session["user"];

                    return View("Dashboard");
                }
                else
                {
                    ViewBag.confirm = "Wrong Password";
                }
            }
            else {

                ViewBag.confirm = "No User";
               
            }
            
            return View();
        }

        public ActionResult Dashboard()
        {

            return View();
        }

       

    }
}
