using BlogWebProject.Models.Domain;
using BlogWebProject.Models.ViewModels;
using BlogWebProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace BlogWebProject.Controllers
{
    public class AdminBlogPostRequestController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IBlogPostRepositry blogPostRepositry;

        public AdminBlogPostRequestController(ITagRepository tagRepository,IBlogPostRepositry blogPostRepositry)
        {
            this.tagRepository = tagRepository;
            this.blogPostRepositry = blogPostRepositry;
        }

        




        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tags = await tagRepository.GetAllAsync();

            var model = new AddBlogPostRequest
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.DisplayName, Value = x.Id.ToString() })
            };

            return View(model);
        }

        public ITagRepository GetTagRepository()
        {
            return tagRepository;
        }




        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest, ITagRepository tagRepository)
        {
            var blogPost = new BlogPost
            {
                Heading = addBlogPostRequest.Heading,
                PageTitle = addBlogPostRequest.PageTitle,
                Content = addBlogPostRequest.Content,
                ShortDescription = addBlogPostRequest.ShortDescription,
                FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
                UrlHandle = addBlogPostRequest.UrlHandle,
                PublishedDate = addBlogPostRequest.PublishedDate,
                Author = addBlogPostRequest.Author,
                Visible = addBlogPostRequest.Visible,

            };


            var selectedTags=new List<Tag>();   
            foreach (var selectedTagId in addBlogPostRequest.SelectdTag)
            {
                 var selectedTagIdasGuid=Guid.Parse(selectedTagId);
                var existingtag = await tagRepository.GetTagAsync(selectedTagIdasGuid);


                  if(existingtag != null) { 

                    selectedTags.Add(existingtag);
                  }
            }

            blogPost.Tags = selectedTags;   


            await blogPostRepositry.AddAsync(blogPost);
            return RedirectToAction("Add");
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
           var blogPosts = await blogPostRepositry.GetAllAsync(); 
            return View(blogPosts);
        } 


    }
}
