using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ComboBoxPairItem
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public ComboBoxPairItem(int Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
