using BuisnessProcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BuisnessProcess.ViewModel
{
    public class ShowOrderViewModel : Page
    {
        #region Свойства завсимости

        public Table Table
        {
            get { return (Table)GetValue(TableProperty); }
            set { SetValue(TableProperty, value); }
        }

        public static readonly DependencyProperty TableProperty =
            DependencyProperty.Register("Table", typeof(Table), typeof(ShowOrderViewModel), new PropertyMetadata(null));

        #endregion


        #region Конструкторы

        public ShowOrderViewModel()
        {
            Table = FillData.Tables.First();
        }


        public ShowOrderViewModel(Table table)
        {
            Table = table;
        }

        #endregion
    }
}
