using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atividade1 : MonoBehaviour
{
    //faça um script que a cada clique do mouse adicione 1, mas a cada 5 cliques 
    //faça uma particula spawnar na posição do mouse
    [SerializeField] int clickQuantidade;
    [SerializeField] int click5;
    [SerializeField] ParticleSystem particula;
    [SerializeField] Transform mousePositionOBJ;
    void Start()
    {
        particula.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickQuantidade++;
            click5++;
        }
        if (click5 == 5)
        {
            StartCoroutine(particulaActivate());
            click5 = 0;
        }
        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos3 = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos3.z = -1;
        mousePositionOBJ.position = mousePos3;
    }
    public IEnumerator particulaActivate()
    {
        particula.gameObject.SetActive(true);
        particula.Play();
        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos3 = Camera.main.ScreenToWorldPoint(mousePos);
        particula.transform.position = mousePos3;
        yield return new WaitForSeconds(1);
        particula.gameObject.SetActive(false);
    }

}
