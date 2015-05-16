using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace DataArt
{
    public class MainWindowsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        private readonly CustomersEntities _dbContext = new CustomersEntities();

        public CustomersEntities DbContext
        {
            get { return _dbContext; }
        }



        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (value == null || _selectedCustomer == value)
                    return;
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
                OnPropertyChanged("States");
            }
        }



        private ObservableCollection<State> _states;

        public ObservableCollection<State> States
        {
            get { return SelectedCustomer == null ? null : new ObservableCollection<State>(_states); }
            private set
            {
                if (_states == value)
                    return;
                _states = value;
                OnPropertyChanged("States");
            }
        }


        public bool IsChanged
        {
            get { return DbContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified).Any(); }
            set { OnPropertyChanged("IsChanged"); }
        }



        public MainWindowsViewModel()
        {
            States = new ObservableCollection<State>(DbContext.States.OrderBy(state => state.Name));
        }
    }
}