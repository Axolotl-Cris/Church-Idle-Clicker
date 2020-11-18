using UnityEngine;

[CreateAssetMenu]
public class Resource : ScriptableObject {

    public int gainPerClick = 5;

    public int ResourcesOwned {
        get => PlayerPrefs.GetInt(name, 0);
        set => PlayerPrefs.SetInt(name, value);
    }

    public void GainResource() {
        ResourcesOwned += gainPerClick;
    }
}









