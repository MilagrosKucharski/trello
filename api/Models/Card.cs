using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api;

public class Card {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Description { get; set; } = null!;
    public int ColumnId { get; set; }
    [ForeignKey("ColumnId")]
    public Column Column { get; set; } = null!;
}