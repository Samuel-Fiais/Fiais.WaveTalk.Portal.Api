using Fiais.WaveTalk.Portal.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiais.WaveTalk.Portal.Infra.Data.Configurations;

internal abstract class BaseConfiguration
{
    protected void ConfigureBaseEntity<T>(EntityTypeBuilder<T> builder, bool ignoreBaseEntity = false) where T : class
    {
        if (!ignoreBaseEntity && typeof(T).BaseType == typeof(EntityBase))
            throw new Exception($"Você está tentando configurar um {nameof(EntityBase)} com o configuration errado.");

        var propId = typeof(T).GetProperty(nameof(EntityBase.Id));
        if (propId != null && propId.PropertyType == typeof(Guid))
        {
            builder.HasKey(propId.Name);
            builder.Property(propId.Name)
                .ValueGeneratedOnAdd()
                .IsRequired();

            return;
        }

        throw new Exception($"{typeof(T)} - Propriedade Id não encontrada.");
    }
}

internal abstract class BaseConfiguration<T> : BaseConfiguration, IEntityTypeConfiguration<T> where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        ConfigureBaseEntity(builder, true);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasAlternateKey(x => x.AlternateId);
        builder.HasIndex(x => x.AlternateId).IsUnique();
        builder.Property(x => x.AlternateId)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");
    }
}
