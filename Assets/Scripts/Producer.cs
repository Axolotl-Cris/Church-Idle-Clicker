using UnityEngine;
using UnityEngine.UI;

public class Producer : MonoBehaviour
{
    public ProductionUnit productionUnit;
    public Text currentLevelText;
    public Text costText;
    public Text gainText;

    private float _elapsedTime;
    
    void Start()
    {
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
        var faith = FindObjectOfType<Resource>();
        faith.ResourcesOwned += this.productionUnit.resourcesProduced * this.Level;
    }
    
    int Level {
        get => PlayerPrefs.GetInt("Lvl", 0);
        set {
            PlayerPrefs.SetInt("Lvl", value);
            UpdateLevelText();
        }
    }
    
    void UpdateLevelText() {
        this.currentLevelText.text = this.Level.ToString($"Lvl 0");
    }
 
    public void LvlUp() {
        var faith = FindObjectOfType<Resource>();
        if (faith.ResourcesOwned >= this.productionUnit.cost) {
            faith.ResourcesOwned -= this.productionUnit.cost;
            this.Level += 1;
        }
    }

}
