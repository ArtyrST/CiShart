using System.ComponentModel.DataAnnotations;

namespace ArraysDz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            const int size = 5;
            int even = 0, odd = 0, unique = 0;

            int[] arr = new int[size] { 1, 6, 1, 4, 8 };

            for (int i = 0; i < size; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    even++;
                }
                else odd++;
                for (int j = i; j < size; j++)
                {
                    if (arr[j] != arr[i]) { unique++; }
                    else if (arr[j] == arr[i]) { unique--; }
                }
            }
            Console.WriteLine($"Unique: {unique} , Even: {even}, Odd: {odd}");
            //2
            Console.Write("Type a digit : ");
            int digit = int.Parse(Console.ReadLine());
            Console.WriteLine();
            foreach (int i in arr)
            {
                if (i < digit)
                {
                    Console.Write($"|{i}| ");
                }

            }
            Console.WriteLine();
            //3
            //            Оголосити одновимірний(5 елементів) масив з назвою
            //A i двовимірний масив(3 рядки, 4 стовпці) дробових чисел
            //з назвою B.Заповнити одновимірний масив А числами,
            //введеними з клавіатури користувачем, а двовимірний
            //масив В — випадковими числами за допомогою циклів.
            //Вивести на екран значення масивів: масиву А — в один
            //рядок, масиву В — у вигляді матриці.
            //Знайти у даних
            //масивах загальний максимальний елемент,
            //мінімальний
            //елемент,
            //загальну суму усіх елементів,
            //загальний добуток
            //усіх елементів,
            //суму парних елементів масиву А,
            //суму
            //непарних стовпців масиву В.
            float max_zag, min_zag, sum_zag = 0, dob_zag = 1, A_even_sum = 0, B_odd_sum = 0; 
            int[] A = new int[5];
            float[,] B = new float[3,4];
            Random rand = new Random();
            max_zag = A[0];
            
            for (int i = 0; i < 5; i++)
            {
                
                A[i] = int.Parse(Console.ReadLine());
                
                
            }
            min_zag = A[0];
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"|{A[i]}| ");
                if (max_zag < A[i])
                {
                    max_zag = A[i];
                }
                if (A[i] < min_zag)
                {
                    min_zag = A[i];
                }
                sum_zag += A[i];
                dob_zag *= A[i];
                if (A[i] % 2 == 0)
                {
                    A_even_sum += A[i];
                }
            }
            Console.WriteLine();
            for (int i = 0;i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i,j] = (float)(rand.NextDouble() * 100);
                    Console.Write($"|{B[i,j]}| ");
                    if (max_zag < B[i,j])
                    {
                        max_zag = B[i,j];
                    }
                    if (B[i,j] < min_zag)
                    {
                        min_zag = B[i,j];
                    }
                    sum_zag += B[i,j];
                    dob_zag *= B[i,j];
                    if ((j+1) % 2 != 0)
                    {
                        B_odd_sum += B[i,j];
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine($"Максимальне загальне число: {max_zag}, Мінімальне загальне число: {min_zag}, Загальна сума: {sum_zag}, Загальний добуток: {dob_zag}, Сума парних в А: {A_even_sum}, Сума непарних стовпців В: {B_odd_sum}");
            //4
            int[,] array_matrix = new int[5, 5];
            int summ = 0;
            int mat_min, mat_max;
            int min_index_i = 0, min_index_j = 0;
            int max_index_i = 0, max_index_j = 0;
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0;j < 5; j++)
                {
                    array_matrix[i, j] = rand.Next(-100, 100);
                }
            }
            
            mat_min = array_matrix[0, 0];
            mat_max = array_matrix[0, 0];
            for (int i = 0;i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (array_matrix[i,j] < mat_min)
                    {
                        mat_min = array_matrix[i,j];
                        min_index_i = i;
                        min_index_j = j;
                    }
                    if (array_matrix[i,j] > mat_max)
                    {
                        mat_max = array_matrix[i,j];
                        max_index_i = i;
                        max_index_j = j;
                    }
                }
            }
                if ((min_index_i > max_index_i) && (min_index_j > max_index_j))
                {
                    for (int i = 0; i < max_index_i + 1; i++)
                    {
                        for (int j = 0; j < max_index_j + 1; j++) {
                        summ += array_matrix[i, j];
                        }
                    }
                    for (int i = min_index_i; i < array_matrix.GetLength(0); i++)
                    {
                        for (int j = min_index_j; j < array_matrix.GetLength(1); j++)
                        {
                            summ += array_matrix[i, j];
                        }
                    }
                }
            else
            {
                for(int i = min_index_i;i < max_index_i; i++)
                {
                    for (int j = min_index_j; j < max_index_j; j++)
                    {
                        summ += array_matrix[i, j];
                    }
                }
            }
            for(int i = 0; i < array_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < array_matrix.GetLength(1); j++)
                {
                    Console.Write($"|{array_matrix[i, j]}|  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Сума вийшла: {summ} , Min: {mat_min}, Max: {mat_max}");
                
            
        }
    }
}
