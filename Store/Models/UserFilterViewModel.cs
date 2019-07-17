using Store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models
{
    public class UserFilterViewModel
    {
        public IEnumerable<User> Users { get; set; }

        public SelectList FullName { get; set; }

        public SelectList Email { get; set; }

        public SelectList Create_At { get; set; }
    }
}