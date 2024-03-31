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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<IEnumerable<Category>>))]
        public async Task<IEnumerable<Category>> GetTheListOfCategory()
        {
            return await _serviceCategory.GetTheListOfCategory();
        }

        /// <summary>
        /// Obtain list of sub category by id.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        [EnableCors]
        [HttpGet()]
        [Route("GetTheListOfSubCategoryByCategoryId/{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<IEnumerable<SubCategory>>))]
        public async Task<IEnumerable<SubCategory>> GetTheListOfSubCategoryByCategoryId(int id)
        {
            return await _serviceSubCategory.GetTheListOfSubCategoryByCategoryId(id);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<IEnumerable<Product>>))]
        public async Task<IEnumerable<Product>> GetTheListOfProductBySubCategoryId(int id)
        {
            return await _serviceProduct.GetTheListOfProductBySubCategoryId(id);
        }

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>The new user.</returns>
        [EnableCors]
        [HttpPost()]
        [Route("RegisterUser")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<User>))]
        public async Task<User> RegisterUser(User user)
        {
            return null;
        }
    }
}