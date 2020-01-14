using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Ending : MonoBehaviour
{
    public VideoPlayer end;
    // Start is called before the first frame update
    void Start()
    {
        end.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Invoke("NextScene",1f);
    }
    void NextScene()
    {
        SceneManager.LoadScene(0);
    }
}
