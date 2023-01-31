namespace GeradorDeRelatorios.Models
{
    public class DadosEstraidos
    {
        public string data { get; set; }
        public int? quantidade { get; set; }
        public string? dataSaida { get; set; }
        public string? retencao1 { get; set; }
        public string? retencao2 { get; set; }
        public string? retencao3 { get; set; }
        public string? retencao4 { get; set; }
        public string? retencao5 { get; set; }
        public string? retencao6 { get; set; }
        public string? retencao7 { get; set; }
        public string? retencao8 { get; set; }
        public string? retencao9 { get; set; }
        public string? retencao10 { get; set; }
        public string? retencao11 { get; set; }
        public string? retencao12 { get; set; }

        public DadosEstraidos(string data, int? quantidade=0, string? retencao1="", string? retencao2="", string? retencao3 = "", string? retencao4 = "", string? retencao5 = "", string? retencao6 = "", string? retencao7 = "", string? retencao8 = "", string? retencao9 = "", string? retencao10 = "", string? retencao11 = "", string? retencao12 = "")
        {
            this.data = data;
            this.quantidade = quantidade;
            
            this.retencao1 = retencao1;
            this.retencao2 = retencao2;
            this.retencao3 = retencao3;
            this.retencao4 = retencao4;
            this.retencao5 = retencao5;
            this.retencao6 = retencao6;
            this.retencao7 = retencao7;
            this.retencao8 = retencao8;
            this.retencao9 = retencao9;
            this.retencao10 = retencao10;
            this.retencao11 = retencao11;
            this.retencao12 = retencao12;
        }
    }
}
