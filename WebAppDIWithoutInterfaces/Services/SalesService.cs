using WebAppDIWithoutInterfaces.Models;

namespace WebAppDIWithoutInterfaces.Services
{
    public class SalesService
    {
        private readonly List<Sale> _salesRecords;

        public SalesService()
        {
            _salesRecords = new List<Sale>();
        }

        public void AddSale(Sale sale)
        {
            _salesRecords.Add(sale);
        }

        public List<Sale> GetSales()
        {
            
            return _salesRecords;
        }

        public Sale GetSaleById(int id)
        {
            return _salesRecords.FirstOrDefault(s => s.Id == id);
        }

        public bool UpdateSale(int id, Sale updateSale)
        {
            var sale = _salesRecords.FirstOrDefault(s => s.Id == id);
            if ( sale!=null)
            {
                sale.Product = updateSale.Product;
                sale.Amount= updateSale.Amount;
                return true;
            }
            return false;
        }

        public bool DeleteSale(int id)
        {
            var sale=_salesRecords.FirstOrDefault(s=>s.Id == id);
            if (sale != null)
            {
                _salesRecords.Remove(sale);
                return true;
            }
            return false;
        }
    }
}
