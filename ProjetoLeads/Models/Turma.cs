using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProjetoLeads.Models;

public partial class Turma
{
    public int Id { get; set; }
    [DisplayName("Turma")]
    public string Descricao { get; set; }
    [DisplayName("Curso")]
    public int CursoId { get; set; }
}
