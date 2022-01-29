using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test2 : MonoBehaviour
{

    public Sprite srcSprite;

    void Start()
    {
        Init();

        var img = transform.parent.Find("Image");
        var btn = img.gameObject.AddComponent<Button>();
        btn.transition = Selectable.Transition.None;
        btn.onClick.AddListener(Hello2);
    }

    void Init()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                CreateSprite(i, j);
            }
        }
    }

    void CreateSprite(int i, int j)
    {
        GameObject go = new GameObject(i.ToString()+j+ToString());
        go.AddComponent<Image>().sprite = srcSprite;
        
        go.transform.SetParent(transform, false);
    }

    public void Hello(GameObject i)
    {
        i.transform.Translate(0, 4f, 0);
    }

    public void Hello2()
    {
        Debug.Log("Test2.Hello2 call!");
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 80, 20), "Main"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
