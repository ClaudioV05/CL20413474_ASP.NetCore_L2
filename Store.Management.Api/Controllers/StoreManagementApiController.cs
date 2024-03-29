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
        private readonly IServiceSubCategory _serviceSubCategory;

        /// <summary>
        /// StoreManagementApiController.
        /// </summary>
        /// <param name="serviceCategory"></param>
        /// <param name="serviceSubCategory"></param>
        public StoreManagementApiController(IServiceCategory serviceCategory,
                                            IServiceSubCategory serviceSubCategory)
        {
            _serviceCategory = serviceCategory;
            _serviceSubCategory = serviceSubCategory;
        }

        /// <summary>
        /// Obtain all list of category.
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        [HttpGet()]
        [Route("ObtainAllListOfCategory")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Category>))]
        public IEnumerable<Category> ObtainAllListOfCategory()
        {
            return _serviceCategory.ObtainAllListOfCategory();
        }

        /// <summary>
        /// Obtain list of sub category by id.
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        [HttpGet()]
        [Route("ObtainListOfSubCategoryById/{categoryID}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SubCategory>))]
        public IEnumerable<SubCategory> ObtainListOfSubCategoryById(int categoryID)
        {
            return _serviceSubCategory.ObtainListOfSubCategoryById(categoryID);
        }
    }
}