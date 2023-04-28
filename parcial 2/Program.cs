
int[,] tablero = new int[5, 5];

void paso1_crear_tablero()
{
    for (int f = 0; f < tablero.GetLength(0); f++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            tablero[f, c] = 0;
        }
    }
}

void paso2_colocar_barcos()
{
    asignar_posicion_aleatoria(1);
    asignar_posicion_aleatoria(1);
    asignar_posicion_aleatoria(1);
    asignar_posicion_aleatoria(1);
}

void paso3_colocar_submarinos()
{
    asignar_posicion_aleatoria(-1);
    asignar_posicion_aleatoria(-1);
    asignar_posicion_aleatoria(-1);
    asignar_posicion_aleatoria(-1);
}

void paso4_imprimir_tablero()
{
    string caracter_imprimir = "";
    for (int f = 0; f < tablero.GetLength(0); f++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            switch (tablero[f, c])
            {
                case 0:
                    caracter_imprimir = "-";
                    break;
                case 1:
                    caracter_imprimir = "-";
                    break;
                case -1:
                    caracter_imprimir = "-";
                    break;
                case -2:
                    caracter_imprimir = "°";
                    break;
            }
            Console.Write(caracter_imprimir + " ");
        }
        Console.WriteLine();
    }
}

void paso5_ingreso_cordenadas()
{
    int fila, columna = 0;
    int barcos_destruidos = 0; 
    int num_barcos = 4; // numero de barcos 
    Console.Clear();
    do
    {
        Console.Write("ingresa la primera coordenada (fila) : ");
        fila = Convert.ToInt32(Console.ReadLine());
        Console.Write("ingresa la segunda coordenada  (columna): ");
        columna = Convert.ToInt32(Console.ReadLine());
        if (tablero[fila, columna] == 1)
        {
            Console.Beep();
            tablero[fila, columna] = -2;
            Console.WriteLine("BAM, DERIBASTE UNA NAVE ENEMIGA");
            barcos_destruidos++; // aumenta el contador de barcos 
            if (barcos_destruidos == num_barcos) 
            {
                Console.WriteLine("JUEGO TERMINADO, EXCELENTE TRABAJO");
                break; // termina el juego
            }
            Thread.Sleep(3000); // 3 segundos
        }
        else if (tablero[fila, columna] == -1)
        {
            Console.Beep();
            tablero[fila, columna] = -2;
            Console.WriteLine("KABOOM!!!, EXTERMINASTE UN SUBMARINO ENEMIGO");
            Thread.Sleep(3000); // 3 segundos 
        }
        else
        {
            tablero[fila, columna] = -2;
        }
        Console.Clear();
        paso4_imprimir_tablero();
    } while (true);
}

void asignar_posicion_aleatoria(int valor)
{
    Random rnd = new Random();
    int fila = 0;
    int columna = 0;
    do
    {
        fila = rnd.Next(0, 5);
        columna = rnd.Next(0, 5);
    } while (tablero[fila, columna] != 0);
    tablero[fila, columna] = valor;
}

paso1_crear_tablero();
paso2_colocar_barcos();
paso3_colocar_submarinos();
paso4_imprimir_tablero();
paso5_ingreso_cordenadas();