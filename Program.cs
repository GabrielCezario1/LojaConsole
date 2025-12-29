class Program
{
    // DEFINIÇÃO DA CLASSE PRODUTO
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }

    // BANCO DE DADOS EM MEMÓRIA
    // 'static' significa que essa lista pertence ao programa todo e não morre enquanto ele roda.
    static List<Produto> produtos = new List<Produto>();

    // Contador para gerar IDs automáticos (1, 2, 3...)
    static int proximoId = 1;

    static void Main(string[] args)
    {
        // Variável para controlar se o programa deve continuar rodando
        bool executando = true;

        while (executando)
        {
            // Limpa a tela para o menu ficar bonito
            Console.Clear();

            Console.WriteLine("=== 🏪 GESTÃO DE ESTOQUE (MEMÓRIA RAM) ===");
            Console.WriteLine("1. Novo Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Remover Produto");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");

            // Lê o que o usuário digitou
            string opcao = Console.ReadLine();

            // Tomada de Decisão
            switch (opcao)
            {
                case "1":
                    CadastrarProduto();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    RemoverProduto();
                    break;
                case "4":
                    Console.WriteLine("Encerrando sistema...");
                    executando = false;
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }

            // Pausa para o usuário ler a mensagem antes de limpar a tela novamente
            if (executando)
            {
                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }
    }

    static void CadastrarProduto()
    {
        Console.WriteLine("\n--- 🆕 NOVO PRODUTO ---");

        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Preço: ");
        // decimal.Parse converte o texto digitado para número decimal
        decimal preco = decimal.Parse(Console.ReadLine());

        Console.Write("Quantidade em Estoque: ");
        int estoque = int.Parse(Console.ReadLine());

        // VALIDAÇÃO (Regra de Negócio)
        if (preco <= 0)
        {
            Console.WriteLine("❌ ERRO: O preço deve ser maior que zero.");
            return; // Sai do método sem salvar
        }

        // Criando o Objeto (O Biscoito saindo do Molde)
        Produto novoProduto = new Produto();
        novoProduto.Id = proximoId;
        novoProduto.Nome = nome;
        novoProduto.Preco = preco;
        novoProduto.Estoque = estoque;

        // Adicionando na Lista (Banco de Dados Fake)
        produtos.Add(novoProduto);

        // Incrementa o ID para o próximo não ser igual
        proximoId++;

        Console.WriteLine("✅ Produto cadastrado com sucesso!");
    }

    static void ListarProdutos()
    {
        Console.WriteLine("\n--- 📦 LISTA DE PRODUTOS ---");

        // Verifica se a lista está vazia
        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        // Laço de Repetição: Para cada 'p' dentro da lista 'produtos'
        foreach (Produto p in produtos)
        {
            // Usando interpolação de string ($"") para formatar
            Console.WriteLine($"ID: {p.Id} | {p.Nome} | R$ {p.Preco:F2} | Estoque: {p.Estoque}");
        }
    }

    static void RemoverProduto()
    {
        Console.WriteLine("\n--- 🗑️ REMOVER PRODUTO ---");

        // Primeiro, mostramos o que tem para facilitar
        ListarProdutos();

        Console.Write("\nDigite o ID do produto que deseja remover: ");
        int idParaRemover = int.Parse(Console.ReadLine());

        // LÓGICA DE BUSCA
        // Expressão Lambda: "Procure um produto 'p' onde o p.Id seja igual ao idParaRemover"
        Produto produtoEncontrado = produtos.Find(p => p.Id == idParaRemover);

        if (produtoEncontrado != null)
        {
            produtos.Remove(produtoEncontrado);
            Console.WriteLine($"✅ O produto '{produtoEncontrado.Nome}' foi removido!");
        }
        else
        {
            Console.WriteLine("❌ Produto não encontrado.");
        }
    }
}