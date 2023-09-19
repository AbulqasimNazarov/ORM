using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToDoApp.Entities;

public class Note
{
    public int Id { get; set; }
    public string Name { get; set;}
    public string Priority { get; set;}
    public string Status { get; set;}

    public override string ToString() => $"{Id}.{Name}, {Priority}, {Status}";
}

