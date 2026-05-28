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

        var bandaEncontrada = bandasRegistradas.Keys.FirstOrDefault(k => k.Equals(nomeDaBanda, StringComparison.OrdinalIgnoreCase));

        if (bandaEncontrada != null)
        {
            bandasRegistradas.Remove(bandaEncontrada);
            Console.WriteLine($"A banda {bandaEncontrada} foi excluída com sucesso!");
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        }

        Thread.Sleep(4000);
        Console.Clear();
    }
}
