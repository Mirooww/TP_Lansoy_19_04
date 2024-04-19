using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Mission
{
    public int MissionId { get; set; }

    [Required]
    public string Lieu { get; set; } 

    [Required]
    public int Annee { get; set; }
    public List<Espion> Espions { get; } = new List<Espion>();
}
