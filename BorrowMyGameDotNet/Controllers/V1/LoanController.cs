using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BorrowMyGameDotNet.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class LoanController : ControllerBase
    {
    }
}