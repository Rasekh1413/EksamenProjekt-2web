﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCZealand.Models;

[Table("LærerOgKompetenceAllokering")]
public partial class LærerOgKompetenceAllokering : IHarId
{
    [NotMapped]
    public int Id
    {
        get { return Lokaid; }
        set { Lokaid = value; }
    }

    [Key]
    [Column("LOKAid")]
    public int Lokaid { get; set; }

    [Column("LOKAidBeskrivelse")]
    [StringLength(250)]
    public string LokaidBeskrivelse { get; set; }

    [Column("LærerID")]
    public int? LærerId { get; set; }

    [Column("KompetenceID")]
    public int? KompetenceId { get; set; }

    [ForeignKey("KompetenceId")]
    [InverseProperty("LærerOgKompetenceAllokerings")]
    public virtual Kompetence Kompetence { get; set; }

    [ForeignKey("LærerId")]
    [InverseProperty("LærerOgKompetenceAllokerings")]
    public virtual Lærer Lærer { get; set; }
}