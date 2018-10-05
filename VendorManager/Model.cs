namespace VendorManager
{
    public class Model
    {
        public string PBI { get; set; }
        public string UMLName { get; set; }
        public string ControllerClass { get; set; }
        public string ControllerMethod { get; set; }

        public string LoanCenterModelRequest { get; set; }
        public string LoanCenterModelResponse { get; set; }

        public string CanonicInterfaceClass { get; set; }
        public string CanonicInterfaceMethod { get; set; }

        public string CanonicClass { get; set; }
        public string CanonicMethod { get; set; }

        public string IOCSereviceInstaller { get; set; }
        public string IOCServicesFacadeInstaller { get; set; }
        public string MeAndMyLoan { get; set; }

        public string MSContractRequest { get; set; }
        public string MSContractResponse { get; set; }

        public string ServiceInterfacesInterfaceClass { get; set; }
        public string ServiceInterfacesInterfaceMethod { get; set; }

        //MicroService
        public string MSFacadeClass { get; set; }

        public string MSFacadeFactoryClass { get; set; }
        public string MSFacadeMethod { get; set; }
        public string MSProxyInterface { get; set; }
        public string MSProxyClient { get; set; }


        public string MSServiceInterface { get; set; }
        public string MSServiceClass { get; set; }
        public string MSHelperClass { get; set; }
        public string FQN { get; set; }
        public string HttpPort { get; set; }
        public string tcpPort { get; set; }
        public string MSServiceHost { get; set; }
        public string MSHostConfig { get; set; }

        public string ProductTypeEnum { get; set; }
        public string VendorTypeEnum { get; set; }

        //Service Host Service

        public string ServiceFacadeClass { get; set; }
        public string ServiceFacadeInterface { get; set; }

        public string ServiceFacadeMethod { get; set; }

        public string ServiceVMRequest { get; set; }
        public string ServiceVMResponse { get; set; }

        public string ServiceHandleContract { get; set; }
        public string ServiceClass { get; set; }
        public string ServiceMethodName { get; set; }

        public string DALClass { get; set; }

        public string DALMethod { get; set; }

        public string DALConverterMethod { get; set; }

        public string DALConverterClass { get; set; }

        public string Notes { get; set; }
        public string TestParameters { get; set; }


    }
}