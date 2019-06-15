using System;


namespace Number3
{
    class Program
    {
        static void Main(string[] args)
        {
            double X = 0;
            double Y = 0;
            //Вводим X, Y с клавиатуры
            getInput(out X, out Y);
            double u = 0;
            if (Parabola(X, Y) && ExpMinus(X, Y) && ExpPlus(X, Y))
            {
                u = X + Y;
                Console.WriteLine("Точка находится внутри области");
            }
            else
            {
                Console.WriteLine("Точка находится за пределами области");
                u = X - Y;
            }
            Console.WriteLine("U=" + u);
            Console.ReadLine();
        }

        /// <summary>
        /// Метод проверяющий находится ли точка выше параболы или на ней
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        static bool Parabola(double X, double Y)
        {
            // Вычислим нижню границу Y для заданного X
            double y_ = X * X;
            // если заданный Y больше равен, чем нижняя граница, то возвращаем true
            if (Y >= y_)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Метод проверяющий находится ли точка ниже экспоненты
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        static bool ExpPlus(double X, double Y)
        {
            // вычислим верхнюю границу для заданного x
            double _y = Math.Exp(X);
            // если заданный Y меньше или равен, чем нижняя граница, то true
            if (Y <= _y)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Метод проверяющий нааходится ли точка ниже отрицательной экспоненты
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        static bool ExpMinus(double X, double Y)
        {
            return ExpPlus(-X, Y);
        }



        /// <summary>
        /// Метод ввода X, Y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void getInput(out double x, out double y)
        {
            // Ввод Х
            Console.Write("Введите X:");
            x = CheckInputDouble();
            Console.Write("Введите Y:");
            y = CheckInputDouble();
        }

        /// <summary>
        /// Метод контроля правильности ввода для double
        /// </summary>
        /// <returns>значение double</returns>
        static double CheckInputDouble()
        {
            double result = 0;
            do
            {
                string inp = Console.ReadLine();
                // если случайно поставили точку вместо запятой, заменим ее
                inp = inp.Replace(".", ",");
                // пробуем разобрать введенный 
                if (Double.TryParse(inp, out result))
                    break;
                Console.WriteLine("Ошибка ввода! Повторите ввод!!");
            }
            while (true);
            return result;
        }
    }
}
