using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Class
{
    public static class ConectDB
    {
        public static LibraryEntities cone { get; } = new LibraryEntities();
    }
}
