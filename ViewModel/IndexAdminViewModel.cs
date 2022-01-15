using System.Collections.Generic;
using WebApplicationCMS.Models;

namespace WebApplicationCMS.ViewModel
{
    public class IndexAdminViewModel
    {
        public int Id { get; set; }
        public List<Section> SectionList { get; set; }
    }
}
