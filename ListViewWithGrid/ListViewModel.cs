using System.ComponentModel;

namespace ListViewWithGrid
{
    public class ListViewModel: INotifyPropertyChanged
    {

		public string Description { get; set; }
		public int Qty { get; set; }
		public bool Ordered { get; set; }

        public ListViewModel(string description, int qty, bool ordered){

            this.Description = description;
            this.Qty = qty;
            this.Ordered = ordered;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
