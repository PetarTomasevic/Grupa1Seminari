﻿using System;
using System.Collections.Generic;

namespace Seminar2HelgaAbramovic.Models;

public partial class Gradovi
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public string Postanskibroj { get; set; } = null!;

    public int IdDrzave { get; set; }

    public virtual ICollection<Adrese> Adreses { get; } = new List<Adrese>();

    public virtual Drzave? IdDrzaveNavigation { get; set; } = null!;
}
