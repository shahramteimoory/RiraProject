using System.ComponentModel.DataAnnotations;

namespace Rira.Domain.Entities
{
    public record BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public string? Description { get; set; }
    }

    public abstract record BaseEntity : BaseEntity<long>
    { }
}
