using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserTable.Models
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}