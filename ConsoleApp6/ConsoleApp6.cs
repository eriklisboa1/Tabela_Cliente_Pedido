using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Loja1Entities())
            {//PARA CLIENTES E PEDIDOS
                Cliente cliente1 = new Cliente()
                {
                    Nome = "Erik",
                    Email = "eriklisboa72@outlook.com"
                };
                db.Clientes.Add(cliente1);
                db.SaveChanges(); //SALVAR O CLIENTE

                Cliente cliente2 = new Cliente()
                {
                    Nome = "Outra pessoa",
                    Email = "Harrr@outlook.com"
                };
                db.Clientes.Add(cliente2);
                db.SaveChanges();

                Cliente cliente3 = new Cliente()
                {
                    Nome = "fulano",
                    Email = "fulano@gmail.com"
                };
                db.Clientes.Add(cliente3);
                db.SaveChanges();

                cliente1.Pedidoes.Add(new Pedido
                {
                    Item = "Anel",
                    Preco = 2500
                });
                cliente2.Pedidoes.Add(new Pedido
                {
                    Item = "Nimbus 2000",
                    Preco = 10000
                });
                cliente3.Pedidoes.Add(new Pedido
                {
                    Item = "PC",
                    Preco = 3600
                });
                db.SaveChanges();

                //linq = language integratedd query
                var query = from c in db.Clientes.Include("Pedidoes")
                            select c;

                foreach  (var cliente in query)
                {
                    Console.WriteLine($"Cliente:{cliente.Nome}");
                    Console.WriteLine("Pedidos:");
                    Console.WriteLine("========");
                    foreach (var p in cliente.Pedidoes)
                    {
                        Console.WriteLine($"Item: {p.Item}, Preço:{p.Preco}");
                    }


                }               
                Console.WriteLine("Pressione qualquer tecla...");
                Console.ReadKey();
            }
        }
    }
}
