﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Mappings.Identity;

public class IdentityUserClaim : IEntityTypeConfiguration<IdentityUserClaim<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<long>> builder)
    {
        builder.ToTable("IdentityClaim");
        builder.HasKey(uc => uc.Id);
        builder.Property(uc => uc.ClaimType).HasMaxLength(255);
        builder.Property(uc => uc.ClaimValue).HasMaxLength(255);
    }
}