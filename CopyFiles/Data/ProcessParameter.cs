using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFiles.Data
{
    public class ProcessParameter
    {
        public ProcessParameter()
        {
            SrcPath = new List<string>();
            Ext = new List<string>();
        }

        public bool UseFromDate { get; set; }
        public DateTime FromDate { get; set; }
        public bool UseToDate { get; set; }
        public DateTime ToDate { get; set; }
        public string DistPath { get; set; }
        public List<string> SrcPath { get; }
        public List<string> Ext { get; }
        public bool FileIgnore { get; set; }
    }
}
