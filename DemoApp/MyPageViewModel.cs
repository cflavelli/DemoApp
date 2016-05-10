using System.Collections.Generic;
using Xamarin.Forms;

namespace DemoApp
{
    public class MyPageViewModel
    {
        public List<string> Items { get; set; }

        public string LabelText { get; set; }

        public Color PageBackgroundColor { get; set; }
    }

    public class MyDesignPageViewModel
    {
        public MyDesignPageViewModel()
        {
            Items = new List<string> { "Item1", "Item2", "Item3", "Item4", "Item5", };
        }

        public List<string> Items { get; set; }

        public string LabelText { get; set; } = "Olá desenvolvedores Xamarin!";

        public Color PageBackgroundColor { get; set; } = Color.FromHex("#3498db");
    }
}
