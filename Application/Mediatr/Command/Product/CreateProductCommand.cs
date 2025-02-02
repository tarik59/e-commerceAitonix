﻿using Application.Contracts;
using Application.Services;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EC_Domain.Entity;
using Application.Repositories;

namespace Application.Mediatr.Command.Products
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public ProductDto Product;
        public CreateProductCommand(ProductDto product)
        {
            Product = product;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        private readonly IRepository<EC_Domain.Entity.Brand> _brandRepo;
        private readonly IRepository<EC_Domain.Entity.Gender> _genderRepo;
        private readonly IRepository<EC_Domain.Entity.TypeOfProduct> _typeOfProductRepo;
        public CreateProductCommandHandler(IMapper mapper, IProductService productService, IRepository<EC_Domain.Entity.Product> productRepo, IRepository<EC_Domain.Entity.Brand> brandRepo, IRepository<EC_Domain.Entity.Gender> genderRepo, IRepository<EC_Domain.Entity.TypeOfProduct> typeOfProductRepo)
        {
            _mapper = mapper;
            _productService = productService;
            _brandRepo = brandRepo;
            _genderRepo = genderRepo;
            _typeOfProductRepo = typeOfProductRepo;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new EC_Domain.Entity.Product();
            product.Name = request.Product.Name;
            product.Quantity = request.Product.Quantity;
            product.Price = request.Product.Price;
            product.Description = request.Product.Description;
            product.Model = request.Product.Model;
            product.ImageUrl = request.Product.ImageUrl;
            var brand = await _brandRepo.Get(c => c.Name == request.Product.Brand.Name);
            if (brand == null)
            {
                throw new Exception("Brand does not exists");
            }
            product.brandId = brand.Id;

            var gender = await _genderRepo.Get(c => c.Name == request.Product.Gender.Name);
            if (gender == null)
            {
                throw new Exception("Gender does not exists");
            }
            product.genderId = gender.Id;

            var typeOfProduct = await _typeOfProductRepo.Get(c => c.Name == request.Product.TypeOfProduct.Name);
            if (typeOfProduct == null)
            {
                throw new Exception("That type of product does not exist");
            }
            product.typeOfProductId = typeOfProduct.Id;
            await _productService.AddProductAsync(product);
            
            return Unit.Value;
        }
    }
}
