﻿using BlogWebProject.Data;
using BlogWebProject.Models.Domain;


using BlogWebProject.Repositories;
 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogWebProject.Models.ViewModels;

namespace BlogWebProject.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        public AdminTagsController( ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
        }

 
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }




        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest) {
            //mapping the addTagRequest
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

          await  tagRepository.AddAsync(tag);    
             
            return RedirectToAction("List");  
        }






        [HttpGet]
        public async Task<IActionResult> List()
        {
            var tags = await tagRepository.GetAllAsync();  

            return View(tags);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            //var tag=  blogieDbContext.Tags.Find(id);
            var tag = await tagRepository.GetTagAsync(id);
            if(tag != null){
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };
                return View(editTagRequest);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };
           var updatedTag= tagRepository.UpdateAsync(tag);

            if(updatedTag != null)
            {
                return RedirectToAction("Edit", new { id = editTagRequest.Id });

            }
            else
            {
                return RedirectToAction("Edit", new { id = editTagRequest.Id });

            }


        }

        [HttpPost]
        public async  Task<IActionResult> Delete(EditTagRequest editTagRequest){

          var deletedTag=  await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deletedTag != null)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = editTagRequest.Id });

        }
    }
}
