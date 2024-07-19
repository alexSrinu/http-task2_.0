using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace task_2._0.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[89]\d{9}$", ErrorMessage = "The mobile number must be 10 digits long and start with 8 or 9.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string CountryId { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Hobbies are required.")]
        public string Hobbies { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

       // public bool IsActive { get; set; }
    }


    //public class Register
    //{

    //    [Key]
    //    public int Id { get; set; }
    //    [Required(ErrorMessage = "VALID UserName")]
    //    public string Name { get; set; }
    //    [Required(ErrorMessage = "Password is required.")]
    //    [DataType(DataType.Password)]
    //    [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    //    [Display(Name = "Password")]
    //    public string Password { get; set; }

    //    [Required(ErrorMessage = "Confirm Password is required.")]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Confirm Password")]
    //    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    //    public string ConfirmPassword { get; set; }
    //    [Required]
    //    [RegularExpression(@"^[89]\d{9}$", ErrorMessage = "The mobile number must be 10 digits long and start with 8 or 9.")]
    //    [DataType(DataType.PhoneNumber)]

    //    public string Phone { get; set; }
    //    [Required(ErrorMessage = "Email address is required.")]
    //    [EmailAddress(ErrorMessage = "Invalid Email Address")]

    //    public string Email { get; set; }
    //    [Required(ErrorMessage = "SELECT COUNTRY NAME")]
    //    public string CountryId { get; set; }
    //    [Required(ErrorMessage = "must enter")]
    //    public string Gender { get; set; }
    //    [Required(ErrorMessage = "Must Select")]
    //    public string Hobbies { get; set; }
    //    [Display(Name = "Date of Birth")]
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime DateOfBirth { get; set; }

    //    public bool IsActive { get; set; }




    //    /*   public Register()
    //       {
    //           Hobbies = new List<Hobby>
    //           {
    //               new Hobby { Name = "Reading" },
    //               new Hobby { Name = "Traveling" },
    //               new Hobby { Name = "Cooking" },
    //               new Hobby { Name = "Sports" }
    //           };
    //       }


    //       public class Hobby
    //       {
    //           public string Name { get; set; }
    //           public bool IsSelected { get; set; }
    //       }*/

    //}

}