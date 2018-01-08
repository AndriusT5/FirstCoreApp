using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Data;
using CoreApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreApp.Conrollers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IMyAppRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IMyAppRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to ge Products {ex}");
                return BadRequest("Failed to get products result");
            }
           
        }
    }
}