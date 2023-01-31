namespace GeradorDeRelatorios.Models
{
    public class QuantidadeRemove
    {
        public string dataCreate { get; set; }
        public double? quantidadeEntrada { get; set; }
        public double? quantidadeSaida { get; set; }
        public string qtd0 { get; set; }
        public string qtd1 { get; set; }
        public string qtd2 { get; set; }
        public string qtd3 { get; set; }
        public string qtd4 { get; set; }
        public string qtd5 { get; set; }
        public string qtd6 { get; set; }
        public string qtd7 { get; set; }
        public string qtd8 { get; set; }
        public string qtd9 { get; set; }
        public string qtd10 { get; set; }
        public string qtd11 { get; set; }

        public QuantidadeRemove(string dataCreate, double? quantidadeEntrada, double? quantidadeSaida, string qtd0, string qtd1, string qtd2, string qtd3, string qtd4, string qtd5, string qtd6, string qtd7, string qtd8, string qtd9, string qtd10, string qtd11)
        {
            this.dataCreate = dataCreate;
            this.quantidadeEntrada = quantidadeEntrada;
            this.quantidadeSaida = quantidadeSaida;
            this.qtd0 = qtd0;
            this.qtd1 = qtd1;
            this.qtd2 = qtd2;
            this.qtd3 = qtd3;
            this.qtd4 = qtd4;
            this.qtd5 = qtd5;
            this.qtd6 = qtd6;
            this.qtd7 = qtd7;
            this.qtd8 = qtd8;
            this.qtd9 = qtd9;
            this.qtd10 = qtd10;
            this.qtd11 = qtd11;
        }
    }
}
