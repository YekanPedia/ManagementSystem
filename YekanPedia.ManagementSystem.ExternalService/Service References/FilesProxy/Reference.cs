﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YekanPedia.ManagementSystem.ExternalService.FilesProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FileInfo", Namespace="http://schemas.datacontract.org/2004/07/YekanPedia.FileManagement.Proxy.Model")]
    [System.SerializableAttribute()]
    public partial class FileInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DirectLinkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ExtensionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DirectLink {
            get {
                return this.DirectLinkField;
            }
            set {
                if ((object.ReferenceEquals(this.DirectLinkField, value) != true)) {
                    this.DirectLinkField = value;
                    this.RaisePropertyChanged("DirectLink");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Extension {
            get {
                return this.ExtensionField;
            }
            set {
                if ((object.ReferenceEquals(this.ExtensionField, value) != true)) {
                    this.ExtensionField = value;
                    this.RaisePropertyChanged("Extension");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FilesProxy.IFilesProxy")]
    public interface IFilesProxy {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilesProxy/GetListFiles", ReplyAction="http://tempuri.org/IFilesProxy/GetListFilesResponse")]
        System.Collections.Generic.List<YekanPedia.ManagementSystem.ExternalService.FilesProxy.FileInfo> GetListFiles(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilesProxy/GetListFiles", ReplyAction="http://tempuri.org/IFilesProxy/GetListFilesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<YekanPedia.ManagementSystem.ExternalService.FilesProxy.FileInfo>> GetListFilesAsync(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilesProxy/CreateDirectory", ReplyAction="http://tempuri.org/IFilesProxy/CreateDirectoryResponse")]
        string CreateDirectory(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilesProxy/CreateDirectory", ReplyAction="http://tempuri.org/IFilesProxy/CreateDirectoryResponse")]
        System.Threading.Tasks.Task<string> CreateDirectoryAsync(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilesProxy/GetDirectorySize", ReplyAction="http://tempuri.org/IFilesProxy/GetDirectorySizeResponse")]
        long GetDirectorySize();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilesProxy/GetDirectorySize", ReplyAction="http://tempuri.org/IFilesProxy/GetDirectorySizeResponse")]
        System.Threading.Tasks.Task<long> GetDirectorySizeAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFilesProxyChannel : YekanPedia.ManagementSystem.ExternalService.FilesProxy.IFilesProxy, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FilesProxyClient : System.ServiceModel.ClientBase<YekanPedia.ManagementSystem.ExternalService.FilesProxy.IFilesProxy>, YekanPedia.ManagementSystem.ExternalService.FilesProxy.IFilesProxy {
        
        public FilesProxyClient() {
        }
        
        public FilesProxyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FilesProxyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilesProxyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilesProxyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<YekanPedia.ManagementSystem.ExternalService.FilesProxy.FileInfo> GetListFiles(string address) {
            return base.Channel.GetListFiles(address);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<YekanPedia.ManagementSystem.ExternalService.FilesProxy.FileInfo>> GetListFilesAsync(string address) {
            return base.Channel.GetListFilesAsync(address);
        }
        
        public string CreateDirectory(string address) {
            return base.Channel.CreateDirectory(address);
        }
        
        public System.Threading.Tasks.Task<string> CreateDirectoryAsync(string address) {
            return base.Channel.CreateDirectoryAsync(address);
        }
        
        public long GetDirectorySize() {
            return base.Channel.GetDirectorySize();
        }
        
        public System.Threading.Tasks.Task<long> GetDirectorySizeAsync() {
            return base.Channel.GetDirectorySizeAsync();
        }
    }
}
