using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject weaponSelectMenu;

    public GameObject player; // to enable after choosing weapon
    public GameObject[] weaponPrefabs; // ShrimpGun, Rifle
    public Transform weaponSpawnPoint;

    void Start()
    {
        Time.timeScale = 0f; // freeze game at start
        player.SetActive(false); // disable player
    }

    public void OnStartButton()
    {
        startMenu.SetActive(false);
        weaponSelectMenu.SetActive(true);
    }

    public void OnChooseWeapon(int index)
    {
        Instantiate(weaponPrefabs[index], weaponSpawnPoint.position, weaponSpawnPoint.rotation, player.transform);
        weaponSelectMenu.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1f; // unfreeze game
    }
}
