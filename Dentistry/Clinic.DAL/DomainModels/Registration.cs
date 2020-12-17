namespace Clinic.DAL.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration()
        {
            Registration_Service = new HashSet<Registration_Service>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegistrationId { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        public TimeSpan RegistrationTime { get; set; }

        [StringLength(300)]
        public string RegistrationComment { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public int RegistrationStatusId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual RegistrationStatus RegistrationStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration_Service> Registration_Service { get; set; }
    }
}
