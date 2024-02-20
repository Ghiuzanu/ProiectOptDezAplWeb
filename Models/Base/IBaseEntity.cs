namespace ProiectOptDezAplWeb.Models.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        DateTime? DataCreated { get; set; }

        DateTime? DataModified { get; set; }
    }
}
