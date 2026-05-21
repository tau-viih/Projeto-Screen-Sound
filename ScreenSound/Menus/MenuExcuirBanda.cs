using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuExcluirBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Excluir uma banda");

        Console.Write("Digite o nome da banda que deseja excluir: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            bandasRegistradas.Remove(nomeDaBanda);
            Console.WriteLine($"A banda {nomeDaBanda} foi excluída com sucesso!");
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        }

        Thread.Sleep(4000);
        Console.Clear();
    }
}
