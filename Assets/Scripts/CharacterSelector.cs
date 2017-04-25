using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour {

    public List<GameObject> characterList;
    public int index = 0;
    public string LevelToLoad; // String variable to hold name of Scene to load.

    // Use this for initialization
    void Start () {

        GameObject[] characters = Resources.LoadAll<GameObject>("Prefab");

        foreach(GameObject c in characters)
        {
            GameObject _char = Instantiate(c) as GameObject;
            _char.transform.SetParent(GameObject.Find("CharacterList").transform);

            characterList.Add(_char);
            _char.SetActive(false);
            characterList[index].SetActive(true);
        }

        PlayerPrefs.SetInt("Character", index);
    }
	
    public void Next()
    {
        characterList[index].SetActive(false);

        if (index == characterList.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        characterList[index].SetActive(true);

        PlayerPrefs.SetInt("Character", index);
    }

    public void Previous()
    {
        characterList[index].SetActive(false);

        if (index == 0)
        {
            index = characterList.Count - 1;
        }
        else
        {
            index--;
        }

        characterList[index].SetActive(true);

        PlayerPrefs.SetInt("Character", index);
    }

    // On Mouse Click Method.
    public void OnClick()
    {
        print(PlayerPrefs.GetInt("Character"));

        // Load Level from string passed in.
        SceneManager.LoadScene(LevelToLoad);
    }
}
