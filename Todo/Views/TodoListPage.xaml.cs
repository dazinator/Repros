using System;
using System.Diagnostics;
using System.Threading;
using Xamarin.Forms;

namespace Todo
{


    public partial class TodoListPage : ContentPage
    {
       

        private readonly TodoItemDatabase _db;      
        private readonly IPageProvider _pageProvider;      
      

        public TodoListPage(TodoItemDatabase db,          
            IPageProvider pageProvider)
        {
            _db = db;          
            _pageProvider = pageProvider;           
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await _db.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            var todoPage = _pageProvider.GetContentPage<TodoItemPage>();
            todoPage.BindingContext = new TodoItem();
            await Navigation.PushAsync(todoPage);
        }

        async void OnListItemSelected(object sender, ItemTappedEventArgs e)
        {
            ((App)App.Current).ResumeAtTodoId = (e.Item as TodoItem).ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + (e.Item as TodoItem).ID);

            var todoPage = _pageProvider.GetContentPage<TodoItemPage>();
            todoPage.BindingContext = e.Item as TodoItem;
            await Navigation.PushAsync(todoPage);
        }

        async void OnAddAccount(object sender, EventArgs e)
        {
         
        }

        async void OnSelectAccount(object sender, EventArgs e)
        {
            var accountSelect = _pageProvider.GetContentPage<AccountSelectPage>();
          //  accountSelect.
            await Navigation.PushAsync(accountSelect);
            // await _accountService.AddAccount("com.todo.auth_example", null);
        }

        async void OnGetToken(object sender, EventArgs e)
        {
        

        }



    }
}
