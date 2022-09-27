using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class Game
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? ImgUrl { get; set; }
        public string? HtmlUrl { get; set; }
        public byte[] CreatedAt { get; set; } = null!;
        public byte[] UpdatedAt { get; set; } = null!;
    }
}
