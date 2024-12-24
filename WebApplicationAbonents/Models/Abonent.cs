using System;
using System.Collections.Generic;

namespace WebApplicationAbonents.Models;

public partial class Abonent
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Surname { get; set; }

    public string? Pochta { get; set; }

    public string? Patronymic { get; set; }
}
