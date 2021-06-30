using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace todo.Views
{
    class TodoCell : ViewCell
    {
        public TodoCell()
        {
            StackLayout horizontalLayout = new StackLayout();
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            horizontalLayout.Spacing = 50;

            Label left = new Label();
            Label right = new Label();
            //set bindings
            left.SetBinding(Label.TextProperty, "ID");
            right.SetBinding(Label.TextProperty, "Name");

            horizontalLayout.Children.Add(left);
            horizontalLayout.Children.Add(right);

            View = horizontalLayout;
        }
    }
}
