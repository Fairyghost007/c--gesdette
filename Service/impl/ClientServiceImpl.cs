using Cours.Models;
using Cours.Repository;

namespace Cours.Service.Impl
{

    public class ClientServiceImpl : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientServiceImpl(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public List<Client> FindAll()
        {
            return clientRepository.SelectAll();
        }

        public Client FindById(int id)
        {
            return clientRepository.SelectById(id)!;
        }

        public void Save(Client client)
        {
            try
            {
                clientService.Save(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving client: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void Delete(int id)
        {
            clientRepository.Delete(id);
        }

        public void Update(Client client)
        {
            clientRepository.Update(client);
        }

        public Client? FindBySurname(string surnom)
        {
            return clientRepository.FindBySurname(surnom);
        }
    }

}