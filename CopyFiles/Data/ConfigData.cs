using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFiles.Data
{
    public class ConfigData
    {
        public bool UseDateFrom { get; set; }
        public string DateFrom { get; set; }
        public bool UseDateTo { get; set; }
        public string DateTo { get; set; }
        public string DistPath { get; set; }
        public List<string> SrcPath { get; set; }
        public bool FileIgnore { get; set; }
    }
}
