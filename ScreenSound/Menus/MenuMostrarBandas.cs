using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarBandas : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");

        if (bandasRegistradas.Count == 0)
        {
            Console.WriteLine("Nenhuma banda registrada.");
        }
        else
        {
            foreach (Banda banda in bandasRegistradas.Values)
            {
                ExibirHierarquiaBanda(banda);
            }
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

    private void ExibirHierarquiaBanda(Banda banda)
    {
        Console.WriteLine($"\n {banda.Nome}");

        if (banda.Albuns.Count == 0)
        {
            Console.WriteLine("   └─ Nenhum álbum cadastrado");
        }
        else
        {
            for (int i = 0; i < banda.Albuns.Count; i++)
            {
                Album album = banda.Albuns[i];
                bool ehUltimoAlbum = i == banda.Albuns.Count - 1;
                string prefixoAlbum = ehUltimoAlbum ? "   └─" : "   ├─";

                Console.WriteLine($"{prefixoAlbum}  {album.Nome}");

                if (album.Musicas.Count == 0)
                {
                    string prefixoMusica = ehUltimoAlbum ? "      " : "   │  ";
                    Console.WriteLine($"{prefixoMusica}└─ Nenhuma música cadastrada");
                }
                else
                {
                    for (int j = 0; j < album.Musicas.Count; j++)
                    {
                        Musica musica = album.Musicas[j];
                        bool ehUltimaMusica = j == album.Musicas.Count - 1;
                        string prefixoMusica = ehUltimoAlbum ? "      " : "   │  ";
                        string conectorMusica = ehUltimaMusica ? "└─" : "├─";

                        Console.WriteLine($"{prefixoMusica}{conectorMusica} {musica.Nome}");
                    }
                }
            }
        }
    }
}