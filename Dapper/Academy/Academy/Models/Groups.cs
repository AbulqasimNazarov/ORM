using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Academy.Models
{
    public class Groups
    {
        public int? Id { get; set; }
        public string? GroupName { get; set; }
        public int? StudentsCount { get; set; }
        public int? TeacherId { get; set; }
        public string? TeacherName { get; set; }


       
    }

    
}
