using Xamarin.Forms;

namespace DemoApp
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
            BindingContext = new MyPageViewModel();
        }
    }
}
