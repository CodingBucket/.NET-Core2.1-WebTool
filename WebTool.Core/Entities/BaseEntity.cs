using System;

namespace WebTool.Core.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
