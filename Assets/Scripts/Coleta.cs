using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Coleta : MonoBehaviour
{
    [SerializeField] Animator coletaAnim;
    public int id;
    private Image itemSprite;
    private RectTransform rectTransform;
    public string nomeFlor;
    [SerializeField] ShowFlowerUI showFlowerUI;
    [HideInInspector] public int uiNumber;
    void Start()
    {
        showFlowerUI = FindObjectOfType<ShowFlowerUI>();
        GetComponent<Button>().onClick.AddListener(Collect);
        GetComponent<Button>().onClick.AddListener(() => showFlowerUI.OnCollect(nomeFlor, id));
        itemSprite = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        nomeFlor = gameObject.name;
    }
    void Collect()
    {
        StartCoroutine(CollectAction());
    }
    IEnumerator CollectAction()
    {
        Vector3 startPos = rectTransform.position; 
        float elapsedTime = 0f; //o numero usado no Lerp
        Vector3 finalPos = new Vector3(rectTransform.position.x, rectTransform.transform.position.y + 3, rectTransform.transform.position.z);
        Animator animation = Instantiate(coletaAnim, transform.position, transform.rotation);
        SpriteRenderer coletaSprite = animation.GetComponent<SpriteRenderer>();
        itemSprite.enabled = false;
        animation.SetTrigger("Coletar");
        coletaSprite.sprite = itemSprite.sprite;
        while( elapsedTime < 1)
        {
            animation.transform.position = Vector3.Lerp(startPos, finalPos, elapsedTime / 1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        FlowerQuantity.flowerCount++;
        Destroy(animation.gameObject);
        Destroy(gameObject);
    }
}

public static class FlowerQuantity
{
    public static int flowerCount = 0;
}