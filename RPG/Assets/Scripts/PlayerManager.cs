using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;   //Keep track of the player

    public void KillPlayer()
    {
        //Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
