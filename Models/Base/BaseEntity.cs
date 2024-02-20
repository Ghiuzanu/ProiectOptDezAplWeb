using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectOptDezAplWeb.Models.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }
        public DateTime? DataCreated { get; set; }
        public DateTime? DataModified { get; set; }
    }
}
