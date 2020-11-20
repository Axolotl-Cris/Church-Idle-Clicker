using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{

    public GameObject logoText;

    public void Start()
    {
        logoText.SetActive(false);
    }

    public void OnMouseOver()
    {
        logoText.SetActive(true);
        Debug.Log("Mouse is over GameObject.");
    }

    public void OnMouseExit()
    {
        logoText.SetActive(false);
        Debug.Log("Mouse is no longer on GameObject.");
    }

}
