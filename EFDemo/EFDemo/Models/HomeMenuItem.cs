using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemo.Models
{
    public enum MenuItemType
    {
        Departments,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
