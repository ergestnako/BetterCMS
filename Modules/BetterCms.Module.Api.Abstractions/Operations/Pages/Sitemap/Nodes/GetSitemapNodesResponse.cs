﻿using System;
using System.Runtime.Serialization;

using BetterCms.Module.Api.Infrastructure;

namespace BetterCms.Module.Api.Operations.Pages.Sitemap.Nodes
{
    [Obsolete("Use everything from BetterCms.Module.Api.Operations.Pages.Sitemaps name space.")]
    [DataContract]
    public class GetSitemapNodesResponse :  ListResponseBase<SitemapNodeModel>
    {
    }
}