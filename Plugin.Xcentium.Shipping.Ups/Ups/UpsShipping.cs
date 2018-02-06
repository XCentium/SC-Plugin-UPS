using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Carts;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Commerce.Plugin.Fulfillment;

namespace Plugin.Xcentium.Shipping.Ups.Ups
{
    /// <summary>
    /// 
    /// </summary>
    public static class UpsShipping
    {
        /// <summary>
        /// 
        /// </summary>
        public static UpsClientPolicy UpsClientPolicy = new UpsClientPolicy();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cart"></param>
        /// <param name="getSellableItemPipeline"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        internal static decimal GetCartShippingRate(string name, Cart cart, IGetSellableItemPipeline getSellableItemPipeline, CommercePipelineExecutionContext context)
        {

            var rates = GetCartShippingRates(cart, getSellableItemPipeline, context);

            if (rates == null || !rates.Any()) return 0m;
            try
            {
                return rates.FirstOrDefault(x => x.Key.ToLower() == name.ToLower()).Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return 0m;
        }


        internal static List<KeyValuePair<string, decimal>> GetCartShippingRates(Cart cart,
            IGetSellableItemPipeline getSellableItemPipeline, CommercePipelineExecutionContext context)
        {
            var input = new UpsReqestInput();
            UpsClientPolicy = context.GetPolicy<UpsClientPolicy>();
            if (cart != null && cart.Lines.Any<CartLineComponent>() &&
                cart.HasComponent<PhysicalFulfillmentComponent>())
            {
                var component = cart.GetComponent<PhysicalFulfillmentComponent>();

                var shippingParty = component?.ShippingParty;

                input.AddressLine1 = shippingParty?.Address1;
                input.AddressLine2 = shippingParty?.Address2;
                input.City = shippingParty?.City;
                input.CountryCode = shippingParty?.CountryCode;
                input.StateCode = shippingParty?.StateCode;
                input.ZipPostalCode = shippingParty?.ZipPostalCode;

                input.PriceValue = cart.Totals.SubTotal.Amount;

                decimal height = 0.0M;
                decimal width = 0.0M;
                decimal length = 0.0m;
                decimal weight = 0.0m;

                foreach (var cartLineComponent in cart.Lines)
                {

                    // get specific weight value
                    var productArgument = ProductArgument.FromItemId(cartLineComponent.ItemId);
                    if (!productArgument.IsValid()) continue;
                    var sellableItem = getSellableItemPipeline.Run(productArgument, context).Result;

                    if (sellableItem != null &&  sellableItem.HasComponent<ItemSpecificationsComponent>())
                    {
                        var itemSpec = sellableItem.GetComponent<ItemSpecificationsComponent>();

                        if (itemSpec.Weight > 0) weight += itemSpec.Weight;

                        if (itemSpec.Height > 0) height += itemSpec.Height;

                        if (itemSpec.Width > 0 && itemSpec.Width > width) width = itemSpec.Width;

                        if (itemSpec.Length > 0 && itemSpec.Length > length) length = itemSpec.Length;
                    }

                }

                input.Height = Math.Ceiling(height).ToString(CultureInfo.CurrentCulture);
                input.Width = Math.Ceiling(width).ToString(CultureInfo.CurrentCulture);
                input.Length = Math.Ceiling(length).ToString(CultureInfo.CurrentCulture);
                input.Weight = weight;

            }

            var rates = GetShippingRates(input, context);

            return rates;
        }

        private static List<KeyValuePair<string, decimal>> GetShippingRates(UpsReqestInput input, CommercePipelineExecutionContext context)
        {
            UpsClientPolicy = context.GetPolicy<UpsClientPolicy>();

            var usernameToken = new
            {
                Username = UpsClientPolicy.Username,
                Password = UpsClientPolicy.Password
            };

            var serviceAccessToken = new { AccessLicenseNumber = UpsClientPolicy.AccessLicenseNumber};

            var upsSecurity = new
            {
                UsernameToken = usernameToken,
                ServiceAccessToken = serviceAccessToken
            };

            var transactionReference = new {CustomerContext = UpsClientPolicy.CustomerContext};

            var request = new
            {
                RequestOption = UpsClientPolicy.RequestOption,
                TransactionReference = transactionReference
            };



            var shipperAddress = new
            {
                AddressLine =
                new string[]
                {
                    UpsClientPolicy.ShipperAddressLine1, UpsClientPolicy.ShipperAddressLine2,
                    UpsClientPolicy.ShipperAddressLine3
                },
                City = UpsClientPolicy.ShipperCity,
                StateProvinceCode = UpsClientPolicy.ShipperStateOrProvinceCode,
                PostalCode = UpsClientPolicy.ShipperPostalCode,
                CountryCode = UpsClientPolicy.ShipperCountryCode
            };

            var shipper = new 
            {
                Name = UpsClientPolicy.ShipperName,
                ShipperNumber = UpsClientPolicy.ShipperNumber,
                Address = shipperAddress
            };

            var shipToAddress = new
            {
                AddressLine =
                new string[]
                {
                    input.AddressLine1, input.AddressLine2,
                    input.AddressLine2
                },
                City = input.City,
                StateProvinceCode = input.StateCode,
                PostalCode = input.ZipPostalCode,
                CountryCode = input.CountryCode
            };

            var shipTo = new
            {
                Name = input.AddressLine1,
                Address = shipToAddress
            };


            var shipperFromAddress = new
            {
                AddressLine =
                new string[]
                {
                    UpsClientPolicy.ShipFromAddressLine1, UpsClientPolicy.ShipFromAddressLine2,
                    UpsClientPolicy.ShipFromAddressLine3
                },
                City = UpsClientPolicy.ShipFromCity,
                StateProvinceCode = UpsClientPolicy.ShipFromStateOrProvinceCode,
                PostalCode = UpsClientPolicy.ShipFromPostalCode,
                CountryCode = UpsClientPolicy.ShipFromCountryCode
            };

            var shipFrom = new
            {
                Name = UpsClientPolicy.ShipFromName,
                Address = shipperFromAddress
            };

            var service = new
            {
                Code = "[zzz]",
                Description = UpsClientPolicy.ServiceDescription
            };

            var packagingType = new
            {
                Code = UpsClientPolicy.PackageType,
                Description = UpsClientPolicy.PackageTypeDescription
            };

            var dimensionUnitOfMeasurement = new
            {
                Code = UpsClientPolicy.DimensionsUnitOfMeasureCode,
                Description = UpsClientPolicy.DimensionsUnitOfMeasureDescription
            };

            var dimensions = new
            {
                UnitOfMeasurement = dimensionUnitOfMeasurement,
                Length = input.Length,
                Width = input.Width,
                Height = input.Height
            };

            var packageUnitOfMeasurement = new
            {
                Code = UpsClientPolicy.PackageWeightUnitOfMeasurementCode,
                Description = UpsClientPolicy.PackageWeightUnitOfMeasurementDescription
            };

            var packageWeight = new
            {
                UnitOfMeasurement = packageUnitOfMeasurement,
                Weight = input.Weight.ToString(CultureInfo.InvariantCulture)
            };

            var package = new
            {
                PackagingType = packagingType,
                Dimensions = dimensions,
                PackageWeight = packageWeight
            };

            var shipmentRatingOptions = new { NegotiatedRatesIndicator  = UpsClientPolicy.NegotiatedRatesIndicator };

            var shipment = new
            {
                Shipper = shipper,
                ShipTo = shipTo,
                ShipFrom = shipFrom,
                Service = service,
                Package = package,
                ShipmentRatingOptions = shipmentRatingOptions

            };

            var rateRequest = new
            {
                Request = request,
                Shipment = shipment
            };

            var upsRateRequest = new
            {
                UPSSecurity = upsSecurity,
                RateRequest = rateRequest
            };

            var shippingCodesList = ShippingCodeConstant.Method.Keys.ToList();

            var rates = new List<KeyValuePair<string,decimal>>();

            var json = JsonConvert.SerializeObject(upsRateRequest);

            foreach (var code in shippingCodesList)
            {
                var jsonRequest = json.Replace("[zzz]",code);

                using (var client = new HttpClient())
                {
                    var uri = new Uri(UpsClientPolicy.Url);
                    var stringContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                    var response = client.PutAsync(uri, stringContent).Result;
                    var responseString = response.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        try
                        {
                            var responsList = JsonConvert.DeserializeObject<UspsResponse>(responseString);
                            if (responsList?.RateResponse != null)
                            {
                                var responseCode = responsList.RateResponse.RatedShipment.Service.Code;
                                responseCode = ShippingCodeConstant.Method[responseCode];
                                decimal.TryParse(responsList.RateResponse.RatedShipment.TotalCharges.MonetaryValue,
                                    out var totalChage);
                                rates.Add(new KeyValuePair<string, decimal>(responseCode, totalChage));
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            
                        }
                        

                    }

                }
                Thread.Sleep(1);

            }



            return rates;
        }

    }
}
