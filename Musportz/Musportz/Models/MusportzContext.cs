using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Musportz.Models
{
    public partial class MusportzContext : DbContext
    {
        public MusportzContext()
        {
        }

        public MusportzContext(DbContextOptions<MusportzContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogPost> BlogPost { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<MailMessage> MailMessage { get; set; }
        public virtual DbSet<PostComments> PostComments { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Musportz;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.ToTable("blogPost");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.UserProfileId).HasColumnName("userProfileId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BlogPost)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__blogPost__catego__4E88ABD4");

                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.BlogPost)
                    .HasForeignKey(d => d.UserProfileId)
                    .HasConstraintName("FK__blogPost__userPr__4D94879B");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("categoryName")
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MailMessage>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FromuserProfileId).HasColumnName("fromuserProfileId");

                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasColumnName("messageText")
                    .HasColumnType("text");

                entity.Property(e => e.MessageTitle)
                    .IsRequired()
                    .HasColumnName("messageTitle")
                    .IsUnicode(false);

                entity.Property(e => e.TouserProfileId).HasColumnName("touserProfileID");

                entity.HasOne(d => d.FromuserProfile)
                    .WithMany(p => p.MailMessageFromuserProfile)
                    .HasForeignKey(d => d.FromuserProfileId)
                    .HasConstraintName("FK__MailMessa__fromu__5CD6CB2B");

                entity.HasOne(d => d.TouserProfile)
                    .WithMany(p => p.MailMessageTouserProfile)
                    .HasForeignKey(d => d.TouserProfileId)
                    .HasConstraintName("FK__MailMessa__touse__5DCAEF64");
            });

            modelBuilder.Entity<PostComments>(entity =>
            {
                entity.ToTable("postComments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlogPostId).HasColumnName("blogPostId");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserProfileId).HasColumnName("userProfileId");

                entity.HasOne(d => d.BlogPost)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.BlogPostId)
                    .HasConstraintName("FK__postComme__blogP__5441852A");

                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.UserProfileId)
                    .HasConstraintName("FK__postComme__userP__534D60F1");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("userProfile");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("displayName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasColumnName("photoPath")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredAt)
                    .HasColumnName("registeredAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserAccountId)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
