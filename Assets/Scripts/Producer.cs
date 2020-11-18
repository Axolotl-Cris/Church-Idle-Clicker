﻿using UnityEngine;
using UnityEngine.UI;

public class Producer : MonoBehaviour {
    public ProductionUnit productionUnit;
    public Text currentLevelText;
    public Text costText;
    public Text gainText;

    private float _elapsedTime;

    public Resource resource;

    void Start() {
        currentLevelText.text = productionUnit.lvl.ToString();
        costText.text = productionUnit.cost.ToString();
        gainText.text = productionUnit.resourcesProduced.ToString();
        UpdateLevelText();
    }

    void Update() {
        this._elapsedTime += Time.deltaTime;
        if (this._elapsedTime >= this.productionUnit.productionTime) {
            ProduceFaith();
            this._elapsedTime -= this.productionUnit.productionTime;
        }
    }

    void ProduceFaith() {
        resource.ResourcesOwned += this.productionUnit.resourcesProduced * this.Level;
        Debug.Log(this.productionUnit.resourcesProduced + " resources produced");
        Debug.Log(this.Level + " level"); 
    }

    int Level {
        get => PlayerPrefs.GetInt(this.productionUnit.name, 0);
        set {
            PlayerPrefs.SetInt(this.productionUnit.name, value);
            UpdateLevelText();
        }
    }

    void UpdateLevelText() {
        this.currentLevelText.text = this.Level.ToString($"Lvl 0");
    }

    public void LvlUp() {
        if (resource.ResourcesOwned >= this.productionUnit.cost) {
            resource.ResourcesOwned -= this.productionUnit.cost;
            this.Level += 1;
        }
    }

    public void OnClickBoost() {
        if (resource.ResourcesOwned >= this.productionUnit.cost) {
            resource.ResourcesOwned -= this.productionUnit.cost;
            resource.gainPerClick += this.productionUnit.onClickBoost;
            this.Level += 1;
        }
    }
}      