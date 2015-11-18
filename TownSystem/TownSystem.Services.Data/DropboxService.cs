namespace TownSystem.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Spring.IO;
    using Spring.Social.Dropbox.Api;
    using Spring.Social.Dropbox.Connect;
    using Spring.Social.OAuth1;
    using TownSystem.Services.Data.Contracts;
    using TownSystem.Common.Constants;

    public class DropboxService : IDropboxService
    {
        private string dropboxAppKey;
        private string dropboxAppSecret;
        private IDropbox dropboxApi;
        private OAuthToken oauthAccessToken;

        public DropboxService()
        {
            this.dropboxAppKey = DropboxConstants.DropboxAppKey;
            this.dropboxAppSecret = DropboxConstants.DropboxAppSecret;
            this.dropboxApi = this.GetDropboxApi();
        }

        // Create new folder
        private string CreateFolder(ITownsService towns, int townId)
        {
            string newFolderName = towns.ById(townId).FirstOrDefault().Name;
            Entry createFolderEntry = GetDropboxApi().CreateFolderAsync(newFolderName).Result;
            return createFolderEntry.Path;
        }
        public async Task<Entry> UploadImageToCloud(IResource resource, string fileName, ITownsService towns, int townId)
        {
            string path = "/" +  CreateFolder(towns, townId) + "/" + fileName;
            Entry uploadFileEntry = await this.dropboxApi.UploadFileAsync(resource, path);

            return uploadFileEntry;
        }

        public async Task<string> GetImageUrl(string path)
        {
            var mediaLink = await this.dropboxApi.GetMediaLinkAsync(path);

            return mediaLink.Url;
        }

        private IDropbox GetDropboxApi()
        {
            DropboxServiceProvider serviceProvider = this.Initialize(this.dropboxAppKey, this.dropboxAppSecret);
            IDropbox currentDropboxApi = serviceProvider.GetApi(this.oauthAccessToken.Value, this.oauthAccessToken.Secret);

            return currentDropboxApi;
        }

        private DropboxServiceProvider Initialize(string key, string secret)
        {
            DropboxServiceProvider dropboxServiceProvider = new DropboxServiceProvider(key, secret, AccessLevel.AppFolder);

            this.oauthAccessToken = this.LoadOAuthToken();

            return dropboxServiceProvider;
        }

        private OAuthToken LoadOAuthToken()
        {
            this.oauthAccessToken = new OAuthToken(DropboxConstants.OAuth1, DropboxConstants.OAuth2);

            return this.oauthAccessToken;
        }
    }
}
