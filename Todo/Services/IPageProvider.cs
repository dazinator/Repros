using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo
{
    public interface IPageProvider
    {
        TPage GetContentPage<TPage>()
            where TPage : ContentPage;


        NavigationPage GetMainNavigationPage();

        Page GetMainPage();


    }
}

