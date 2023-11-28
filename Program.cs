using System;
using System.IO;

string cheminFichierCSV = $@"C:\\Users\\Utilisateur\\Desktop\\Solutions\\QuizzConsole\\QuestionsExample.csv";

if (File.Exists(cheminFichierCSV))
{
    string[] lignes = File.ReadAllLines(cheminFichierCSV);

    foreach (string ligne in lignes)
    {
        string[] colonnes = ligne.Split(';'); // Utilisation du point-virgule comme délimiteur

        // Ajoutez ces lignes pour déboguer
        Console.WriteLine($"Contenu de la ligne : {ligne}");
        //Console.WriteLine($"Nombre de colonnes : {colonnes.Length}");

        if (colonnes.Length == 3) // Correction du nombre attendu de colonnes
        {
            string question = colonnes[0];
            string reponses = colonnes[1];
            int reponseCorrecte = int.Parse(colonnes[2]);

            string[] optionsReponses = reponses.Split('/');

            Console.WriteLine($"Question : {question}");

            for (int i = 0; i < optionsReponses.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {optionsReponses[i]}");
            }

            Console.Write("Votre réponse : ");
            int reponseUtilisateur = int.Parse(Console.ReadLine());

            if (reponseUtilisateur == reponseCorrecte)
            {
                Console.WriteLine("Correct !\n");
            }
            else
            {
                Console.WriteLine($"Incorrect. La réponse correcte est : {reponseCorrecte}\n");
            }
        }
        else
        {
            Console.WriteLine("La ligne du fichier CSV n'a pas le bon format.\n");
        }
    }
}
else
{
    Console.WriteLine("Le fichier CSV n'existe pas.");
}

Console.ReadLine(); // Attendez que l'utilisateur appuie sur "Entrée" avant de fermer la console
