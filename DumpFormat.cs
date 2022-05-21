using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTools
{
    public class DumpFormat
    {
        public char Format { get; set; }
        public string FormatDescription { get; set; }

        public string FullFormat { get { return FormatDescription + " - " + Format; } }

        public DumpFormat(char format, string formatDescription)
        {
            Format = format;
            FormatDescription = formatDescription;
        }

        public override string ToString()
        {
            return FullFormat;
        }
    }
}
