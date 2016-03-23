using MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.ViewModel.Pharmacy
{
    public class PharmacyViewModel
    {
       [Required(ErrorMessage = "Please enter zipcode or city")]
       public string ZipCode { get; set; }
       [Required(ErrorMessage = "Please enter State")]
       public string State { get; set; }
       public List<PharmacyDetails> Pharmacies { get; set; }
    }
}