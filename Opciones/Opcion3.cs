public class Opcion3
{

    public static void Iniciar()
    {
        Console.Clear();
        bool continuar = true;
        while (continuar == true)
        {

            Console.WriteLine(@"
Que desea CONFIGURAR?

    1. Vacuna.                                                                 
    2. Provincia.
    R. Regresar.

");
            string opc = Herramientas.InputString("Escriba la opcion -> ", ConsoleColor.Cyan);
            switch (opc.ToLower())
            {
                case "1": GestionVacuna(); break;
                case "2": GestionProvincia(); break;
                case "r":
                    continuar = false;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine($"La opcion ( {opc} ) no existe, digite una opcion valida");
                    Herramientas.Continuar();
                    break;
            }
        }
    }

    static void GestionVacuna()
    {
        var db = new CovidContext();
        bool continuar = true;
        while (continuar == true)
        {
            Console.Clear();
            Console.WriteLine(@"
Gestion de Vacuna

    1. Agregar.                                                                 
    2. Editar.
    3. Eliminar.
    4. Listar.
    R. Regresar.

");
            var vacuna = new Vacuna();

            string opc = Herramientas.InputString("Escriba la opcion -> ", ConsoleColor.Cyan);

            if (db.Vacunas != null)
            {
                switch (opc.ToLower())
                {
                    case "1":
                        Console.Clear();
                        ASCII.Agregar();
                        Console.WriteLine("AGREGAR VACUNA");
                        vacuna.Nombre = Herramientas.InputString("Ingrese el nombre de la vacuna: ", ConsoleColor.Cyan);
                        db.Vacunas.Add(vacuna);
                        db.SaveChanges();
                        Herramientas.Mensaje("Vacuna Agregada Correctamente",ConsoleColor.Green);
                        Herramientas.Continuar();
                        break;
                    case "2":
                        Console.Clear();
                        ASCII.Modificar();
                        Console.WriteLine("EDITAR VACUNA");
                        listar();

                        var editar = db.Vacunas.Find(Herramientas.InputInt("Ingrese el id de la vacuna: ", ConsoleColor.Cyan));

                        if (editar == null)
                        {
                            Herramientas.MensajeError("Esta vacuna no existe");
                            Herramientas.Continuar();
                        }
                        else
                        {
                            Console.WriteLine($"Editar Vacuna {editar.Nombre}");
                            editar.Nombre = Herramientas.InputString($"Ingrese el nuevo nombre de la vacuna ({editar.Nombre})", ConsoleColor.Cyan);
                            db.SaveChanges();
                            Herramientas.Mensaje("Vacuna Editada Correctamente",ConsoleColor.Green);
                            Herramientas.Continuar();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        ASCII.Eliminar();
                        Console.WriteLine("ELIMINAR VACUNA");
                        Console.WriteLine("");
                        listar();
                        var eliminar = db.Vacunas.Find(Herramientas.InputInt("Ingrese el id de la vacuna: ", ConsoleColor.Cyan));

                        if (eliminar == null)
                        {
                            Console.WriteLine("");
                            Herramientas.MensajeError("Esta vacuna no existe");
                            Herramientas.Continuar();
                        }
                        else
                        {
                            db.Vacunas.Remove(eliminar);
                            db.SaveChanges();
                            Herramientas.Mensaje($"Vacuna ({eliminar.Nombre}) Eliminada",ConsoleColor.Green);
                            Herramientas.Continuar();
                        }

                        break;
                    case "4":
                    ASCII.Listar();
                        listar();
                        Herramientas.Continuar();
                        break;
                    case "r":
                        continuar = false;
                        Console.Clear();
                        break;
                    default:
                        Herramientas.MensajeError($"La opcion ( {opc} ) no existe, digite una opcion valida");
                        Herramientas.Continuar();
                        break;
                }
            }
        }

        void listar()
        {
            Console.WriteLine("Estas son las vacunas existentes:");
            Console.WriteLine("");

            foreach (var item in db.Vacunas.ToList())
            {
                Console.WriteLine($"{item.Id}. {item.Nombre}");
            }
        }
    }

    static void GestionProvincia()
    {
        var db = new CovidContext();
        Console.Clear();
        bool continuar = true;
        while (continuar == true)
        {

            Console.WriteLine(@"
Gestion de Provincias

    1. Agregar.                                                                 
    2. Editar.
    3. Eliminar.
    4. Listar.
    R. Regresar.

");
            var provincia = new Provincia();

            string opc = Herramientas.InputString("Escriba la opcion -> ", ConsoleColor.Cyan);

            if (db.Provincias != null)
            {
                switch (opc.ToLower())
                {
                    case "1":
                        Console.Clear();
                        ASCII.Agregar();
                        Console.WriteLine("AGREGAR PROVINCIA");
                        Console.WriteLine("");
                        provincia.Nombre = Herramientas.InputString("Ingrese el nombre de la Provincia: ", ConsoleColor.Cyan);
                        db.Provincias.Add(provincia);
                        Console.WriteLine("");
                        db.SaveChanges();
                        Herramientas.Mensaje($"Provincia {provincia.Nombre} agregada",ConsoleColor.Green);
                        break;
                    case "2":
                        Console.Clear();
                        ASCII.Modificar();
                        Console.WriteLine("EDITAR PROVINCIA");
                        Console.WriteLine("");
                        listar();

                        var editar = db.Provincias.Find(Herramientas.InputInt("Ingrese el id de la provincia: ", ConsoleColor.Cyan));

                        if (editar == null)
                        {
                            Console.WriteLine("");
                            Herramientas.MensajeError("Esta Provincia no existe");
                            Herramientas.Continuar();
                        }
                        else
                        {
                            Console.WriteLine($"Editar Provincia {editar.Nombre}");
                            Console.WriteLine("");
                            editar.Nombre = Herramientas.InputString($"Ingrese el nuevo nombre de la provincia ({editar.Nombre})", ConsoleColor.Cyan);
                            db.SaveChanges();
                            Herramientas.Mensaje("Vacuna Editada Correctamente",ConsoleColor.Green);
                            Herramientas.Continuar();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        ASCII.Eliminar();
                        Console.WriteLine("ELIMINAR PROVINCIA");
                        Console.WriteLine("");
                        listar();
                        var eliminar = db.Provincias.Find(Herramientas.InputInt("Ingrese el id de la provincia: ", ConsoleColor.Cyan));

                        if (eliminar == null)
                        {Console.WriteLine("");
                            Herramientas.MensajeError("Esta provincia no existe");
                            Herramientas.Continuar();
                        }
                        else
                        {
                            db.Provincias.Remove(eliminar);
                            db.SaveChanges();
                            Console.WriteLine("");
                            Herramientas.Mensaje($"Provincia ({eliminar.Nombre}) Eliminada",ConsoleColor.Green);
                            Herramientas.Continuar();
                        }

                        break;
                    case "4":
                    ASCII.Listar();
                        listar();
                        break;
                    case "r":
                        continuar = false;
                        Console.Clear();
                        break;
                    default:
                        Herramientas.MensajeError($"La opcion ( {opc} ) no existe, digite una opcion valida");
                        Herramientas.Continuar();
                        break;
                }
            }

            void listar()
            {   
                Console.WriteLine("Estas son las provincias: ");
                foreach (var item in db.Provincias.ToList())
                {
                    Console.WriteLine($"{item.Id}. {item.Nombre}");
                }
            }
        }
    }

}