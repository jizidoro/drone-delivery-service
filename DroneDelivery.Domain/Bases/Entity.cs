using DroneDelivery.Domain.Bases.Interfaces;

namespace DroneDelivery.Domain.Bases;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }

    public virtual Guid Key => Id;

    public virtual string Value => ToString()!;
}