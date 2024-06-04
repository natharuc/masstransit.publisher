namespace Publicador
{
    internal class LocalConfiguration
    {
        public LocalConfiguration()
        {
        }

        public string DllFile { get; set; }
        public string Contract { get; set; }
        public string Json { get; set; }
        public string Queue { get; set; }
        public string ConnectionString { get; set; }
    }
}