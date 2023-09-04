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
using System;

using System.Reflection;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services_Layer.DTOS.Orders;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Branches;
using Services_Layer.DTOS.Products;

namespace Services_Layer.Custom_Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniquePropertyForUpdateAttribute : ValidationAttribute
    {
        private readonly ValidationModel _model;
        private readonly string _idPropertyName;

        public UniquePropertyForUpdateAttribute(ValidationModel model, string idPropertyName)
        {
            _model = model;
            _idPropertyName = idPropertyName;
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
                    if (validationContext.ObjectInstance is UpdateOrderDTO orderDto)
                    {
                        // Get the value of the specified Id property
                        var entityId = (int)validationContext.ObjectType.GetProperty(_idPropertyName)?.GetValue(orderDto);

                        // Check uniqueness for the "Name" property of the "Order" model
                        var isUniqueOrderName = !dbContext.Order.Any(o => o.Name == newValue && o.Id != entityId);

                        if (!isUniqueOrderName)
                        {
                            return new ValidationResult($"{propertyName} must be unique.");
                        }
                    }
                    break;

                case ValidationModel.Product:
                    if (validationContext.ObjectInstance is UpdateProductDTO product)
                    {
                        // Get the value of the specified Id property
                        var entityId = (int)validationContext.ObjectType.GetProperty(_idPropertyName)?.GetValue(product);

                        // Check uniqueness for the "Name" property of the "Order" model
                        var isUniqueOrderName = !dbContext.Products.Any(o => o.Name == newValue && o.Id != entityId);

                        if (!isUniqueOrderName)
                        {
                            return new ValidationResult($"{propertyName} must be unique.");
                        }
                    }
                    break;

                case ValidationModel.Country:
                    if (validationContext.ObjectInstance is UpdateCountryDTO Country)
                    {
                        // Get the value of the specified Id property
                        var entityId = (int)validationContext.ObjectType.GetProperty(_idPropertyName)?.GetValue(Country);

                        // Check uniqueness for the "Name" property of the "Order" model
                        var isUniqueOrderName = !dbContext.Countries.Any(o => o.Name == newValue && o.Id != entityId);

                        if (!isUniqueOrderName)
                        {
                            return new ValidationResult($"{propertyName} must be unique.");
                        }
                    }
                    break;

                case ValidationModel.Distributor:
                    if (validationContext.ObjectInstance is UpdateDistributorDTO Distributor)
                    {
                        // Get the value of the specified Id property
                        var entityId = (int)validationContext.ObjectType.GetProperty(_idPropertyName)?.GetValue(Distributor);

                        // Check uniqueness for the "Name" property of the "Order" model
                        var isUniqueOrderName = !dbContext.Distributors.Any(o => o.Name == newValue && o.ID != entityId);

                        if (!isUniqueOrderName)
                        {
                            return new ValidationResult($"{propertyName} must be unique.");
                        }
                    }
                    break;


                case ValidationModel.Role:
                    if (validationContext.ObjectInstance is UpdateRoleDTO Role)
                    {
                        // Get the value of the specified Id property
                        var entityId = (int)validationContext.ObjectType.GetProperty(_idPropertyName)?.GetValue(Role);

                        
                        var isUniqueRoleName = !dbContext.Roles.Any(o => o.Name == newValue && o.Id != entityId);

                        if (!isUniqueRoleName)
                        {
                            return new ValidationResult($"{propertyName} must be unique.");
                        }
                    }
                    break;

                case ValidationModel.Pharmacy:
                    if (validationContext.ObjectInstance is UpdatePharmacyDTO Pharmacy)
                    {
                        // Get the value of the specified Id property
                        var entityId = (int)validationContext.ObjectType.GetProperty(_idPropertyName)?.GetValue(Pharmacy);


                        var isUniqueRoleName = !dbContext.Pharmacies.Any(o => o.Name == newValue && o.Id != entityId);

                        if (!isUniqueRoleName)
                        {
                            return new ValidationResult($"{propertyName} must be unique.");
                        }
                    }
                    break;

                case ValidationModel.Branch:
                    if (validationContext.ObjectInstance is UpdateBranchDTO Branch)
                    {
                        // Get the value of the specified Id property
                        var entityId = (int)validationContext.ObjectType.GetProperty(_idPropertyName)?.GetValue(Branch);


                        var isUniqueRoleName = !dbContext.Branches.Any(o => o.Name == newValue && o.Id != entityId);

                        if (!isUniqueRoleName)
                        {
                            return new ValidationResult($"{propertyName} must be unique.");
                        }
                    }
                    break;

                // Handle other models similarly

                default:
                    // Handle unsupported model types
                    return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }
}
