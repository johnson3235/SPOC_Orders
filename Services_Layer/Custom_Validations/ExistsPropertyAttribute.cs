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
    using static Azure.Core.HttpHeader;

    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

    // Adjust this namespace to match your project

    public class ExistsPropertyAttribute : ValidationAttribute
    {
        private readonly ValidationModel _model;

        public ExistsPropertyAttribute(ValidationModel model)
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
            if (value == null || !(value is int Id))
            {
                return new ValidationResult("Invalid Type ID.");
            }
            bool exists = false;

            switch (_model)
            {
                case ValidationModel.Order:
                    exists = dbContext.Set<Order>().Any(o => o.Id == Id);
                    break;

                case ValidationModel.Product:
                    exists = dbContext.Set<Product>().Any(p => p.Id == Id);
                    break;

                case ValidationModel.Role:
                    exists = dbContext.Set<Role>().Any(p => p.Id == Id);
                    break;

                case ValidationModel.Distributor:
                    exists = dbContext.Set<Distributor>().Any(p => p.ID == Id);
                    break;

                case ValidationModel.Pharmacy:
                    exists = dbContext.Set<Pharmacy>().Any(p => p.Id == Id);
                    break;

                case ValidationModel.Branch:
                    exists = dbContext.Set<Branch>().Any(p => p.Id == Id);
                    break;

                case ValidationModel.Country:
                    exists = dbContext.Set<Country>().Any(p => p.Id == Id);
                    break;

                case ValidationModel.Med_Rep:
                    CustomUser user = dbContext.Set<CustomUser>().Find(Id);
                    if (user == null || user.RoleId == 1)
                    {
                        exists = false;
                    }
                    exists = true;
                    break;

                case ValidationModel.DM:
                    CustomUser user2 = dbContext.Set<CustomUser>().Find(Id);
                    if (user2 == null || user2.RoleId == 2)
                    {
                        exists = false;
                    }
                    exists = true;
                    break;
                // Add cases for other models as needed

                default:
                    // Handle unsupported model types
                    return ValidationResult.Success;
            }

            if (!exists)
            {
                return new ValidationResult($"The specified {validationContext.MemberName} does not exist.");
            }

            return ValidationResult.Success;
        }
    }

}