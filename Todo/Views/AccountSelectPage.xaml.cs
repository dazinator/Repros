using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Todo
{
    public partial class AccountSelectPage : ContentPage
    {

        private readonly TodoItemDatabase _db;    
        private readonly IPageProvider _pageProvider;     

        public AccountSelectPage(TodoItemDatabase db, IPageProvider pageProvider)
        {
            _db = db;
         
            _pageProvider = pageProvider;         
            InitializeComponent();         

            ApplicationEnvironments = new ObservableCollection<Server>(db.Servers.ToArray());          

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Reset the 'resume' id, since we just want to re-start here
            // ((App)App.Current).ResumeAtTodoId = -1;
            RefreshAccountsList();
       
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        public async Task RefreshAccountsList()
        {
          
        }

     

      


        async void OnCancel(object sender, EventArgs e)
        {          
            await Navigation.PopAsync();
        }

        async void OnListItemSelected(object sender, ItemTappedEventArgs e)
        {
         
          
        }      

        public ObservableCollection<Server> ApplicationEnvironments { get; set; }

        private Server _server;

        public Server SelectedApplicationEnvironment
        {
            get
            {
                return _server;
            }
            set
            {
                _server = value;
                //_options.DefaultServerName = value?.Name;
                RefreshAccountsList();
            }
        }

    }
}
