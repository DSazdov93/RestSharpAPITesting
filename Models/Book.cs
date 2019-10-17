using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpAPITesting
{
    public class Book
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<User> data { get; set; }
    }
}
