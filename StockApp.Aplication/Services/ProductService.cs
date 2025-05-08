using StockApp.Aplication.ViewModel;
using StockApp.Core.Entities;
using StokApp.Persistence.Contexts;
using StokApp.Persistence.Repositories;

namespace StockApp.Aplication.Services
{
    public class ProductService
    {
        private readonly ProducRepository _repository;

        public ProductService(StockAppContext context)
        {
            this._repository = new(context);
        }

        public async Task Add(SaveProductViewModel vm)
        {
            var product = new Product
            {
                Name = vm.Name,
                Description = vm.Description,
                Price = vm.Price,
                PathImage = vm.UrlImage,
                CategoryId = vm.CategoryId,
            };
            await _repository.AddAsync(product);
        }

        public async Task<ICollection<ProductViewModel>> GetAllViewModel()
        {
            var product = await _repository.GetAllAsync();
            var products_view_model = product.Select(viewModel => new ProductViewModel
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                UrlImage = viewModel.PathImage
            }).ToList();
            return products_view_model;
        }

        public async Task<SaveProductViewModel> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            var products_view_model = new SaveProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                UrlImage = product.PathImage,
                CategoryId = product.CategoryId
            };
            return products_view_model;
        }

        public async Task UpdateProductViewModel(SaveProductViewModel vm)
        {
            var product = new Product
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Price = vm.Price,
                PathImage = vm.UrlImage,
                CategoryId = vm.CategoryId,
            };
            await _repository.UpdateAsync(product);
        }

        public async Task RemoveProductViewModel(SaveProductViewModel vm)
        {
            var content = await _repository.GetByIdAsync(vm.Id);
            content.Remove = true;
            await _repository.UpdateAsync(content);
        }
    }
}
