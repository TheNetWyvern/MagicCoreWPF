using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCoreWPF
{
    public class Configurator
    {
        public string dataBaseName = "magiccore";
        public string folderName = "MagicCore";
        public string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private static readonly Lazy<Configurator>
            lazy =
            new Lazy<Configurator>
                (() => new Configurator());

        private Configurator() { }
        public static Configurator Instance 
        { 
            get 
            {
                return lazy.Value;
            } 
        }
    }
}
