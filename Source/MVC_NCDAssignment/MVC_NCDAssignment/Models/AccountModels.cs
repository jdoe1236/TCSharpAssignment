using MVC_NCDAssignment.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace MVC_NCDAssignment.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
    public class SearchInfoModel
    {
        [Display(Name = "Name")]
        [StringLength(SearchUtils.MAX_NAME_LENGTH, ErrorMessage = "The {0} must be from {2} to {1} characters long.", MinimumLength = 4)]
        public string Name { get; set; }

        //[Display(Name = "")]
        //public bool HasName { get; set; }


        [Display(Name = "Min")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Min age must be a number")]
        public byte? MinAge { get; set; }

        [Display(Name = "Max")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Max age must be a number")]
        public byte? MaxAge { get; set; }

        [Display(Name = "Female")]
        public bool CanBeFemale { get; set; }

        [Display(Name = "Male")]
        public bool CanBeMale { get; set; }

        [Display(Name = "Min")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Max age must be a number")]
        public short? MinHeight { get; set; }

        [Display(Name = "Max")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Max age must be a number")]
        public short? MaxHeight { get; set; }

        [Display(Name = "Min")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Max age must be a number")]
        public short? MinWeight { get; set; }

        [Display(Name = "Max")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Max age must be a number")]
        public short? MaxWeight { get; set; }

        [Display(Name = "Nationality")]
        [StringLength(SearchUtils.MAX_NATIONALITY_LENGTH, ErrorMessage = "The {0} must be from {2} to {1} characters long.", MinimumLength = 2)]
        public string Nationality { get; set; }
    }
}
