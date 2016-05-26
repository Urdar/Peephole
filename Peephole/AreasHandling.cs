using Peephole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peephole
{
    public class AreasHandling
    {

        public static void insertInMenu(string areaName)
        {
            using (var db = new Entities())
            {

                // Check if areaname is already in MainMenu table, return if so
                if (db.MainMenu.Any(o => o.AreaName.Equals(@areaName))) return;

                MainMenu menu = new MainMenu(); // New Menu object
                menu.ShowInMenu = true; // Show menu item by default
                menu.AreaName = @areaName; // Currently the name of the Area.
                menu.LinkText = @areaName;
                //      menu.ParentId = 'NULL'; // Default value. Which action to call from menu
                menu.URL = "~"; // Default. Which controller to initiate from menu

                db.MainMenu.Add(menu);
                db.SaveChanges();

            }
        }

    }
}