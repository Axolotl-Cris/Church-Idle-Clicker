using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour {
    
    public Text faithAmountText;
    
    public int faithPerClick = 5;

    private int _faithAmount;
    
    void Start() {
        FaithAmount = PlayerPrefs.GetInt("Faith", 0);
    }

    void OnDestroy() {
        PlayerPrefs.SetInt("Faith", FaithAmount);
    }
    
    
    public int FaithAmount {
        get => this._faithAmount;
        set {
            _faithAmount = value;
            faithAmountText.text = value.ToString("You have 0 faith");
        } 
    }
    
    
    public void GainFaith() {
        FaithAmount += faithPerClick;
    }
}








