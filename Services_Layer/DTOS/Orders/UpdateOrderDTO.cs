﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services_Layer.Custom_Validations;
using DB_Layer.Models;

namespace Services_Layer.DTOS.Orders
{
    public class UpdateOrderDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        [UniquePropertyForUpdateAttribute(ValidationModel.Order, nameof(Id))]
        public string Name { get; set; }

        [Required, MaxLength(255),MinLength(3)]
        public string Description { get; set; }


        [ExistsProperty(ValidationModel.Med_Rep)]
        public int MedRepId { get; set; }


        [ExistsProperty(ValidationModel.DM)]
        public int DMId { get; set; }


        [ExistsProperty(ValidationModel.Pharmacy)]
        public int PharmacyId { get; set; }


        [ExistsProperty(ValidationModel.Branch)]
        public int BranchId { get; set; }

        [ExistsProperty(ValidationModel.Country)]
        public int CountryId { get; set; }

        [Required]
        public virtual List<OrderProductsDTO> OrderProducts { get; set; }

    }
}
