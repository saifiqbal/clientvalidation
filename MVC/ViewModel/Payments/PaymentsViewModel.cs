using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModel.Payments
{
    public class PaymentsViewModel
    {
        public bool IsCopay { get; set; }
        public string CopayCode { get; set; }

        [Required(ErrorMessage ="amount is required")]
        public string Amount { get; set; }
        public string CreditCardNumber { get; set;}
        public string CreditCardType { get; set; }
        [ValidateFile]
        public HttpPostedFileBase ProfilePhoto { get; set; }
        [Required(ErrorMessage ="Dob is required")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString =
        //   "{0:yyyy-MM-dd}",
        //    ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage ="Future dates not allowed")]
        public DateTime? DateOfBirth { get; set; }
    }
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int MaxContentLength = 1024 * 1024 * 3; //3 MB
            string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };

            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", AllowedFileExtensions);
                return false;
            }
            else if (file.ContentLength > MaxContentLength)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            return !((DateTime)value > DateTime.Now);
        }
    }
}