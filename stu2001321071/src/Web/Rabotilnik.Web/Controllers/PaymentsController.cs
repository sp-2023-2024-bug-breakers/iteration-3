namespace Rabotilnik.Web.Controllers
{
    using System.Threading.Tasks;

    using Rabotilnik.Services.Interfaces;
    using Rabotilnik.Web.ViewModels.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PaymentsController : BaseController
    {
        private readonly IFreelancePlatform freelancePlatform;

        public PaymentsController(IFreelancePlatform freelancePlatform)
        {
            this.freelancePlatform = freelancePlatform;
        }

        [Authorize(Roles = "Freelancer, Employer")]
        public async Task<IActionResult> Checkout(string id)
        {
            var contract = await this.freelancePlatform.ContractManager.GetContractByIdAsync<SingleContractViewModel>(id);

            if (contract is null)
            {
                return this.View("Error");
            }

            var recipientId = contract.FreelancerId;
            var paymentAmount = (int)contract.OfferFixedPrice * 100;
            var intent = this.freelancePlatform.StripeManager.CreatePaymentIntent(paymentAmount, recipientId, contract.Id);

            this.ViewData["ClientSecret"] = intent.ClientSecret;
            this.ViewData["CurrentUser"] = recipientId;

            return this.View(contract);
        }
    }
}
