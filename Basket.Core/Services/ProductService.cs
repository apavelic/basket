﻿using Basket.Core.Infrastructure;
using Basket.Core.Interfaces;
using Basket.Core.Models;
using Basket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public List<ProductDTO> GetProducts()
        {
            try
            {
                List<ProductDTO> model = new List<ProductDTO>();

                var products = _productRepository.GetAll().AsEnumerable();

                foreach (var product in products)
                {
                    model.Add(new ProductDTO
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Price = product.Price
                    });
                }

                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
