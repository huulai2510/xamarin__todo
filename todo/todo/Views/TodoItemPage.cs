using System;
using Todo.Data;
using Todo.Models;
using Xamarin.Forms;

namespace todo.Views
{
    public partial class TodoItemPage : ContentPage
    {
        Label IDLabel;
        Entry entryID;
        Label nameLabel;
        Entry entryName;
        Button saveButton;
        Button deleteButton;
        StackLayout stackLayout;
        public TodoItemPage()
        {
            Title = "Todo";
            IDLabel = new Label { Text = "ID" };

            entryID = new Entry {
                IsReadOnly = true,
                Text = "0"
            };
            entryID.SetBinding(Entry.TextProperty, "ID");

            nameLabel = new Label { Text = "Name" };

            entryName = new Entry();
            entryName.SetBinding(Entry.TextProperty, "Name");

            saveButton = new Button
            {
                Text = "Save",
                TextColor = Color.White,
                BackgroundColor = Color.Blue,
            };
            saveButton.Clicked += SaveButton_Clicked;

            deleteButton = new Button
            {
                Text = "Delete",
                TextColor = Color.White,
                BackgroundColor = Color.Red
            };
            deleteButton.Clicked += DeleteButton_Clicked;

            stackLayout = new StackLayout {
                Margin = new Thickness(20)
            };

            stackLayout.Children.Add(IDLabel);
            stackLayout.Children.Add(entryID);
            stackLayout.Children.Add(nameLabel);
            stackLayout.Children.Add(entryName);
            stackLayout.Children.Add(saveButton);
            stackLayout.Children.Add(deleteButton);

            Content = stackLayout;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            deleteButton.IsEnabled = entryID.Text != "0";
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.DeleteTodoAsync(todoItem);
            await Navigation.PopAsync();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.SaveTodoAsync(todoItem);
            await Navigation.PopAsync();
        }
    }
}
