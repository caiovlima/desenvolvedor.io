namespace NSE.Identidade.API.Extensions
{
    public class AppSettings
    {
        public string AutenticacaoUrl { get; set; }

        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
