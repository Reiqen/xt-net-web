using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task6.Entities
{
    public class Award
    {
        public int id { get; set; }
        public string title { get; set; }

        public override string ToString() => "Title: " + title + ".";
    }
}
