﻿using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;

namespace Store.Management.Application.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly IRepositoryCategory _repositoryCategory;

        public ServiceCategory(IRepositoryCategory repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }

        public IEnumerable<Category> ObtainAllListOfCategory()
        {
            try
            {
                var listOfCategory = _repositoryCategory.ObtainAllListOfCategory();
                return (from category in listOfCategory where category.CategoryID > 0 select category).ToList();
            }
            catch (Exception)
            {
                return new List<Category>();
            }
        }
    }
}