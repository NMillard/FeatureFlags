using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FeatureToggle.Examples.SimpleWebApi.Controllers {
    
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class UsersController : ControllerBase {

        [HttpGet]
        [FeatureOn(nameof(Toggles.ToggleKey.NewUserType))]
        public IActionResult All() {
            return Ok();
        }
    }

    public class FeatureOnAttribute : Attribute {
        public FeatureOnAttribute(string newUserTypeName) {
            Console.WriteLine(newUserTypeName);
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            return;
        }

        public void OnActionExecuted(ActionExecutedContext context) {
            return;
        }
    }
}