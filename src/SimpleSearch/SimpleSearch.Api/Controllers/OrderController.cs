using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nest;
using SimpleSearch.Api.Constants;
using SimpleSearch.Api.Infrastructure.Exception;
using SimpleSearch.Api.Models.Request;
using SimpleSearch.Api.Models.Response;
using SimpleSearch.Api.Services;

namespace SimpleSearch.Api.Controllers
{
    [Route("v1/orders")]
    [Produces("application/json")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderSearchService _orderSearchService;

        public OrderController(IOrderSearchService orderSearchService)
        {
            _orderSearchService = orderSearchService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearchRequest request)
        {
            var result = _orderSearchService.Search(request);
            
            return Ok(result);
        }
    }
}