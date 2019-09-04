﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Loja.Modelos;
using Loja.Data;

namespace Loja.Importer
{
    public class Importador
    {
        public void Importer()
        {
            Data.Data manager = new Data.Data();
            string filePath = @"Url do excel"; //URL MISSING
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(File.OpenRead(filePath)))
                {
                    List<string> listaProdutos = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        //line é a row da excel sheet,
                        string line = reader.ReadLine();
                        listaProdutos.Add(line);                        
                    }
                    List<Produto> produtos = new List<Produto>();
                    foreach(string product in listaProdutos)
                    {
                        Produto produto = new Produto();
                        var substrings = product.Split(';');
                        produto.Id = Int32.Parse(substrings[0]);
                        produto.Nome = substrings[1];
                        produto.Preco = Convert.ToDecimal(substrings[2]);
                        produto.Tipo = substrings[3];
                        produto.DataDeAquisicao = DateTime.Parse(substrings[4]);
                        produto.DataDeVenda = DateTime.Parse(substrings[5]);
                        produtos.Add(produto);
                    }
                    manager.Adicionar(produtos);
                }
            }
        }
    }
}