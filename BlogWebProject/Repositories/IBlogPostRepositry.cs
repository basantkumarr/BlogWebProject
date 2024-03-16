using BlogWebProject.Models.Domain;

namespace BlogWebProject.Repositories
{
    public interface IBlogPostRepositry
    {


        Task<IEnumerable<BlogPost?>> GetAllAsync();

        Task<BlogPost?> GetAsync(Guid id);
        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost?> UpdateAsync(BlogPost blogPost);

        Task<BlogPost?> DeleteAsync(Guid id);    

    }
}
