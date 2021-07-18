using System;
using TechStyle.Dominio.Modelo;
using TechStyle.Dominio.Repositorio;

namespace TechStyle.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SegmentoRepositorio segRep = new();
            ProdutoRepositorio produtoRep = new();
            Menu();
            string opcao = Console.ReadLine().ToUpper();

            while (opcao != "X")
            {
                switch (opcao)
                {
                    #region Cadastrar Segmento
                    case "1":
                        Console.WriteLine("Digite 1 para cadastro automatico ou 2 para cadastrar manualmente");
                        int opcaocadastrosegmento = int.Parse(Console.ReadLine());
                        if (opcaocadastrosegmento == 1)
                        {
                            segRep.Incluir("Masculino", "Frio");
                            break;
                        }
                        else
                        {
                            Console.Write("Digite a categoria: ");
                            string categoria = Console.ReadLine();
                            Console.Write("Digite a subcategoria: ");
                            string subCategoria = Console.ReadLine();
                            segRep.Incluir(categoria, subCategoria);
                            break;
                        }
                    #endregion

                    #region Listar Segmentos
                    case "2":
                        var listaSegmento = segRep.SelecionarTudo(); 
                        foreach (Segmento obj in listaSegmento)
                        {
                            Console.WriteLine(obj);
                        }
                        break;
                    #endregion

                    #region Alterar segmento
                    case "3":
                        Console.Clear();
                        Console.WriteLine("lista de segmentos: ");
                        var visListaSegmento = segRep.SelecionarTudo();
                        foreach (Segmento obj in visListaSegmento)
                        {
                            Console.WriteLine(obj);
                        }
                        
                        Console.WriteLine("\nDigite a ID do segmento que deseja alterar: ");
                        int segmentoId = int.Parse(Console.ReadLine());
                        Console.Write("Digite a nova categoria: ");
                        string novaCategoria = Console.ReadLine();
                        Console.Write("Digite a nova subcategoria: ");
                        string novaSubCategoria = Console.ReadLine();

                        segRep.Alterar(novaCategoria, novaSubCategoria, segmentoId);

                        Console.WriteLine("\nlista de segmentos atualizada: ");
                        visListaSegmento = segRep.SelecionarTudo();
                        foreach (Segmento obj in visListaSegmento)
                        {
                            Console.WriteLine(obj);
                        }
                        break;
                    #endregion

                    #region Desativar segmento
                    case "4":
                        break;
                    #endregion

                    #region Cadastrar produto
                    case "5":
                        Console.WriteLine("Digite 1 para cadastro automatico ou 2 para cadastrar manualmente");
                        int opcaocadastroproduto = int.Parse(Console.ReadLine());
                        if (opcaocadastroproduto == 1)
                        {
                            Segmento segprod1 = segRep.listaDeSegmentos[0];
                            produtoRep.Incluir("blusa com capuz", "preta", "lokicoste", "manga longa", "algodao", "teste", "M", segprod1, 120*1);
                            break;
                        }
                        else
                        {
                            Console.Write("Digite o nome: ");
                            string nome = Console.ReadLine();
                            Console.Write("Digite a cor: ");
                            string cor = Console.ReadLine(); 
                            Console.Write("Digite a marca: ");
                            string marca = Console.ReadLine();
                            Console.Write("Digite o modelo: ");
                            string modelo = Console.ReadLine();
                            Console.Write("Digite o material: ");
                            string material = Console.ReadLine();
                            Console.Write("Digite o sku: ");
                            string sku = Console.ReadLine();
                            Console.Write("Digite o tamanho: ");
                            string tamanho = Console.ReadLine();
                            Console.Write("Digite o valor: ");
                            decimal valor = decimal.Parse(Console.ReadLine());
                            Console.Write("Digite a categoria: ");
                            string categoria = Console.ReadLine();
                            Console.Write("Digite a subcategoria: ");
                            string subCategoria = Console.ReadLine();

                            segRep.Incluir(categoria, subCategoria);
                            Segmento segmentoProduto = segRep.listaDeSegmentos.Find(x => x.Categoria == categoria && x.SubCategoria == subCategoria);

                            produtoRep.Incluir(nome, cor, marca, modelo, material, sku, tamanho, segmentoProduto, valor);
                            break;
                        }
                    #endregion

                    #region Listar Produtos
                    case "6":
                        var listaProduto = produtoRep.SelecionarTudo();
                        foreach (Produto obj in listaProduto)
                        {
                            Console.WriteLine(obj);
                        }
                        break;
                    #endregion

                    #region Alterar produto
                    case "7":
                        Console.Clear();
                        Console.WriteLine("lista de produtos: ");
                        var visListaProduto = produtoRep.SelecionarTudo();
                        foreach (Produto obj in visListaProduto)
                        {
                            Console.WriteLine(obj);
                        }

                        Console.WriteLine("\nDigite a ID do produto que deseja alterar: ");
                        int produtoId = int.Parse(Console.ReadLine());
                        Console.Write("Digite o novo nome: ");
                        string nNome = Console.ReadLine();
                        Console.Write("Digite a cor: ");
                        string nCor = Console.ReadLine();
                        Console.Write("Digite a marca: ");
                        string nMarca = Console.ReadLine();
                        Console.Write("Digite o modelo: ");
                        string nModelo = Console.ReadLine();
                        Console.Write("Digite o material: ");
                        string nMaterial = Console.ReadLine();
                        Console.Write("Digite o sku: ");
                        string nSku = Console.ReadLine();
                        Console.Write("Digite o tamanho: ");
                        string nTamanho = Console.ReadLine();
                        Console.Write("Digite o valor: ");
                        decimal nValor = decimal.Parse(Console.ReadLine());
                        Console.Write("Digite a categoria: ");
                        string nCategoria = Console.ReadLine();
                        Console.Write("Digite a subcategoria: ");
                        string nSubCategoria = Console.ReadLine();

                        segRep.Incluir(nCategoria, nSubCategoria);
                        Segmento nSegmentoProduto = segRep.listaDeSegmentos.Find(x => x.Categoria == nCategoria && x.SubCategoria == nSubCategoria);

                        produtoRep.Alterar(produtoId, nNome, nMaterial, nCor, nTamanho, nModelo, nMarca, nSegmentoProduto, nSku, nValor);

                        Console.WriteLine("\nlista de produtos atualizada: ");
                        visListaProduto = produtoRep.SelecionarTudo();
                        foreach (Produto obj in visListaProduto)
                        {
                            Console.WriteLine(obj);
                        }
                        break;
                    #endregion

                    #region Alterar valor do produto
                    case "8":
                        Console.Clear();
                        visListaProduto = produtoRep.SelecionarTudo();
                        foreach (Produto obj in visListaProduto)
                        {
                            Console.WriteLine(obj);
                        }

                        Console.Write("\nDigite o id do produto que deseja alterar o valor: ");
                        int Idproduto = int.Parse(Console.ReadLine());
                        Console.Write("Digite o novo valor: ");
                        decimal valorNovo = decimal.Parse(Console.ReadLine());

                        produtoRep.AlterarValorVenda(Idproduto, valorNovo);

                        Console.WriteLine("\nLista atualizada: ");
                        foreach (Produto obj in visListaProduto)
                        {
                            Console.WriteLine(obj);
                        }
                        break;
                    #endregion

                    case "C":
                        Console.Clear();
                        break;
                }
                Menu();
                opcao = Console.ReadLine().ToUpper();
            }

        }

        static void Menu()
        {
            Console.WriteLine("Digite a opção:" +
                              "\n1 - para cadastrar segmento" +
                              "\n2 - para visualizar segmentos" +
                              "\n3 - para alterar segmento" +
                              //"\n4 - para desabilitar segmento" + 
                              "\n5 - para criar produto" +
                              "\n6 - para listar produtos" +
                              "\n7 - para alterar produto" +
                              "\n8 - para alterar valor produto" +
                              //"\n9 - para desabilitar produto" +
                              "\nC - para limpar a tela" +
                              "\nX - para sair");
        }
    }
}
