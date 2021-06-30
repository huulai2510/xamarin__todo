using System;
using System.IO;
using todo.Views;
using Todo.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todo
{
    public partial class App : Application
    {
        static TodoItemDatabase database;
        // Create the database connection as a singleton.
        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TodoListPage())
            {
                BarTextColor = Color.White,
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
