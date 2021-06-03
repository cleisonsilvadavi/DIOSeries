using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
          String opcaoUsuario = ObterOpcaoUsuario();

          while (opcaoUsuario.ToString() != "X") {
              switch (opcaoUsuario) {
                  case "1": 
                        ListarSeries();
                        break;
                  case "2":
                        InserirSerie();
                        break;
                  case "3":
                        AtualizarSerie();
                        break;
                  case "4": 
                        ExcluirSerie();
                        break;
                  case "5":
                        RetornarSerie();
                        break;
                  case "C":
                        Console.Clear();
                        break;
                  default:
                        throw new ArgumentOutOfRangeException();      

              }
              opcaoUsuario = ObterOpcaoUsuario();
          }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
                     
           
        }          
       
        private static void ListarSeries() {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();

            if (lista.Count==0){
                Console.WriteLine("Nenhuma série cadastrado");
                return;
            }
            foreach(var serie in lista) {
                Console.WriteLine("#ID {0}: - {1} - {2}",serie.retornaId(), serie.retornaTitulo(), serie.Excluido.ToString());
            }
        }
        private static void ExcluirSerie() {
            Console.WriteLine();
            Console.WriteLine("Digite o ID da Série");
            int Id = int.Parse(Console.ReadLine());
            repositorio.Excluir(Id);
            
            Console.WriteLine("Série Excluída com sucesso!");
            Console.WriteLine("Série Excluída com sucesso!");

        }
        private static void AtualizarSerie(){
            Console.WriteLine("Digite o ID da Série");
            int Id = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues<Genero>()){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inídio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero) entradaGenero,
                                        ano: entradaAno,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(Id, novaSerie);                                         

        }
        private static void InserirSerie(){
            Console.WriteLine("Inserir nova Série");
            foreach(int i in Enum.GetValues<Genero>()){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inídio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero) entradaGenero,
                                        ano: entradaAno,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao);
            repositorio.insere(novaSerie);                                         


        }

        private static void RetornarSerie() {
            Console.WriteLine("Digite o ID da Série");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine(repositorio.RetornaporId(Id).ToString());            
        }

        public static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- inserir nova série");
            Console.WriteLine("3- atualizar série");
            Console.WriteLine("4- excluir série");
            Console.WriteLine("5- visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;

        }

    }  
}
