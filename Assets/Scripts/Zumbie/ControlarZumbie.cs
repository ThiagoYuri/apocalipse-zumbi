using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarZumbie : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade = 1;
    private Animator animator;
    private Rigidbody rigidbodyZumbie;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");    
        int geraTipoZumbie = Random.Range(1,28);
        transform.GetChild(geraTipoZumbie).gameObject.SetActive(true);
        rigidbodyZumbie = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {     
            if(!(Jogador == null))   
            {             
                float distancia = Vector3.Distance(transform.position, Jogador.transform.position); 
                Vector3 direcao = Jogador.transform.position - transform.position;  
                Quaternion novaRotacao = Quaternion.LookRotation(direcao);
                rigidbodyZumbie.MoveRotation(novaRotacao);      
                if(distancia > 2.9){                   
                    rigidbodyZumbie.MovePosition(rigidbodyZumbie.position + direcao.normalized * Velocidade*Time.deltaTime);      
                    animator.SetBool("Atacando",false);
                } else{
                    animator.SetBool("Atacando",true);
                }
            }                 
    }


    void AtacaJogador(){
        if(!(Jogador == null))   
        {  
            Time.timeScale = 0;
            Jogador.GetComponent<ControlarJogador>().TextoGameOver.SetActive(true);
            Jogador.GetComponent<ControlarJogador>().Vivo = false;
        }
    }
}
