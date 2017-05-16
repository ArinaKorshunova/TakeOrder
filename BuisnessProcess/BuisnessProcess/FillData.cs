using BuisnessProcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessProcess
{
    public static class FillData
    {
        public static string Administrator;

        public static List<Table> Tables = GetTables();

        public static List<Menu> GetMenu()
        {
            List<Menu> menu = new List<Menu>();

            menu.Add(new Menu { Id = 1, Name = "Чай черный", Price = 30 });
            menu.Add(new Menu { Id = 2, Name = "Чай зеленый", Price = 25 });
            menu.Add(new Menu { Id = 3, Name = "Американо", Price = 90 });
            menu.Add(new Menu { Id = 4, Name = "Капучино", Price = 90 });
            menu.Add(new Menu { Id = 5, Name = "Латте", Price = 90 });
            menu.Add(new Menu { Id = 6, Name = "Наполеон", Price = 120 });
            menu.Add(new Menu { Id = 7, Name = "Тирамису", Price = 150 });
            menu.Add(new Menu { Id = 8, Name = "Творожно-черничный кейк", Price = 130 });
            menu.Add(new Menu { Id = 9, Name = "Ванильная панакота", Price = 120 });
            menu.Add(new Menu { Id = 10, Name = "Салат с креветками", Price = 250 });
            menu.Add(new Menu { Id = 11, Name = "Салат с печенью и грибами", Price = 190 });
            menu.Add(new Menu { Id = 12, Name = "Салат Цезарь", Price = 200 });
            menu.Add(new Menu { Id = 13, Name = "Салат с телятиной", Price = 220 });
            menu.Add(new Menu { Id = 14, Name = "Салат с лососем", Price = 280 });
            menu.Add(new Menu { Id = 15, Name = "Омлет", Price = 150 });
            menu.Add(new Menu { Id = 16, Name = "Блинчики с творогом и изюмом", Price = 160 });
            menu.Add(new Menu { Id = 17, Name = "Сырники", Price = 180 });

            return menu;
        }

        public static List<Table> GetTables()
        {
            List<Table> tables = new List<Table>();

            for (int i = 1; i < 11; i++){
                tables.Add(new Table { Number = i, Order = new List<Menu>(), IsFree = true});
            }

            return tables;
        }
    }
}
