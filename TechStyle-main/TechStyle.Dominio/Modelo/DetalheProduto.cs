using System;

namespace TechStyle.Dominio.Modelo
{
    public class DetalheProduto
    {
        public string Material { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tamanho { get; set; }

        public void Adicionar(string material, string cor, string marca, string modelo, string tamanho)
        {
            Material = material;
            Cor = cor;
            Marca = marca;
            Modelo = modelo;
            Tamanho = tamanho;
        }

        internal void Alterar(int id)
        {



        }

        public override string ToString()
        {
            return Material+ ", " + Cor + ", "+Marca+", "+ Modelo + ", "+ Tamanho;
        }
    }
}
