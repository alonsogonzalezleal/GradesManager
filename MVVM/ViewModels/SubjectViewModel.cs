using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Android.App;
using GradesManager.MVVM.Models;
using PropertyChanged;

namespace GradesManager.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SubjectViewModel
    {
        public Subject Subject { get; set; }

        public ICommand ClickCalculate { get; }

        public decimal FinalGrade { get; set; }

        public SubjectViewModel() {
            Subject = new Subject
            {
                Name = string.Empty,
                Item1 = new Item {},
                Item2 = new Item {},
                Item3 = new Item {}
            };

            ClickCalculate = new Command(() =>
                {
                    int totalValue = calculateTotalValue();

                    if (totalValue!=100)
                    {
                        App.Current.MainPage.DisplayAlert("Error", "La suma de los valores de los rubros debe sumar 100%. Actualmente suma " + totalValue + "%", "Aceptar");
                        return;
                    }

                    decimal finalGrade = calculateTotalGrade();

                    if (finalGrade > 10 || finalGrade < 0)
                    {
                        App.Current.MainPage.DisplayAlert("Error", "La calificación total no puede ser mayor a 10. Actualmente da " + finalGrade, "Aceptar");
                        return;

                    }

                    FinalGrade = finalGrade;

                }
            );
        }

        private int calculateTotalValue()
        {
            return Subject.Item1.Value + Subject.Item2.Value + Subject.Item3.Value;
        }

        private decimal calculateTotalGrade()
        {
            return (getIndividualGrade(Subject.Item1.Grade, Subject.Item1.Value) + getIndividualGrade(Subject.Item2.Grade, Subject.Item2.Value) + getIndividualGrade(Subject.Item3.Grade, Subject.Item3.Value))/10;
        }

        private decimal getIndividualGrade(decimal ActualGrade, decimal ActualValue)
        {
            return ((ActualGrade*ActualValue)/10);
        }
    }
}
