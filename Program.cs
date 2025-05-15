//Nomnre del autor del codigo: Jesus Augusto Chacon Corredor

namespace calculadora
{
    using System;

    // Clase base para la operación
    public class Operacion
    {
        // Declara un método virtual RealizarOperacion que acepta un arreglo de números de tipo double como operandos y devuelve un número de tipo double. Esta es la función que realizará la operación específica (suma, resta, multiplicación, división). Esta implementación por defecto devuelve 0 y será sobrescrita en las clases derivadas para cada operación específica.
        public virtual double RealizarOperacion(double[] operandos)
        {
            return 0; // Implementación por defecto, será sobrescrito en las clases derivadas
        }
    }

    //Clase para la operación de suma
    public class Suma : Operacion
    {

        // Sobreescribe el método RealizarOperacion de la clase base con la funcionalidad específica de esta clase.
        public override double RealizarOperacion(double[] operandos)
        {

            // Inicializa la variable resultado con 0.
            double resultado = 0;

            // Inicia un bucle foreach que recorre todos los elementos del array operandos.
            foreach (double operando in operandos)
            {

                // Suma el operando actual al resultado actual y asigna el resultado a la variable resultado.
                resultado += operando;
            }

            // Devuelve el resultado de la suma de todos los operandos.
            return resultado;
        }
    }

    // Clase para la operación de resta
    public class Resta : Operacion
    {

        // Sobreescribe el método RealizarOperacion de la clase base con la funcionalidad específica de esta clase.
        public override double RealizarOperacion(double[] operandos)
        {

            // Inicializa la variable resultado con el primer elemento del array operandos.
            double resultado = operandos[0];

            // Inicia un bucle for que comienza desde el segundo elemento del array operandos.
            for (int i = 1; i < operandos.Length; i++)
            {

                // Resta el operando actual al resultado actual y asigna el resultado a la variable resultado.
                resultado -= operandos[i];
            }

            // Devuelve el resultado de las restas.
            return resultado;
        }
    }

    // Clase para la operacion de multiplicacion
    public class Multiplicacion : Operacion
    {

        // Sobreescribe el método RealizarOperacion de la clase base con la funcionalidad específica de esta clase.
        public override double RealizarOperacion(double[] operandos)
        {

            // Inicializa la variable resultado con 1.
            double resultado = 1;

            // Inicia un bucle foreach que recorre todos los elementos del array operandos.
            foreach (double operando in operandos)
            {

                // Multiplica el resultado actual por el operando actual y asigna el resultado a la variable resultado.
                resultado *= operando;
            }

            // Devuelve el resultado de la multiplicación.
            return resultado;
        }
    }

    // Clase para la operación de división
    public class Division : Operacion
    {

        //Sobrescribe el método RealizarOperacion para la clase Division, implementando la operación de división. Verifica si hay al menos dos operandos y si alguno de ellos es cero, en cuyo caso lanza una excepción. Luego, realiza la división de los operandos sucesivos y devuelve el resultado.
        public override double RealizarOperacion(double[] operandos)
        {
            if (operandos.Length < 2)
            {
                throw new ArgumentException("La división requiere al menos dos operandos");
            }

            // Inicializa la variable resultado con el primer elemento del array operandos.
            double resultado = operandos[0];

            // Inicia un bucle que recorre todos los elementos del array operandos, empezando desde el segundo elemento.
            for (int i = 1; i < operandos.Length; i++)
            {

                // Comprueba si el operando actual es igual a cero.
                if (operandos[i] == 0)
                {

                    // Lanza una excepción si el operando actual es cero, indicando que no se puede dividir por cero.
                    throw new DivideByZeroException("No se puede dividir por cero");
                }

                // Realiza la división del resultado actual por el operando actual.
                resultado /= operandos[i];
            }

            // Devuelve el resultado de la división después de haber recorrido todos los operandos en el array operandos.
            return resultado;
        }
    }

    //Define la clase Program con su método principal Main, que es el punto de entrada del programa.
    class Program
    {
        static void Main(string[] args)
        {

            //Muestra un mensaje en la consola solicitando al usuario que ingrese el operador de la operación que desea realizar, y luego lee el primer carácter de la entrada del usuario.
            Console.WriteLine("Ingrese la operación a realizar (+, -, *, /):");
            char operador = Console.ReadLine()[0];

            //Muestra un mensaje en la consola solicitando al usuario que ingrese los operandos separados por espacios, luego lee la entrada del usuario, la divide por espacios y convierte cada parte en un número de punto flotante (double), almacenando los valores en un arreglo de operandos.
            Console.WriteLine("Ingrese los operandos separados por espacios:");
            string[] inputOperandos = Console.ReadLine().Split(' ');
            double[] operandos = Array.ConvertAll(inputOperandos, Double.Parse);


            //Utiliza un bloque switch para seleccionar una instancia de la clase de operación correspondiente según el operador ingresado por el usuario. Si el operador es +, crea una instancia de Suma; si es -, crea una instancia de Resta; si es *, crea una instancia de Multiplicacion; si es /, crea una instancia de Division. Si no coincide con ninguno de estos casos, muestra un mensaje de error y finaliza la ejecución del programa.

            // Declara una variable operacion de tipo Operacion.
            Operacion operacion;
            switch (operador)
            {

                // En caso de que el operador sea '+' suma:
                case '+':

                    // Asigna a la variable operacion una instancia de la clase Suma.
                    operacion = new Suma();

                    // break le da fin del bloque switch.
                    break;

                // En caso de que el operador sea '-' resta:
                case '-':

                    // Asigna a la variable operacion una instancia de la clase Resta.
                    operacion = new Resta();

                    // break le da fin del bloque switch.
                    break;

                // En caso de que el operador sea '*' multiplicar:    
                case '*':

                    // Asigna a la variable operacion una instancia de la clase Multiplicacion.
                    operacion = new Multiplicacion();

                    // break le da fin del bloque switch.
                    break;

                // En caso de que el operador sea '/':    
                case '/':

                    // Asigna a la variable operacion una instancia de la clase Division.
                    operacion = new Division();

                    // break le da fin del bloque switch.
                    break;

                // En caso de que el operador no sea ninguno de los anteriores:    
                default:

                    // Imprime un mensaje indicando que el operador es inválido.
                    Console.WriteLine("Operador inválido");

                    // Retorna, finalizando la ejecución del método actual.
                    return;
            }

            //utilizamos (try) para intenta realizar la operación seleccionada utilizando los operandos proporcionados. Si la operación se realiza con éxito, muestra el resultado en la consola. Si ocurre un error durante la operación, captura la excepción y muestra un mensaje de error en la consola.
            try
            {
                double resultado = operacion.RealizarOperacion(operandos);
                Console.WriteLine("El resultado es: " + resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}