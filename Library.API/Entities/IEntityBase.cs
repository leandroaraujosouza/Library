namespace Library.API.Entities
{
    public interface IEntityBase
    {
        string CreatedAt { get; set; }
        string Id { get; set; }
        string UpdateAt { get; set; }
    }
}