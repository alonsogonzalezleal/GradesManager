using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesManager.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Semester
    {
        public string Name { get; set; }
        public Item Item1 { get; set; }
        public Item Item2 { get; set; }
        public Item Item3 { get; set; }

        public Semester()
        {
        }
    }
}
