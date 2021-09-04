
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
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (1, N'employee', NULL, NULL, NULL, 1, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (2, N'department', NULL, NULL, NULL, 1, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (3, N'country', NULL, NULL, NULL, 2, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (4, N'company', NULL, NULL, NULL, 2, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (5, N'manager', NULL, NULL, NULL, 3, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (6, N'tax', NULL, NULL, NULL, 4, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (7, N'vat', NULL, NULL, NULL, 5, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (8, N'sale', NULL, NULL, NULL, 6, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (9, N'task', NULL, NULL, NULL, 4, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (10, N'job', NULL, NULL, NULL, 2, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (11, N'document', NULL, NULL, NULL, 7, NULL)
GO
INSERT [dbo].[SiteMap] ([SitemapId], [code], [link], [icon], [intl], [ParentId], [menu]) VALUES (12, N'documentfile', NULL, NULL, NULL, 6, NULL)
GO
