using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public CanvasScaler canvasScale;
    Vector2 sixteenByNine = new Vector2 (1600, 900);
    Vector2 fullHD = new Vector2(1920, 1080);

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ChangeResolution()
    {
        canvasScale.referenceResolution = sixteenByNine;
    }

    public void FullHD()
    {
        canvasScale.referenceResolution = fullHD;
    }
}
