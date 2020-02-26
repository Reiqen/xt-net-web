using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.GitHub.Reiqen.Task10_11.Entities
{
    public class Award
    {
        public int award_id { get; set; }
        public string title { get; set; }
        public byte[] image { get; set; }

        public override string ToString() => "Title: " + title + ".";
    }
}