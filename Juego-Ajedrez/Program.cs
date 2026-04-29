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
Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
Console.WriteLine("-_-          ¡Bienvenido al sistema!          -_-");
Console.WriteLine("-_-             Juego de Ajedrez              -_-");
Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
Console.WriteLine();