using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentYourMovie.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer's name is required.")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        [Minimum18YearsIfMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribeToNewsLetter { get; set; }


        //Membership Type
        
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}