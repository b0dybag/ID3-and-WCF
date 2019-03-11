﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ST3PClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Income", ReplyAction="http://tempuri.org/IService1/IncomeResponse")]
        string[][] Income(string[][] body, string[] head, int d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Income", ReplyAction="http://tempuri.org/IService1/IncomeResponse")]
        System.Threading.Tasks.Task<string[][]> IncomeAsync(string[][] body, string[] head, int d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetTreeInfo", ReplyAction="http://tempuri.org/IService1/SetTreeInfoResponse")]
        bool SetTreeInfo(string[][] body, string[] head, int d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetTreeInfo", ReplyAction="http://tempuri.org/IService1/SetTreeInfoResponse")]
        System.Threading.Tasks.Task<bool> SetTreeInfoAsync(string[][] body, string[] head, int d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddRecord", ReplyAction="http://tempuri.org/IService1/AddRecordResponse")]
        void AddRecord(string[] record);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddRecord", ReplyAction="http://tempuri.org/IService1/AddRecordResponse")]
        System.Threading.Tasks.Task AddRecordAsync(string[] record);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTree", ReplyAction="http://tempuri.org/IService1/GetTreeResponse")]
        string[][] GetTree();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTree", ReplyAction="http://tempuri.org/IService1/GetTreeResponse")]
        System.Threading.Tasks.Task<string[][]> GetTreeAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ST3PClient.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ST3PClient.ServiceReference1.IService1>, ST3PClient.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[][] Income(string[][] body, string[] head, int d) {
            return base.Channel.Income(body, head, d);
        }
        
        public System.Threading.Tasks.Task<string[][]> IncomeAsync(string[][] body, string[] head, int d) {
            return base.Channel.IncomeAsync(body, head, d);
        }
        
        public bool SetTreeInfo(string[][] body, string[] head, int d) {
            return base.Channel.SetTreeInfo(body, head, d);
        }
        
        public System.Threading.Tasks.Task<bool> SetTreeInfoAsync(string[][] body, string[] head, int d) {
            return base.Channel.SetTreeInfoAsync(body, head, d);
        }
        
        public void AddRecord(string[] record) {
            base.Channel.AddRecord(record);
        }
        
        public System.Threading.Tasks.Task AddRecordAsync(string[] record) {
            return base.Channel.AddRecordAsync(record);
        }
        
        public string[][] GetTree() {
            return base.Channel.GetTree();
        }
        
        public System.Threading.Tasks.Task<string[][]> GetTreeAsync() {
            return base.Channel.GetTreeAsync();
        }
    }
}