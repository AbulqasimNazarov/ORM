using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Students
    {
        public int? StudentId { get; set; }
        public string? StudentName { get; set; }
        public int? TeacherId { get; set; }
        public string? TeacherName { get; set; }
    }
}
