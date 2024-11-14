using Cours.Core;
using Cours.Enum;
using Cours.Repository;
using Cours.Repository.Impl;

namespace Cours.Core.Factory
{
    public static class ClientFactory
    {
        public static IClientRepository? CreateClientRepository(Persistence type, Database dbType)
        {
            IClientRepository? clientRepository;
            
            // Dapper-based Client Repository logic
            switch (type)
            {
                case Persistence.DATABASE:
                    switch (dbType)
                    {
                        case Database.MYSQL:
                            clientRepository = new ClientRepositoryDapperImpl(new DataBaseConnection(dbType));
                            break;

                        case Database.POSTGRESQL:
                            clientRepository = new ClientRepositoryDapperImpl(new DataBaseConnection(dbType));
                            break;

                        default:
                            clientRepository = null;
                            break;
                    }
                    break;

                case Persistence.LIST:
                    clientRepository = new ClientRepositoryListImpl();
                    break;

                default:
                    clientRepository = null;
                    break;
            }
            return clientRepository;
        }
    }
}
