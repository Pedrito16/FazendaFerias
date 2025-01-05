using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class ShowFlowerUI : MonoBehaviour
{
    [SerializeField] GameObject showFlower;
    [SerializeField] Sprite[] flowerSprites;
    [SerializeField] int uiQuantity;
    TextMeshProUGUI flowerName;
    [SerializeField] RectTransform spawnTransform;

    [SerializeField] bool isCollecting;
    [SerializeField] bool inactive;

    [SerializeField] float secondsDestroy;
    [SerializeField] private float timer = 0;
    public delegate void AddInventario(int id);
    public AddInventario addInventario;
    void Start()
    {
        uiQuantity = 0;
    }
    private void Update()
    {
        if (!isCollecting && !inactive)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 5)
        {
            uiQuantity = 0;
            timer = 0;
            inactive = true;
        }
    }
    public void OnCollect(string name, int id)
    {
        GameObject flowerUILocal = Instantiate(showFlower, spawnTransform.position, spawnTransform.rotation);
        uiQuantity++;
        Image flowerImage = flowerUILocal.GetComponent<Image>();
        isCollecting = true;
        inactive = false;
        RectTransform canvaTransform = GetComponentInParent<RectTransform>();
        flowerName = flowerUILocal.GetComponentInChildren<TextMeshProUGUI>();

        addInventario?.Invoke(id);

        if (uiQuantity > 5)
        {
            uiQuantity = 1;
        }

        flowerUILocal.transform.SetParent(canvaTransform);
        flowerImage.sprite = flowerSprites[id];
        flowerName.text = name;
        flowerUILocal.transform.position = spawnTransform.position + new Vector3(0, 60 * -uiQuantity, 0);

        Destroy(flowerUILocal,  secondsDestroy);
        StartCoroutine(End());
    }
    IEnumerator End()
    {
        //arrumar essa parte amanhã (talvez se colocar um if que aciona com bool)
        yield return new WaitForSeconds(secondsDestroy);
        isCollecting = false;
        timer = 0;
    }
}
