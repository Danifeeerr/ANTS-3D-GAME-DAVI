using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class UIController : MonoBehaviour
{
    public GameObject followersText;
    public GameObject restartButton;

    private void OnEnable()
    {
        EventController.FollowersUpdate += followersUpdate;
        EventController.MatchLost += enableRestartButton;
        EventController.MatchWon += enableRestartButton;
    }

    private void OnDisable()
    {
        EventController.FollowersUpdate -= followersUpdate;
        EventController.MatchLost -= enableRestartButton;
        EventController.MatchWon -= enableRestartButton;
    }
    public void disableObject(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void enableObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    
    public void reloadScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void exitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void enableRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void followersUpdate(float count)
    {
        followersText.GetComponent<TextMeshProUGUI>().text = "Followers: " + count + "/8";
        if (count > 7)
        {
            followersText.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        else
        {
            followersText.GetComponent<TextMeshProUGUI>().color = Color.black;
        }
    }
}
