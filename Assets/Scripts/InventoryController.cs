using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] floresTextos;
    [SerializeField] int[] numerosFlores;

    [SerializeField] private ShowFlowerUI showFlowerUI;
    // Start is called before the first frame update
    void Start()
    {
        showFlowerUI.addInventario += AdicionarFlor;
        int resetNumber = 0;
        foreach(var textos in floresTextos)
        {
            textos.text = resetNumber.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AdicionarFlor(int id)
    {
        numerosFlores[id]++;
        floresTextos[id].text = numerosFlores[id].ToString();
    }
}
