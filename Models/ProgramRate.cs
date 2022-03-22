using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rater_api.Models;

public class ProgramRate {
    [Key]
    public int ProgramRateId { get; set; }
    [Required]
    public string ProgramReview { get; set; }
    
    public int RateNumber { get; set; }
    public DateTime Created_At { get; set; }
    [ForeignKey("SchoolProgramId")]
    public int SchoolProgramId { get; set; }
    // public SchoolProgram SchoolProgram { get; set; }
}