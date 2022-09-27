using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class Image
    {
        public long Id { get; set; }
        public string? ImgUrl { get; set; }
        public byte[] CreatedAt { get; set; } = null!;
        public byte[] UpdatedAt { get; set; } = null!;
    }
}
