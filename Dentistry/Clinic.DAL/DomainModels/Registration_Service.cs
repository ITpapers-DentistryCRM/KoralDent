namespace Clinic.DAL.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registration_Service
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Registration_ServiceId { get; set; }

        public int RegistrationId { get; set; }

        public int ServiceId { get; set; }

        public virtual Registration Registration { get; set; }

        public virtual Service Service { get; set; }
    }
}
