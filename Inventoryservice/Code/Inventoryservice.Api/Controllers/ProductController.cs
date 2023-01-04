using System.Collections.Generic;
using Inventoryservice.BusinessServices.Interfaces;
using Inventoryservice.BusinessEntities.Entities;
using Inventoryservice.Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Inventoryservice.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _ProductService;
        private readonly IMapper _mapper;
        public ProductController(IProductService ProductService,IMapper mapper)
        {
            _ProductService = ProductService;
            _mapper = mapper;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var ProductDTOs = _mapper.Map<IEnumerable<ProductDto>>(_ProductService.GetAll());
            return Ok(ProductDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(string id)
        {
            var ProductDTO = _mapper.Map<ProductDto>(_ProductService.Get(id));
            return Ok(ProductDTO);
        }

        [HttpPost]
        public ActionResult<Product> Save(Product Product)
        {
            var ProductDTOs = _mapper.Map<ProductDto>(_ProductService.Save(Product));
            return Ok(ProductDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Update([FromRoute] string id, Product Product)
        {
            var ProductDTOs = _mapper.Map<ProductDto>(_ProductService.Update(id, Product));
            return Ok(ProductDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _mapper.Map<bool>(_ProductService.Delete(id));
            if(res== false) return null;
            return Ok(res);

        }


    }
}
