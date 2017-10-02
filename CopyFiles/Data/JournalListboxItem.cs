using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFiles.Data
{
    public class JournalListboxItem
    {
        public JournalListboxItem()
        {
            Text = string.Empty;
            ItemColor = Color.Empty;
        }

        public JournalListboxItem(string text) : this()
        {
            Text = text;
        }

        public JournalListboxItem(string text, Color itemColor) : this(text)
        {
            ItemColor = itemColor;
        }

        public Color ItemColor { get;  }
        public string Text { get; }

        public override string ToString()
        {
            //return $"{Text} -- {ItemColor}";
            return Text;
        }
    }
}
