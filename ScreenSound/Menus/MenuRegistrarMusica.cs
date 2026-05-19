using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro de músicas");

        Console.Write("Digite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (!bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Banda banda = bandasRegistradas[nomeDaBanda];

        Console.Write("Digite o título do álbum: ");
        string tituloAlbum = Console.ReadLine()!;

        if (!banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
        {
            Console.WriteLine($"\nO álbum {tituloAlbum} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));

        Console.Write("Digite o nome da música: ");
        string nomeMusica = Console.ReadLine()!;

        Musica musica = new Musica(banda, nomeMusica);
        album.AdicionarMusica(musica);

        Console.WriteLine($"\nA música {nomeMusica} foi registrada com sucesso no álbum {tituloAlbum}!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}