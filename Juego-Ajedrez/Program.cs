using System.Text;

string Password = "E$quizo1984";
string Usuario = "Koalas";
string UsuarioUsado = "";
string UserPassword = "";
bool login=false;

void TClear()
{
    Console.ReadKey();
    Console.Clear();
}

void MClear()
{
    Console.WriteLine();
    Console.WriteLine("Presione cualquier tecla para continuar...");
    Console.ReadKey();
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
    Console.Write($"Ingrese el usuario: ");
    UsuarioUsado = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine($"Intento {i + 1} de 3");
    Console.Write($"Ingrese la contraseña: ");
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
        Console.Write($"Datos incorrectos. Te quedan {3-i-1} de 3 intentos.");
       TClear();
    }
 
}
Console.Clear();
if (login == true)
{
    Console.WriteLine("El usuario y contraseña ingresados son correctos.\n\n¡Bienvenido!");
    MClear();
}
else if (login == false)
{

    Console.WriteLine("Intentos acabados. Acceso denegado.");
    Console.ReadKey();
}