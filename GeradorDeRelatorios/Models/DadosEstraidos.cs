namespace GeradorDeRelatorios.Models
{
    public class DadosEstraidos
    {
        public string data { get; set; }
        public string? dataCriacao { get; set; }
        public string? dataSaida { get; set; }

        public DadosEstraidos(string data, string? dataCriacao, string? dataSaida)
        {
            this.data = data;
            this.dataCriacao = dataCriacao;
            this.dataSaida = dataSaida;
        }
    }
}
