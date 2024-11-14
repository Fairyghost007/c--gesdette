using gesdette15.Models;

namespace gesdette15.Service
{
    public interface IClientService
    {
        List<Client> FindAll();
        Client FindById(int id);
        void Save(Client client);
        void Delete(int id);
        void Update(Client client);

        Client? FindBySurname(string surnom);
       

    }
}