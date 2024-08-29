using System;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Mapping;

public static class ProductMapping
{
    public static Product ToEntity(this CreateProductDto product){
      return new Product(){
        Name= product.Name,
        Description = product.Description,
        Rating = product.Rating,
        BackdropUrl = product.BackdropUrl,
        CategoryId = product.CategoryId,
        CurrentPrice = product.CurrentPrice,
        OldPrice = product.OldPrice
      };
    }


    public static Product ToEntity(this updateProductDto product, int id){
      return new Product(){
        Id = id,
        Name= product.Name,
        Description = product.Description,
        CategoryId = product.CategoryId,
        BackdropUrl = product.BackdropUrl,
        Rating = product.Rating,
        CurrentPrice = product.CurrentPrice,
        OldPrice = product.OldPrice,
      };
    }

    public static ProductSummaryDto ToProductSummaryDto(this Product product){
        return new(
            product.Id,
            product.Name,
            product.CurrentPrice,
            product.OldPrice,
            product.Description,
            product.BackdropUrl,
            product.Rating,
            product.Category!.Name
        );
    }

        public static ProductDetailsDto ToProductDetailsDto(this Product product){
        return new(
            product.Id,
            product.Name,
            product.CurrentPrice,
            product.OldPrice,
            product.BackdropUrl,
            product.Description,
            product.Rating,
            product.CategoryId
        );
    }
}
