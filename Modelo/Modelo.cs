using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

class CovidContext : DbContext{

    public DbSet<Persona> Personas {get; set;}
    public DbSet<Vacuna> Vacunas {get; set;}
    public DbSet<Provincia> Provincias {get; set;}
    public DbSet<Proceso> Procesos {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=covid.db");
    }
}

public class Persona{

    public int Id {get; set;}
    public string Cedula {get; set;} ="";
    public string Nombre {get; set;} = "";
    public string Apellido {get; set;} ="";
    public int Edad {get; set;}
    public string Telefono {get; set;} ="";

}

public class Vacuna{

    public int Id {get; set;}
    public string Nombre {get; set;} ="";

}

public class Provincia{

    public int Id {get; set;}
    public string Nombre {get; set;} ="";

}

public class Proceso{

    public int Id {get; set;}
    public DateTime Fecha {get; set;}
    public Persona Persona {get; set;}
    public Vacuna Vacuna {get; set;}
    public Provincia Provincia {get; set;}

}