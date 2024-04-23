using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Livraria
{
    class DAOPessoa
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public long[] CPF;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public DateTime[] dtNascimento;
        public string[] login;
        public string[] senha;
        public string[] situacao;
        public string[] posicao;
        public int i;
        public int contador;
        public string msg;
        //Construtor
        public DAOPessoa()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=livrariaTI20N;Uid=root;Password=");
            try
            {
                conexao.Open();//Abrir a conexão
                Console.WriteLine("Conectado!");//Teste
            }
            catch(Exception erro)
            {
                Console.WriteLine("Algo deu errado!\n\n" + erro);
                conexao.Close();//Fechar a conexão com o banco
            }
        }//fim do construtor

        public void Inserir(long CPF, string nome, string telefone, string endereco, 
                           DateTime dtNascimento, string login, string senha, 
                           string situacao, string posicao)
        {
            try
            {
                //Declarei as variáveis e preparei o comando
                dados = $"('{CPF}','{nome}','{telefone}','{endereco}','{dtNascimento}','{login}'," +
                        $"'{senha}','{situacao}','{posicao}')";
                comando = $"Insert into pessoa values {dados}";
                //Engatilhar a inserção do banco
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();//Ctrl + Enter
                                                              //Mostrar na tela
                Console.WriteLine(resultado + " linha afetada");
            }
            catch(Exception erro)
            {
                Console.WriteLine("Algo deu errado!\n\n" + erro);               
            }
        }//fim do método

        public void PreencherVetor()
        {
            string query = "select * from pessoa";//Coletar os dados do banco

            //Instanciar
            CPF = new long[100];
            nome = new string[100];
            telefone = new string[100];
            endereco = new string[100];
            dtNascimento = new DateTime[100];
            login = new string[100];
            senha = new string[100];
            situacao = new string[100];
            posicao = new string[100];

            //Preencher
            for(i=0; i < 100; i++)
            {
                CPF[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                endereco[i] = "";
                dtNascimento[i] = new DateTime();
                login[i] = "";
                senha[i] = "";
                situacao[i] = "";
                posicao[i] = "";
            }//fim do for

            //Preparar o comando do select
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura do banco
            MySqlDataReader leitura = coletar.ExecuteReader();            
            
            i = 0;
            contador = 0;
            while (leitura.Read())
            {
                CPF[i] = Convert.ToInt64(leitura["CPF"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                dtNascimento[i] = Convert.ToDateTime(leitura["dtNascimento"]);
                login[i] = leitura["login"] + "";
                senha[i] = leitura["senha"] + "";
                situacao[i] = leitura["situacao"] + "";
                posicao[i] = leitura["posicao"] + "";
                i++;
                contador++;
            }//fim do while
            leitura.Close();//Fecha a conexão com o banco
        }//fim do método

        public string ConsultarTudo()
        {
            PreencherVetor();//Preenche os vetores
            msg = "";
            for(i=0; i < contador; i++)
            {
                msg += "CPF: " + CPF[i] +
                       ", nome: " + nome[i] +
                       ", telefone: " + telefone[i] +
                       ", endereço: " + endereco[i] +
                       ", nascimento: " + dtNascimento[i] +
                       ", login: " + login[i] +
                       ", senha: " + senha[i] +
                       ", posição: " + posicao[i] +
                       ", situação: " + situacao[i];
            }//fim do for

            return msg;
        }//fim do método



    }//fim da classe
}//fim do projeto
