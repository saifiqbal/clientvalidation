using MVC.Models;
using MVC.ViewModel.Payments;
using MVC.ViewModel.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVC.ViewModel;

namespace MVC.Controllers
{
    public class IntakeController : Controller
    {
        // GET: Intake
        public ActionResult Index()
        {
            ViewModel.Intake.IntakeViewModel intakemodel = new ViewModel.Intake.IntakeViewModel();
            intakemodel.PaymentsViewModel = new ViewModel.Payments.PaymentsViewModel();
            intakemodel.PharmacyViewModel = new ViewModel.Pharmacy.PharmacyViewModel();
            intakemodel.PharmacyViewModel.Pharmacies = new List<Models.PharmacyDetails>();


          
            PharmacyDetails pd = new PharmacyDetails();
            pd.PharmacyAddress = "Karachi";
            pd.PharmacyID = "1";
            pd.PharmacyName = "CVS pharmacy";
            intakemodel.PharmacyViewModel.Pharmacies.Add(pd);


            CoreDTO.DTOContactDetails DTOCD = new CoreDTO.DTOContactDetails();
            DTOCD.Address1 = "ABC";
            DTOCD.Address2 = "BCD";
            DTOCD.Email = "ASDDADS";
            DTOCD.CountryList = new List<CoreDTO.Country> { new CoreDTO.Country { Name = "USA", Value = "US" }, new CoreDTO.Country { Name = "Canada", Value = "US" } };
            DTOCD.StateList = new List<CoreDTO.State> { new CoreDTO.State { Name = "NewYork", Value = "US" }, new CoreDTO.State { Name = "Chicago", Value = "US" } };

            ContactDetailsViewModel CDVM = new ContactDetailsViewModel(DTOCD);
         

            intakemodel.ContactDetailsViewModel = CDVM;


            return View(intakemodel);
        }
        #region Payments
        public ActionResult Payments()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Payments(PaymentsViewModel model)
        {
            var movel = ModelState;

            //if (ModelState.IsValid)
            //{
                ModelState.AddModelError("", "Error occured in model");
                ViewModel.Intake.IntakeViewModel intakemodel = new ViewModel.Intake.IntakeViewModel();
                intakemodel.PaymentsViewModel = new ViewModel.Payments.PaymentsViewModel();
                intakemodel.PharmacyViewModel = new ViewModel.Pharmacy.PharmacyViewModel();
                intakemodel.PharmacyViewModel.Pharmacies = new List<Models.PharmacyDetails>();

                PharmacyDetails pd = new PharmacyDetails();
                pd.PharmacyAddress = "Karachi";
                pd.PharmacyID = "1";
                pd.PharmacyName = "CVS pharmacy";
                intakemodel.PharmacyViewModel.Pharmacies.Add(pd);

                CoreDTO.DTOContactDetails DTOCD = new CoreDTO.DTOContactDetails();
                DTOCD.Address1 = "ABC";
                DTOCD.Address2 = "BCD";
                DTOCD.Email = "ASDDADS";
                DTOCD.CountryList = new List<CoreDTO.Country> { new CoreDTO.Country { Name = "USA", Value = "US" }, new CoreDTO.Country { Name = "Canada", Value = "US" } };
                DTOCD.StateList = new List<CoreDTO.State> { new CoreDTO.State { Name = "NewYork", Value = "US" }, new CoreDTO.State { Name = "Chicago", Value = "US" } };

                ContactDetailsViewModel CDVM = new ContactDetailsViewModel(DTOCD);
                intakemodel.ContactDetailsViewModel = CDVM;

                return View("Index", intakemodel);
            //}

        }
        #endregion

        #region PharmacySearch
        public ActionResult Pharmacy()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Pharmacy(PharmacyViewModel pvm,IEnumerable<HttpPostedFileBase> file)
        {
            return Json(new {Sucess="Saved Sucessfully" });
        }
        [HttpGet]
        public JsonResult SearchPharmacy(string Zipcode, string State)
        {
                PharmacyViewModel pvm = new PharmacyViewModel();
                pvm.Pharmacies = new List<PharmacyDetails>();
                PharmacyDetails pd = new PharmacyDetails();
                pd.PharmacyAddress = "Karachi";
                pd.PharmacyID = "1";
                pd.PharmacyName = "CVS pharmacy";
                pvm.Pharmacies.Add(pd);


                PharmacyDetails pd1 = new PharmacyDetails();
                pd1.PharmacyAddress = "Karachi";
                pd1.PharmacyID = "1";
                pd1.PharmacyName = "Shahi Pharmacy";
                pvm.Pharmacies.Add(pd1);
                return Json(new { data = pvm }, JsonRequestBehavior.AllowGet);
        }
        #endregion

       
        public ActionResult ShowPicture()
        {
            //FileInfo ff = new FileInfo(@"C:\Users\Saif10p\Desktop\12674435_10153380623731724_497802467_n.jpg");
            //FileStream fs = ff.OpenRead();
            //byte[] arr = new byte[fs.ReadByte()];
            //fs.Read(arr, 0, arr.Count());
            //// System.IO.File().ReadAllBytes(@"C:\Users\Saif10p\Desktop\12674435_10153380623731724_497802467_n.jpg");
            //return new FileContentResult(arr, "image/jpeg");


            string path = Server.MapPath("~/images/computer.png");
            byte[] imageByteData = System.IO.File.ReadAllBytes(@"C: \Users\Saif10p\Desktop\12674435_10153380623731724_497802467_n.jpg");
            return File(imageByteData, "image/png");

        }

        public ActionResult ContactDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactDetails(ContactDetailsViewModel vm)
        {
            return View();
        }
    }
}