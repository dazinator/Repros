using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo
{
    public class PageProvider : IPageProvider
    {

        private readonly IServiceProvider _serviceProvider;       

        public PageProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;          
        }

        public TPage GetContentPage<TPage>()
            where TPage : ContentPage
        {
            var page = _serviceProvider.GetRequiredService<TPage>();
            return page;
        }

        public NavigationPage GetMainNavigationPage()
        {

            var page = GetMainPage();
            var navPage = new NavigationPage(page);

            navPage.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            navPage.BarTextColor = Color.White;

            return navPage;

        }

        public Page GetMainPage()
        {
            if (!IsUserLoggedIn())
            {
                var accountSelect = _serviceProvider.GetRequiredService<AccountSelectPage>();
                return accountSelect;
            }
            else
            {
                var todolistpage = _serviceProvider.GetRequiredService<TodoListPage>();
                return todolistpage;               
            }
        }

        protected virtual bool IsUserLoggedIn()
        {
            return Thread.CurrentPrincipal.Identity.IsAuthenticated;
        }

    }
}

