namespace Rabotilnik.Web.ViewModels.Reviews
{
    using System;

    using Rabotilnik.Data.Models;
    using Rabotilnik.Services.Mapping;

    public class ReviewsListViewModel : IMapFrom<Review>
    {
        public string SenderFirstName { get; set; }

        public string SenderLastName { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public string DateFormatted => this.CreatedOn.ToLongDateString();
    }
}
