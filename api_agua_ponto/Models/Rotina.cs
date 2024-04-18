namespace api_agua_ponto.Models
{
    public class Rotina
    {
        public int? Id {  get; set; }
        public DateTime? Ingestao { get; set; }
        public int MlIngerido { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public Rotina()
        {
            Ingestao = DateTime.Now;
            MlIngerido = 0;
            UsuarioId = 0;
        }
    }
}
