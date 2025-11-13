using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;

public class TesteAPI : MonoBehaviour
{
    private GameApiService apiService;
    public PlayerMov p;
    public UiManager UI;
    
    async void Start()
    {
        apiService = new GameApiService();
        
        Debug.Log("=== TESTE DA API ===");

        //Adicionar Jogadores
        Jogador novoJogador1 = new Jogador();
        novoJogador1.Item = p.Item;
        novoJogador1.Vida = p.Vida;
        novoJogador1.PosicaoX = p.posX;
        novoJogador1.PosicaoY = p.posY;
        novoJogador1.PosicaoZ = p.posZ;

        //adicionar jogador na API
        Jogador criadoJogador1 = await apiService.CriarJogador(novoJogador1);

        //adicionar itens para o jogador 1
        ItemJogador novoItem1 = new ItemJogador();
        novoItem1.Nome = "Espada";
        novoItem1.Descricao = "Espada de Aço";
        novoItem1.Dano = 10;
        novoItem1.JogadorId = criadoJogador1.id;
        ItemJogador criadoItem1 = await apiService.AdicionarItem(criadoJogador1.id, novoItem1);

        //excluir item do jogador 2
        //await apiService.RemoverItem(criadoJogador1.id, criadoItem2.id);

        //mostrar todos os jogadores
        await MostrarTodosJogadores();


        Debug.Log("=== FIM DOS TESTES ===");
    }

    public async void SavePause()
    {
        Jogador novoJogador1 = new Jogador();
        novoJogador1.Vida = p.Vida;
        novoJogador1.Item = p.Item;
        novoJogador1.PosicaoX = p.posX;
        novoJogador1.PosicaoY = p.posY;
        novoJogador1.PosicaoZ = p.posZ;

        //adicionar jogador na API
        Jogador jogador1End = await apiService.CriarJogador(novoJogador1);
        Debug.Log($"Jogadores criados: (ID: {jogador1End.id})");
    }

    async Task MostrarTodosJogadores()
    {
        Jogador[] jogadores = await apiService.GetTodosJogadores();
        Debug.Log($"Total de jogadores: {jogadores.Length}");
        foreach (var jogador in jogadores)
        {
            Debug.Log($"Jogador:  (ID: {jogador.Item}, Vida: {jogador.Vida})");
            ItemJogador[] itens = await apiService.GetItensJogador(jogador.Item);
            Debug.Log($"  Itens ({itens.Length}):");
            foreach (var item in itens)
            {
                Debug.Log($"    - {item.Nome} (Dano: {item.Dano})");
            }
        }
    }


    void OnDestroy()
    {
        apiService?.Dispose();
    }
}