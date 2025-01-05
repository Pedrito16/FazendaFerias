using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    Vector3 targetPos;
    [SerializeField] float duration;
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Atividade2 player = collision.GetComponent<Atividade2>();
            player.stopPlayer = true;
            targetPos = transform.position;
            StartCoroutine(Animation(player));
        }
    }
    IEnumerator Animation(Atividade2 player)
    {
        float elapsedTime = 0f; //numero usado no lerp
        while(elapsedTime < duration)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cam.transform.position = targetPos;
        player.stopPlayer = false;
    }
}
