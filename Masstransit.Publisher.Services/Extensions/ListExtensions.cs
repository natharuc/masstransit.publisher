namespace Masstransit.Publisher.Services.Extensions
{
    public static class ListExtensions
    {
        public static List<List<T>> Paginar<T>(this List<T> lista, int tamanhoPagina)
        {
            var paginas = new List<List<T>>();

            var pagina = new List<T>();

            foreach (var item in lista)
            {
                pagina.Add(item);

                if (pagina.Count == tamanhoPagina)
                {
                    paginas.Add(pagina);

                    pagina = new List<T>();
                }
            }

            if (pagina.Any())
            {
                paginas.Add(pagina);
            }

            return paginas;
        }

        public static List<List<T>> Page<T>(this IEnumerable<T> lista, int tamanhoPagina)
        {
            return lista.ToList().Paginar(tamanhoPagina);
        }
    }
}