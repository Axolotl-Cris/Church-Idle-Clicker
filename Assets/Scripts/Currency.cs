using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour {
    
    public Text faithAmountText;
    public Text monkLvlText;
    
    public int faithPerClick = 5;

    private int _faithAmount;
    private int _monkLvl;
    
    void Start() {
        _faithAmount = PlayerPrefs.GetInt("Faith", 0);
        _monkLvl = PlayerPrefs.GetInt("MonkLvl", 0);
    }

    void OnDestroy() {
        PlayerPrefs.SetInt("Faith", _faithAmount);
        PlayerPrefs.SetInt("MonkLvl", _monkLvl);
    }

    // void Update() {
    //    faithAmountText.text = _faithAmount.ToString("You have 0 Faith");
    // }
    
    public int CupcakeAmount {
        get => this._faithAmount;
        set {
            _faithAmount = value;
            faithAmountText.text = value.ToString("You have 0 faith");
        } 
    }
    
    public int MonkLvl {
        get => this._monkLvl;
        set {
            _monkLvl = value;
            monkLvlText.text = value.ToString("Monk level: 0");
        } 
    }
    
    public void GainFaith() {
        _faithAmount += faithPerClick;
    }
}








