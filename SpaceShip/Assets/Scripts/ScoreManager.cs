using System.Linq;
using Unity.VisualScripting;
public static class ScoreManager{

    public static Pontuacao[] pontuacoes = new Pontuacao[1].Select(x => new Pontuacao()).ToArray();

    public static void resetPontuacoes(){
        pontuacoes = new Pontuacao[1].Select(x => new Pontuacao()).ToArray();
    }
}