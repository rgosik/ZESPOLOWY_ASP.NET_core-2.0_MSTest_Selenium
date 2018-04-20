using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreApp.Models
{
    public class Klucz
    {
        public string Id { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [Range(0, 999)]
        public int Type { get; set; }

        [NotMapped]
        public string FullKey => string.Format($"{Name} {Type}");
    }
}
