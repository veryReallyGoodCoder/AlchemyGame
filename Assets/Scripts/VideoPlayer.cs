using Articy.Alchemyjam.GlobalVariables;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayer : MonoBehaviour
{

    private VideoPlayer vidPlayer;
    
    public VideoClip idleClip;
    public VideoClip oasisClip;
    public VideoClip villageClip;


    private void Awake()
    {
        vidPlayer = GetComponent<VideoPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
