using System;
using System.Collections.Generic;

namespace Parcial02_BM101219_JP100320.Models;

public partial class Elecciones2019
{
    public int Id { get; set; }

    public string Departamento { get; set; } = null!;

    public string? Candidato { get; set; }

    public int? Votos { get; set; }
}
