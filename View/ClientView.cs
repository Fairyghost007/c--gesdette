using gesdette15.Models;

namespace gesdette15.View
{
    public abstract class ClientView
    {
        public static void ListClients(List<Client> clients)
        {
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }

        public static void ListDetteClient(Client client)
        {
            if (client.Dettes != null)
            {
                foreach (var dette in client.Dettes)
                {
                    Console.WriteLine(dette);
                }
            }
            else
            {
                Console.WriteLine("No dettes available for this client.");
            }
        }

        public static Client CreateClient()
        {
            Console.Write("Surnom : ");
            string surnom = Console.ReadLine() ?? string.Empty;
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine() ?? string.Empty;
            Console.Write("Adresse : ");
            string adresse = Console.ReadLine() ?? string.Empty;

            Client client = new() { Surnom = surnom, Telephone = telephone, Adresse = adresse };

            // Ajout de la dette
            while (true)
            {
                Console.Write("Voulez-vous ajouter une dette à ce client ? (o/n) ");
                string answer = Console.ReadLine()?.ToLower() ?? "n";
                
                if (answer == "o")
                {
                    float montant;
                    while (true)
                    {
                        Console.Write("Montant de la dette : ");
                        if (float.TryParse(Console.ReadLine(), out montant) && montant > 0)
                        {
                            Dette dette = new() { Montant = montant };
                            client.AddDette(dette);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Montant invalide. Merci de saisir un montant positif.");
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            return client;
        }

        public static void UpdateClient(Client client)
        {
            Console.Write("Nouveau surnom : ");
            client.Surnom = Console.ReadLine() ?? client.Surnom;

            Console.Write("Nouveau téléphone : ");
            client.Telephone = Console.ReadLine() ?? client.Telephone;

            Console.Write("Nouvelle adresse : ");
            client.Adresse = Console.ReadLine() ?? client.Adresse;

            Console.WriteLine("Client modifié!");
        }

        public static int DeleteClient()
        {
            Console.Write("Voulez-vous supprimer un client ? (o/n) ");
            string answer = Console.ReadLine()?.ToLower() ?? "n";
            if (answer == "o")
            {
                Console.Write("Id du client à supprimer : ");
                if (int.TryParse(Console.ReadLine(), out int clientId))
                {
                    return clientId;
                }
                Console.WriteLine("Invalid ID. No client deleted.");
            }
            return 0;
        }

        public static int SaisirId()
        {
            Console.Write("Id du client ? ");
            if (int.TryParse(Console.ReadLine(), out int clientId))
            {
                return clientId;
            }
            Console.WriteLine("Invalid ID.");
            return 0;
        }
    }
}
