using RentYourMovie.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentYourMovie.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer's name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Minimum18YearsIfMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribeToNewsLetter { get; set; }


        //Membership Type
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}