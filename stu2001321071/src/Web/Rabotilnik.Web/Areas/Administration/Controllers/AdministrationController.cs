namespace Rabotilnik.Web.Areas.Administration.Controllers
{
    using Rabotilnik.Common;
    using Rabotilnik.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
