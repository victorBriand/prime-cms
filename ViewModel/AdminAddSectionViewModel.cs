using System.Collections.Generic;
using WebApplicationCMS.Models;

namespace WebApplicationCMS.ViewModel
{
    public class AdminAddSectionViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual Page Page { get; set; }
        public List<Page> PageList { get; set; }

    }
}
