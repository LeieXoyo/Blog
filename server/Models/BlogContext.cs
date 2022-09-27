using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace server.Models
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Music> Musics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Blog.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("articles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("author");

                entity.Property(e => e.AuthorIp)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("author_ip");

                entity.Property(e => e.Content)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATETIME")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeleteFlag)
                    .HasColumnType("TINYINT")
                    .HasColumnName("delete_flag")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATETIME")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATETIME")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.HtmlUrl)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("html_url");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("img_url");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATETIME")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("images");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATETIME")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("img_url");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATETIME")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Music>(entity =>
            {
                entity.ToTable("musics");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("author");

                entity.Property(e => e.CoverUrl)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("cover_url");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DATETIME")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FileUrl)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("file_url");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("DATETIME")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
