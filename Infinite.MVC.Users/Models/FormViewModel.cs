using System;
using System.ComponentModel.DataAnnotations;

namespace Infinite.MVC.Users.Models
{
    public class FormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Provide FirstName")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Provide LastName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Provide FatherName")]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Please Provide MotherName")]
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }
        [Required(ErrorMessage = "Please Provide Valid EmailID")]
       
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please Provide Valid Mobile Number")]
     
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Provide Gender")]
      
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Provide Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please Provide Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Provide City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Provide State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please Provide Qualification")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Please Provide EntranceTestScore")]
        public double EntranceTestScore { get; set; }
    }
}
