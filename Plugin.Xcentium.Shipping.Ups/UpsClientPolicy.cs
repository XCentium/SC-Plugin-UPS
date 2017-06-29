using Sitecore.Commerce.Core;

namespace Plugin.Xcentium.Shipping.Ups
{

    /// <summary>
    /// 
    /// </summary>
    public class UpsClientPolicy : Policy
    {
        /// <summary>
        /// 
        /// </summary>
        public UpsClientPolicy()
        {
            // Fedex Keys
            this.Username = "owo2000";
            this.Password = "Password@1";
            this.Url = "https://onlinetools.ups.com/rest/Rate";
            this.AccessLicenseNumber = "2D2B8156A1F1D2CE";
            this.CustomerContext = "Bare Bones Rate Request";
            this.ServiceCode = "03";

            // Other settings
            this.RequestOption = "Rate";
            this.ServiceDescription = "Service Code Description";
            this.PackageTypeDescription = "Rate";
            this.NegotiatedRatesIndicator = string.Empty;
            this.CompensationMultipier = 1m;

            // Shipper settings
            this.ShipperName = "Xcentium";
            this.ShipperNumber = "02Y520";
            this.ShipperAddressLine1 = "615 N Nash Street";
            this.ShipperAddressLine2 = string.Empty;
            this.ShipperAddressLine3 = "Suit 303";
            this.ShipperCity = "El Segundo";
            this.ShipperStateOrProvinceCode = "CA";
            this.ShipperPostalCode = "90245";
            this.ShipperCountryCode = "US";

            // ship from settings
            this.ShipFromName = "Xcentium";
            this.ShipFromAddressLine1 = "615 N Nash Street";
            this.ShipFromAddressLine2 = string.Empty;
            this.ShipFromAddressLine3 = "Suit 303";
            this.ShipFromCity = "El Segundo";
            this.ShipFromStateOrProvinceCode = "CA";
            this.ShipFromPostalCode = "90245";
            this.ShipFromCountryCode = "US";

            // Package settings
            this.PackageType = "02";
            this.DimensionsUnitOfMeasureCode = "IN";
            this.DimensionsUnitOfMeasureDescription = "inches";
            this.PackageWeightUnitOfMeasurementCode = "Lbs";
            this.PackageWeightUnitOfMeasurementDescription = "pounds";

            this.Length = "2";
            this.Width = "2";
            this.Height = "2";
            this.Weight = "0.2";

            ////
            //// Fedex Keys
            //this.Username = string.Empty;
            //this.Password = string.Empty;
            //this.Url = string.Empty;
            //this.AccessLicenseNumber = string.Empty;
            //this.CustomerContext = string.Empty;
            //this.ServiceCode = string.Empty;

            //// Other settings
            //this.RequestOption = string.Empty;
            //this.ServiceDescription = string.Empty;
            //this.PackageTypeDescription = string.Empty;
            //this.NegotiatedRatesIndicator = string.Empty;
            //this.CompensationMultipier = 1m;

            //// Shipper settings
            //this.ShipperName = string.Empty;
            //this.ShipperNumber = string.Empty;
            //this.ShipperAddressLine1 = string.Empty;
            //this.ShipperAddressLine2 = string.Empty;
            //this.ShipperAddressLine3 = string.Empty;
            //this.ShipperCity = string.Empty;
            //this.ShipperStateOrProvinceCode = string.Empty;
            //this.ShipperPostalCode = string.Empty;
            //this.ShipperCountryCode = string.Empty;

            //// ship from settings
            //this.ShipFromName = string.Empty;
            //this.ShipFromAddressLine1 = string.Empty;
            //this.ShipFromAddressLine2 = string.Empty;
            //this.ShipFromAddressLine3 = string.Empty;
            //this.ShipFromCity = string.Empty;
            //this.ShipFromStateOrProvinceCode = string.Empty;
            //this.ShipFromPostalCode = string.Empty;
            //this.ShipFromCountryCode = string.Empty;

            //// Package settings
            //this.PackageType = string.Empty;
            //this.DimensionsUnitOfMeasureCode = string.Empty;
            //this.DimensionsUnitOfMeasureDescription = string.Empty;
            //this.PackageWeightUnitOfMeasurementCode = string.Empty;
            //this.PackageWeightUnitOfMeasurementDescription = string.Empty;

            //this.Length = string.Empty;
            //this.Width = string.Empty;
            //this.Height = string.Empty;
            //this.Weight = string.Empty;
            ////

            this.WeightFieldName = "Weight";
            this.LengthFieldName = "Length";
            this.WidthFieldName = "Width";
            this.HeightFieldName = "Height";

        }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccessLicenseNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerContext { get; set; }

        // shipper detail
        /// <summary>
        /// 
        /// </summary>
        public string ShipperNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShipperName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShipperAddressLine1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShipperAddressLine2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShipperAddressLine3 { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string ShipperCity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShipperStateOrProvinceCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShipperPostalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShipperCountryCode { get; set; }


        // ship from address
        /// <summary>
        /// 
        /// </summary>
        public string ShipFromName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShipFromAddressLine1{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShipFromAddressLine2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShipFromAddressLine3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShipFromCity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShipFromStateOrProvinceCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShipFromPostalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShipFromCountryCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ServiceCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PackageType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DimensionsUnitOfMeasureCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DimensionsUnitOfMeasureDescription { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string PackageWeightUnitOfMeasurementCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PackageWeightUnitOfMeasurementDescription { get; set; }

        // Cart item dimension and weight if not set in catalog
        /// <summary>
        /// 
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// This multiplies the cart total with an inconvenience factor incase postage needs compensation paid out.
        /// </summary>
        public decimal CompensationMultipier { get; set; }

        /// <summary>
        /// Weight field name in Sitecore
        /// </summary>
        public string WeightFieldName { get; set; }

        /// <summary>
        /// Lenght field name in Sitecore
        /// </summary>
        public string LengthFieldName { get; set; }

        /// <summary>
        /// Width field name in Sitecore
        /// </summary>
        public string WidthFieldName { get; set; }

        /// <summary>
        /// Height field name in Sitecore
        /// </summary>
        public string HeightFieldName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RequestOption { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public string ServiceDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PackageTypeDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NegotiatedRatesIndicator { get; set; }


    }


}
