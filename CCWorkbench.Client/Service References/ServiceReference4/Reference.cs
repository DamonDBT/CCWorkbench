﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCWorkbench.Client.ServiceReference4 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference4.IServiceTest")]
    public interface IServiceTest {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTest/GetDataTest", ReplyAction="http://tempuri.org/IServiceTest/GetDataTestResponse")]
        string GetDataTest(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTest/GetDataTest", ReplyAction="http://tempuri.org/IServiceTest/GetDataTestResponse")]
        System.Threading.Tasks.Task<string> GetDataTestAsync(int value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceTestChannel : CCWorkbench.Client.ServiceReference4.IServiceTest, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceTestClient : System.ServiceModel.ClientBase<CCWorkbench.Client.ServiceReference4.IServiceTest>, CCWorkbench.Client.ServiceReference4.IServiceTest {
        
        public ServiceTestClient() {
        }
        
        public ServiceTestClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceTestClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceTestClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceTestClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDataTest(int value) {
            return base.Channel.GetDataTest(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataTestAsync(int value) {
            return base.Channel.GetDataTestAsync(value);
        }
    }
}
