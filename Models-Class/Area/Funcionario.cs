﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "Função Empregrado")]
        public string FuncaoEmpregado { get; set; }

        [Required]
        [Display(Name = "Número Empregado")]
        public int NumeroDeTrabalhador { get; set; }
    }
}
