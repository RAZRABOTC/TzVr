using TMPro;
using UnityEngine;

public class HintUI : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    public void Show(string text)
    {
        label.text = text;
    }
}