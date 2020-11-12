using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {
    
    public int faithAmount;
    void Start() {
        faithAmount = PlayerPrefs.GetInt("Cupcakes", 0);
    }

    void OnDestroy() {
        PlayerPrefs.SetInt("Cupcakes", faithAmount);
    }
}
