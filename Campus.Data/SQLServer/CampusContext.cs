using Microsoft.EntityFrameworkCore;
using Domain.Entities.Admin;

namespace Campus.Data.SQLServer
{
    public class CampusContext : DbContext
    {
        public CampusContext(DbContextOptions<CampusContext> options) : base(options)
        {
        }

        public DbSet<NodeTypeEntity> NodeTypes { get; set; }
        public DbSet<NodeEntity> Nodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NodeEntity>()
                .Property(field => field.Url)
                .IsRequired();

            modelBuilder.Entity<NodeTypeEntity>()
                .Property(field => field.Name)
                .IsRequired();

            modelBuilder.Entity<NodeTypeEntity>()
                .Property(field => field.MachineName)
                .IsRequired();

            modelBuilder.Entity<NodeTypeEntity>()
                .HasMany(c => c.Nodes)
                .WithOne(e => e.NodeType);

            modelBuilder.Entity<NodeTypeEntity>().HasData(
                new NodeTypeEntity[]
                {
                    new NodeTypeEntity
                    {
                        Id = 1,
                        Name = "Page",
                        MachineName = "page",
                        Description = "Simple page for node type Page",
                        Instructions = "Удобочитаемое название типа материалов. Этот текст будет показан в списке на странице создания материала. Рекомендуется использовать названия, начинающиеся с прописной буквы и состоящие только из букв, цифр и пробелов. Название должно быть уникальным."
                    },
                    new NodeTypeEntity
                    {
                        Id = 2,
                        Name = "Article",
                        MachineName = "article",
                        Description = "Simple article for node type Article",
                        Instructions = "Удобочитаемое название типа материалов. Этот текст будет показан в списке на странице создания материала. Рекомендуется использовать названия, начинающиеся с прописной буквы и состоящие только из букв, цифр и пробелов. Название должно быть уникальным."
                    }
                }
            );

            modelBuilder.Entity<NodeEntity>().HasData(
                new NodeEntity[]
                {
                    new NodeEntity {
                        Id = 1,
                        MetaTitle = "Node title 1",
                        MetaDescription = "Node type Description 1",
                        Body = "Node Type Body 1",
                        Title = "Node Title 1",
                        NodeTypeId = 1,
                        Url = "url-1"
                        // Created = DateTime.UtcNow,
                        // Status = 1,
                        // Updated = DateTime.Today,
                        // UserId = 1
                    },
                    new NodeEntity {
                        Id = 2,
                        MetaTitle = "Node title 1",
                        MetaDescription = "Node type Description 1",
                        Body = "Node Type Body 1",
                        Title = "Node Title 1",
                        NodeTypeId = 1,
                        Url = "url-1"
                    },
                }
            );
        }
    }
}
