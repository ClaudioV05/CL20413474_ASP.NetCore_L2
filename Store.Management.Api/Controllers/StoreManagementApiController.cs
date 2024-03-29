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
        private readonly IServiceProduct _serviceProduct;

        /// <summary>
        /// StoreManagementApiController.
        /// </summary>
        /// <param name="serviceCategory"></param>
        /// <param name="serviceSubCategory"></param>
        /// <param name="serviceProduct"></param>
        public StoreManagementApiController(IServiceCategory serviceCategory,
                                            IServiceSubCategory serviceSubCategory,
                                            IServiceProduct serviceProduct)
        {
            _serviceCategory = serviceCategory;
            _serviceSubCategory = serviceSubCategory;
            _serviceProduct = serviceProduct;
        }

        /// <summary>
        /// Obtain all list of category.
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        [HttpGet()]
        [Route("GetTheListOfCategory")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Category>))]
        public IEnumerable<Category> GetTheListOfCategory()
        {
            return _serviceCategory.GetTheListOfCategory();
        }

        /// <summary>
        /// Obtain list of sub category by id.
        /// </summary>
        /// <param name="categoryID"></param>
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

        /// <summary>
        /// Obtain list of product by sub category id.
        /// </summary>
        /// <param name="subCategoryID"></param>
        /// <returns></returns>
        [EnableCors]
        [HttpGet()]
        [Route("GetTheListOfProductBySubCategoryId/{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        public IEnumerable<Product> GetTheListOfProductBySubCategoryId(int id)
        {
            return _serviceProduct.GetTheListOfProductBySubCategoryId(id);
        }
    }
}