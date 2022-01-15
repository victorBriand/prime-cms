using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCMS.Models
{
    public class Section
    {
        public int ID { get; set; }
        public string Content { get; set; }

        public string TitleID { get; set; }

        public virtual Page Page { get; set; }
    }
}
