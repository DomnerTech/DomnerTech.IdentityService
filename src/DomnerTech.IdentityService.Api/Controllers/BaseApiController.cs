using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DomnerTech.IdentityService.Api.Controllers;


[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class BaseApiController : ControllerBase;