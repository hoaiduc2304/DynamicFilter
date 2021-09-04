using DNH.Infrastructure.Database.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFilter.Services
{
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
}
