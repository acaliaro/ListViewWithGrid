using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ListViewWithGrid
{
    public class ListViewPage : ContentPage
    {

        ObservableCollection<ListViewModel> _data { get; set;}

        public ListViewPage()
        {

            // Fill my data
            _data = new ObservableCollection<ListViewModel>();
            _data.Add(new ListViewModel("Apples", 1000, false));
            _data.Add(new ListViewModel("Bananas", 2000, true));
            _data.Add(new ListViewModel("Kiwi", 400, true));

            // Create my listview
            ListView lv = new ListView() { HasUnevenRows = true};
            lv.ItemsSource = _data;
            lv.ItemTemplate = new DataTemplate(typeof(ListViewTemplate));

            this.Content = lv;
        }

        private class ListViewTemplate : ViewCell
        {
            public ListViewTemplate(){


                // Use labels to visualize my data
                Label labelDescription = new Label();
                labelDescription.SetBinding(Label.TextProperty, "Description", stringFormat:"Description {0}");

                Label labelQty = new Label();
                labelQty.SetBinding(Label.TextProperty, "Qty", stringFormat:"Qty: {0}");

                Label labelOrdered = new Label();
                labelOrdered.SetBinding(Label.TextProperty, "Ordered", stringFormat:"Ordered {0}");

                StackLayout sl = new StackLayout() { Orientation = StackOrientation.Horizontal, Children={labelDescription, labelQty, labelOrdered}};

				this.View = sl;

            }
        }
    }
}
