using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradesManager.MVVM.Models;
using PropertyChanged;

namespace GradesManager.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Subject
    {
        public string Name { get; set; }
        public Item Item1 { get; set; }
        public Item Item2 { get; set; }
        public Item Item3 { get; set; }

        public Subject()
        {
        }
    }
}
