using NVoucher.Model;

namespace NVoucher.Service
{
    class ProductResponse:IProductResponse
    {
        public OrderResponse OrderResult { get; set; }
    }
}
