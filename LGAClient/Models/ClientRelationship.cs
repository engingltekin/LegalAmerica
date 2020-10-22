using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGAClient.Models
{
    public class ClientRelationship
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Person")]
        public int ClientId { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("ClientRelationshipType")]
        public int ClientRelationShipTypeId { get; set; }

        public string Notes { get; set; }

        public ClientRelationshipType RelationshipType { get; set; }

    }
}
