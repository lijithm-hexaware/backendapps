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
    public class OrderController : ControllerBase
    {
        IOrderService _OrderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService OrderService,IMapper mapper)
        {
            _OrderService = OrderService;
            _mapper = mapper;
        }

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            var OrderDTOs = _mapper.Map<IEnumerable<OrderDto>>(_OrderService.GetAll());
            return Ok(OrderDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetById(string id)
        {
            var OrderDTO = _mapper.Map<OrderDto>(_OrderService.Get(id));
            return Ok(OrderDTO);
        }

        [HttpPost]
        public ActionResult<Order> Save(Order Order)
        {
            var OrderDTOs = _mapper.Map<OrderDto>(_OrderService.Save(Order));
            return Ok(OrderDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<Order> Update([FromRoute] string id, Order Order)
        {
            var OrderDTOs = _mapper.Map<OrderDto>(_OrderService.Update(id, Order));
            return Ok(OrderDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _mapper.Map<bool>(_OrderService.Delete(id));
            if(res== false) return null;
            return Ok(res);

        }


    }
}
