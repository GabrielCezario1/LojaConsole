class Program
{
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
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());
        Console.Write("Estoque: ");
        int estoque = int.Parse(Console.ReadLine());

        // Instancia a Ponte
        using var context = new LojaContext();

        var novoP = new Produto();
        novoP.Nome = nome;
        novoP.Preco = preco;
        novoP.Estoque = estoque;
        // NÃO PRECISA DO ID (O banco gera sozinho agora!)

        context.Produtos.Add(novoP); // Coloca na caixa de saída
        context.SaveChanges(); // 💾 O Carteiro leva para o banco!

        Console.WriteLine("✅ Produto salvo no Banco de Dados!");
    }

    static void ListarProdutos()
    {
        Console.WriteLine("\n--- 📦 LISTA DE PRODUTOS ---");

        using var context = new LojaContext();
        var produtos = context.Produtos.ToList(); // SELECT * FROM Produtos

        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto encontrado no banco.");
            return;
        }

        foreach (var p in produtos)
        {
            Console.WriteLine($"ID: {p.Id} | {p.Nome} | R$ {p.Preco:F2} | Estoque: {p.Estoque}");
        }
    }

    static void RemoverProduto()
    {
        Console.WriteLine("\n--- 🗑️ REMOVER PRODUTO ---");
        Console.Write("Digite o ID: ");
        int id = int.Parse(Console.ReadLine());

        using var context = new LojaContext();

        // Busca no banco (SELECT * WHERE Id = ...)
        var produto = context.Produtos.Find(id);

        if (produto != null)
        {
            context.Produtos.Remove(produto); // Marca para deletar
            context.SaveChanges(); // 💾 Executa o DELETE no banco
            Console.WriteLine("✅ Produto removido do banco!");
        }
        else
        {
            Console.WriteLine("❌ Produto não encontrado.");
        }
    }
}