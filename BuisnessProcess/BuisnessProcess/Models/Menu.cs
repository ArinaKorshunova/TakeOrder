﻿namespace BuisnessProcess.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAddedToOrder { get; set; }
    }
}
