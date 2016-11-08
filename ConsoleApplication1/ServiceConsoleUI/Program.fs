open System
open System.ServiceModel
open Microsoft.FSharp.Linq
open Microsoft.FSharp.Data.TypeProviders

module prog =
                                                                                 
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
        |Test = 0
        |Live = 1

    let urlLookupFactory key url = 
        {KeyValue = [{Key = key}, {ResourceLocation = url}] |> Map.ofList }

    let platformFactory plat  = 
        match plat with
        | Platform.Test -> urlLookupFactory TestArg TestUrl
        | Platform.Live -> urlLookupFactory  LiveArg LiveUrl
    
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

    type PlatformSerivce = 
        GenesisServices of Platform * seq<Services>
    
    let services arg = 
        match arg with
        |platformFactory

  //  type testEngine = Microsoft.FSharp.Data.TypeProviders.WsdlService<ServiceUri=`testUrl+enginePath`>

    //type testEngine2 = Microsoft.FSharp.Data.TypeProviders.WsdlService<ServiceUri= "http://thearctest.site.co.uk/Services.EngineService/EngineService.svc">

    //let testClient = testEngine.GetBasicHttpBinding_IEngineService

    [<EntryPoint>]
    let main  argv  = 
        let result = System.Text.StringBuilder()
        for arg in argv do
            let rnd =
                match arg with
                | "test e" ->  prog.testEngine2.GetServiceStatus()
                | _  -> null
                 
    
            printfn  "%s" rnd
        let wait  = System.Console.Read()
   
        0 // return an integer exit code
