using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo
{
    public class Upgrade
    {
        private string description;
        private int price;
        private string uniqueId;

        public string Description { get => description; }
        public int Price { get => price; }
        public string ID { get => uniqueId; }


        /// <summary>
        /// Define an Upgrade with a description, a price and an unique ID
        /// </summary>
        public Upgrade(string description, int price, string uniqueId)
        {
            this.description = description;
            this.price = price;
            this.uniqueId = uniqueId;
        }
    }
}
