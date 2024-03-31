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
        private readonly IServiceCategories _serviceCategories;
        private readonly IServiceSubCategories _serviceSubCategories;
        private readonly IServiceProducts _serviceProducts;
        private readonly IServiceUsers _serviceUsers;

        /// <summary>
        /// StoreManagementApiController.
        /// </summary>
        /// <param name="serviceCategories"></param>
        /// <param name="serviceSubCategories"></param>
        /// <param name="serviceProducts"></param>
        /// <param name="serviceUsers"></param>
        public StoreManagementApiController(IServiceCategories serviceCategories,
                                            IServiceSubCategories serviceSubCategories,
                                            IServiceProducts serviceProducts,
                                            IServiceUsers serviceUsers)
        {
            _serviceCategories = serviceCategories;
            _serviceSubCategories = serviceSubCategories;
            _serviceProducts = serviceProducts;
            _serviceUsers = serviceUsers;
        }

        /// <summary>
        /// Obtain all list of categories.
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        [HttpGet()]
        [Route("GetTheListOfCategories")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<IEnumerable<Categories>>))]
        public async Task<IEnumerable<Categories>> GetTheListOfCategories()
        {
            return await _serviceCategories.GetTheListOfCategories();
        }

        /// <summary>
        /// Obtain list of sub category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [EnableCors]
        [HttpGet()]
        [Route("GetTheListOfSubCategoryByCategoryId/{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<IEnumerable<SubCategories>>))]
        public async Task<IEnumerable<SubCategories>> GetTheListOfSubCategoryByCategoryId(int id)
        {
            return await _serviceSubCategories.GetTheListOfSubCategoryByCategoryId(id);
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
            return await _serviceProducts.GetTheListOfProductBySubCategoryId(id);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task))]
        public async Task RegisterUser(User user)
        {
            try
            {
                await _serviceUsers.RegisterUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [EnableCors]
        [HttpPost()]
        [Route("LoginUser")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task))]
        public async Task LoginUser(User user)
        {
            try
            {
                await _serviceUsers.LoginUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}