using UnityEngine;

public class Credits : MonoBehaviour
{

    public GameObject creditsText;

    public void ShowCreds()
    {
        creditsText.SetActive(true);
    }
    public void HideCreds()
    {
        creditsText.SetActive(false);
    }

}
