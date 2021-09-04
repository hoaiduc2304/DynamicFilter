# Dynamic Filter

[![Build status](https://ci.appveyor.com/api/projects/status/xnby6p5v4ur04u76?svg=true)](https://ci.appveyor.com/project/danielgerlag/workflow-core)

Dynamic Filter is a light weight embeddable workflow engine targeting .NET Standard.

### Announcements

#### New related project: Conductor
Conductor is a stand-alone framework to work with MSSQL for paging,sorting and filtering.



## Documentation

See [Tutorial here.](https://github.com/hoaiduc2304/DynamicFilter)

## GetDatabase to Iqueryable 

Define service connect to MSSQL Database.

```c#
using DNH.Infrastructure.Database.SQL;
public class SiteMapServices
    {
        private EFManager<SYSitemap> _sitemap;
        public IQueryable<SYSitemap> Entities;

        public SiteMapServices(IDbContext dbContext)
        {
            _sitemap = new EFManager<SYSitemap>(dbContext);
            Entities = _sitemap.Table;
        }
    }
```
Define controller .

```c#

using Microsoft.AspNetCore.Mvc;
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
        
            SiteMapServices employeeServices = new SiteMapServices(_dbContext);
            var result = employeeServices.Entities.Getpaging(request);
            return Ok(result);
        }
       
    }
}
```
## JSON  Definitions

Define your workflows in JSON or YAML, need to install WorkFlowCore.DSL

```json
{
  "page": 1,
  "pageSize": 10,
  "filter": [
    {
     "field": "Code",
		"operator": "contains",
		"value": "Employee",
		"logic": "Or"
    },
	{
     "field": "parentId",
		"operator": "eq",
		"value": "2",
		"logic": "AND"
    },
  ],
  "sorts": [
    {
      "field": "Code",
      "dir": "desc"
    }
  ]

}
```
operator:
```c#
    {"eq", "="},
    {"neq", "!="},
    {"lt", "<"},
    {"lte", "<="},
    {"gt", ">"},
    {"gte", ">="},
    {"startswith", "StartsWith"},
    {"endswith", "EndsWith"},
    {"contains", "Contains"},
    {"doesnotcontain", "DoesNotContain"}
```

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details