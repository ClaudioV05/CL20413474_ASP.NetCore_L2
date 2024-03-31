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
        private readonly IServiceCategories _serviceCategory;
        private readonly IServiceSubCategories _serviceSubCategory;
        private readonly IServiceProducts _serviceProduct;
        private readonly IServiceUsers _serviceUser;

        /// <summary>
        /// StoreManagementApiController.
        /// </summary>
        /// <param name="serviceCategory"></param>
        /// <param name="serviceSubCategory"></param>
        /// <param name="serviceProduct"></param>
        /// <param name="serviceUser"></param>
        public StoreManagementApiController(IServiceCategories serviceCategory,
                                            IServiceSubCategories serviceSubCategory,
                                            IServiceProducts serviceProduct,
                                            IServiceUsers serviceUser)
        {
            _serviceCategory = serviceCategory;
            _serviceSubCategory = serviceSubCategory;
            _serviceProduct = serviceProduct;
            _serviceUser = serviceUser;
        }

        /// <summary>
        /// Obtain all list of category.
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        [HttpGet()]
        [Route("GetTheListOfCategory")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<IEnumerable<Categories>>))]
        public async Task<IEnumerable<Categories>> GetTheListOfCategory()
        {
            return await _serviceCategory.GetTheListOfCategories();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<IEnumerable<SubCategories>>))]
        public async Task<IEnumerable<SubCategories>> GetTheListOfSubCategoryByCategoryId(int id)
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<IEnumerable<Products>>))]
        public async Task<IEnumerable<Products>> GetTheListOfProductBySubCategoryId(int id)
        {
            return await _serviceProduct.GetTheListOfProductBySubCategoryId(id);
        }

        /// <summary>
        /// Register a new user through identity.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [EnableCors]
        [HttpPost()]
        [Route("RegisterUser")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<User>))]
        public async Task RegisterUser(User user)
        {
            try
            {
                await _serviceUser.RegisterUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}