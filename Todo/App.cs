using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{

    public class App : Application
    {      

        private readonly IPageProvider _pageProvider;

        public App(IPageProvider pageProvider)
        {
            _pageProvider = pageProvider;

            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            MainPage = _pageProvider.GetMainNavigationPage();
        }    
        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            //Debug.WriteLine("OnStart");

            //// always re-set when the app starts
            //// users expect this (usually)
            ////			Properties ["ResumeAtTodoId"] = "";
            //if (Properties.ContainsKey("ResumeAtTodoId"))
            //{
            //	var rati = Properties["ResumeAtTodoId"].ToString();
            //	Debug.WriteLine("   rati=" + rati);
            //	if (!String.IsNullOrEmpty(rati))
            //	{
            //		Debug.WriteLine("   rati=" + rati);
            //		ResumeAtTodoId = int.Parse(rati);

            //		if (ResumeAtTodoId >= 0)
            //		{
            //			var todoPage = new TodoItemPage();
            //			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
            //			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
            //		}
            //	}
            //}
        }

        protected override void OnSleep()
        {
            //Debug.WriteLine("OnSleep saving ResumeAtTodoId = " + ResumeAtTodoId);
            //// the app should keep updating this value, to
            //// keep the "state" in case of a sleep/resume
            //Properties["ResumeAtTodoId"] = ResumeAtTodoId;
        }

        protected override void OnResume()
        {
            //Debug.WriteLine("OnResume");
            //if (Properties.ContainsKey("ResumeAtTodoId"))
            //{
            //	var rati = Properties["ResumeAtTodoId"].ToString();
            //	Debug.WriteLine("   rati=" + rati);
            //	if (!String.IsNullOrEmpty(rati))
            //	{
            //		Debug.WriteLine("   rati=" + rati);
            //		ResumeAtTodoId = int.Parse(rati);

            //		if (ResumeAtTodoId >= 0)
            //		{
            //			var todoPage = new TodoItemPage();
            //			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
            //			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
            //		}
            //	}
            //}
        }


    }
}

