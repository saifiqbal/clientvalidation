using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModel.Intake
{
    public class IntakeViewModel
    {
        public IntakeViewModel() { }
        public Payments.PaymentsViewModel PaymentsViewModel { get; set; }
        public Pharmacy.PharmacyViewModel PharmacyViewModel { get; set; }
        public ContactDetailsViewModel ContactDetailsViewModel { get; set; }
        public string phone { get; set; }

    }
}