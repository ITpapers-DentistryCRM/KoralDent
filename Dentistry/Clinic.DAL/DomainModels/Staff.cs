namespace Clinic.DAL.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            Doctors = new HashSet<Doctor>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StaffId { get; set; }

        public int AccountId { get; set; }

        public int AccountLevel { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffName { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffMiddleName { get; set; }

        [Column(TypeName = "date")]
        public DateTime StaffBirthday { get; set; }

        public double StaffSalary { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
