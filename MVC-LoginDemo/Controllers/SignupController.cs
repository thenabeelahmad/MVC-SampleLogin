using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient; 


namespace MVC_LoginDemo.Controllers
{
    public class SignupController : Controller
    {
        //
        // GET: /Signup/

        DBManager dm = new DBManager();

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(FormCollection frm2)
        {
            string tf11 = frm2[0];
            string tf22 = frm2[1];
            string q = "insert into tbl_demologin values('" + tf11 + "','" + tf22 + "')";
            bool res = dm.InsertUpdateDelete(q);
            if (res == true)
            {
                ViewBag.confirm = "Record Inserted Successfully";
            }
            else
            {
                ViewBag.confirm = "Database Error or Query Error";
            }

            return View();
        }

    }
}
