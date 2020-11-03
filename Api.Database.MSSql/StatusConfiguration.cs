using Api.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.MSSql
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        private const string TableName = "status";
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(20)");

            builder
                .HasMany(b => b.Tasks)
                .WithOne();
        }
    }
}
