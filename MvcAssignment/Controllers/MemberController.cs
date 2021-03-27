using MvcAssignment.Models;
using MvcAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAssignment.Controllers
{
    public class MemberController : Controller
    {
        MemberDetailsRepository oMemberDetailsRepository = new MemberDetailsRepository();
        [HttpGet]
        public ActionResult Register()
        {
            
            RegistrationModel objRegistrationModel = new RegistrationModel();

            objRegistrationModel.GenderList = oMemberDetailsRepository.GetGender();
            objRegistrationModel.Courcelist = oMemberDetailsRepository.GetCource();
            objRegistrationModel.StateList = oMemberDetailsRepository.GetState();
            //objRegistrationModel.CityList = oMemberDetailsRepository.GetCity(8);

            return View(objRegistrationModel);
        }
        [HttpPost]
        public ActionResult GetStateID(string NewStateid)
        {
            int State_ID = Convert.ToInt32(NewStateid);
            RegistrationModel oRegistrationModel = new RegistrationModel();
            oRegistrationModel.CityList= oMemberDetailsRepository.GetCity(State_ID);
            return Json(oRegistrationModel.CityList, JsonRequestBehavior.AllowGet);
        }
        //[HttpGet]
        //public ActionResult Register1()
        //{
        //    MemberDetailsRepository oMemberDetailsRepository = new MemberDetailsRepository();
        //    RegistrationModel objRegistrationModel = new RegistrationModel();
        //    objRegistrationModel.Courcelist= oMemberDetailsRepository.GetCource();
        //    return View(objRegistrationModel);
        //}
        [HttpPost]
        public ActionResult Register(RegistrationModel ObjRegistrationModel)
        {
            MemberDetailsRepository oMemberDetailsRepository = new MemberDetailsRepository();
            oMemberDetailsRepository.getUserData(ObjRegistrationModel);  

            return RedirectToAction("Register");
        }
    }
}