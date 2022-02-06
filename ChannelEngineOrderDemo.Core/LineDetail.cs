using System;

namespace ChannelEngineOrderDemo.Core
{
    /*
     * Line details of the order
     */
    public class LineDetail
    {
        public string Status { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public string StockLocation { get; set; }
        public float UnitVat { get; set; }
        public float LineTotalInclVat { get; set; }
        public float LineVat { get; set; }
        public float OriginalUnitPriceInclVat { get; set; }
        public float OriginalUnitVat { get; set; }
        public float OriginalLineTotalInclVat { get; set; }
        public float OriginalLineVat { get; set; }
        public float OriginalFeeFixed { get; set; }
        public string BundleProductMerchantProductNo { get; set; }
        public string JurisCode { get; set; }
        public string JurisName { get; set; }
        public float VatRate { get; set; }
        public ExtraDataObj[] ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
        public float Quantity { get; set; }
        public float CancellationRequestedQuantity { get; set; }
        public float UnitPriceInclVat { get; set; }
        public float FeeFixed { get; set; }
        public float FeeRate { get; set; }
        public string Condition { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
    }
}
