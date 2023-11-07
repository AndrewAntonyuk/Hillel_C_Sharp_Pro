using InternetShop.Contract.Responses;
using InternetShop.Data.Context;
using InternetShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Service.Commands.Create
{
    public class CreateProductCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }

        public Product CreateProduct()
        {
            return new Product
            {
                Id = Id,
                Name = Name,
                Description = Description,
                CreatedDate = CreatedDate,
                CategoryId = CategoryId
            };
        }

    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly InternetShopDbContext _context;

        public CreateProductCommandHandler(InternetShopDbContext context)
        {
            _context = context;
        }

        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken token = default)
        {
            var existProduct = await _context.Products.SingleOrDefaultAsync(p => p.Id == request.Id, token);

            if (existProduct == null)
            {
                var createdProduct = await _context.Products.AddAsync(request.CreateProduct(), token);
                await _context.SaveChangesAsync(token);

                return new ProductResponse
                {
                    Id = createdProduct.Entity.Id,
                    Name = createdProduct.Entity.Name,
                    Description = createdProduct.Entity.Description,
                    CreatedDate = createdProduct.Entity.CreatedDate,
                    CategoryId = createdProduct.Entity.CategoryId,
                    Category = await _context.Categories.Select(x => new CategoryResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    }).SingleOrDefaultAsync(x => x.Id == request.CategoryId, token) ?? null
                };
            }

            return null;            
        }
    }
}
