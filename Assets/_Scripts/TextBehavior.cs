using UnityEngine;
using UnityEngine.UI;

public class TextBehavior : MonoBehaviour
{
    public Text TextComponent;

    public string DefaultText;

    public string AlternatedText;

    private bool isAlternated;

    private void Start()
    {
        TextComponent.text = DefaultText;
    }

    public void ToggleText()
    {
        if (isAlternated)
        {
            TextComponent.text = DefaultText;
        }
        else
        {
            TextComponent.text = AlternatedText;
        }

        isAlternated = !isAlternated;
    }
}