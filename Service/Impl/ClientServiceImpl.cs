using gesdette15.Models;
using gesdette15.Repository;

namespace gesdette15.Service.Impl
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
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client object cannot be null");
            }

            try
            {
                clientRepository.Insert(client);
                Console.WriteLine("Client saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving client: {ex.Message}");
                throw;
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