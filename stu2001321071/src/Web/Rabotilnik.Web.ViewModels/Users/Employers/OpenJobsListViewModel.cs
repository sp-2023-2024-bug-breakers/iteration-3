namespace Rabotilnik.Web.ViewModels.Users.Employers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Rabotilnik.Common;
    using Rabotilnik.Data.Models;
    using Rabotilnik.Services.Mapping;

    public class OpenJobsListViewModel : IMapFrom<Job>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public Country EmployerLocation { get; set; }

        public string LocationToString
            => this.EmployerLocation.GetAttribute<DisplayAttribute>().Name;

        public DateTime CreatedOn { get; set; }

        public string DateFormatted => TimeCalculator.GetTimeAgo(this.CreatedOn);
    }
}
