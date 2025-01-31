public class HTML{

    public static string estructura(string nombre, string apellido, int edad, string cedula, string dosis){

        String estructura =(@$"
        <!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <link rel='stylesheet' href='html/style.css'>
    <title>Tarjeta Vacunacion</title>
</head>
<body>

    <div class='tarjeta'>
        <div class='Encabezado'>
            <div class='imagenes'>
                <img src='html/recursos/Ministerio.png' width='170px'>
                <img src='html/recursos/Barra.png' width='150px' height='45px' class='barra'>
                <img src='html/recursos/PAI.png' width='100px'>
                <img src='html/recursos/Vacunate.png' width='100px'>
            </div>
            <div class='text'>
                <h1>VICEMINISTERIO DE SALUD COLECTIVA</h1>
                <h3>PROGRAMA AMPLIADO DE INMUNIZACIÓN</h3>
                <p>TARJETA DE VACUNACION COVID 19</p>
            </div>
        </div>
        <div class='datos_personales'>
            <h1>DATOS PERSONALES</h1>
            <table>
                <tr>
                    <td class='columna_titulo Arriba'>Nombre y Apellido</td>
                    <td class='columna_variable Arriba'>{nombre} {apellido}</td>
                </tr>
                <tr>
                    <td class='columna_titulo'>Edad</td>
                    <td class='columna_variable'>{edad}</td>
                </tr>
                <tr>
                    <td class='columna_titulo Abajo'>Documento Identidad</td>
                    <td class='columna_variable Abajo'>{cedula}</td>
                </tr>
            </table>

        </div>
        <div class='datos_vacunacion'>
            <h1>DATOS DE VACUNACIÓN</h1>
            <div class='tabla_vacunacion'>
            <table>
                <tr>
                    <th class='columna_izquierda'>Dosis</th>
                    <th>Lugar</th>
                    <th>Vacuna</th>
                    <th td class='columna_derecha'>Fecha</th>
                </tr>
                {dosis}
            </table>
        </div>
        </div>

    </div>
    
</body>
</html>");

        return estructura;
    }
}