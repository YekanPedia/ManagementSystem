namespace YekanPedia.ManagementSystem.ExternalService.implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using FilesProxy;
    using Elmah;

    public class FilesProxyAdapter : IFilesProxyAdapter
    {
        readonly FilesProxyClient _fileProxyClient;
        public FilesProxyAdapter()
        {
            _fileProxyClient = new FilesProxyClient();
        }

        public string CreateDirectory(string address)
        {
            return _fileProxyClient.CreateDirectory(address);
        }

        public long DirectorySize()
        {
            try
            {
                return _fileProxyClient.GetDirectorySize();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            return 0;
        }

        public List<FileInfo> GetFilesAddress(string address)
        {
            return _fileProxyClient.GetListFiles(address);
        }

        public string UploadImage(PostedImageFile file)
        {
            try
            {
                return _fileProxyClient.UploadImage(file);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return string.Empty;
            }
        }

        public FileInfo UploadDocument(PostedFile file)
        {
            try
            {
                return _fileProxyClient.UploadDocument(file);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return new FileInfo();
            }
        }

        public void Delete(string address)
        {
              _fileProxyClient.DeleteFile(address);
        }
    }
}
