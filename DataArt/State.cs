namespace DataArt
{
    partial class State
    {
        public bool IsChecked
        {
            get { return MainWindow.ViewModel.SelectedCustomer.States.Contains(this); }
            set
            {
                if (value == IsChecked)
                    return;
                if (value)
                    MainWindow.ViewModel.SelectedCustomer.States.Add(this);
                else
                    MainWindow.ViewModel.SelectedCustomer.States.Remove(this);
                OnPropertyChanged("IsChecked");
                MainWindow.ViewModel.IsChanged = true;
            }
        }
    }
}
