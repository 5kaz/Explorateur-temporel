using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeySystem : MonoBehaviour
{
    public List<string> KeysList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetKey(string _color)
    {
        Debug.Log("GET Key " + _color);
        KeysList.Add(_color);
    }

    public bool CanUseKey(string _color)
    {
        if (KeysList.Contains(_color))
        {
            KeysList.Remove(_color);
            return true;
        } else
        {
            return false;
        }
    }
}
