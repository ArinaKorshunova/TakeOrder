using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BuisnessProcess.Models
{
    public class Table
    {
        public int Number { get; set; }
        public string Name { get { return "Стол №" + Number; } }
        public bool IsFree { get; set; }
        public List<Menu> Order { get; set; }
        public string WaiterName { get; set; }
        public decimal TotalPrice { get { return Order.Sum(x => x.Price); } }
        public Visibility MakeOrder { get { return IsFree ? Visibility.Visible : Visibility.Hidden; } }
        public Visibility CloseOrder { get { return !IsFree ? Visibility.Visible : Visibility.Hidden; } }
    }
}
