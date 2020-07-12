using MagicCoreClasses;
using MagicCoreClasses.InfoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCoreWPF
{
    public class Storage
    {

        public List<Category> categories = new List<Category>();
        public List<InfoBlock> infoBlocks = new List<InfoBlock>();

        private static readonly Lazy<Storage>
        lazy =
        new Lazy<Storage>
            (() => new Storage());

            private Storage() { }
            public static Storage Instance
            {
                get
                {
                    return lazy.Value;
                }
            }
        }

   
}
