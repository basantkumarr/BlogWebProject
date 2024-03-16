using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogWebProject.Data;
using BlogWebProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogWebProject.Repositories
{
    public class BlogPostRepositry : IBlogPostRepositry
    {
        private readonly BlogieDbContext blogieDbContext;

        public BlogPostRepositry(BlogieDbContext blogieDbContext)
        {
            this.blogieDbContext = blogieDbContext;
        }

        public BlogPostRepositry()
        {

        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogieDbContext.AddAsync(blogPost);
            await blogieDbContext.SaveChangesAsync();
            return blogPost;
        }

        public   Task<BlogPost?> DeleteAsync(Guid id)
        {

            throw new NotImplementedException();



        }

        public async Task<IEnumerable<BlogPost?>> GetAllAsync()
        {
            return await blogieDbContext.BlogPosts.Include(x=>x.Tags).ToListAsync();
        }


        public Task<BlogPost?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }


    }
}
