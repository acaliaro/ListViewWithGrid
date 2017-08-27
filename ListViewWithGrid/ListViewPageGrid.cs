using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ListViewWithGrid
{
    public class ListViewPageGrid : ContentPage
    {

        ObservableCollection<ListViewModel> _data { get; set;}

        public ListViewPageGrid()
        {
            _data = new ObservableCollection<ListViewModel>();
            _data.Add(new ListViewModel("Apples", 1000, false));
            _data.Add(new ListViewModel("Bananas", 2000, true));
            _data.Add(new ListViewModel("Kiwi", 400, true));

            // Crete a grid for "title"
            Grid grid = CreateGrid();
            grid.Children.Add(new Label { Text = "Description", TextColor = Color.Red, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center}, 0, 1, 0, 1);
			grid.Children.Add(SeparatorV(), 1, 2, 0, 1);
			grid.Children.Add(new Label { Text = "Qty", TextColor = Color.Red, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 2, 3, 0, 1);
			grid.Children.Add(SeparatorV(), 3, 4, 0, 1);
			grid.Children.Add(new Label { Text = "Ordered", TextColor = Color.Red, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 4, 5, 0, 1);

			grid.Children.Add(SeparatorH(), 0, 5, 1, 2);

			// Create the ListView to visualize my data
			ListView lv = new ListView() { HasUnevenRows = true, SeparatorVisibility = SeparatorVisibility.None};
            lv.ItemsSource = _data;
            lv.ItemTemplate = new DataTemplate(typeof(ListViewTemplateGrid));

            StackLayout sl = new StackLayout() { Children = {grid, lv}, Spacing = 0};

            this.Content = sl;
        }

		static Grid CreateGrid()
		{

            Grid grid = new Grid(){RowSpacing = 0, ColumnSpacing = 0};

			// Define row 
			RowDefinition rd = new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) };
            RowDefinition rdSeparator = new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) };

			// Define columns (one for every property I have to visualize)
			ColumnDefinition cdDescription = new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) };
			ColumnDefinition cdQty = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
			ColumnDefinition cdOrdered = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };

			// Add row and columns to grid
			grid.RowDefinitions.Add(rd);
            grid.RowDefinitions.Add(rdSeparator);

			grid.ColumnDefinitions.Add(cdDescription);
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Absolute) }); // Separator
			grid.ColumnDefinitions.Add(cdQty);
			grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Absolute) }); // Separator
			grid.ColumnDefinitions.Add(cdOrdered);

			return grid;
		}

        static BoxView SeparatorV(){

            return new BoxView() { WidthRequest = 2, BackgroundColor = Color.Red };
        }

		static BoxView SeparatorH()
		{

			return new BoxView() { HeightRequest = 2, BackgroundColor = Color.Red };
		}

        class ListViewTemplateGrid : ViewCell
        {
            public ListViewTemplateGrid(){


                Label labelDescription = new Label() {VerticalOptions = LayoutOptions.Center};
                labelDescription.SetBinding(Label.TextProperty, "Description");

                Label labelQty = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
                labelQty.SetBinding(Label.TextProperty, "Qty");

                Label labelOrdered = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
                labelOrdered.SetBinding(Label.TextProperty, "Ordered");

                // Add controls to the grid
                Grid grid = CreateGrid();
                grid.Children.Add(labelDescription, 0,1,0,1);
                grid.Children.Add(SeparatorV(), 1, 2, 0, 1);
                grid.Children.Add(labelQty, 2, 3, 0, 1);
				grid.Children.Add(SeparatorV(), 3, 4, 0, 1);
				grid.Children.Add(labelOrdered, 4, 5, 0, 1);

                grid.Children.Add(SeparatorH(), 0, 5, 1, 2);

                this.View = grid;

            }
        }
    }
}
