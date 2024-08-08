﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Proje.UI.Areas.Admin.Models.BookVMs
{
    public class AdminBookCreateVM
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
        public SelectList Authors { get; set; }
        public SelectList Publishers { get; set; }
    }
}
