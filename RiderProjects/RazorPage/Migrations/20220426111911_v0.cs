

#nullable disable

using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using RazorPage.Models;

namespace RazorPage.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acticles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ArticleContent = table.Column<string>(type: "ntext", nullable: false),
                    ArticleCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acticles", x => x.ArticleId);
                });
            Randomizer.Seed = new Random(8675309);
            var fakerArticle = new Faker<Articles>();
            fakerArticle.RuleFor(a => a.ArticleTitle,
                f => f.Lorem.Sentence(1, 2));
            fakerArticle.RuleFor(a => a.ArticleContent,
                f => f.Lorem.Paragraphs(1, 2));
            fakerArticle.RuleFor(a => a.ArticleCreatedAt,
                f => f.Date.Between(new DateTime(2022, 3, 26),
                    new DateTime(2022, 4, 26)));

            for (int i = 0; i < 150; i++)
            {
                Articles article = fakerArticle.Generate();
                migrationBuilder.InsertData(
                    table: "acticles",
                    columns: new[] {"ArticleTitle", "ArticleContent", "ArticleCreatedAt"},
                    values: new object?[]
                    {
                        article.ArticleTitle,

                        article.ArticleContent,
                        article.ArticleCreatedAt
                    }
                );

            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acticles");
        }
    }
}
