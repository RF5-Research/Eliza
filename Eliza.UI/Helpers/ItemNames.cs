using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliza.UI.Helpers
{
    class ItemNames
    {
        private static readonly ItemNames instance = new ItemNames();
        private readonly Dictionary<int, string> itemNames;

        private ItemNames()
        {
            // Create dictionary with item id's and names.
            //TODO: Move it to a better place, so it can be reused.
            itemNames = new Dictionary<int, string>();
            foreach (var line in File.ReadLines("Resources/Data/items.txt").Skip(1))
            {
                var tempLine = line.Split('\t');

                itemNames.Add(int.Parse(tempLine[0]), tempLine[1]);
            }
        }

        public static ItemNames GetInstance()
        {
            return instance;
        }

        public Dictionary<int, string> GetItemNames()
        {
            return itemNames;
        }
    }
}
