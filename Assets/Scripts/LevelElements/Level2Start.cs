using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Start : MonoBehaviour
{
    HudManager hud => HudManager.instance;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitOneFrame());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitOneFrame(){
        yield return null;
        hud.showTimedMessage("Level 2");

    }
}
