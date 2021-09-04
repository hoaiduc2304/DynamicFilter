using DNH.Infrastructure.Database.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFilter
{
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
            //builder.HasKey(x => x.CompanyId);
            base.Configure(builder);
        }
    }
}
