namespace TownSystem.Services.Data.Contracts
{
    using Spring.IO;
    using Spring.Social.Dropbox.Api;
    using System.Threading.Tasks;

    public interface IDropboxService
    {
        Task<Entry> UploadImageToCloud(IResource resource, string fileName, ITownsService towns, int townId);

        Task<string> GetImageUrl(string path);
    }
}
