using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    class Pessoa
    {
        //Encapsulamento = Deixar as variáveis privadas
        private long CPF;
        private string nome;
        private string endereco;
        private string telefone;
        private DateTime dtNascimento;
        private string login;
        private string senha;
        private string situacao;//Ativo ou Inativo
        private string posicao;//Atendente ou Administrador ou Cliente

        //Método construtor
        public Pessoa()
        {
            ModificarCPF = 0;
            ModificarNome = "";
            ModificarEndereco = "";
            ModificarTelefone = "";
            ModificarDtNascimento = new DateTime();//"00/00/0000 00:00:00"
            ModificarLogin = "";
            ModificarSenha = "";
            ModificarSituacao = "";
            ModificarPosicao = "";
        }//fim do construtor

        //Método Modificadores = Gets e Sets
        public long ModificarCPF
        {
            get { return this.CPF; }
            set { this.CPF = value; }
        }//fim do modificar
        public string ModificarNome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }//fim do modificar
        public string ModificarEndereco
        {
            get { return this.endereco; }
            set { this.endereco = value; }
        }//fim do modificar
        public string ModificarTelefone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }//fim do modificar

        public DateTime ModificarDtNascimento
        {
            get { return this.dtNascimento; }
            set { this.dtNascimento = value; }
        }//fim do modificar

        public string ModificarLogin
        {
            get { return this.login; }
            set { this.login = value; }
        }//fim do modificar

        public string ModificarSenha
        {
            get { return this.senha; }
            set { this.senha = value; }
        }//fim do modificar

        public string ModificarSituacao
        {
            get { return this.situacao; }
            set { this.situacao = value; }
        }//fim do modificar

        public string ModificarPosicao
        {
            get { return this.posicao; }
            set { this.posicao = value; }
        }//fim do modificar

        //Métodos - CRUD
        public void Cadastrar(long CPF, string nome, string telefone, string endereco,
            DateTime dtNascimento, string login, string senha, string posicao)
        {
            ModificarCPF = CPF;
            ModificarNome = nome;
            ModificarTelefone = telefone;
            ModificarEndereco = endereco;
            ModificarDtNascimento = dtNascimento;
            ModificarLogin = login;
            ModificarSenha = senha;
            ModificarSituacao = "Ativo";
            ModificarPosicao = posicao;
        }//fim do método

        public string ConsultarIndividual(long CPF)
        {
            string consulta = "";
            if (ModificarCPF == CPF)
            {
                consulta = "\nNome: " + ModificarNome +
                                  "\nTelefone: " + ModificarTelefone +
                                  "\nEndereço: " + ModificarEndereco +
                                  "\nData de Nascimento: " + ModificarDtNascimento +
                                  "\nLogin: " + ModificarLogin +
                                  "\nSenha: " + ModificarSenha +
                                  "\nSituação: " + ModificarSituacao +
                                  "\nPosição: " + ModificarPosicao;
            }
            else
            {
                consulta = "Número de CPF não é válido!";
            }
            return consulta;
        }//fim do método

        public void AtualizarNome(long CPF, string nome)
        {
            if(ModificarCPF == CPF)
            {
                ModificarNome = nome;
            }
        }//fim do método

        public void AtualizarTelefone(long CPF, string telefone)
        {
            if (ModificarCPF == CPF)
            {
                ModificarTelefone = telefone;
            }
        }//fim do método

        public void AtualizarEndereco(long CPF, string endereco)
        {
            if (ModificarCPF == CPF)
            {
                ModificarEndereco = endereco;
            }
        }//fim do método
        public void AtualizarDataNascimento(long CPF, DateTime dtNascimento)
        {
            if (ModificarCPF == CPF)
            {
                ModificarDtNascimento = dtNascimento;
            }
        }//fim do método

        public void AtualizarSenha(long CPF, string senha)
        {
            if (ModificarCPF == CPF)
            {
                ModificarSenha = senha;
            }
        }//fim do método

        public void AtualizarSituacao(long CPF, string situacao)
        {
            if (ModificarCPF == CPF)
            {
                ModificarSituacao = situacao;
            }
        }//fim do método

        public void AtualizarPosicao(long CPF, string posicao)
        {
            if (ModificarCPF == CPF)
            {
                ModificarPosicao = posicao;
            }
        }//fim do método

        public void Excluir(long CPF)
        {
            if (ModificarCPF == CPF)
            {
                ModificarSituacao = "Inativo";
            }
        }//fim do método
    }//fim da classe
}//fim do projeto
