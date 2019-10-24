using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoSite.Dtos
{
    public class CourseDto
    {
               
        public int CourseID { get; set; }
        public string Title { get; set; }
        public Nullable<int> Credits { get; set; }


    }
}