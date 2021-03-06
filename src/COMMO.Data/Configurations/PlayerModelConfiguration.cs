// <copyright file="PlayerModelConfiguration.cs" company="2Dudes">
// Copyright (c) 2018 2Dudes. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using COMMO.Data.Models;

namespace COMMO.Data.Configurations
{
    public class PlayerModelConfiguration : IEntityTypeConfiguration<PlayerModel>
    {
        public void Configure(EntityTypeBuilder<PlayerModel> builder)
        {
            builder.HasKey(b => b.Player_Id);

            builder.Property(t => t.Charname)
                .IsRequired();

            builder.Property(t => t.Account_Id)
                .IsRequired();

            builder.Property(t => t.Account_Nr)
                .IsRequired();
        }
    }
}
