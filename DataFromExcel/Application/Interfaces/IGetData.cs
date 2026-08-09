using DataFromExcel.Domain;

namespace DataFromExcel.Application.Interfaces
{
    public interface IGetData
    {
        IEnumerable<ObjectOfSaleInPurchasePayment> ObjectOfSaleInPurchasePayment();
        IEnumerable<ObjectOfSaleInContract> ObjectOfSaleInContract();
        IEnumerable<TotalFloorArea> TotalFloorArea();
        IEnumerable<AreaOfActivityPayment> AreaOfActivity();
    }
}
