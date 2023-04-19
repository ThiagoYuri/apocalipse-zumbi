using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlarJogador : MonoBehaviour
{
    public float Velocidade = 10;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public bool Vivo = true;
    private Rigidbody jogador;
    private Animator animator;
    private Vector3 direcao;
    void Start(){
        jogador = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
        Vivo  = true;
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ =  Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX,0,eixoZ);

        if(direcao !=  Vector3.zero){
            animator.SetBool("Movendo",true);
        }else{
            animator.SetBool("Movendo",false);
        }

        if(Vivo == false){
            if(Input.GetButtonDown("Fire1")){
                SceneManager.LoadScene("Fase1");
            }
        }
    }

    void FixedUpdate() {        
       jogador.MovePosition
        (jogador.position +
        (direcao* Velocidade * Time.deltaTime));      
        
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction*100, Color.red);

        RaycastHit impacto;

        if(Physics.Raycast(raio, out impacto, 100, MascaraChao)){
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = 0;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            jogador.MoveRotation(novaRotacao);
        }
    }
}
