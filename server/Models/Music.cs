using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class Music
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? CoverUrl { get; set; }
        public string? FileUrl { get; set; }
        public byte[] CreatedAt { get; set; } = null!;
        public byte[] UpdatedAt { get; set; } = null!;
    }
}
