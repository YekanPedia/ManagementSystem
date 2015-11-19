namespace YekanPedia.ManagementSystem.ExternalService.implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using FilesProxy;

    public class FilesProxyAdapter : IFilesProxyAdapter
    {
        readonly FilesProxyClient _fileProxyClient;
        public FilesProxyAdapter()
        {
            _fileProxyClient = new FilesProxyClient();
        }
        public List<FileInfo> GetFilesAddress(string address)
        {
            return _fileProxyClient.GetListFiles(address);
        }
    }
}
