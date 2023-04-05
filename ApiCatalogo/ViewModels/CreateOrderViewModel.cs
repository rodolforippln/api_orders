namespace ApiCatalogo.ViewModels;

public class CreateOrderViewModel
{
    public int OrderId { get; set; }

    public string? OriginPointCode { get; set; }
    public string? OriginPartnerPointCode { get; set; }
    public string? OriginPostalCode { get; set; }
    public bool ToCollect { get; set; }
}
