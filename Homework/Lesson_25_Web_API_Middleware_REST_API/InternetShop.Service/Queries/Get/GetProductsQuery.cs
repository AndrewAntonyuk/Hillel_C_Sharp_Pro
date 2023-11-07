using InternetShop.Contract.Responses;
using InternetShop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Service.Queries.Get
{
    public class GetProductsQueryHandler : IRequestHandler<IList<ProductResponse>>
    {
        private readonly InternetShopDbContext _context;

        public GetProductsQueryHandler(InternetShopDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ProductResponse>> Handle(CancellationToken token = default)
        {
            return await _context.Products
                           .AsNoTracking()
                           .Select(x => new ProductResponse
                           {
                               Id = x.Id,
                               Name = x.Name,
                               Description = x.Description,
                               CreatedDate = x.CreatedDate,
                               CategoryId = x.CategoryId,
                               Category = new CategoryResponse
                               {
                                   Id = x.Category.Id,
                                   Name = x.Category.Name,
                                   Description = x.Category.Description
                               }
                           })
                           .ToListAsync(token);
        }
    }
}
