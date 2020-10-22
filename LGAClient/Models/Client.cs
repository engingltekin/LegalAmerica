using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGAClient.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Person")]
        public  int PersonId { get; set; }

        [ForeignKey("ClientCategory")]
        public int ClientCategoryId { get; set; }

        public ICollection<ClientRelationship> Relationships { get; set; }

        public ClientCategory CategoryType { get; set; }

    }
}
