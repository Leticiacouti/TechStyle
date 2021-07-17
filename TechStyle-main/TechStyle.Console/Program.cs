using System;
using TechStyle.Dominio.Modelo;
using TechStyle.Dominio.Repositorio;

namespace TechStyle.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe a categoria");
            var categoria = Console.ReadLine();

            Console.WriteLine("Informe a subcategoria");
            var subcategoria = Console.ReadLine();

            SegmentoRepositorio segrep = new SegmentoRepositorio();

            segrep.Incluir(categoria, subcategoria);
            segrep.Incluir("Masculino", "Social");
            segrep.Incluir("Infantil", "fantasias");
            segrep.Incluir("Feminino", "Social");
            segrep.Incluir("Feminino", "Saias");


            var lstSeg = segrep.SelecionarTudo();

            foreach(Segmento obj in lstSeg)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("ID para alterar");
            int alterarId = int.Parse(Console.ReadLine());

            Console.WriteLine("Categoria");
            string categoraAlterar = Console.ReadLine();

            Console.WriteLine("Sub");
            string subaltera = Console.ReadLine();

            segrep.Alterar(categoraAlterar, subaltera, alterarId);

            foreach (Segmento obj in lstSeg)
            {
                Console.WriteLine(obj);
            }




            //Console.WriteLine("ID segmento");
            //var idseg = int.Parse(Console.ReadLine());
            //Console.WriteLine("Nome");
            //var nome = Console.ReadLine();
            //Console.WriteLine("Valor da venda");
            //decimal valorVenda = decimal.Parse(Console.ReadLine());
            //Console.WriteLine("SKU");
            //var sku = Console.ReadLine();
            //Console.WriteLine("Material");
            //var material = Console.ReadLine();
            //Console.WriteLine("Cor");
            //var cor = Console.ReadLine();
            //Console.WriteLine("Marca");
            //var marca = Console.ReadLine();
            //Console.WriteLine("Modelo");
            //var modelo = Console.ReadLine();
            //Console.WriteLine("Tamanho");
            //string tamanho = Console.ReadLine();

            //Produto prod = new Produto();

            //prod.Cadastrar(nome, material, cor, tamanho, modelo, marca, idseg, sku, valorVenda);

            //Console.WriteLine(prod);

            /*
             1 - para cadastrar categoria/sub
             2 - para cadastrar produtos
             3 - para vender produto
             4 - Altera dados do produto
             5 - Alterar categoria
             


            // digitou 1

            

            SegmentoRepositorio repoSeg = new();

            repoSeg.Incluir(categoria, subcategoria);
           /* repoSeg.Incluir("Masculino", "Social");
            repoSeg.Incluir("Infantil", "fantasias");
            repoSeg.Incluir("Feminino", "Social");
            repoSeg.Incluir("Feminino", "Saias");*/

            //var lstSeg = repoSeg.SelecionarTudo();

            //Console.WriteLine("Qual segmento alterar?");
            //int indice = int.Parse(Console.ReadLine());

            //repoSeg.Alterar(indice, lstSeg);

            //Console.WriteLine(lstSeg[0]);



            // ---------------------------------------------

            // digitou 2

            /*var prod = new Produto();
            prod.Cadastrar(10, "Casaco de couro preto", "teste", lstSeg[0]);

            Console.WriteLine(prod);*/


            //Segmento seg = new Segmento();
            //seg.Cadastrar(2, "Calcados", "tenis");

            //Console.WriteLine("Você deseja consultar o codigo da categoria/subcategoria ? s/n");
            //var resposta = Console.ReadLine();
            //if(resposta == "s")
            //{
            //    var resultadoConsulta = repoSeg.SelecionarTudo();
            //    foreach (var item in resultadoConsulta)
            //    {
            //        Console.WriteLine($"{item.Id} - {item.Categoria} / {item.Subcategoria}");
            //    }
            //}

            //Console.WriteLine("Informe o codigo desejado");
            //var idSeg = int.Parse(Console.ReadLine());

            //var segmento = repoSeg.SelecionarPorId(idSeg);

            //Console.WriteLine($"{segmento.Id} - {segmento.Categoria} / {segmento.Subcategoria}");


            //Produto prod = new Produto();
            //prod.Cadastrar(10, "Kit de meias", "a1s5edf6a4", seg);



        }
    }
}
