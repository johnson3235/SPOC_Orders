using DB_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repo_Layer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services_Layer.Custom_Validations
{
    using System.ComponentModel.DataAnnotations;
    // Adjust this namespace to match your project

    public class UniqueOrderNameAttribute : ValidationAttribute
    {
        private readonly ValidationModel _model;

        public UniqueOrderNameAttribute(ValidationModel model)
        {
            _model = model;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (DataDbContext)validationContext.GetService(typeof(DataDbContext));

            if (dbContext == null)
            {
                // Handle the error as needed, e.g., logging
                return ValidationResult.Success; // or handle the error as needed
            }

            var propertyName = "Name";
            var newValue = (string)value;

            switch (_model)
            {
                case ValidationModel.Order:
                    // Check uniqueness for the "Name" property of the "Order" model
                    var isUniqueOrderName = !dbContext.Order.Any(o => o.Name == newValue);

                    if (!isUniqueOrderName)
                    {
                        return new ValidationResult($"{propertyName} must be unique.");
                    }
                    break;

                case ValidationModel.Product:
                    // Check uniqueness for the "Name" property of the "Product" model
                    var isUniqueProductName = !dbContext.Products.Any(p => p.Name == newValue);

                    if (!isUniqueProductName)
                    {
                        return new ValidationResult($"{propertyName} must be unique.");
                    }
                    break;

                case ValidationModel.Branch:
                    // Check uniqueness for the "Name" property of the "Product" model
                    var isUniqueBranchName = !dbContext.Branches.Any(p => p.Name == newValue);

                    if (!isUniqueBranchName)
                    {
                        return new ValidationResult($"{propertyName} must be unique.");
                    }
                    break;

                case ValidationModel.Pharmacy:
                    // Check uniqueness for the "Name" property of the "Product" model
                    var isUniquePharmacyName = !dbContext.Pharmacies.Any(p => p.Name == newValue);

                    if (!isUniquePharmacyName)
                    {
                        return new ValidationResult($"{propertyName} must be unique.");
                    }
                    break;

                case ValidationModel.Distributor:
                    // Check uniqueness for the "Name" property of the "Product" model
                    var isUniqueDistributorName = !dbContext.Distributors.Any(p => p.Name == newValue);

                    if (!isUniqueDistributorName)
                    {
                        return new ValidationResult($"{propertyName} must be unique.");
                    }
                    break;
                case ValidationModel.Country:
                    // Check uniqueness for the "Name" property of the "Product" model
                    var isUniqueCountryName = !dbContext.Countries.Any(p => p.Name == newValue);

                    if (!isUniqueCountryName)
                    {
                        return new ValidationResult($"{propertyName} must be unique.");
                    }
                    break;
                case ValidationModel.Role:
                    // Check uniqueness for the "Name" property of the "Product" model
                    var isUniqueRoleName = !dbContext.Roles.Any(p => p.Name == newValue);

                    if (!isUniqueRoleName)
                    {
                        return new ValidationResult($"{propertyName} must be unique.");
                    }
                    break;

                default:
                    // Handle unsupported model types
                    return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }


    }
}