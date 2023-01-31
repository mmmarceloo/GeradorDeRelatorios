using Newtonsoft.Json;

namespace GeradorDeRelatorios.Models
{
    class Periodo
    {
        public string Id { get; set; }
        public string? date_create { get; set; }
        public string? date_remove { get; set; }


        public static List<Periodo> JsonDesserializar(string Json)
        {
            var x = JsonConvert.DeserializeObject<List<Periodo>>(Json);
            return x;
            
        }
    }
    
}
