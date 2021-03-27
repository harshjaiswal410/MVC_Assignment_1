using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAssignment.Models
{
    public class RegistrationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RollNo { get; set; }
        public int Cource_id { get; set; }
        public string Cource_name { get; set; }
        public int ID { get; set; }
        public string Gender { get; set; }
        public int City_id { get; set; }
        public string City_name { get; set; }
        public int State_id { get; set; }
        public string State_name { get; set; }

        //public string Gender { get; set; }
        //public string State { get; set; }
        //public string City { get; set; }
        //public string Cource { get; set; }

        public List<GenderModel> GenderList { get; set; }
        public List<CourceModel> Courcelist { get; set; }
        public List<StateModel> StateList { get; set; }
        public List<SelectListItem> CityList { get; set; }
    }
}