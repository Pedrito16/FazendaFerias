using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlores : MonoBehaviour
{
    [SerializeField] GameObject[] flores;
    [SerializeField] int tamanhoY, tamanhoX; //o tamanho do quadrado (coloquei 2 para poder escolher um retângulo
    [SerializeField] int numeroAleatorio;
    [SerializeField] private float distanciaEntreFlores;
    [SerializeField] RectTransform canvaTransform;
    [SerializeField] RectTransform florScale; // uma flor para ter base da escala básica, e ponto de partida do spawn
    private Coleta florScript;
    void Start()
    {
        for(int i = 0; i < tamanhoX; i++)
        {
            for (int j = 0; j < tamanhoY; j++)
            {
                float posX = i * distanciaEntreFlores;
                float posY = -j * distanciaEntreFlores;
                numeroAleatorio = Random.Range(0, flores.Length);
                Vector3 Pos = florScale.position + new Vector3(posX, posY, 0);
                GameObject flor = Instantiate(flores[numeroAleatorio], Pos, Quaternion.identity);
                flor.name = flores[numeroAleatorio].name;
                florScript = flor.GetComponent<Coleta>();
                florScript.id = numeroAleatorio;
                flor.transform.SetParent(canvaTransform);
                flor.transform.localScale = florScale.localScale;
            }
        }
    }
}
