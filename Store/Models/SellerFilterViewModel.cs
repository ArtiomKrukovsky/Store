using Store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models
{
    public class SellerFilterViewModel
    {
        public IEnumerable<Seller> Sellers { get; set; }

        public SelectList Country { get; set; }

        public SelectList User { get; set; }
    }
}