using DataFromExcel.Domain;

namespace DataFromExcel.Application.Interfaces
{
    public interface IGetData
    {
        IEnumerable<ObjectOfSaleInPurchasePayment> ObjectOfSaleInPurchasePayment();
        IEnumerable<ObjectOfSaleInContract> ObjectOfSaleInContract();
        IEnumerable<ObjectOfSaleInPurchaseInvoice> ObjectOfSaleInPurchaseInvoice();
        IEnumerable<TotalFloorArea> TotalFloorArea();
    }
}
