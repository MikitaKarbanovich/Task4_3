using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace Task4_3
{
    public class Matrix
    {
        public string Path { get; set; }
        public double[,] FirstMatrix { get; set; }
        public double[,] SecondMatrix { get; set; }
        public double[,] ResultMatrix { get; set; }
        public int ResultMatrixRows { get; set; }
        public int ResultMatrixCols { get; set; }

        public Matrix()
        {
            this.Path = ConfigurationManager.AppSettings["path"];
        }

        public void ReadFromFile()
        {
            int indexOfSecondMatrix = 0;
            List<string> lines = new List<string>();
            string[] readText = File.ReadAllLines(this.Path);
            for (int index = 0; index < readText.Length; index++)
            {
                string s = readText[index];
                if (s == "")
                {
                    indexOfSecondMatrix = index + 1;
                    break;
                }
                lines.Add(s.Trim());
                Console.WriteLine(s);
            }
            string[] numbers = lines[0].Split(' ');
            int rows = lines.Count;
            int columns = numbers.Length;
            this.ResultMatrixRows = rows;
            this.FirstMatrix = new double[rows, columns];
            int j = 0;
            int i = 0;
            foreach (var row in lines)
            {
                foreach (var col in row.Trim().Split(' '))
                {
                    this.FirstMatrix[i, j] = double.Parse(col.Trim());
                    j++;
                }
                j = 0;
                i++;
            }
            Console.WriteLine();
            lines = new List<string>(); ;
            for (int h = indexOfSecondMatrix; h < readText.Length; h++)
            {
                string s = readText[h];
                lines.Add(s.Trim());
                Console.WriteLine(s);
            }
            numbers = lines[0].Split(' ');
            rows = lines.Count;
            columns = numbers.Length;
            this.ResultMatrixCols = columns;
            this.SecondMatrix = new double[rows, columns];
            j = 0;
            i = 0;
            foreach (var row in lines)
            {
                foreach (var col in row.Trim().Split(' '))
                {
                    this.SecondMatrix[i, j] = double.Parse(col.Trim());
                    j++;
                }
                j = 0;
                i++;
            }
            Console.WriteLine();
        }
        public void Multiplay()
        {
            if (FirstMatrix.GetLength(1) == SecondMatrix.GetLength(0))
            {
                ResultMatrix = new double[FirstMatrix.GetLength(0), SecondMatrix.GetLength(1)];
                for (int i = 0; i < ResultMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < ResultMatrix.GetLength(1); j++)
                    {
                        ResultMatrix[i, j] = 0;
                        for (int k = 0; k < FirstMatrix.GetLength(1); k++)
                            ResultMatrix[i, j] = ResultMatrix[i, j] + FirstMatrix[i, k] * SecondMatrix[k, j];
                    }
                }
            }
            else
            {
                Console.WriteLine("\n Number of columns in First Matrix should be equal to Number of rows in Second Matrix.");
                Console.WriteLine("\n Please re-enter correct dimensions.");
                Environment.Exit(-1);
            }
        }

        public void ReusltOutput()
        {
            Console.WriteLine("Result of multiplication: ");
            for (int i = 0; i < this.ResultMatrixRows; i++)
            {
                for (int j = 0; j < this.ResultMatrixCols; j++)
                {
                    Console.Write($"{ResultMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
