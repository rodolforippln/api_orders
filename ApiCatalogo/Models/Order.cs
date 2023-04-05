using System.Text.Json.Serialization;

namespace ApiCatalogo.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string? OriginPointCode { get; set; }
        public string? OriginPartnerPointCode { get; set; }
        public string? OriginPostalCode { get; set; }
        public bool ToCollect { get; set; }
        public string? DestinationPointCode { get; set; }
        public string? DestinationPostalCode { get; set; }
        public bool ToDelivery { get; set; }
        public string? ServiceCode { get; set; }
        public int InsuranceType { get; set; }
        public string? InsuranceCompany { get; set; }
        public string? InsurancePolicyNumber { get; set; }
        public decimal DeclaredValue { get; set; }
        public string? PreviousDocuments { get; set; }
        
        //public string? SenderDocument { get; set; }
        //public string? SenderStateRegistration { get; set; }
        //public string? SenderName { get; set; }
        //public bool SenderPayer { get; set; }
        //public string? SenderTelephoneCountryCode { get; set; }
        //public string? SenderTelephoneAreaCityCode { get; set; }
        //public string? SenderTelephonePhoneNumber { get; set; }
        //public string? SenderAddressStreet { get; set; }
        //public string? SenderAddressComplement { get; set; }
        //public string? SenderAddressNumber { get; set; }
        //public string? SenderAddressPostalCode { get; set; }
        //public string? SenderAddressNeighborhood { get; set; }
        //public string? SenderAddressCity { get; set; }
        //public string? SenderAddressState { get; set; }
        //public string? SenderAddressCountry { get; set; }

        public string? ReceiverDocument { get; set; }
        public string? ReceiverStateRegistration { get; set; }
        public string? ReceiverName { get; set; }
        public bool ReceiverPayer { get; set; }
        public string? ReceiverTelephoneCountryCode { get; set; }
        public string? ReceiverTelephoneAreaCityCode { get; set; }
        public string? ReceiverTelephonePhoneNumber { get; set; }
        public string? ReceiverAddressStreet { get; set; }
        public string? ReceiverAddressComplement { get; set; }
        public string? ReceiverAddressNumber { get; set; }
        public string? ReceiverAddressPostalCode { get; set; }
        public string? ReceiverAddressNeighborhood { get; set; }
        public string? ReceiverAddressCity { get; set; }
        public string? ReceiverAddressState { get; set; }
        public string? ReceiverAddressCountry { get; set; }
        public bool GenerateDocumentNumber { get; set; }
        public int PaymentMethod { get; set; }

        [JsonIgnore]
        public ICollection<Volume>? Volumes { get; set; }
    }
}
