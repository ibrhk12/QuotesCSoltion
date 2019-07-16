using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesC.ViewModel
{
    public class EnglishVM
    {
        public string imageId { get; set; }

        public IFormFile image { get; set; }
        public string imageName { get; set; }
        public string imageUrl { get; set; }
        public string Quote { get; set; }
    }
}
