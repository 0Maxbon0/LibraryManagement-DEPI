using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.BLL.Dtos
{
    public class BookDtos
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
