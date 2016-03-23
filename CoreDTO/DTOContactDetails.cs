using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDTO
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class DTOContactDetails
    {
        public DTOContactDetails()
        {
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public List<Country> CountryList{get;set;}
        public List<State> StateList { get; set; }
    }
    public class Country {
        public string Name { get; set; }
        public string Value { get; set; }

    }
    public class State
    {
        public string Name { get; set; }
        public string Value { get; set; }

    }
}
