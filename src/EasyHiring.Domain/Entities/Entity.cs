using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace EasyHiring.Domain.Entities;

public abstract class Entity
{
    [Key] [BsonIgnoreIfDefault] 
    public Guid Id { get; protected set; }
    public DateTime CreatedDate { get; protected set; } = DateTime.Now;
    public DateTime ModifiedDate { get; protected set; } = DateTime.Now;
    public bool IsActive { get; protected set; } = true;

    public void SetIsActive(bool value)
    {
        IsActive = value;
    }
}