using BuisnessProcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BuisnessProcess.ViewModel
{
    public class AddOrderViewModel : Window
    {
        #region Свойства зависимости
        
        public Table Table
        {
            get { return (Table)GetValue(TableProperty); }
            set { SetValue(TableProperty, value); }
        }
        
        public static readonly DependencyProperty TableProperty =
            DependencyProperty.Register("Table", typeof(Table), typeof(AddOrderViewModel), new PropertyMetadata(null));

        

        public List<Menu> Menu
        {
            get { return (List<Menu>)GetValue(MenuProperty); }
            set { SetValue(MenuProperty, value); }
        }
        
        public static readonly DependencyProperty MenuProperty =
            DependencyProperty.Register("Menu", typeof(List<Menu>), typeof(AddOrderViewModel), new PropertyMetadata(null));



        #endregion


        #region Конструкторы

        public AddOrderViewModel(int tableNumber)
        {
            Table = FillData.Tables.FirstOrDefault(x => x.Number == tableNumber);
            Menu = FillData.GetMenu();
        }

        public AddOrderViewModel()
        {
            Table = FillData.Tables.First();
            Menu = FillData.GetMenu();
        }

        #endregion
    }
}
