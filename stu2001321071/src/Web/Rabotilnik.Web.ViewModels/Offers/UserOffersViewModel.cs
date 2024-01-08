namespace Rabotilnik.Web.ViewModels.Offers
{
    using Rabotilnik.Data.Models;
    using Rabotilnik.Services.Mapping;

    public class UserOffersViewModel : IMapFrom<Offer>
    {
        public string Id { get; set; }

        public string JobId { get; set; }

        public string JobTitle { get; set; }

        public int FixedPrice { get; set; }

        public int DeliveryDays { get; set; }
    }
}
