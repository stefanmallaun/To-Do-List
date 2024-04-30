using System.ComponentModel.DataAnnotations;

namespace To_Do_List.Models
{
    public class To_do_Element
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength (1000)]
        public string Description { get; set; }
        public Type_of_Element Type { get; set; }


    }
}
