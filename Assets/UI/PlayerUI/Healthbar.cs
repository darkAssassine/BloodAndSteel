using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private Health health;

    [SerializeField]
    private RectMask2D peddingMask;

    [SerializeField]
    private RectTransform barRec;

    private void Update()
    {
        peddingMask.padding = new Vector4(0,0,barRec.rect.width - barRec.rect.width * ((float)health.CurrentHp / (float)health.MaxHp), 0);
    }
}
