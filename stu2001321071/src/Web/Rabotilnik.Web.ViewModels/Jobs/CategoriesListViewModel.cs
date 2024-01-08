namespace Rabotilnik.Web.ViewModels.Jobs
{
    using Rabotilnik.Data.Models;
    using Rabotilnik.Services.Mapping;

    public class CategoriesListViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
