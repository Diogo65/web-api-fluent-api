using System.Collections.Generic;

namespace WebApiVagas.Filters
{
    public class ResultadoValidacao
    {
        private string mensagem;
        public string Mensagem
        {
            get
            {
                return mensagem;
            }
        }

        private Dictionary<string, List<string>> erros;
        public Dictionary<string, List<string>> Erros
        {
            get
            {
                return erros;
            }
        }

        public ResultadoValidacao(string mensagem)
        {
            this.mensagem = mensagem;
        }

        public void AdicionarErro(string chave, string erro)
        {
            if (erros == null)
                erros = new Dictionary<string, List<string>>();

            if(!erros.ContainsKey(chave))
                erros[chave] = new List<string>();

            erros[chave].Add(erro);
        }
    }
}