using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QuotesC.ViewModel
{
    public class ArabicVM
    {
        public string imageId { get; set; }

        public IFormFile image { get; set; }
        public string imageName { get; set; }
        public string imageUrl { get; set; }
        public string Quote { get; set; }
    }
}
