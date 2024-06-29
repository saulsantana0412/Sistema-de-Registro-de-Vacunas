
bool cont = true;

while(cont == true)
{
    Console.Clear();
    ASCII.inicio();
    Console.WriteLine(@"   
PROGRAMA PARA REGISTRAR LOS PROCESOS DE VACUNACION DE LAS PERSONAS VACUNADAS

    1. Registrar
    2. Exportar
    3. Configurar
    X. Salir

");

    string opc = Herramientas.InputString("Escriba la opcion -> ", ConsoleColor.Cyan);
    switch (opc.ToLower())
    {
        case "1": Opcion1.Iniciar(); break;
        case "2": Opcion2.Iniciar(); break;
        case "3": Opcion3.Iniciar(); break;
        case "x": 
        cont = false; 
        ASCII.Despedida();
            break;
        default:
        Console.WriteLine($"La opcion ( {opc} ) no existe, digite una opcion valida");
        Herramientas.Continuar();
            break;
    }
}