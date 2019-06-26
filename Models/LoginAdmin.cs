using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace EatAp.Models {
public class LoginAdmin
{
    
    [Required]
    public string Email {get; set;}
    [Required]
    public string Password { get; set; }
}

}