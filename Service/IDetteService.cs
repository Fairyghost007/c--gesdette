using gesdette15.Models;

namespace gesdette15.Service
{
    public interface IDetteService
    {
        List<Dette> FindAll();
        Dette FindById(int id);
        void Save(Dette dette);
        void Delete(int id);
        void Update(Dette dette);

    

    }
}