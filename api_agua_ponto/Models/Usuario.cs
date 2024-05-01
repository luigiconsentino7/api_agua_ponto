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
        public string DataNascimento { get; set; }
        public double Peso { get; set; }
        public int Idade { get; set; }
        public double Altura { get; set; }
        public string RotinaAcorda { get; set; }
        public string RotinaDorme { get; set; }
        public int MediaAgua {  get; set; }
        public List<Rotina> Rotinas { get; set; }

        public Usuario()
        {
            Email = String.Empty;
            Senha = String.Empty;
            Nome = String.Empty;
            Sobrenome = String.Empty;
            DataNascimento = String.Empty;
            Peso = 0;
            Idade = 0;
            Altura = 0;
            RotinaAcorda = String.Empty;
            RotinaDorme = String.Empty;
            MediaAgua = 0;
            Rotinas = new List<Rotina>();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
            
    }
}
