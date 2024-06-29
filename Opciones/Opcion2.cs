using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Threading;
public class Opcion2
{

    public static void Iniciar()
    {
        var db = new CovidContext();
        Console.Clear();
        ASCII.Exportar();

        if (db.Personas != null && db.Procesos != null)
        {

            Console.WriteLine("Ingrese el numero de la cedula para exportar la persona.");
            Console.WriteLine("L. Listado");
            Console.WriteLine("R. Regresar");

            Persona? persona = null;
            bool bucle = true;

            while (persona == null && bucle == true)
            {
                var cedula = Herramientas.InputString("Ingrese aqui -> ", ConsoleColor.Cyan);
                if (cedula.ToLower().Trim() == "l")
                {
                    Console.WriteLine("Listado de Personas");
                    foreach (var item in db.Personas.ToList())
                    {
                        Console.WriteLine($"Id: {item.Id} | Cedula: {item.Cedula} | Nombre: {item.Nombre} | Apellido: {item.Apellido}");
                    }

                    Console.WriteLine("");
                    persona = db.Personas.Find(Herramientas.InputInt("Ingrese el id de la persona -> ", ConsoleColor.Cyan));
                }
                else if (cedula.ToLower().Trim() == "r")
                {
                    bucle = false;
                }
                else
                {
                    persona = db.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();
                }
            }

            if (persona != null && db.Personas != null)
            {
                
                var ListadoProcesos = db.Procesos.Where(x => x.Persona.Id == persona.Id)
                .Include(x => x.Vacuna).Include(x => x.Provincia).ToList();

                string dosis = "";
                int i = 0;

                Console.WriteLine("HTML Mostrandose");
                foreach (var item in ListadoProcesos)
                {
                    i++;
                    dosis += (@$"
                    <tr>
                    <td class='columna_izquierda'>Dosis {i}</td>
                    <td>{item.Provincia.Nombre}</td>
                    <td>{item.Vacuna.Nombre}</td>
                    <td td class='columna_derecha'>{item.Fecha.ToShortDateString()}</td>
                    </tr>
                ");
                }
                File.WriteAllText("index.html", HTML.estructura(persona.Nombre, persona.Apellido, persona.Edad, persona.Cedula, dosis));
                mostrar("index.html");

                void mostrar(string archivo)
                {
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = archivo;
                    System.Diagnostics.Process.Start(psi);
                }
            }
        }   
    }
}
