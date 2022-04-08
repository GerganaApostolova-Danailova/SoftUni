﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
            this.Diagnoses = new HashSet<Diagnose>();
            this.Visitations = new HashSet<Visitation>();
        }
        [Key]
        public int PatientId { get; set; }

        [MaxLength(50), Required]
        public string FirstName  { get; set; }


        [MaxLength(50), Required]
        public string LastName  { get; set; }

        [MaxLength(250), Required]
        public string Address  { get; set; }

        [MaxLength(80)]
        public string Email  { get; set; }

        public bool HasInsurance { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
