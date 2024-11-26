using RumoAutoQuery.services;
using System;

namespace RumoAutoQuery
{
    internal class Program
    {
        private static readonly string _input = "C:\\Users\\dctti\\Documents\\projects\\project-rumo-auto-query\\input";
        private static readonly string _output = "C:\\Users\\dctti\\Documents\\projects\\project-rumo-auto-query\\output"
        private static readonly string _columnName = "Chave";
        static void Main(string[] args)
        {
            Console.WriteLine("Começando a rotina RumoAutoQuery...");
            FileService fileService = new FileService(_input, _output, _columnName);
            DatabaseService databaseService = new DatabaseService();

            var columnValues = fileService.ReadFiles();

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
