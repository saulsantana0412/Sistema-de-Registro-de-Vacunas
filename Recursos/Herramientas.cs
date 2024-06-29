public class Herramientas
{
    public static string InputString(string solicitud, ConsoleColor color)
    {
        string text = "";

        do
        {
            Console.ForegroundColor = color;
            Console.Write(solicitud);
            Console.ResetColor();
            text = Console.ReadLine() ?? "";

            if (text == "" || text.Length == 0) { MensajeError("El campo no puede estar vacio"); }

        } while (text == "" || text.Length == 0);

        return text;
    }

    public static int InputInt(string solicitud, ConsoleColor color)
    {
        int num = 0;
        bool validacion = false;

        do
        {
            try
            {
                num = int.Parse(InputString(solicitud, color));
                validacion = true;

            }
            catch (System.FormatException)
            {
                MensajeError("Caracter invalido, ingrese un número");
            }
        } while (validacion == false);

        return num;

    }

    public static void Mensaje(string mensaje, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }

    public static void MensajeError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }

    public static void Continuar()
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("-> Presiona CUALQUIER TECLA para continuar <-");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }

}
