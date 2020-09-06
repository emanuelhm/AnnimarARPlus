using UnityEngine;
using UnityEngine.UI;

public class ConfigurationBehavior : MonoBehaviour
{
    public ButtonBehavior ButtonBehaviorUp;

    public ButtonBehavior ButtonBehaviorDown;

    public MovementBehavior MovementBehavior;

    public Slider MovimentoSlider;

    public InputField MovimentoInput;

    public Slider TempoSlider;

    public InputField TempoInput;

    public void OnMovimentoSliderChange()
    {
        MovimentoInput.text = MovimentoSlider.value.ToString();
        MovementBehavior.Quantity = MovimentoSlider.value;
    }

    public void OnMovimentoInputChange()
    {
        if (float.TryParse(MovimentoInput.text, out float value))
        {
            MovimentoSlider.value = value;
            MovementBehavior.Quantity = value;
        }
        else
        {
            MovimentoInput.text = MovimentoSlider.value.ToString();
            MovementBehavior.Quantity = MovimentoSlider.value;
        }
    }

    public void OnTempoSliderChange()
    {
        TempoInput.text = TempoSlider.value.ToString();
        ButtonBehaviorUp.Time = TempoSlider.value;
        ButtonBehaviorDown.Time = TempoSlider.value;
    }

    public void OnTempoInputChange()
    {
        if (float.TryParse(TempoInput.text, out float value))
        {
            TempoSlider.value = value; 
            ButtonBehaviorUp.Time = value;
            ButtonBehaviorDown.Time = value;
        }
        else
        {
            TempoInput.text = TempoSlider.value.ToString();
            ButtonBehaviorUp.Time = TempoSlider.value;
            ButtonBehaviorDown.Time = TempoSlider.value;
        }
    }
}