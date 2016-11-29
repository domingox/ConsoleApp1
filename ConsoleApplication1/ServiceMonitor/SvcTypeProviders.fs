

namespace ServiceMonitor

    module service =

        open Microsoft.FSharp.Data.TypeProviders
                                                                                 
        ///let [<Literal>] Instructions : Map<string, string> = ("",""); ("",""); ("",""); ("","")
       // type serviceProvider = Microsoft.FSharp.Data.TypeProviders.WsdlService


        let [<Literal>] TestUrl = "http://thearctest.site.co.uk"
        let [<Literal>] LiveUrl = "http://thearc.isite.co.uk"
        let [<Literal>] TestArg = "-t"
        let [<Literal>] LiveArg = "-l"
   
        type CmdArgs = {
            Key :  string 
            }
        type Url = {
             ResourceLocation : string        
            }
        type UrlLookup = {
            KeyValue : Map<CmdArgs, Url>
            }

        type Platform = 
            |Test of UrlLookup
            |Live of UrlLookup

        let urlLookupFactory key url = 
            Map.ofSeq <| { KeyValue = [{Key = key}, {ResourceLocation = url}] }

        let (|Test|Live|) x =
            match x with
            | Test(TestArg) -> Test(urlLookupFactory TestArg TestUrl)
            | Live(LiveArg) -> Live(urlLookupFactory  LiveArg LiveUrl)

        let platformFactory plat  = 
            match plat with
            | TestArg -> Test(urlLookupFactory TestArg TestUrl)
            | LiveArg -> Live(urlLookupFactory  LiveArg LiveUrl)

    
        type Services = 
            | Mail  of UrlLookup
            | Digest of UrlLookup
            | IncidentNotification  of UrlLookup
            | ActivityRiskEngine of UrlLookup

        let serviceFactory = 
            seq{
                yield ActivityRiskEngine(urlLookupFactory "-engine" "/Services.EngineService/EngineService.svc")
                yield Digest(urlLookupFactory "-digest" "/Services.Digest/DigestService.svc")
                yield IncidentNotification(urlLookupFactory "-notify" "/Services.IncidentNotification/IncidentNotificationService.svc")
                yield Mail(urlLookupFactory "-mail" "/Services.mail/mailService.svc")
            }

        type PlatformSerivce = {
            GenesisServices : Platform * seq<Services>
            }
        let testPlatform : PlatformSerivce = {GenesisServices = platformFactory TestArg, serviceFactory }
        let livePlatform : PlatformSerivce = {GenesisServices = platformFactory LiveArg, serviceFactory}


        let wsdlService = WsdlService

        type testEngine = WsdlService<ServiceUri="http://thearc.isite.co.uk/Services.EngineService/EngineService.svc">

     //   testEngine.GetBasicHttpBinding_IEngineService().
    //                               
    //open System
    //open System.Xml
    //
    //type ActionMethods = CheckStatus | StartService | StopService
    //
    //type EndpointType =  Soap
    //
    //type EndpointProtocol = Http | Https | Tcp 
    //
    //type EndpointMethods = POST | GET
    //
    //type BaseEndpointTypeKeys =
    //    member this.Address =  addr
    //    member this.EndpointProtocol;
    //      Method   : EndpointMethods;
    //     } 
    //
    //type SoapEndpointTypeKeys 
    //   inherit BaseEndpointTypeKeys  =
    //      member     SOAPAction : XmlDocument
    //  
    //   
    //let EndpointTypeParams endpointType =
    //    match endpointType with
    //    | EndpointType.Soap -> 
    //
    //type Endpoint = 
    //    { ID : int
    //      Name : string
    //      Type : EndpointType
    //      Params : Dict<BaseEndpointTypeKeys, string> }
    //
    //type Service = 
    //    { ID : int
    //      Name : string
    //      Endpoints : Endpoint
    //      Actions : List<Action> }
    //
    //type Action = 
    //    { 
    //    Name : string 
    //    LastInitiated  : DateTime
    //    Finished :DateTime
    //    Result: string
    //    Type: ActionTypes
    //    
    //    }
    //
    //
    //
    //   