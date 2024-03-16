using BlogWebProject.Models.Domain;

namespace BlogWebProject.Repositories
{
    public interface ITagRepository
    {
        
        Task<IEnumerable<Tag?>?>  GetAllAsync(); 

        Task<Tag?> GetTagAsync(Guid id);


        Task<Tag?> AddAsync(Tag tag);
        Task<Tag?> UpdateAsync(Tag tag); 
        Task<Tag?> DeleteAsync(Guid id);

        
    }
}
