// **Задача 62**. Напишите программу, которая заполнит спирально массив 4 на 4. 
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07
public class Metods
{
  public static int Input(string msg)
  {
    Console.WriteLine(msg);
    return Convert.ToInt32(Console.ReadLine());
  }
  public static string Printing(int[,] matrix)
  {
    string result = String.Empty;
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
      for (int j = 0; j < columns; j++)
      {
        if (matrix[i, j] < 10) result += $"0{matrix[i, j]} ";
        else result += $"{matrix[i, j]} ";

      }
      result += "\n";
    }
    return result;
  }
  public static void FillSpiral(int[,] matrix, int rows, int columns, int startRow = 0, int startColumns = 0, int schet = 1)
  {
    for (int j = startColumns; j < columns - 1; j++)
    {
      matrix[startRow, j] = schet;
      schet++;
    }
    for (int i = startRow; i < rows - 1; i++)
    {
      matrix[i, columns - 1] = schet;
      schet++;
    }
    for (int m = columns - 1; m > startColumns; m--)
    {
      matrix[rows - 1, m] = schet;
      schet++;
    }
    for (int n = rows - 1; n > startRow; n--)
    {
      matrix[n, startColumns] = schet;
      schet++;
    }
    if (rows - 1 != 0 & columns - 1 != 0)
    {
      startRow++;
      startColumns++;
      rows--;
      columns--;
      FillSpiral(matrix, rows, columns, startRow, startColumns, schet);
    }
    else if (matrix.GetLength(0) % 2 == 1 && matrix.GetLength(0) == matrix.GetLength(1))
      matrix[matrix.GetLength(0) / 2, matrix.GetLength(1) / 2] = schet;
  }



  public static int[,] Create(int rows, int columns)
  {
    return new int[rows, columns];
  }

  public static void RunProg()
  {
    int rows = Input("Введите количество строк: ");
    int columns = Input("Введите количество столбцов: ");
    int[,] matrix = Create(rows, columns);
    FillSpiral(matrix, rows, columns);
    Console.WriteLine(Printing(matrix));
  }
}
