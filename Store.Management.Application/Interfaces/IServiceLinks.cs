﻿using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceLinks.
    /// </summary>
    public interface IServiceLinks
    {
        /// <summary>
        /// To obtain the list of object category.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>The list from object category</returns>
        List<Category> GetTheListOfCategory(string uri);

        /// <summary>
        /// To obtain the list of object sub category.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>The list from object sub category</returns>
        List<SubCategory> LoadObjectSubCategoryById(string uri);

        /// <summary>
        /// To obtain the list of product by sub category id.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>he list from object product</returns>
        List<Product> GetTheListOfProductBySubCategoryId(string uri);
    }
}