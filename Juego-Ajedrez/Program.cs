using System.Runtime.CompilerServices;
using System.Text;

string Password = "E$quizo1984";
string Usuario = "Koalas";
string UsuarioUsado = "";
string UserPassword = "";
int intentos = 3;
bool login=false;

void TClear()
{
    Console.ReadKey();
    Console.Clear();
}

void MClear()
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Presione cualquier tecla para continuar: ");
    Console.ReadKey();
    Console.ResetColor();
    Console.Clear();
}

string LeerContra()
{
    StringBuilder sb = new StringBuilder();
    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.Enter)
        {
            break;
        }

        if (key.Key == ConsoleKey.Backspace && sb.Length > 0)
        {
           
            sb.Remove(sb.Length - 1, 1);
            
            Console.Write("\b \b");
        }
        else if (!char.IsControl(key.KeyChar))
        {
            sb.Append(key.KeyChar);
            Console.Write("*");
        }
    }
    return sb.ToString();
}

for (int i = 0; i < 3; i++)
{
    Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
    Console.WriteLine("-_-                 SISTEMA DE ACCESO                 -_-");
    Console.WriteLine("-_-                 Juego de Ajedrez                  -_-");
    Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
    Console.WriteLine();
    Console.Write($"Por favor, ingrese el usuario, intento {intentos}: ");
    UsuarioUsado = Console.ReadLine();
    Console.WriteLine();
    Console.Write($"Por favor, ingrese la contraseña, intento {intentos}: ");
    UserPassword = LeerContra();
    Console.WriteLine();
    Console.WriteLine();

    if (UsuarioUsado == Usuario && UserPassword == Password)
    {
        login = true; 
        break;
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
        Console.WriteLine("-_-                  DATOS INCORRECTOS                -_-");
        Console.WriteLine($"-_-            Te quedan {3-i-1} de 3 intentos              -_-");
        Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
        Console.WriteLine();
        Console.Write("Presione cualquier letra para continuar: ");
        intentos--;
       TClear();
        Console.ResetColor();
    }
 
}
Console.Clear();
if (login == true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
    Console.WriteLine("-_-                   DATOS CORRECTOS                 -_-");
    Console.WriteLine("-_-  El usuario y contraseña ingresados son correctos -_-");
    Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
    Console.ResetColor();
    MClear();
}
else if (login == false)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Intentos acabados. Acceso denegado.\nIngrese cualquier letra para salir del programa: ");
    Console.ReadKey();
    Console.ResetColor();
    return;
}
int opcion = 0;
bool validacion = true;
do
{
    Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
    Console.WriteLine("-_-          ¡Bienvenido al sistema!          -_-");
    Console.WriteLine("-_-             Juego de Ajedrez              -_-");
    Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
    Console.WriteLine();
    Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
    Console.WriteLine("-_-              JUEGO DE TABLERO             -_-");
    Console.WriteLine("-_-            1. Iniciar Partida             -_-");
    Console.WriteLine("-_-            2. Ver reglas del Juego        -_-");
    Console.WriteLine("-_-            3. Ver puntaje más alto        -_-");
    Console.WriteLine("-_-            4. Salir                       -_-");
    Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
    Console.WriteLine();
    Console.Write("Seleccione una opción: ");
    validacion = int.TryParse(Console.ReadLine(), out opcion);
    while (!validacion || opcion < 1 || opcion > 4)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Opción no válida. Por favor, seleccione una opción del 1 al 4: ");
        Console.ResetColor();
        validacion = int.TryParse(Console.ReadLine(), out opcion);
    }
    switch (opcion)
    {
        case 1:
            Console.Clear();

            break;
        case 2:
            Console.Clear();
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("-_-              Reglas del Juego             -_-");
            Console.WriteLine("-_-                 De Ajedrez                -_-");
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.Write("Presione cualquier tecla para continuar: ");
            Console.ReadKey();
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("-_-              Puntaje más alto             -_-");
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.Write("Presione cualquier tecla para continuar: ");
            Console.ReadKey();
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("Saliendo del programa...");
            break;

    }
} while (opcion!=4);