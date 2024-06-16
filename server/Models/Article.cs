using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class Article
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? AuthorIp { get; set; }
        public string Content { get; set; } = null!;
        public long DeleteFlag { get; set; }
        public byte[]? CreatedAt { get; set; }
        public byte[]? UpdatedAt { get; set; }
    }

    public class ArticleDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Content { get; set; } = null!;
        public byte[]? CreatedAt { get; set; }
        public byte[]? UpdatedAt { get; set; }
    }
}
