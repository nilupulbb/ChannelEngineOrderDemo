using System;

namespace ChannelEngineOrderDemo.Core
{
    /*
     * Order Details
     */
    public class Order
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int ChannelId { get; set; }
        public string GlobalChannelName { get; set; }
        public int GlobalChannelId { get; set; }
        public string ChannelOrderSupport { get; set; }
        public string ChannelOrderNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public string Status { get; set; }
        public bool IsBusinessOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object MerchantComment { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public float SubTotalInclVat { get; set; }
        public float SubTotalVat { get; set; }
        public float ShippingCostsVat { get; set; }
        public float TotalInclVat { get; set; }
        public float TotalVat { get; set; }
        public float OriginalSubTotalInclVat { get; set; }
        public float OriginalSubTotalVat { get; set; }
        public float OriginalShippingCostsInclVat { get; set; }
        public float OriginalShippingCostsVat { get; set; }
        public float OriginalTotalInclVat { get; set; }
        public float OriginalTotalVat { get; set; }
        public LineDetail[] Lines { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CompanyRegistrationNo { get; set; }
        public string VatNo { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReferenceNo { get; set; }
        public float ShippingCostsInclVat { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string ChannelCustomerNo { get; set; }
        public ExtraDataObj ExtraData { get; set; }
    }

}
