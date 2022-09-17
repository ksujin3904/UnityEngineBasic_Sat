using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
     public void Onclick()
    {
        if (SongSelector.Instance.LoadSelectedSongData())
        {
            SceneMover.MoveTo("Play");
        }
    }
}
