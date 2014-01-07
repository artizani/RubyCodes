using NVoucher.Model;

namespace NVoucher.Service.Model
{
    class ProductResponse:IProductResponse
    {
        public OrderResponse OrderResult { get; set; }
    }
}
