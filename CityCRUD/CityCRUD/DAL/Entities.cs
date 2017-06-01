using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityCRUD.DAL
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Allow { get; set; }
    }
}