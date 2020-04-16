using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour
{
    private GameObject[] personajes;
    private int index;
    private void Start()
    {
        index = PlayerPrefs.GetInt("Seleccionado");

        personajes = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            personajes[i]= transform.GetChild(i).gameObject;
        }
        foreach (GameObject p in personajes){p.SetActive(false);}
        if (personajes[index]) { personajes[index].SetActive(true); }
    }
    public void Left()
    {
        personajes[index].SetActive(false);
        index--;
        if (index < 0) { index = personajes.Length - 1; }
        personajes[index].SetActive(true);
    }
    public void Right()
    {
        personajes[index].SetActive(false);
        index++;
        if (index == personajes.Length) { index = 0; }
        personajes[index].SetActive(true);
    }
    public void Confirm() 
    {
        PlayerPrefs.SetInt("Seleccionado", index);
        SceneManager.LoadScene("World 1"); 
    }
}

