using UnityEngine;

[CreateAssetMenu]
public class Resource : ScriptableObject {

    public int gainPerClick = 5;

    public int ResourcesOwned {
        get => PlayerPrefs.GetInt(this.name, 12);
        set => PlayerPrefs.SetInt(this.name, value);
    }

    public void GainResource() {
        ResourcesOwned += gainPerClick;
    }
}








