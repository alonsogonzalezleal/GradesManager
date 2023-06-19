using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GradesManager.MVVM.Models;

namespace GradesManager.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SemesterViewModel
    {
        public Semester Semester { get; set; }

        public ICommand ClickCalculate { get; }

        public decimal FinalGrade { get; set; }
        public string Message { get; set; }
        public decimal ToGetSix { get; set; }
        public decimal ToGetTen { get; set; }

        public SemesterViewModel()
        {
            Semester = new Semester
            {
                Name = string.Empty,
                Item1 = new Item { },
                Item2 = new Item { },
                Item3 = new Item { }
            };

            ClickCalculate = new Command(() =>
            {
                int totalValue = calculateTotalValue();

                if (totalValue != 100)
                {
                    App.Current.MainPage.DisplayAlert("Error", "La suma de los valores de los rubros debe sumar 100%. Actualmente suma " + totalValue + "%", "Aceptar");
                    return;
                }

                decimal finalGrade = Math.Round(calculateTotalGrade());

                if (finalGrade > 10 || finalGrade<0)
                {
                    App.Current.MainPage.DisplayAlert("Error", "La calificación total no puede ser mayor a 10. Actualmente da " + finalGrade, "Aceptar");
                    return;

                }

                decimal toGetSix = toGetSpecificGrade(6, finalGrade, Semester.Item3.Value);
                decimal toGetTen = toGetSpecificGrade(10, finalGrade, Semester.Item3.Value);

                if (toGetSix > -1)
                {
                    ToGetSix = toGetSpecificGrade(6, finalGrade, Semester.Item3.Value);
                } else
                {
                    ToGetSix = 0;
                }

                if (toGetTen > -1) {
                    ToGetTen = toGetSpecificGrade(10, finalGrade, Semester.Item3.Value);
                    Message = "¡Ánimo! Si se puede";
                } else
                {
                    ToGetTen = 0;
                    Message = "¡Lástima! Sigue participando";
                }                

                FinalGrade = finalGrade;

            }
            );
        }

        private int calculateTotalValue()
        {
            return Semester.Item1.Value + Semester.Item2.Value + Semester.Item3.Value;
        }

        private decimal calculateTotalGrade()
        {
            return (getIndividualGrade(Semester.Item1.Grade, Semester.Item1.Value) + getIndividualGrade(Semester.Item2.Grade, Semester.Item2.Value) + getIndividualGrade(Semester.Item3.Grade, Semester.Item3.Value)) / 10;
        }

        private decimal getIndividualGrade(decimal ActualGrade, decimal ActualValue)
        {
            return ((ActualGrade * ActualValue) / 10);
        }

        private decimal toGetSpecificGrade(decimal SpecificGrade, decimal ActualGrade, int ActualValue)
        {
            decimal differenceInValue = (SpecificGrade - ActualGrade)*10;
            decimal necessaryGrade = Math.Round((differenceInValue * 10) / ActualValue, 2);

            if (necessaryGrade > 10) {
                necessaryGrade = -1;
            }

            return necessaryGrade;
        }
    }
}
