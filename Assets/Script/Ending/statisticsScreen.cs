using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class statisticsScreen : MonoBehaviour
{

    public TMP_Text creditos_pulo;
    public TMP_Text creditos_queda;
    public TMP_Text creditos_bnuy;
    public TMP_Text creditos_guerreiro;
    public TMP_Text creditos_afogada;
    public TMP_Text creditos_anos;
    public TMP_Text creditos_death;

    [SerializeField] private GameObject pergaminho1;
    [SerializeField] private GameObject pergaminho2;
    [SerializeField] private GameObject pergaminho3;

    private int i = 0;
    private int calculaAnos;


    public GameObject statisticsPanel;
    
    void Start()
    {
            calculaAnos = Info_Player.deaths * 40;
            creditos_pulo.SetText( Info_Player.jumps.ToString() + " Times");
            creditos_queda.SetText(  Info_Player.death_fall.ToString()+ " Times");
            creditos_bnuy.SetText( Info_Player.death_enemy1.ToString()+ " Times");
            creditos_guerreiro.SetText( "Got you " +  Info_Player.death_enemy2.ToString()+ " Times");
            creditos_afogada.SetText( Info_Player.death_projectile1.ToString()+ " Times");
            creditos_anos.SetText( "You spent " + calculaAnos.ToString() + " years");
            creditos_death.SetText( "In " +  Info_Player.deaths.ToString() + " lives");
        
    }

    public void foda(){
        if(i == 0){
            pergaminho1.SetActive(false);
            pergaminho2.SetActive(true);
            i++;
          }
        else if(i == 1){
            pergaminho2.SetActive(false);
            pergaminho3.SetActive(true);
            i++;
        }
        else if(i == 2){
            SceneManager.LoadScene("Ending");
        }
    }

}
