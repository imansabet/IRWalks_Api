using IRWalks.API.Models.Domain;

namespace IRWalks.API.Repositories
{
    public interface IImageRepository
    {

        Task<Image> Upload(Image image);
        
    }
}
