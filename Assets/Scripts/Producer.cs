using UnityEngine;
using UnityEngine.UI;

public class Producer : MonoBehaviour {
    public ProductionUnit productionUnit;
    
    public Text currentLevelText;
    public Text costText;
    public Text gainText;
    public Text perClickText;
    public Button upgradeButton;
    
    private float _elapsedTime;

    private bool CanGetUpgrades => productionUnit.costResource.ResourcesOwned >= productionUnit.CurrentCost(this.Level);

    void Start() {
        currentLevelText.text = this.Level.ToString("LVL 0");
        costText.text = $"{productionUnit.CurrentCost(this.Level)}";
        gainText.text = $"+{productionUnit.CurrentProduction(this.Level)}/SEC";
        perClickText.text = productionUnit.costResource.gainPerClick.ToString("+0/CLICK");
        UpdateLevelText();
    }

    void Update() {
        this._elapsedTime += Time.deltaTime;
        if (this._elapsedTime >= this.productionUnit.productionTime) {
            ProduceFaith();
            this._elapsedTime -= this.productionUnit.productionTime;
        }
        
        if (CanGetUpgrades) {
            costText.color = new Color(18f/255f, 18f/255f, 18f/255f);
            upgradeButton.interactable = true;
        } else { 
            costText.color = new Color(50f/255f, 50f/255f, 50f/255f);
            upgradeButton.interactable = false;
        }
    }
    
    void ProduceFaith() {
        productionUnit.productionResourse.ResourcesOwned += Mathf.RoundToInt(this.productionUnit.resourcesProduced * this.Level);
    }

    int Level {
        get => PlayerPrefs.GetInt(this.productionUnit.name, 0);
        set {
            PlayerPrefs.SetInt(this.productionUnit.name, value);
            UpdateLevelText();
        }
    }

    void UpdateLevelText() {
        this.currentLevelText.text = this.Level.ToString("LVL 0");
    }

    public void LvlUp() {
        if (productionUnit.costResource.ResourcesOwned >= productionUnit.CurrentCost(this.Level)) {
            productionUnit.costResource.ResourcesOwned -= productionUnit.CurrentCost(this.Level);
            this.Level += 1;
            costText.text = $"{productionUnit.CurrentCost(this.Level)}";
            gainText.text = $"+{productionUnit.CurrentProduction(this.Level)}/SEC";
        }
    }

    public void OnClickBoost() {
        if (productionUnit.costResource.ResourcesOwned >= productionUnit.CurrentCost(this.Level)) {
            productionUnit.costResource.ResourcesOwned -= productionUnit.CurrentCost(this.Level);
            productionUnit.costResource.gainPerClick += this.productionUnit.perClickIncrease;
            this.Level += 1;
            costText.text = $"{productionUnit.CurrentCost(this.Level)}";
            perClickText.text = productionUnit.costResource.gainPerClick.ToString("+0/CLICK");
        }
    }
}      