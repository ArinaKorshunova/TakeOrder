using BuisnessProcess.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BuisnessProcess.ViewModel
{
    public class MainWindowViewModel : Window
    {
        #region Свойства

        public int? CurrentTable { get; set; }

        #endregion

        #region Свойства зависимости

        public List<Table> Tables   
        {
            get { return (List<Table>)GetValue(TablesProperty); }
            set { SetValue(TablesProperty, value); }
        }
        
        public static readonly DependencyProperty TablesProperty =
            DependencyProperty.Register("Tables", typeof(List<Table>), typeof(MainWindowViewModel), new PropertyMetadata(null));
        

        public string CurrentData
        {
            get { return (string)GetValue(CurrentDataProperty); }
            set { SetValue(CurrentDataProperty, value); }
        }
        
        public static readonly DependencyProperty CurrentDataProperty =
            DependencyProperty.Register("CurrentData", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(null));
        

        public Table SelectedTable
        {
            get { return (Table)GetValue(SelectedTableProperty); }
            set { SetValue(SelectedTableProperty, value); }
        }
        
        public static readonly DependencyProperty SelectedTableProperty =
            DependencyProperty.Register("SelectedTable", typeof(Table), typeof(MainWindowViewModel), new PropertyMetadata(null));

        
        public DelegateCommand<int?> MakeOrderCommand
        {
            get { return (DelegateCommand<int?>)GetValue(MakeOrderCommandProperty); }
            set { SetValue(MakeOrderCommandProperty, value); }
        }
        
        public static readonly DependencyProperty MakeOrderCommandProperty =
            DependencyProperty.Register("MakeOrderCommand", typeof(DelegateCommand<int?>), typeof(MainWindowViewModel), new PropertyMetadata(null));

        
        public DelegateCommand<int?> CloseOrderCommand
        {
            get { return (DelegateCommand<int?>)GetValue(CloseOrderCommandProperty); }
            set { SetValue(CloseOrderCommandProperty, value); }
        }

        public static readonly DependencyProperty CloseOrderCommandProperty =
            DependencyProperty.Register("CloseOrderCommand", typeof(DelegateCommand<int?>), typeof(MainWindowViewModel), new PropertyMetadata(null));

        
        public AddOrderViewModel AddOrderVM
        {
            get { return (AddOrderViewModel)GetValue(AddOrderVMProperty); }
            set { SetValue(AddOrderVMProperty, value); }
        }
        
        public static readonly DependencyProperty AddOrderVMProperty =
            DependencyProperty.Register("AddOrderVM", typeof(AddOrderViewModel), typeof(MainWindowViewModel), new PropertyMetadata(null));

        
        public Visibility ShowOrderVisibility
        {
            get { return (Visibility)GetValue(ShowOrderVisibilityProperty); }
            set { SetValue(ShowOrderVisibilityProperty, value); }
        }
        
        public static readonly DependencyProperty ShowOrderVisibilityProperty =
            DependencyProperty.Register("ShowOrderVisibility", typeof(Visibility), typeof(MainWindowViewModel), new PropertyMetadata(null));


        public Visibility AddOrderVisibility
        {
            get { return (Visibility)GetValue(AddOrderVisibilityProperty); }
            set { SetValue(AddOrderVisibilityProperty, value); }
        }

        public static readonly DependencyProperty AddOrderVisibilityProperty =
            DependencyProperty.Register("AddOrderVisibility", typeof(Visibility), typeof(MainWindowViewModel), new PropertyMetadata(null));


        public ShowOrderViewModel ShowOrderVM
        {
            get { return (ShowOrderViewModel)GetValue(ShowOrderVMProperty); }
            set { SetValue(ShowOrderVMProperty, value); }
        }

        public static readonly DependencyProperty ShowOrderVMProperty =
            DependencyProperty.Register("ShowOrderVM", typeof(ShowOrderViewModel), typeof(MainWindowViewModel), new PropertyMetadata(null));


        public DelegateCommand SelectedTableCommand
        {
            get { return (DelegateCommand)GetValue(SelectedTableCommandProperty); }
            set { SetValue(SelectedTableCommandProperty, value); }
        }
        
        public static readonly DependencyProperty SelectedTableCommandProperty =
            DependencyProperty.Register("SelectedTableCommand", typeof(DelegateCommand), typeof(MainWindowViewModel), new PropertyMetadata(null));

        
        public DelegateCommand SaveOrderCommand
        {
            get { return (DelegateCommand)GetValue(SaveOrderCommandProperty); }
            set { SetValue(SaveOrderCommandProperty, value); }
        }
        
        public static readonly DependencyProperty SaveOrderCommandProperty =
            DependencyProperty.Register("SaveOrderCommand", typeof(DelegateCommand), typeof(MainWindowViewModel), new PropertyMetadata(null));
        

        public decimal? DaySumm
        {
            get { return (decimal?)GetValue(DaySummProperty); }
            set { SetValue(DaySummProperty, value); }
        }
        
        public static readonly DependencyProperty DaySummProperty =
            DependencyProperty.Register("DaySumm", typeof(decimal?), typeof(MainWindowViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public MainWindowViewModel()
        {
            Tables = FillData.Tables;
            CurrentData = string.Format("{0} Администратор: {1}", DateTime.Today.ToString("dd.MM.yyyy"), FillData.Administrator);

            MakeOrderCommand = new DelegateCommand<int?>(MakeOrder);
            CloseOrderCommand = new DelegateCommand<int?>(CloseOrder);
            SelectedTableCommand = new DelegateCommand(SelectTable);
            SaveOrderCommand = new DelegateCommand(SaveOrder);
            DaySumm = 0;

            AddOrderVM = new AddOrderViewModel();
            ShowOrderVM = new ShowOrderViewModel();
            AddOrderVisibility = Visibility.Hidden;
            ShowOrderVisibility = Visibility.Hidden;
        }


        #endregion

        #region Методы

        private void MakeOrder(int? tableNumber)
        {
            CurrentTable = tableNumber;

            AddOrderVM = tableNumber != null ? new AddOrderViewModel((int)tableNumber) : new AddOrderViewModel();
            ShowOrderVisibility = Visibility.Hidden;
            AddOrderVisibility = Visibility.Visible;
        }

        private void SelectTable()
        {
            if (SelectedTable != null)
            {
                CurrentTable = SelectedTable.Number;

                if (SelectedTable != null && !SelectedTable.IsFree)
                {
                    ShowOrderVM = new ShowOrderViewModel(SelectedTable);
                    AddOrderVisibility = Visibility.Hidden;
                    ShowOrderVisibility = Visibility.Visible;
                }
                else
                {
                    ShowOrderVisibility = Visibility.Hidden;
                }
            }
        }

        private void CloseOrder(int? tableNumber)
        {
            CurrentTable = tableNumber;

            var currentTable = Tables.FirstOrDefault(x => x.Number == CurrentTable);
            currentTable.WaiterName = null;
            currentTable.Order = new List<Models.Menu>();
            currentTable.IsFree = true;

            UpdateTableData();

            AddOrderVisibility = Visibility.Hidden;
            ShowOrderVisibility = Visibility.Hidden;

        }

        private void SaveOrder()
        {
            var order = AddOrderVM.Menu.Where(x => x.IsAddedToOrder).ToList();
            
            var currentTable = Tables.FirstOrDefault(x => x.Number == CurrentTable);
            currentTable.WaiterName = AddOrderVM.Table.WaiterName;
            currentTable.Order = order;
            currentTable.IsFree = false;

            DaySumm += currentTable.TotalPrice;

            UpdateTableData();

            ShowOrderVM = new ShowOrderViewModel(currentTable);
            AddOrderVisibility = Visibility.Hidden;
            ShowOrderVisibility = Visibility.Visible;
        }

        private void UpdateTableData()
        {
            var allTables = Tables;
            Tables = new List<Table>();
            Tables = allTables;
        }

        #endregion 

    }
}
