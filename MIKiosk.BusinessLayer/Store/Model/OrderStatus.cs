namespace MIKiosk.BusinessLayer.Store.Model
{
    public enum OrderStatus
    {
        OpenedByUser=1,
        NotPayed=2,
        Payed=3,
        InStock=4,
        ReadyTodelivery=5,
        Delivered=6,
    }
}