
module service
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