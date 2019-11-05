using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestaMVC.Models
{
    public class FestaModel
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public float ValorDoIngresso { get; set; }

    }
}
