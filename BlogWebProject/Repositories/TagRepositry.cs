using Azure;
using BlogWebProject.Data;
using BlogWebProject.Models.Domain;
using BlogWebProject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BlogWebProject.Repositories
{
    public class TagRepositry : ITagRepository
    {


        private readonly BlogieDbContext blogieDbContext;
        public TagRepositry(BlogieDbContext blogieDbContext)
        {
            this.blogieDbContext = blogieDbContext;
        }
        public TagRepositry()
        {
            
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogieDbContext.Tags.AddAsync(tag);
            await blogieDbContext.SaveChangesAsync();

            return tag;

        }

        public async Task<Tag> DeleteAsync(Guid id)
        {
            var existingtag = await blogieDbContext.Tags.FindAsync(id);
            if (existingtag != null)
            {
                blogieDbContext.Tags.Remove(existingtag);
                await blogieDbContext.SaveChangesAsync();
                return existingtag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogieDbContext.Tags.ToListAsync();
        }

        public async Task<Tag>? GetTagAsync(Guid id)
        {
            return await blogieDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag> UpdateAsync(Tag tag)
        {
            var existigTag = await blogieDbContext.Tags.FindAsync(tag.Id);

            if (existigTag != null)
            {
                existigTag.Name = tag.Name;
                existigTag.DisplayName = tag.DisplayName;

                blogieDbContext.SaveChanges();
                return existigTag;
            }
            return null;
        }
    }
}