using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Net.Http;

namespace YellowCounter.FileProvider.Url
{
    class UrlFileInfo : IFileInfo
    {
        private readonly HttpResponseMessage _response;

        public UrlFileInfo(HttpResponseMessage response)
        {
            _response = response;
        }
        public bool Exists => _response.IsSuccessStatusCode;

        public long Length => _response.Content.Headers.ContentLength ?? 0;

        public string PhysicalPath => _response.Content.Headers.ContentLocation.AbsoluteUri;

        public string Name => _response.Content.Headers.ContentLocation.LocalPath;

        public DateTimeOffset LastModified => _response.Content.Headers.LastModified ?? DateTimeOffset.MinValue;

        public bool IsDirectory => false;

        public Stream CreateReadStream()
        {
            return _response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
        }
    }
}
