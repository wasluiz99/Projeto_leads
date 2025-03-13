using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProjetoLeads.Models;

public partial class Aluno
{
    public int Id { get; set; }
    [DisplayName("Nº Matricula")]
    public int CodigoMatricula { get; set; }

    public string Nome { get; set; }

    public string Telefone { get; set; }
    [DisplayName("E-mail")]
    public string Email { get; set; }
    [DisplayName("Curso")]
    public int CursoId { get; set; }
    [DisplayName("Turma")]
    public int TurmaId { get; set; }
    [DisplayName("Data Cadastro")]
    public DateTime DataCadastro { get; set; }
}
