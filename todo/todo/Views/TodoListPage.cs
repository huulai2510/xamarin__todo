using System;
using System.Collections.Generic;
using Todo.Models;
using Xamarin.Forms;

namespace todo.Views
{
    public partial class TodoListPage : ContentPage
    {
        ListView listView = new ListView();
        bool _isRunning;
        public TodoListPage()
        {
            Title = "Todo";
            ToolbarItem toolbarItem = new ToolbarItem
            {
                Text = "Example Item",
                IconImageSource = ImageSource.FromFile("plus.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };
            toolbarItem.Clicked += ToolbarItem_Clicked;
            // "this" refers to a Page object
            this.ToolbarItems.Add(toolbarItem);
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            

            List<TodoItem> todoItems = await App.Database.GettodosAsync();
            listView.ItemTemplate = new DataTemplate(typeof(TodoCell));
            listView.ItemsSource = todoItems;
            listView.Margin = new Thickness(20);
            listView.ItemTapped += ListView_ItemTapped;
            //listView.ItemSelected += ListView_ItemSelected;
            Content = listView;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (_isRunning)
                return;

            _isRunning = true;
            try
            {
                if (e.Item != null)
                {
                    await Navigation.PushAsync(new TodoItemPage
                    {
                        BindingContext = e.Item as TodoItem
                    });
                }
            }
            finally
            {
                _isRunning = false;
            }
            
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }
    }
}
