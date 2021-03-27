using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAssignment.Models
{
    public class CityModel
    {
        public int City_id { get; set; }
        public string City_name { get; set; }
        public List<SelectListItem> Citylist { get; set; }
    }
}