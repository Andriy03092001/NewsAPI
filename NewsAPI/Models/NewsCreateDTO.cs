using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAPI.Models
{
    public class NewsCreateDTO
    {
        public string Title { get; set; }
        public string DatePost { get; set; }
        public string LinkImage { get; set; }
        public string Description { get; set; }
    }
}
