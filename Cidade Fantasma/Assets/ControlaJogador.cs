using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    public float Velocidade = 10;
    Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public GameObject PainelDeWin;
    public int Vida = 5;
    public ControlaInterface scriptControlaInterface;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxisRaw("Horizontal");
        float eixoZ = Input.GetAxisRaw("Vertical");

        direcao = new Vector3 (eixoX, 0, eixoZ);

        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Movendo", true);
        } else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }

        

    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = direcao.normalized * Velocidade;
        //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Velocidade * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;
        if (Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRrotacao = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(novaRrotacao);
        }
    }

    public void TomarDano()
    {
        Vida -= 1;
        scriptControlaInterface.AtualizarSliderVidaJogador();
        if (Vida == 0)
        {
            Time.timeScale = 0;
            scriptControlaInterface.GameOver();
        }

        
    }
   
}
