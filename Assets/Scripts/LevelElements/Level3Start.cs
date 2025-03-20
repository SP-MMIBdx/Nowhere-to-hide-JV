using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Start : MonoBehaviour
{
    HudManager hud => HudManager.instance;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(WaitOneFrame());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitOneFrame(){
        yield return null;
        hud.showTimedMessage("Level 3");

    }
}