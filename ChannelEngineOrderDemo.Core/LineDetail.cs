using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineOrderDemo.Core
{
    public class LineDetail
    {
        public string Status { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public object StockLocation { get; set; }
        public float UnitVat { get; set; }
        public float LineTotalInclVat { get; set; }
        public float LineVat { get; set; }
        public float OriginalUnitPriceInclVat { get; set; }
        public float OriginalUnitVat { get; set; }
        public float OriginalLineTotalInclVat { get; set; }
        public float OriginalLineVat { get; set; }
        public int OriginalFeeFixed { get; set; }
        public object BundleProductMerchantProductNo { get; set; }
        public object JurisCode { get; set; }
        public object JurisName { get; set; }
        public int VatRate { get; set; }
        public object[] ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
        public int Quantity { get; set; }
        public int CancellationRequestedQuantity { get; set; }
        public float UnitPriceInclVat { get; set; }
        public int FeeFixed { get; set; }
        public int FeeRate { get; set; }
        public string Condition { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
    }
}
