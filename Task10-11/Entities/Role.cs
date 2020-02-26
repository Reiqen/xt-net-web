using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.GitHub.Reiqen.Task10_11.Entities
{
    public class Role
    {
        public int role_id { get; set; }
        public string title { get; set; }

        public override string ToString() => "Title: " + title + ".";
    }
}