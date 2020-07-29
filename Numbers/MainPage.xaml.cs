using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Numbers
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private Random _random;
        private MainViewModel _vm;

        public MainPage()
        {
            InitializeComponent();
            //ButtonCircleRenderer.Init();
        }

        private void Handle_Clicked(object sender, EventArgs e)
        {
            _random = new Random();
            _vm = BindingContext as MainViewModel;
            var num = GenerateFirstRow();

            _vm.Numbers = String.Join(".", num[1].Select(x => x.ToString()).ToArray());

            for (int i = 1; i <= num.Count; i++)
            {
                CalculatePyramid(num, i);
            }

            _vm.Result = num[_vm.Count].First();
            _vm.ResultVisibility = false;
        }

        private Dictionary<int, List<int>> GenerateFirstRow()
        {
            var num = new Dictionary<int, List<int>>();
            var nums = new List<int>();
            for (var i = 0; i < _vm?.Count; i++)
            {
                nums.Add(_random.Next(1, 19));
            }
            num.Add(1, nums);
            return num;
        }

        private static void CalculatePyramid(Dictionary<int, List<int>> num, int i)
        {
            num.TryGetValue(i, out var lastRow);
            if (lastRow.Count == 1) return;
            
            var nextRow = new List<int>();
            for (int j = 0; j < lastRow.Count - 1; j++)
            {
                nextRow.Add(lastRow[j] + lastRow[j + 1]);
            }

            num.Add(i + 1, nextRow);
        }

        private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            _vm = BindingContext as MainViewModel;
            _vm.Count = (int)e.NewValue;
        }

        private void Handle_Clicked2(object sender, EventArgs e)
        {
            _vm = BindingContext as MainViewModel;
            _vm.ResultVisibility = true;
        }
    }
}
