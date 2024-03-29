using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using System.Net.Mime;

namespace Store.Management.Api.Controllers
{
    /// <summary>
    /// StoreManagementApiController.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StoreManagementApiController : ControllerBase
    {
        private readonly IServiceCategory _serviceCategory;

        /// <summary>
        /// StoreManagementApiController.
        /// </summary>
        /// <param name="serviceCategory"></param>
        public StoreManagementApiController(IServiceCategory serviceCategory)
        {
            _serviceCategory = serviceCategory;
        }

        /// <summary>
        /// Obtain all list of category.
        /// </summary>
        /// <returns></returns>
        [DisableCors]
        [HttpGet(Name = "ObtainAllListOfCategory")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Category>))]
        public IEnumerable<Category> ObtainAllListOfCategory()
        {
            return _serviceCategory.ObtainAllListOfCategory();
        }
    }
}