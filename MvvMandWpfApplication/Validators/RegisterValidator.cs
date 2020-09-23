using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;

using MvvMandWpfApplication.Models;

namespace MvvMandWpfApplication.Validators
{
    public class RegisterValidator : AbstractValidator<UsersDTO>
    {

        #region Validation Control for Register

        public RegisterValidator(UsersDTO user)
        {
            RuleFor(u => user.FirstName).NotEmpty().WithName("First Name");
            RuleFor(u => user.FirstName).Length(3, 50).WithMessage("Length of First Name invalid. It must be greater than 3 and less than 50 characters");
            RuleFor(u => user.FirstName).Matches(@"^[A-Za-zğüşıöçĞÜŞİÖÇ]{3,50}$").WithMessage("Invalid First Name"); // character length must be between 3 and 50


            RuleFor(u => user.LastName)
                .NotEmpty().WithName("Please specify a Last Name")
                .Length(3, 50).WithMessage("Length of Last Name invalid. It must be greater than 3 and less than 50 characters")
                .Matches(@"^[A-Za-zğüşıöçĞÜŞİÖÇ]{3,50}$").WithMessage("Invalid Last Name");

            RuleFor(u => user.Email).NotEmpty().WithMessage("Email address is required.")
                                    .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(u => user.Password).NotEmpty().WithMessage("Password must not be empty");
            RuleFor(u => user.Password).Length(8, 20).WithMessage("Password must be eight character at least.");
            RuleFor(u => user.PasswordConfirm).NotEmpty().WithMessage("Password Valid must not be empty");
            RuleFor(u => user.Password).Equal(u => user.PasswordConfirm).WithMessage("Password and Password Confirm must be equal.");

            RuleFor(u => user.UserName)
                .NotEmpty().WithMessage("Username must not be empty")
                .Length(4, 10).WithMessage("Length of the username invalid. It must be grater than 4 and less than 10 characters")
                .Matches(@"^[a-z0-9]{4,10}$").WithMessage("Invalid username");
        }

        #endregion


    }

}
