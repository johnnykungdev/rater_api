using System.ComponentModel.DataAnnotations;

namespace rater_api.Models;

public class SchoolProgram {
    [Key]
    public int SchoolProgramId { get; set; }
    public string ProgramName { get; set; }
    public string ProgramDesc { get; set; }
    
    public List<ProgramRate> ProgramRates { get; set; }
}