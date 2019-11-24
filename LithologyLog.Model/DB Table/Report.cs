using System.ComponentModel.DataAnnotations;

namespace LithologyLog.Model
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public int ContractorOrgId { get; set; }
        public int ClientOrgId { get; set; }
        [StringLength(100)]
        public string SiteName { get; set; }
        [StringLength(100)]
        public string ProjectName { get; set; }
        public string Borehole { get; set; }
        public float Depth { get; set; }
        public float Diameter { get; set; }
        public float CoreRecovery { get; set; }
        [StringLength(100)]
        public string DrillingEquipment { get; set; }
        [StringLength(100)]
        public string DrillingMethode { get; set; }
        public float GroundDedectionWatherLevel { get; set; }
        public float GroundStableWatherLevelValue { get; set; }
        public float Elavation { get; set; }
        public float BoreholeNCoordinate { get; set; }
        public float BoreholeECoordinate { get; set; }
        public string PageCreationMember { get; set; }
    }
}
