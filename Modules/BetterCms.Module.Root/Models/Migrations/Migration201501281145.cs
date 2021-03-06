﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Migration201501281145.cs" company="Devbridge Group LLC">
// 
// Copyright (C) 2015,2016 Devbridge Group LLC
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// 
// <summary>
// Better CMS is a publishing focused and developer friendly .NET open source CMS.
// 
// Website: https://www.bettercms.com 
// GitHub: https://github.com/devbridge/bettercms
// Email: info@bettercms.com
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using BetterModules.Core.DataAccess.DataContext.Migrations;
using BetterModules.Core.Models;

using FluentMigrator;

namespace BetterCms.Module.Root.Models.Migrations
{
    /// <summary>
    /// Categories: created parent category id and macro.
    /// </summary>
    [Migration(201501281145)]
    public class Migration201501281145 : DefaultMigration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Migration201501281145"/> class.
        /// </summary>
        public Migration201501281145()
            : base(RootModuleDescriptor.ModuleName)
        {
        }

        public override void Up()
        {
            if (!Schema.Schema(SchemaName).Table("CategoryTrees").Column("Macro").Exists())
            {
                Create
                    .Column("Macro")
                    .OnTable("CategoryTrees").InSchema(SchemaName)
                    .AsString(MaxLength.Text).Nullable();
            }
        }
    }
}