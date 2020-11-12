using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour {

    public int faithAmount;
    public Text faithAmountText;
    
    void Start() {
        faithAmount = PlayerPrefs.GetInt("Cupcakes", 0);
    }

    void OnDestroy() {
        PlayerPrefs.SetInt("Cupcakes", faithAmount);
    }

    void Update() {
        faithAmountText.text = faithAmount.ToString("You have 0 Faith");
    }
    
    public void GainFaith() {
        faithAmount += 5;
    }
}








