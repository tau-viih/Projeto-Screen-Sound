using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAvaliarMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);

        ExibirTituloDaOpcao("Avaliar música");

        Console.Write("Digite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;

        var bandaEncontrada = bandasRegistradas.Keys.FirstOrDefault(k => k.Equals(nomeDaBanda, StringComparison.OrdinalIgnoreCase));

        if (bandaEncontrada == null)
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Banda banda = bandasRegistradas[bandaEncontrada];

        Console.Write("Digite o nome do álbum: ");
        string nomeAlbum = Console.ReadLine()!;

        Album? album = banda.Albuns.FirstOrDefault(a => a.Nome.Equals(nomeAlbum, StringComparison.OrdinalIgnoreCase));

        if (album == null)
        {
            Console.WriteLine($"\nO álbum {nomeAlbum} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Console.WriteLine("\nMúsicas do álbum:");
        foreach (var tituloMusica in album.Musicas)
        {
            Console.WriteLine($"- {tituloMusica.Nome}");
        }

        Console.Write("\nDigite o nome da música: ");
        string nomeMusica = Console.ReadLine()!;

        Musica? musica = album.ObterMusica(nomeMusica);
        if (musica == null)
        {
            Console.WriteLine($"\nA música {nomeMusica} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Console.Write($"Qual a nota que a música {nomeMusica} merece: ");
        Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
        musica.AdicionarNota(nota);
        Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para a música {nomeMusica}");
        Thread.Sleep(2000);
        Console.Clear();
    }
}