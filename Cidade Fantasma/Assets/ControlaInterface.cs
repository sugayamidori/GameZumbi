using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour
{

    private ControlaJogador scriptControlaJogador;
    public Slider SliderVidaJogador;
    public GameObject PainelDeGameOver;
    public GameObject TextDeWin;

    // Start is called before the first frame update
    void Start()
    {
        scriptControlaJogador = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();

        SliderVidaJogador.maxValue = scriptControlaJogador.Vida;
        AtualizarSliderVidaJogador();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AtualizarSliderVidaJogador()
    {
        SliderVidaJogador.value = scriptControlaJogador.Vida;
    }

    public void GameOver()
    {
        PainelDeGameOver.SetActive(true);
    }

    public void Reiniciar ()
    {
        SceneManager.LoadScene("game");
    }

     void OnTriggerEnter(Collider other)
    {
        // Verificar se o objeto que entrou em contato é um Empty
        if (other.gameObject.CompareTag("Cerca_Destruido_Passagem"))
        {
            EncerrarJogo();
        }
    }

    void EncerrarJogo()
    {
        Time.timeScale = 0;
        TextDeWin.SetActive(true);
    }
}
