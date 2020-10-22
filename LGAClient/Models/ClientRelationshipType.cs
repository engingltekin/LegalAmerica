using System.ComponentModel.DataAnnotations;

namespace LGAClient.Models
{
    public class ClientRelationshipType
    {
        [Key]
        public int Id { get; set; }

        public string RelationshipType { get; set; }
    }
}
