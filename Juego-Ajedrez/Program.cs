using System.Runtime.CompilerServices;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_Ajedrez
{
    internal class Program
    {
        static string Password = "E$quizo1984";
        static string Usuario = "Koalas";
        static string UsuarioUsado = "";
        static string UserPassword = "";
        static int intentos = 3;
        static bool login = false;

        public class Jugador
        {
            public string nombre {  get; set; }
            public string color { get; set; }
            public bool turno { get; set; }
            public int puntaje { get; private set; }

            public Jugador(string nombre1, string color)
            {
                this.nombre=nombre1;
                puntaje = 0;
                turno = true;
            }

            public void SumarPuntos(int puntos)
            {
                puntaje += puntos;
            }

            public void MostrarEstado()
            {
                Console.WriteLine($"Jugador: {nombre} | Color: {color}");
            }
        }

        public abstract class Pieza
        {
            public string Equipo { get; set; }
            public string Simbolo { get;  set; }
            public Pieza(string equipo) => Equipo = equipo;
            public abstract bool MovimientoValido(int fO, int cO, int FD, int CD, Pieza[,] tablero);
        }

        public class Rey : Pieza
        {
            public Rey(string equipo) : base(equipo) => Simbolo = equipo == "J1" ? "S1" : "S2";

            public override bool MovimientoValido(int fO, int cO, int fD, int cD, Pieza[,] tablero)
            {
                int dir = Equipo == "J1" ? 1 : -1;
                if (cD == cO && fD == fO + dir && tablero[fD, cD] == null) return true;

                if (Math.Abs(cD - cO) == 1 && fD == fO + dir && tablero[fD, cD] != null) return true;

                return false;
            }

        }

        public class Torre : Pieza
        {
            public Torre(string equipo) : base(equipo) => Simbolo = equipo == "J1" ? "T1" : "T2";

            public override bool MovimientoValido(int fO, int cO, int fD, int cD, Pieza[,] tablero)
            {
                if (fO != fD && cO != cD)
                {
                    return false;
                }
                if (fO == fD)
                {
                    int paso = cO < cD ? 1 : -1;
                    for (int c = cO + paso; c != cD; c += paso)
                        if (tablero[fO, c] != null) return false;
                }
                else
                {
                    int paso = fO < fD ? 1 : -1;
                    for (int f = fO + paso; f != fD; f += paso)
                        if (tablero[f, cO] != null) return false;
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
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
                    Console.WriteLine($"-_-            Te quedan {3 - i - 1} de 3 intentos              -_-");
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
                Console.Clear();
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
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Opción no válida.\nPor favor, seleccione una opción del 1 al 4: ");
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
                        Console.WriteLine();
                        Console.WriteLine("-_-_-_-_-_-_-_-  PIEZAS POR JUGADOR  -_-_-_-_-_-_-");
                        Console.WriteLine("   Rey      ->  x1");
                        Console.WriteLine("   Torre    ->  x2");
                        Console.WriteLine("   Soldado  ->  x4");
                        Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                        Console.WriteLine();
                        Console.WriteLine("-_-_-_-_-_-_-_-_-  MOVIMIENTOS  -_-_-_-_-_-_-_-_-");
                        Console.WriteLine("   Rey     : Una casilla en cualquier direccion.");
                        Console.WriteLine("   Torre   : Linea recta, no salta piezas.");
                        Console.WriteLine("   Soldado : Avanza una, ataca diagonal,");
                        Console.WriteLine("             no puede retroceder.");
                        Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                        Console.WriteLine();
                        Console.WriteLine("-_-_-_-_-_-_-_-  ATAQUE Y VICTORIA  -_-_-_-_-_-_-");
                        Console.WriteLine("   Moverse a casilla rival -> elimina esa pieza.");
                        Console.WriteLine("   Ganas si: Capturas al Rey rival.");
                        Console.WriteLine("   Ganas si: Eliminas todas las piezas del rival.");
                        Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                        Console.WriteLine();
                        Console.WriteLine("-_-_-_-_-_-_-_-_-_-  PROHIBIDO  -_-_-_-_-_-_-_-_-");
                        Console.WriteLine("   Salirse del tablero.");
                        Console.WriteLine("   Mover piezas del rival.");
                        Console.WriteLine("   Ir a casilla propia ocupada.");
                        Console.WriteLine("   Torre no puede atravesar piezas.");
                        Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                        Console.WriteLine();
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
            } while (opcion != 4);
        }
    }
}