using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class Opening : MonoBehaviour
{
    public VideoPlayer start;
    // Start is called before the first frame update
    void Start()
    {
        start.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Invoke("NextScene",1f);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(2);
    }
}
