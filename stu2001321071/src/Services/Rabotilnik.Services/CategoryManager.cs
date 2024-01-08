namespace Rabotilnik.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Rabotilnik.Data.Common.Repositories;
    using Rabotilnik.Data.Models;
    using Rabotilnik.Services.Interfaces;
    using Rabotilnik.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CategoryManager : ICategoryManager
    {
        private readonly IRepository<Category> repository;

        public CategoryManager(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllJobCategoriesAsync<T>()
            => await this.repository
                .All()
                .OrderBy(x => x.Name)
                .To<T>()
                .ToListAsync();
    }
}
