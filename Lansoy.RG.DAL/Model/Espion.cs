using Lansoy.RG.DAL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Espion
{
    public int EspionId { get; set; }

    [MaxLength(30)]
    public string Nom { get; set; } 

    [MaxLength(50)]
    public string NomDeCode { get; set; } 
    public string Ville { get; set; } 
    public List<Mission> Missions { get; } = new List<Mission>();
    public List<Espion> Espions { get; } = new List<Espion>();

}
