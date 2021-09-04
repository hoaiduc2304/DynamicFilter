# Dynamic Filter

[![Build status](https://ci.appveyor.com/api/projects/status/xnby6p5v4ur04u76?svg=true)](https://ci.appveyor.com/project/danielgerlag/workflow-core)

Dynamic Filter is a light weight embeddable workflow engine targeting .NET Standard.

### Announcements

#### New related project: Conductor
Conductor is a stand-alone framework to work with MSSQL for paging,sorting and filtering.



## Documentation

See [Tutorial here.](https://github.com/hoaiduc2304/DynamicFilter)

## Filtering in 5 mins 
### Create new Table 

CREATE TABLE [dbo].[SiteMap](
	[SitemapId] [int] NOT NULL,
	[code] [nvarchar](50) NULL,
	[link] [nvarchar](50) NULL,
	[icon] [nvarchar](25) NULL,
	[intl] [nvarchar](50) NULL,
	[ParentId] [int] NULL,
	[menu] [nvarchar](500) NULL,
 CONSTRAINT [PK_SiteMap] PRIMARY KEY CLUSTERED 
(
	[SitemapId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


### Repository with MSSQL 

#### Add Entity Model 

```c#
 public class SYSitemap 
    {
        public int SitemapId { get; set; }
        public string code { get; set; }
        public string link { get; set; }
        public string icon { get; set; }
        public string intl { get; set; }
        public int? ParentId { get; set; }
        public string menu { get; set; }
    }


    public class SYSitemapMap : EntityTypeConfiguration<SYSitemap>
    {
        public override void Configure(EntityTypeBuilder<SYSitemap> builder)
        {
            builder.ToTable("SiteMap");
            builder.HasKey(x => new { x.SitemapId});
            base.Configure(builder);
        }
    }
```
#### Add Service : 

```c#
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

### Controller and Filtering 

```C#
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
```
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

Just 5 mins , we can pagging , filtering and sorting. Wish this example help us to reduce the time to develop common function.
<kbd>
<img src="https://github.com/hoaiduc2304/DynamicFilter/blob/main/Images/swagger1.jpg" alt="Dynamic Filter" />
</kbd>
## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
