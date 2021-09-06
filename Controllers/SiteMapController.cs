using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNH.Infrastructure.Paging;
using DynamicFilter.Services;
using DNH.Infrastructure.Database.SQL;

namespace DynamicFilter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteMapController : ControllerBase
    {
        IDbContext _dbContext;
        public SiteMapController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="accountName"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost("paging")]
        public virtual IActionResult Paging([FromBody] FilterRequest request)
        {
        
            SiteMapServices siteMapServices = new SiteMapServices(_dbContext);
            var result = siteMapServices.Entities.Getpaging(request);
            return Ok(result);
        }
    }
}
