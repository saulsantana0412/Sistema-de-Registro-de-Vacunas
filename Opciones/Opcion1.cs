public class Opcion1
{
    public static void Iniciar()
    {
        
        var db = new CovidContext();
        var proceso = new Proceso();
        var persona = new Persona();
        Console.Clear();
        ASCII.Agregar();
        Console.WriteLine("REGISTRAR PERSONA");
        Console.WriteLine("");

        var cedula = Herramientas.InputString("Ingrese la cedula de la persona: ", ConsoleColor.Cyan);
        
        persona = db.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();

        if (persona == null)
        {
            persona = new Persona();
            persona.Cedula = cedula;
            persona.Nombre = Herramientas.InputString("Ingrese el nombre de la persona: ", ConsoleColor.Cyan);
            persona.Apellido = Herramientas.InputString($"Ingrese el apellido de {persona.Nombre}: ", ConsoleColor.Cyan);
            persona.Telefono = Herramientas.InputString($"Ingrese el telefono: ", ConsoleColor.Cyan);
            persona.Edad = Herramientas.InputInt("Ingrese la edad: ", ConsoleColor.Cyan);
            db.Personas.Add(persona);
            db.SaveChanges();
            persona = db.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();
        }
        proceso.Persona = persona;
        proceso.Fecha = DateTime.Now;


        Console.WriteLine("Listado de vacunas");
        foreach (var item in db.Vacunas.ToList())
        {
            Console.WriteLine($"{item.Id} ~ {item.Nombre}");
        }

        while (proceso.Vacuna == null)
        {
            var vacuna = db.Vacunas.Find(Herramientas.InputInt("Ingrese el id de la vacuna que se esta inyectando: ", ConsoleColor.Cyan));

            if (vacuna == null)
            {
                Herramientas.MensajeError("Esta Vacuna no existe");
            }
            else
            {
                proceso.Vacuna = vacuna;
            }
        }

        Console.WriteLine("Listado de provincias");
        foreach (var item in db.Provincias.ToList())
        {
            Console.WriteLine($"{item.Id} ~ {item.Nombre}");
        }


            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(proceso.Provincia);


        while (proceso.Provincia == null)
        {
            var provincia = db.Provincias.Find(Herramientas.InputInt("En que provincia se esta vacunando? ", ConsoleColor.Cyan));

            if (provincia == null)
            {
                Herramientas.MensajeError("Esta Provincia no existe");
            }
            else
            {
                proceso.Provincia = provincia;
            }

        }

        db.Procesos.Add(proceso);
        db.SaveChanges();

    }

}