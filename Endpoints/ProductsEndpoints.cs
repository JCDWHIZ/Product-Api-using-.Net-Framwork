using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Mapping;

namespace WebApplication1.Endpoints;

public static class ProductsEndpoints
{
const string name = "GetProducts";


public static WebApplication MapProductsEndpoints (this WebApplication app){


 var group = app.MapGroup("products");
    
  // GET products
group.MapGet("/", async(ProductContext dbContext) =>
await dbContext.Product.
Include(product => product.Category).
Select(product => product.ToProductSummaryDto()).AsNoTracking().ToListAsync());

// Get products/id
group.MapGet("/{id}", async (int id, ProductContext dbContext) => 
{    
    Product? product = await dbContext.Product.FindAsync(id);

    return product is null ? Results.NotFound() : Results.Ok(product);
}).WithName(name);


// create a new product
group.MapPost("/", async (CreateProductDto newProduct , ProductContext dbContext) =>
{

Product product = newProduct.ToEntity();
// product.Category = dbContext.Category.Find(newProduct.CategoryId);

dbContext.Product.Add(product);
await dbContext.SaveChangesAsync();

return Results.CreatedAtRoute(name, new{id = product.Id}, product.ToProductDetailsDto());
}).WithParameterValidation();

 

// update a single prodcuts
group.MapPut("/{id}", async (int id, updateProductDto updateProduct, ProductContext dbContext)=> {
//  var index = Products.FindIndex(product => product.Id == id);
var existingProduct = dbContext.Product.Find(id);

 if(existingProduct is null){
  return Results.NotFound(); 
   }

   dbContext.Entry(existingProduct).CurrentValues.SetValues(updateProduct.ToEntity(id));
await dbContext.SaveChangesAsync();
 return Results.Created();
}).WithParameterValidation();


group.MapDelete("products/{id}", async (int id, ProductContext dbContext)=> {
    await dbContext.Product.Where(product => product.Id == id).ExecuteDeleteAsync();

    return Results.NoContent();
});
  
return app;
}
} 