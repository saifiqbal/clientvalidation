using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.ViewModel
{
    public class ContactDetailsViewModel
    {
        public ContactDetailsViewModel() { }
        public ContactDetailsViewModel(CoreDTO.DTOContactDetails DTOContact) {
            FirstName = DTOContact.FirstName;
            LastName = DTOContact.LastName;
            Email = DTOContact.Email;
            Address1 = DTOContact.Address1;
            Address2 = DTOContact.Address2;
            CountryList = DTOContact.CountryList.Select(i => new SelectListItem() {Text = i.Name,Value=i.Value });
            StateList = DTOContact.StateList.Select(i => new SelectListItem() { Text = i.Name, Value = i.Value });
        }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string SelectedCountry { get; set;}
        public string SelectedState { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }
    }
}