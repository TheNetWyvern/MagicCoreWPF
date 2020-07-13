using MagicCoreClasses.InfoRepository;
using System;
using System.Collections.Generic;

namespace MagicCoreWPF
{
    public class Storage
    {
        public readonly List<Category> Categories = new List<Category>();
        public List<InfoBlock> InfoBlocks = new List<InfoBlock>();

        private static readonly Lazy<Storage> _lazy = new Lazy<Storage>(() => new Storage());

        private Storage()
        {
        }

        public static Storage Instance => _lazy.Value;
    }
}