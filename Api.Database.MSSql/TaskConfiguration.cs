using Api.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.MSSql
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        private const string TableName = "task";
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(x => x.Guid);

            builder.Property(x => x.Guid)
                .HasColumnName("Guid")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => x.Guid)
                .HasName("Guid")
                .IsUnique();

            builder.Property(x => x.TimeStamp)
                .HasColumnName("Timestamp")
                .HasColumnType("datetime");

            builder.HasOne(x => x.Status)
                .WithMany(t => t.Tasks)
                .HasForeignKey(dt => dt.StatusId);
        }
    }
}
