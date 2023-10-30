using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GUISkin layout;
    Hashtable fases = new Hashtable();
	private GUIStyle guiStylePts = new GUIStyle();
	private GUIStyle guiStyleTtr = new GUIStyle();
    private GUIStyle guiStyleEnd = new GUIStyle();
    private GUIStyle guiStyleSma = new GUIStyle();
    private GUIStyle guiStylePrd = new GUIStyle();
    public GameObject alek;
    public GameObject zoio1;
    public GameObject zoio2;
    public GameObject zoio3;
    public int nivelZoio = 1;
    private bool venceu = false;
    private bool perdeu = false;

    private bool enemyOnScreen = false;

    private void setStylePrd(){
        guiStylePrd.fontSize = 22;
        guiStylePrd.normal.textColor = Color.red;

        Texture2D debugTex = new Texture2D(1,1);
        debugTex.SetPixel(0,0, Color.black);
        debugTex.Apply();

        guiStylePrd.normal.background = debugTex;
    }
    private void setPtsStyle(){
		guiStylePts.fontSize = 22;
		guiStylePts.normal.textColor = new Color(0.3f, 0.0f, 0.5f, 1.0f);

		Texture2D debugTex = new Texture2D(1,1);
	  	debugTex.SetPixel(0,0, Color.black);
	  	debugTex.Apply();

		guiStylePts.normal.background = debugTex;
	}

    private void setTtrStyle(){
		guiStyleTtr.fontSize = 22;
		guiStyleTtr.normal.textColor = Color.red;

		Texture2D debugTex = new Texture2D(1,1);
	  	debugTex.SetPixel(0,0, Color.black);
	  	debugTex.Apply();

		guiStyleTtr.normal.background = debugTex;
	}

    private void setEndStyle(){
		guiStyleEnd.fontSize = 22;
		guiStyleEnd.normal.textColor = Color.green;

		Texture2D debugTex = new Texture2D(1,1);
      	debugTex.SetPixel(0,0,Color.black);
      	debugTex.Apply();

		guiStyleEnd.normal.background = debugTex;
	}

    private void setSmaStyle(){
		guiStyleSma.fontSize = 12;
		guiStyleSma.normal.textColor = new Color(0.3f, 0.0f, 0.5f, 1.0f);		

		Texture2D debugTex = new Texture2D(1,1);
	  	debugTex.SetPixel(0,0, new Color(0.0f, 0.0f, 0.0f, 0.3f));
	  	debugTex.Apply();

		guiStyleSma.normal.background = debugTex;
	}

    public void addScore(int tipo){
        switch(tipo){
            case 0:
                ScoreManager.pontuacoes[faseAtual()].aleks += 1;
                break;
            case 1:
                ScoreManager.pontuacoes[faseAtual()].zoio1 += 1;
                break;
            case 2:
                ScoreManager.pontuacoes[faseAtual()].zoio2 += 1;
                break;
            case 3:
                ScoreManager.pontuacoes[faseAtual()].zoio3 += 1;
                break;
            case 4:
                ScoreManager.pontuacoes[faseAtual()].fugaAleks += 1;
                break;
            case 5:
                ScoreManager.pontuacoes[faseAtual()].fugaZoio1 += 1;
                break;
            case 6:
                ScoreManager.pontuacoes[faseAtual()].fugaZoio2 += 1;
                break;
            case 7:
                ScoreManager.pontuacoes[faseAtual()].fugaZoio3 += 1;
            break;
        }
    }

    public void hit(){
        ScoreManager.pontuacoes[faseAtual()].vidas -= 1;
    }

    public void perdeuFase(){
        perdeu = true;
    }

    public void venceuFase(){
        venceu = true;
    }

    private int faseAtual(){
		if(SceneManager.GetActiveScene().name == "fase")
        {
			return 0;
        }
		else
		{
			return -1;
		}
	}

    public void enemyKilled(){
        enemyOnScreen = false;
	}

    void showPlacar(){
		GUI.Label(new Rect(22, Screen.height-2 - 22, 280, 22),
         "Vidas: " + ScoreManager.pontuacoes[faseAtual()].vidas +
         " ||| Pontos: " + ScoreManager.pontuacoes[faseAtual()].pontuacaoFinal(),
         guiStylePts
        );
	}

	void OnGUI ()
    {
	    GUI.skin = layout;

        if(SceneManager.GetActiveScene().name == "intro"
        || SceneManager.GetActiveScene().name == "abertura"
        || SceneManager.GetActiveScene().name == "vitoria"
        || SceneManager.GetActiveScene().name == "perda")
        {
            if (GUI.Button(new Rect(Screen.width - 80, Screen.height - 40, 60, 22), "Pular"))
            {
                Invoke("changeScene", 0.5f);
            }
        }

        if(SceneManager.GetActiveScene().name == "menu"){
            if (GUI.Button(new Rect(Screen.width/2 - 150, Screen.height - 40, 300, 22), "Impedir a trollada final!"))
            {
                Invoke("changeScene", 0.5f);
            }
        }

        if(SceneManager.GetActiveScene().name == "intro"){
            GUI.Label(new Rect(42, Screen.height-10 - 22, 1400, 22),
                "Noticia urgente! Ao Vivo: Everson Zoio ameaça destruir o Brasil e toda a terra para exterminar a humanidade!",
                guiStyleTtr
            );
        }

        if(SceneManager.GetActiveScene().name == "menu"){
            GUI.Label(new Rect(32, Screen.height-10 - 45, 500, 22),
                "Teclas W e S para subir e descer\nTecla Espaço para atirar. Salve a terra!",
                guiStyleTtr
            );
        }

        if(SceneManager.GetActiveScene().name == "reset"){
            int basePosY = 100;

            foreach(Pontuacao pontuacao in ScoreManager.pontuacoes){
				GUI.Label(new Rect(Screen.width / 2 - 120, basePosY, 240, 26), "Pontos: " + pontuacao.pontuacaoFinal(), guiStyleSma);
				basePosY += 90;

                GUI.Label(new Rect(Screen.width / 2 - 120, basePosY, 240, 26), "Aleks(10p): " + pontuacao.aleks, guiStyleSma);
				basePosY += 90;

                GUI.Label(new Rect(Screen.width / 2 - 120, basePosY, 240, 26), "Zoio base(50p): " + pontuacao.zoio1, guiStyleSma);
                basePosY += 90;

                GUI.Label(new Rect(Screen.width / 2 - 120, basePosY, 240, 26), "Zoio bomba(100p): " + pontuacao.zoio2, guiStyleSma);
                basePosY += 90;

                GUI.Label(new Rect(Screen.width / 2 - 120, basePosY, 240, 26), "Zoio blaster(1000p): " + pontuacao.zoio3, guiStyleSma);
                basePosY += 90;

                GUI.Label(new Rect(Screen.width / 2 - 120, basePosY, 240, 26), "Aleks perdidos(-10p): " + pontuacao.fugaAleks, guiStyleSma);
                basePosY += 90;

                GUI.Label(new Rect(Screen.width / 2 - 120, basePosY, 240, 26), "Zoio base perdido(-50p): " + pontuacao.fugaZoio1, guiStyleSma);
                basePosY += 90;

                GUI.Label(new Rect(Screen.width / 2 - 120, basePosY, 240, 26), "Zoio bomba perdido(-100p): " + pontuacao.fugaZoio2, guiStyleSma);
                basePosY += 90;

                GUI.Label(new Rect(Screen.width / 2 - 120, basePosY, 240, 26), "Zoio blaster perdido(-1000p): " + pontuacao.fugaZoio3, guiStyleSma);
                basePosY += 90;
			}

            if (GUI.Button(new Rect(Screen.width/2 - 106, Screen.height - 40, 220, 22), "Voltar ao menu"))
            {
                restartGameManager();
            }
        }

        if(SceneManager.GetActiveScene().name == "fase"){
            showPlacar();

            if(ScoreManager.pontuacoes[faseAtual()].vidas <= 0){
                perdeu = true;
            }

            if(!enemyOnScreen && (ScoreManager.pontuacoes[faseAtual()].aleks == 0) && (ScoreManager.pontuacoes[faseAtual()].fugaAleks == 0)){
                enemyOnScreen = true;
                Invoke("chamarAlek", 1.0f);
            }else if(!enemyOnScreen && (ScoreManager.pontuacoes[faseAtual()].zoio1 == 0 && ScoreManager.pontuacoes[faseAtual()].fugaZoio1 == 0)){
                enemyOnScreen = true;
                Invoke("chamarZoio", 2.0f);
            }else if(!enemyOnScreen && (ScoreManager.pontuacoes[faseAtual()].zoio2 == 0 && ScoreManager.pontuacoes[faseAtual()].fugaZoio2 == 0)){
                enemyOnScreen = true;
                Invoke("chamarZoio", 3.0f);
            }else if(!enemyOnScreen && (ScoreManager.pontuacoes[faseAtual()].zoio3 == 0 && ScoreManager.pontuacoes[faseAtual()].fugaZoio3 == 0)){
                enemyOnScreen = true;
                Invoke("chamarZoio", 4.0f);
            }

            if(venceu){
                GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 50, 900, 100), "Você derrotou Zoio e impediu a trollada final, parabens!\n Mas fique atento, em 5 anos ele tentara novamente!", guiStyleEnd);
                Invoke("vencedor", 5.0f);
            }
            else if(perdeu){
                GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 50, 900, 100), "Voce fracassou em impedir a trollada final de Zoio!\n Por sua culpa a terra e toda a humanidade foi destruida!", guiStylePrd);
                Invoke("derrotado", 5.0f);
            }
        

        }
	}

    public void chamarAlek(){
        Instantiate(alek, new Vector3(22, 0, 0), Quaternion.identity);
        enemyOnScreen = true;
    }

    public void chamarZoio(){
        switch(nivelZoio){
            case 1:
                Instantiate(zoio1, new Vector3(22, 0, 0), Quaternion.identity);
                nivelZoio = 2;
                break;
            case 2:
                Instantiate(zoio2, new Vector3(22, 0, 0), Quaternion.identity);
                nivelZoio = 3;
                break;
            case 3:
                Instantiate(zoio3, new Vector3(22, 0, 0), Quaternion.identity);
                nivelZoio = 0;
            break;
        }

        enemyOnScreen = true;
    }

    public void derrotado(){
        SceneManager.LoadScene("perda");
    }

    public void vencedor(){
        SceneManager.LoadScene("vitoria");
    }

    private void restartGameManager(){
        ScoreManager.resetPontuacoes();
        nivelZoio = 1;
        enemyOnScreen = false;
        venceu = false;
        perdeu = false;
		Invoke("changeScene", 0.5f);
	}

    private void changeScene(){
        SceneManager.LoadScene(fases[SceneManager.GetActiveScene().name].ToString());
	}

    void Start()
    {
        fases.Add("intro", "abertura");
        fases.Add("abertura", "menu");
        fases.Add("menu", "fase");
        // fases.Add("fase", "perda");
        fases.Add("perda", "reset");
        fases.Add("vitoria", "reset");
        fases.Add("reset", "menu");

        setStylePrd();
        setPtsStyle();
        setEndStyle();
        setSmaStyle();
        setTtrStyle();
    }

    void Update()
    {
    }
}