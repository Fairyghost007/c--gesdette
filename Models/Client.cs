namespace Cours.Models
{
    public class Client
    {
        public int Id { get;  set; }
        public string? Surnom { get; set; }
        public string? Telephone { get; set; }
        public string? Adresse { get; set; }

        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }

        public List<Dette> Dettes { get; } = new List<Dette>();

        private static int count;

        public Client(string surnom, string telephone, string adresse)
        {
            Surnom = surnom ?? throw new ArgumentNullException(nameof(surnom));
            Telephone = telephone ?? throw new ArgumentNullException(nameof(telephone));
            Adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));

            count++;
            Id = count;
            CreateAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
        }

        public void AddDette(Dette dette)
        {
            Dettes.Add(dette);
            dette.Id = Dettes.Count;
            dette.Client = this;
        }

        public override string ToString() => $"Client[Id={Id}, Surnom='{Surnom}', Telephone='{Telephone}', Adresse='{Adresse}']";

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            Client client = (Client)obj;
            return Id == client.Id && Surnom == client.Surnom && Telephone == client.Telephone && Adresse == client.Adresse;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Surnom, Telephone, Adresse);

        public void SetCreateAt(DateTime date) => CreateAt = date;
        public void SetUpdateAt(DateTime date) => UpdateAt = date;
    }
}
