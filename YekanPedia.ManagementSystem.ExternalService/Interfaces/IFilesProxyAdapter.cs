namespace YekanPedia.ManagementSystem.ExternalService.Interfaces
{
    using System.Collections.Generic;
    using FilesProxy;
    public interface IFilesProxyAdapter
    {
        List<FileInfo> GetFilesAddress(string address);
    }
}
