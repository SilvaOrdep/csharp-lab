using System.Globalization;

namespace basic_csharp.SystemFiles;

public class FilesExercise01 : Exercise
{
    /*
     *Fazer um programa para ler o caminho de um arquivo .csv
       contendo os dados de itens vendidos. Cada item possui um
       nome, preco unitario e quantidade, separados por virgula. Vocé
       deve gerar um novo arquivo chamado "summary.csv", localizado
       em uma subpasta chamada "out" a partir da pasta original do
       arquivo de origem, contendo apenas o nome ‘eo valor total para
       aquele item (prego unitario multiplicado pela quantidade),
       conforme exemplo.
     *
     */
    public override void ExecuteAction()
    {
        string sourceFile = @"SystemFiles/SourceFile.csv";
        using (StreamReader sr = File.OpenText(sourceFile))
        {
            try
            {
                string sourceFolderPath = Path.GetDirectoryName(sourceFile);

                string targetFolderPath = Path.Combine(sourceFolderPath, "out");
                Directory.CreateDirectory(targetFolderPath);

                string targetFile = Path.Combine(targetFolderPath, "summary.csv");
                
                while (!sr.EndOfStream)
                {
                    using (StreamWriter sw =
                           File.AppendText(targetFile))
                    {
                        string[] lineProductInfo = sr.ReadLine().Split(",");
                        double total = double.Parse(lineProductInfo[1], CultureInfo.InvariantCulture) *
                                       double.Parse(lineProductInfo[2], CultureInfo.InvariantCulture);
                        sw.WriteLine($"{lineProductInfo[0]},{total.ToString().Replace(",", ".")}");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}