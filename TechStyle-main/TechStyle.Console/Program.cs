using System;
using System.Collections.Generic;
using TechStyle.Dados.Repositorio;
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
            EstoqueRepositorio estoqueRep = new();
            LojaRepositorio lojaRep = new();

            PedidoDeVendasRepositorio pedidoRep = new();

            Console.WriteLine("Digite 1 para parte de estocagem ou 2 para parte de vendas");
            string opcaoPrincipal = Console.ReadLine();

            if (opcaoPrincipal == "1")
            {
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

                            segRep.Alterar(segmentoId, novaCategoria, novaSubCategoria);

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
                        #endregion //TODO: ativar/desativar segmento

                        #region Cadastrar produto
                        case "5":
                            Console.WriteLine("Digite 1 para cadastro automatico ou 2 para cadastrar manualmente");
                            int opcaocadastroproduto = int.Parse(Console.ReadLine());
                            if (opcaocadastroproduto == 1)
                            {
                                Segmento segprod1 = segRep.SelecionarPorId(1);
                                produtoRep.Incluir("blusa com capuz", "preta", "lokicoste", "manga longa", "algodao", "teste", "M", segprod1, 120 * 1);
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
                                Console.Write("Digite o Id do segmento: ");
                                int id_Segmento = int.Parse(Console.ReadLine());

                                Segmento segmentoProduto = segRep.SelecionarPorId(id_Segmento);

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
                            Console.Write("Digite o id do segmento: ");
                            int idSegmento = int.Parse(Console.ReadLine());
                            Segmento segmento = segRep.SelecionarPorId(idSegmento);

                            produtoRep.Alterar(produtoId, nNome, nMaterial, nCor, nTamanho, nModelo, nMarca, segmento, nSku, nValor);

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

                        #region cadastrar produto no estoque
                        case "10":
                            Console.Clear();
                            Console.WriteLine("Digite o Id do produto que voce deseja cadastrar no estoque: ");
                            produtoId = int.Parse(Console.ReadLine());
                            Produto p1 = produtoRep.SelecionarPorId(produtoId);
                            estoqueRep.Incluir(p1, 50, "Prateleira 1");
                            break;
                        #endregion

                        #region Visualizar estoque
                        case "11":
                            Console.WriteLine("Estoque: ");
                            foreach (Estoque x in estoqueRep.SelecionarTudo())
                            {
                                Console.WriteLine(x);
                            }
                            break;
                        #endregion

                        #region Alterar local de estocagem ou qtd minima
                        case "12":
                            Console.Clear();
                            Console.Write("Digite 1 para alterar local de estocagem ou 2 para alterar qtd minima em estoque: ");
                            int opcaoEstoque = int.Parse(Console.ReadLine());

                            if (opcaoEstoque == 1)
                            {
                                Console.Write("\nDigite o id do estoque que deseja alterar seu local de armazenagem: ");
                                int estoqueId = int.Parse(Console.ReadLine());

                                Console.WriteLine("\nQual o novo local de armazenagem? ");
                                string novoLocal = Console.ReadLine();

                                estoqueRep.AlterarLocal(estoqueId, novoLocal);

                                Console.WriteLine("Local de armazenagem alterado!");
                            }
                            else if (opcaoEstoque == 2)
                            {
                                Console.Write("\nDigite o id do estoque que deseja alterar sua qtd minima: ");
                                int estoqueId = int.Parse(Console.ReadLine());

                                Console.WriteLine("\nQual a nova qtd minima? ");
                                int novoQtdMin = int.Parse(Console.ReadLine());

                                estoqueRep.AlterarQtdMinima(estoqueId, novoQtdMin);

                                Console.WriteLine("Quantidade minima alterada!");
                            }
                            break;
                        #endregion

                        #region cadastrar loja
                        case "13":
                            Console.Clear();
                            Console.WriteLine("Digite o Id do produto que voce deseja cadastrar na loja: ");
                            produtoId = int.Parse(Console.ReadLine());
                            p1 = produtoRep.SelecionarPorId(produtoId);
                            lojaRep.Incluir(p1, 20);
                            break;
                        #endregion

                        #region Listar loja
                        case "14":
                            Console.WriteLine("Loja: ");
                            foreach (Loja x in lojaRep.SelecionarTudo())
                            {
                                Console.WriteLine(x);
                            }
                            break;
                        #endregion

                        #region Transferir para loja
                        case "15":
                            Console.Clear();
                            Console.WriteLine("digite o id da loja que voce deseja transferir o produto: ");
                            int idLoja = int.Parse(Console.ReadLine());

                            Loja procuraLoja = lojaRep.SelecionarPorId(idLoja);
                            Estoque procuraEstoque = estoqueRep.SelecionarPorProduto(procuraLoja.Produto);

                            lojaRep.TransferirParaLoja(idLoja, procuraEstoque, 10);

                            Console.WriteLine($"\nAgora tem {procuraLoja.QuantidadeLocal} na loja e {procuraEstoque.QuantidadeLocal} no estoque");
                            break;
                        #endregion

                        case "C":
                            Console.Clear();
                            break;

                    }
                    Console.WriteLine();
                    Menu();
                    opcao = Console.ReadLine().ToUpper();
                }
            }

            else if (opcaoPrincipal =="2")
            {
                Venda venda = new();
                Console.Write("Quantos itens diferentes foram colocados no carrinho? ");
                int quantidadeItens = int.Parse(Console.ReadLine());

                for (int i = 0; i < quantidadeItens; i++)
                {
                    Console.Write($"Digite o Id do {i+1}º produto: ");
                    int idProduto = int.Parse(Console.ReadLine());
                    Console.Write("Qual a quantidade desse item o cliente irá levar? ");
                    int qtdProduto = int.Parse(Console.ReadLine());

                    Produto p1 = produtoRep.SelecionarPorId(idProduto);

                    pedidoRep.Incluir(p1, qtdProduto, venda);
                }

                foreach(PedidoDeVenda pedido in pedidoRep.SelecionarPorVenda(venda.Id))
                {
                    venda.PedidoDeVenda.Add(pedido);
                }
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
                              "\n10 - cadastrar item no estoque" +
                              "\n11 - visualizar estoque" +
                              "\n12 - alterar qtd minima em estoque e localização" +
                              "\n13 - cadastrar produto na loja" +
                              "\n14 - verificar produtos na loja" +
                              "\n15 - trasnferir itens para loja" +
                              "\nC - para limpar a tela" +
                              "\nX - para sair");
        }
    }
}

