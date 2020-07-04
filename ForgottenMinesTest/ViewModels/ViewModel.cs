using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ForgottenMinesTest.Models;
using Xamarin.Forms;

namespace ForgottenMinesTest.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
            
        public List<Model> Models { get; private set; }
        public List<Model> ThreeModels { get; private set; }

        public ICommand ExpandCommand { get; private set; }

        public bool IsExpanded { get; set; }
        public string Message { get; private set; } = "Done In Market []";

        public string InputCurrency { get; } = "Currency";
        public string currencyyparameter { get; } = "CurrencyParameter";
        public string MarketParameter { get; } = "Market Parameter";
        public string Result { get; } = "Result";

        




        public ViewModel()
        {
            CreateCollection();
            ThreeModels = Models.Take(3).ToList();
            ExpandCommand = new Command<Model>(Expand);
            IsExpanded = true;

    }

        void Expand(Model model)
        {
            Message = $"{model.Name} tapped.";
            OnPropertyChanged("Message");
        }

        void CreateCollection()
        {
            
           
            Models = new List<Model>();

            Models.Add(new Model

            {
                Name = "",
                Location = "",
                Details = "",
                ImageUrl = "",
                Currency="CurrencyUSD",
                Market="Market(ABC)",
                Result="Result(X)",
                Message = "New Test Message",

            });

           
            

            
        }

      


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
