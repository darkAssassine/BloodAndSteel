using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LosingScreenText : MonoBehaviour
{
    [SerializeField]
    private string[] sayings;

    [SerializeField]
    private TMPro.TextMeshProUGUI textElement;

    private void OnEnable()
    {
        int index = Random.Range(0, sayings.Length);
        textElement.text = sayings[index];
    }
}
