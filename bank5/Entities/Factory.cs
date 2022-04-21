﻿using System.ComponentModel.DataAnnotations;

namespace bank5.Entities;

public class Factory
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? FactoryType { get; set; }
    
    public string? UNP { get; set; }
    
    public int? BankId { get; set; }
    public string? UrlAdress { get; set; }
    
    public bool IsBank { get; set; }

}