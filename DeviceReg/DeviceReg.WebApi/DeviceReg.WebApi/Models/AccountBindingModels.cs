using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DeviceReg.WebApi.Models
{
    // Modelle, die als Parameter für AccountController-Aktionen verwendet werden.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "Externes Zugriffstoken")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Aktuelles Kennwort")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mindestens {2} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Neues Kennwort")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Neues Kennwort bestätigen")]
        [Compare("NewPassword", ErrorMessage = "Das neue Kennwort stimmt nicht mit dem Bestätigungskennwort überein.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "E-Mail")]
        public string User { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mindestens {2} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Kennwort")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Kennwort bestätigen")]
        [Compare("Password", ErrorMessage = "Das Kennwort stimmt nicht mit dem Bestätigungskennwort überein.")]
        public string ConfirmPassword { get; set; }

        public GenderType Gender { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public LanguageType Language { get; set; }

        public string Phone { get; set; }

        public IndustryFamilyType Industry_Family { get; set; }

        public string Industry_Type { get; set; }

        public string Company { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
        public LanguageType Preferred_Language { get; internal set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Anmeldeanbieter")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Anbieterschlüssel")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mindestens {2} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Neues Kennwort")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Neues Kennwort bestätigen")]
        [Compare("NewPassword", ErrorMessage = "Das neue Kennwort stimmt nicht mit dem Bestätigungskennwort überein.")]
        public string ConfirmPassword { get; set; }
    }

    #region IdentityCustomization
    public class EmailConfirmationBindingModel
    {
        public string ConfirmationHash { get; set; }
    }

    public class ResetPasswordBindingModel
    {
        public string UserEmail { get; set; }
        public string SecretAnswer { get; set; }
    }



    #endregion
}
