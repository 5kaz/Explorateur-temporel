using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKeySystem : MonoBehaviour
{
    public List<string> KeysList;
    private List<Image> KeysUIList;

    [SerializeField] private Image[] keyImage;
    private GameObject CanvasUI;
    [SerializeField] private int keySpacing;
    [SerializeField] private Vector3 firstKeyPosition;

    [SerializeField] private Dictionary<string, Image> mapStringkeyUI = new Dictionary<string, Image>();
    // Start is called before the first frame update
    void Start()
    {
        KeysUIList = new List<Image>();
        CanvasUI = GameObject.Find("Canvas Key");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetKey(string _color)
    {
        Debug.Log("GET Key " + _color);
        KeysList.Add(_color);

        int index = 0;
        switch (_color)
        {
            case "orange":
                index = 0;
                break;
            case "green":
                index = 1;
                break;
            case "purple":
                index = 2;
                break;
            case "blue":
                index = 3;
                break;
            case "pink":
                index = 4;
                break;
            case "red":
                index = 5;
                break;
        }
        Image keyImageID = Instantiate(keyImage[index], CanvasUI.transform);

        mapStringkeyUI.Add(_color, keyImageID);

        keyImageID.transform.position = keyImageID.transform.position + new Vector3(keySpacing * KeysUIList.Count, 0,0);

        KeysUIList.Add(keyImageID);
    }

    public bool CanUseKey(string _color)
    {
        if (KeysList.Contains(_color))
        {
            KeysList.Remove(_color);

            KeysUIList.Remove(mapStringkeyUI[_color]);
            Destroy(mapStringkeyUI[_color]);

            int index = 0;
            foreach ( Image keyID in KeysUIList)
            {
                keyID.transform.position = firstKeyPosition + new Vector3(keySpacing * index, 0, 0);
                index++;
            }

            return true;
        } else
        {
            return false;
        }
    }
}
