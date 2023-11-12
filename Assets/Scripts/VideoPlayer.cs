using Articy.Alchemyjam.GlobalVariables;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayer : MonoBehaviour
{

    private VideoPlayer vidPlayer;

    [Header("Basic Animations")]
    public VideoClip idleClip;


    public VideoClip oasisClip;
    public VideoClip villageClip;


    private void Awake()
    {
        vidPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Crossroads()
    {
        if (ArticyGlobalVariables.Default.playerVars.goOasis)
        {

        }
    }

}
