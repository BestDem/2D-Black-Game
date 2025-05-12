using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    //создание синглтона для гарантирования существования единственного объекта конкретного класса
    public static CutsceneManager Instance;

   [SerializeField] private List<CutsceneStruct> cutscenes = new List<CutsceneStruct>();

    //можно вызывать из любого скрипта метод с помощью CutsceneManager.cutsceneDataBase["ключ"]
    //CutsceneManager.Instance.StartCutscene("ключ")
    public static Dictionary<string, GameObject> cutsceneDataBase = new Dictionary<string, GameObject>();

    //информация об активной на данный момент сцене
   public static GameObject activeCutscene;

    private void Awake()
    {
        Instance = this;

        InitializeCutsceneDataBase();

        foreach (var cutscene in cutsceneDataBase)
        {
            cutscene.Value.SetActive(false);
        }
    }   

    private void InitializeCutsceneDataBase()
    {
        cutsceneDataBase.Clear();

        for (int i = 0; i < cutscenes.Count; i++)
        {           
            //заполнение данными
            cutsceneDataBase.Add(cutscenes[i].cutsceneKey, cutscenes[i].cutsceneObject);
        }
    }

    public void StartCutscene(string cutsceneKey)
    {
        if (!cutsceneDataBase.ContainsKey(cutsceneKey)) 
        {
            return;
        } 

        if (activeCutscene != null)
        {
            if (activeCutscene == cutsceneDataBase[cutsceneKey])
            {
                return;
            }
        }

        activeCutscene = cutsceneDataBase[cutsceneKey];

        foreach (var cutscene in cutsceneDataBase)
        {
            cutscene.Value.SetActive(false);
        }
        playerMovement.SetCanMove(false);

        cutsceneDataBase[cutsceneKey].SetActive(true);
    }

    public void EndCutscene()
    {
        if (activeCutscene != null)
        {
            activeCutscene.SetActive(false);
            activeCutscene = null;
            playerMovement.SetCanMove(true);
        }
    }
}

[System.Serializable]
public struct CutsceneStruct
{
    public string cutsceneKey;
    public GameObject cutsceneObject;
}
