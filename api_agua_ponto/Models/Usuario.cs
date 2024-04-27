using api_agua_ponto.Helper;

namespace api_agua_ponto.Models
{
    public class Usuario
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Peso { get; set; }
        public int Idade { get; set; }
        public DateTime RotinaAcorda { get; set; }
        public DateTime RotinaDorme { get; set; }
        public int MediaAgua {  get; set; }
        public List<Rotina> Rotinas { get; set; }

        public Usuario()
        {
            Email = String.Empty;
            Senha = String.Empty;
            Nome = String.Empty;
            Sobrenome = String.Empty;
            DataNascimento = DateTime.Now;
            Peso = 0;
            Idade = 0;
            RotinaAcorda = DateTime.Now;
            RotinaDorme = DateTime.Now;
            MediaAgua = 0;
            Rotinas = new List<Rotina>();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
            
    }
}
