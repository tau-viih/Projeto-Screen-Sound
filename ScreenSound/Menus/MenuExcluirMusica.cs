using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuExcluirMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Excluir uma música");

        Console.Write("Digite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;

        var bandaEncontrada = bandasRegistradas.Keys.FirstOrDefault(k => k.Equals(nomeDaBanda, StringComparison.OrdinalIgnoreCase));

        if (bandaEncontrada == null)
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
            Thread.Sleep(4000);
            Console.Clear();
            return;
        }

        Banda banda = bandasRegistradas[bandaEncontrada];
        Console.Write("Digite o nome do álbum: ");
        string nomeDoAlbum = Console.ReadLine()!;

        Album? album = banda.Albuns.FirstOrDefault(a => a.Nome.Equals(nomeDoAlbum, StringComparison.OrdinalIgnoreCase));

        if (album == null)
        {
            Console.WriteLine($"O álbum {nomeDoAlbum} não foi encontrado!");
            Thread.Sleep(4000);
            Console.Clear();
            return;
        }

        Console.Write("Digite o nome da música que deseja excluir: ");
        string nomeDaMusica = Console.ReadLine()!;

        Musica? musicaParaExcluir = album.Musicas.FirstOrDefault(m => m.Nome.Equals(nomeDaMusica, StringComparison.OrdinalIgnoreCase));

        if (musicaParaExcluir != null)
        {
            album.Musicas.Remove(musicaParaExcluir);
            Console.WriteLine($"A música {musicaParaExcluir.Nome} foi excluída com sucesso!");
        }
        else
        {
            Console.WriteLine($"A música {nomeDaMusica} não foi encontrada!");
        }

        Thread.Sleep(4000);
        Console.Clear();
    }
}