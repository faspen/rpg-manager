using RPGManager.Data;
using System.ComponentModel.DataAnnotations;

namespace RPGManager.Dtos.Specializations
{
    public class SpecializationAddEditDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ArchetypeId { get; set; }
    }
}
