
using Lansoy.RG.DAL.DAL;

namespace Lansoy.RG.Cli

{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Je n'ai pas réussi à faire mieux pour l'appel de commande :
                // .\Lansoy.RG.Cli.exe - Import [fichier] [racine]\TP_Jordan_LANSOY\Lansoy.RG.Cli\bin\Debug\net8.0
                if (args.Length > 1 && args[0].ToLower() == "-import")
                {
                    var cheminFichier = args[1];
                    var dbContext = new LansoyDbContext(); 
                    var serviceImport = new ImportEspion(dbContext);
                    serviceImport.ImporterEspions(cheminFichier);
                    Console.WriteLine("Importation réussie.");
                }
                else
                {   
                   
                    Console.WriteLine("Argument '-Import' suivi d'un chemin de fichier est requis.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur est survenue : {ex.Message}");
            }
        }
    }
}
