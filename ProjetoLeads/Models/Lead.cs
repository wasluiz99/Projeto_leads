using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLeads.Models;

public partial class Lead
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Nome")]
    public string Nome { get; set; }
    [Required]
    [DisplayName("Telefone")]
    public string Telefone { get; set; }
    [Required]
    [DisplayName("E-mail")]
    public string Email { get; set; }
    [Required]
    [DisplayName("Curso interesse")]
    public int CursoInteresse { get; set; }
}
