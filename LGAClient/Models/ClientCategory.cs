using System.ComponentModel.DataAnnotations;

namespace LGAClient.Models
{
    public class ClientCategory
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }
    }
}
