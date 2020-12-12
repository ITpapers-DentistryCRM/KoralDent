namespace Clinic.DAL.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Service")]
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            Registrations = new HashSet<Registration>();
            Registration_Service = new HashSet<Registration_Service>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceId { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceName { get; set; }

        [Required]
        [StringLength(200)]
        public string ServiceDescription { get; set; }

        public TimeSpan ServiceDuration { get; set; }

        public double ServicePrice { get; set; }

        public int SpecializationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration_Service> Registration_Service { get; set; }

        public virtual Specialization Specialization { get; set; }
    }
}
