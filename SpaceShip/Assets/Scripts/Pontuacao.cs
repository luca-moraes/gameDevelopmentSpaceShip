public class Pontuacao {
    public int vidas = 3;
    public int aleks = 0;
    public int zoio1 = 0;
    public int zoio2 = 0;
    public int zoio3 = 0;
    public int fugaAleks = 0;
    public int fugaZoio1 = 0;
    public int fugaZoio2 = 0;
    public int fugaZoio3 = 0;

    public int pontuacaoFinal(){
        return (aleks * 10) + (zoio1 * 50) 
        + (zoio2 * 100) + (zoio3 * 1000) 
        - (fugaAleks * 10) - (fugaZoio1 * 50) 
        - (fugaZoio2 * 100) - (fugaZoio3 * 1000);
    }
}