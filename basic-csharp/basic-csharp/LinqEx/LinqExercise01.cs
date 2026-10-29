using System.Globalization;

namespace basic_csharp.LinqEx;

public class LinqExercise01 : Exercise
{
    /*
     *Fazer um programa para ler um conjunto de produtos a partir de um
       arquivo em formato .csv (suponha que exista pelo menos um produto).
       Em seguida mostrar o preço médio dos produtos. Depois, mostrar os
       nomes, em ordem decrescente, dos produtos que possuem preço
       inferior ao preco médio.
     *
     */

    class Product
    {
        public string? Name { get; set; }
        public double Price { get; set; }
    }

    public override void ExecuteAction()
    {
        string sourceFilePath = Console.ReadLine();

        List<Product> products = new List<Product>();
        foreach (string line in File.ReadLines(sourceFilePath))
            products.Add(new Product
                { Name = line.Split(",")[0], Price = double.Parse(line.Split(",")[1], CultureInfo.InvariantCulture) });

        double avgPrice = products.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
        Console.WriteLine(avgPrice);
        foreach (var s in products.Where(p => p.Price < avgPrice).Select(p => p.Name).OrderByDescending(s => s))
            Console.WriteLine(s);
    }
}