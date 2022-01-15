using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCMS.Models
{
    public class Page
    {
        public int Id { get; set; } // Because the property is named Id it will be automatically recognized as key
        [StringLength(100)] //Set higher if needed
        public string Title { get; set; }
        [StringLength(400)] //Set higher if needed
        public string Description { get; set; }

        public IEnumerable<Section> Sections { get; set; }

    }
}
