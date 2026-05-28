using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuExcluirAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Excluir um álbum");

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
        Console.Write("Digite o nome do álbum que deseja excluir: ");
        string nomeDoAlbum = Console.ReadLine()!;

        Album? albumParaExcluir = banda.Albuns.FirstOrDefault(a => a.Nome.Equals(nomeDoAlbum, StringComparison.OrdinalIgnoreCase));

        if (albumParaExcluir != null)
        {
            banda.Albuns.Remove(albumParaExcluir);
            Console.WriteLine($"O álbum {albumParaExcluir.Nome} foi excluído com sucesso!");
        }
        else
        {
            Console.WriteLine($"O álbum {nomeDoAlbum} não foi encontrado!");
        }

        Thread.Sleep(4000);
        Console.Clear();
    }
}