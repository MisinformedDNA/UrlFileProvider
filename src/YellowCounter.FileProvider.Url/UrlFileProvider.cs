using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Net.Http;

namespace YellowCounter.FileProvider.Url
{
    public class UrlFileProvider : IFileProvider
    {
        public IDirectoryContents GetDirectoryContents(string url)
        {
            throw new NotImplementedException();
        }

        public IFileInfo GetFileInfo(string url)
        {
            var client = new HttpClient();
            var result = client.GetAsync(url).GetAwaiter().GetResult();
            return new UrlFileInfo(result);
        }

        public IChangeToken Watch(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
