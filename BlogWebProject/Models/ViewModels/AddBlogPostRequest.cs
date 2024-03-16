﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWebProject.Models.ViewModels
{
    public class AddBlogPostRequest
    {
        public Guid Id { get; set; }
        public string? Heading { get; set; }

        public string? PageTitle { get; set; }

        public string? Content { get; set; }

        public string? ShortDescription { get; set; }


        public string? FeaturedImageUrl { get; set; }
        public string? UrlHandle { get; set; }

        public string? Author { get; set; }

        public DateOnly? PublishedDate { get; set; }
        public bool Visible { get; set; }

 
        public IEnumerable<SelectListItem>? Tags { get; set; }

public string[] SelectdTag { get; set; } = Array.Empty<string>();   
    }
}
