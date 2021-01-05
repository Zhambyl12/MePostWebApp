Misc

    public class Misc
    {  
        public static  ServiceReference1.WebService1SoapClient WsAramexUZ = new WebService1SoapClient(EndpointConfiguration.WebService1Soap); 
    }
    
    
HomeController

    CalculateResponse otv = await Misc.WsAramexUZ.CalculateAsync("ALBANIA", 20, 24, 10, 1.2, "Parcel"); 
    double res = double.Parse( otv.Body.CalculateResult.ToString());