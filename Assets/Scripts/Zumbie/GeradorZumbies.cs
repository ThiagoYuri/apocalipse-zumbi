using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbies : MonoBehaviour
{
    public GameObject Zumbie;
    float contadorTempo = 0;
    public float TempoGerarZumbi = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        contadorTempo += Time.deltaTime;

        if(contadorTempo >= TempoGerarZumbi){
            Instantiate(Zumbie,transform.position, transform.rotation);
            contadorTempo = 0;
        }
    }
}
