using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GUISkin layout;
    Hashtable fases = new Hashtable();
    GameObject[] naves;
	private GUIStyle guiStylePts = new GUIStyle();
	private GUIStyle guiStyleTtr = new GUIStyle();
    private GUIStyle guiStyleEnd = new GUIStyle();
    private GUIStyle guiStyleSma = new GUIStyle();
    private GUIStyle guiStylePrd = new GUIStyle();

    private bool invadido = false;

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
		guiStylePts.normal.textColor = Color.green;

		Texture2D debugTex = new Texture2D(1,1);
	  	debugTex.SetPixel(0,0, Color.yellow);
	  	debugTex.Apply();

		guiStylePts.normal.background = debugTex;
	}

    private void setTtrStyle(){
		guiStyleTtr.fontSize = 22;
		guiStyleTtr.normal.textColor = Color.blue;

		Texture2D debugTex = new Texture2D(1,1);
	  	debugTex.SetPixel(0,0, Color.green);
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
		guiStyleSma.normal.textColor = Color.red;		

		Texture2D debugTex = new Texture2D(1,1);
	  	debugTex.SetPixel(0,0, new Color(0.0f, 0.0f, 0.0f, 0.3f));
	  	debugTex.Apply();

		guiStyleSma.normal.background = debugTex;
	}

    public void AddScore(int score){
        ScoreManager.pontuacoes[faseAtual()].pontos += score;
    }

    public void hit(){
        ScoreManager.pontuacoes[faseAtual()].vidas -= 1;
    }

    public void ResetScore(){
        ScoreManager.resetPontuacoes();
    }

    private int faseAtual(){
		if(SceneManager.GetActiveScene().name == "Fase1")
        {
			return 0;
        }
		else if(SceneManager.GetActiveScene().name == "Fase2")
        {
			return 1;
        }
		else
		{
			return -1;
		}
	}

    private void changeScene(){
        SceneManager.LoadScene(fases[SceneManager.GetActiveScene().name].ToString());
	}

    private void searchNaves(){
        naves = GameObject.FindGameObjectsWithTag("nave");
	}

    public void invasao(){
        invadido = true;
    }

    void showPlacar(){
		GUI.Label(new Rect(22, Screen.height-2 - 22, 280, 22), "Vidas: " + ScoreManager.pontuacoes[faseAtual()].vidas + " ||| Pontos: " + ScoreManager.pontuacoes[faseAtual()].pontos, guiStylePts);
	}

	void OnGUI () 
    {
	    GUI.skin = layout;

        if (GUI.Button(new Rect(Screen.width - 80, Screen.height - 40, 60, 22), "Pular"))
        {
            Invoke("changeScene", 0.5f);
        }
	}

    public void derrotado(){
        ScoreManager.resetPontuacoes();
        SceneManager.LoadScene("perda");
    }

    private void readNaves(){
		naves = GameObject.FindGameObjectsWithTag("nave");
	}

    private void RestartGameManager(){
        ScoreManager.resetPontuacoes();
		Invoke("changeScene", 1);
	}

    void Start()
    {
        fases.Add("intro", "abertura");
        fases.Add("abertura", "menu");
        fases.Add("menu", "fase");
        fases.Add("fase", "perda");
        fases.Add("perda", "vitoria");
        fases.Add("vitoria", "reset");
        fases.Add("reset", "menu");

        setStylePrd();
        searchNaves();   
        setPtsStyle();
        setEndStyle();
        setSmaStyle();
        setTtrStyle();
        readNaves();
    }

    void Update()
    {
		readNaves();
    }
}