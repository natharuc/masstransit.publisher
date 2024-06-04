namespace Publicador.Classes
{
    public class Message
    {
        public Contract Contract { get; set; }
        public string Body { get; set; }
        public bool HasContractType
        {
            get
            {
                return Contract?.Type != null;
            }
        }
    }
}
