using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankingApi.Models.EF;

public partial class SethuApiDbContext : DbContext
{
    public SethuApiDbContext()
    {
    }

    public SethuApiDbContext(DbContextOptions<SethuApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountDetail> AccountDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:apiinstance.database.windows.net,1433;Initial Catalog=sethu_apiDB;Persist Security Info=False;User ID=axaadmin;Password=Password@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountDetail>(entity =>
        {
            entity.HasKey(e => e.AccId).HasName("PK__AccountD__A471AFDA2CAB3815");

            entity.Property(e => e.AccId).HasColumnName("accId");
            entity.Property(e => e.AccBalance)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("accBalance");
            entity.Property(e => e.AccName)
                .HasMaxLength(150)
                .HasColumnName("accName");
            entity.Property(e => e.AccNo)
                .HasMaxLength(20)
                .HasColumnName("accNo");
            entity.Property(e => e.AccType)
                .HasMaxLength(50)
                .HasColumnName("accType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
