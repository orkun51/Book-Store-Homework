using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookStoreHW
{
    public class Book
    {
        public int Id {get;set; }

        public string Title {get;set; }

        public int GenreId{get;set; }

        public int PageCount{get;set; }

        public DateTime PublishDate {get; set; }
        
    }
}