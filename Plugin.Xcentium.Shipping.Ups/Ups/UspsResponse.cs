using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.Xcentium.Shipping.Ups.Ups
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponseStatus
    {
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Alert
    {

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TransactionReference
    {
        /// <summary>
        /// 
        /// </summary>
        public string CustomerContext { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Response
    {

        /// <summary>
        /// 
        /// </summary>
        public ResponseStatus ResponseStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Alert> Alert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TransactionReference TransactionReference { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class Service
    {
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class RatedShipmentAlert
    {


        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class UnitOfMeasurement
    {

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class BillingWeight
    {

        /// <summary>
        /// 
        /// </summary>
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Weight { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class TransportationCharges
    {

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MonetaryValue { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ServiceOptionsCharges
    {

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MonetaryValue { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class TotalCharges
    {

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MonetaryValue { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TotalCharge
    {

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MonetaryValue { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class NegotiatedRateCharges
    {
        /// <summary>
        /// 
        /// </summary>
        public TotalCharge TotalCharge { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TransportationCharges2
    {

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MonetaryValue { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class ServiceOptionsCharges2
    {

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MonetaryValue { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class TotalCharges2
    {

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MonetaryValue { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class UnitOfMeasurement2
    {

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class BillingWeight2
    {

        /// <summary>
        /// 
        /// </summary>
        public UnitOfMeasurement2 UnitOfMeasurement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Weight { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class RatedPackage
    {

        /// <summary>
        /// 
        /// </summary>
        public TransportationCharges2 TransportationCharges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ServiceOptionsCharges2 ServiceOptionsCharges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TotalCharges2 TotalCharges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BillingWeight2 BillingWeight { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RatedShipment
    {

        /// <summary>
        /// 
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<RatedShipmentAlert> RatedShipmentAlert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BillingWeight BillingWeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TransportationCharges TransportationCharges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ServiceOptionsCharges ServiceOptionsCharges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TotalCharges TotalCharges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public NegotiatedRateCharges NegotiatedRateCharges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RatedPackage RatedPackage { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RateResponse
    {

        /// <summary>
        /// 
        /// </summary>
        public Response Response { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RatedShipment RatedShipment { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UspsResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public RateResponse RateResponse { get; set; }
    }
    
}
