using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject startMenu;
    public GameObject weaponSelectMenu;

    [Header("Player & Weapon Setup")]
    public GameObject player;                // Player GameObject to enable/disable
    public Transform weaponHolder;           // The transform (usually camera or hand) where weapon will be parented
    public GameObject[] weaponPrefabs;       // List of weapon prefabs (ShrimpGun, Rifle, etc.)

    void Start()
    {
        Time.timeScale = 0f;  // Freeze game time at start
        player.SetActive(false);  // Disable player controls
        startMenu.SetActive(true);
        weaponSelectMenu.SetActive(false);
    }

    // Called when "Start" button is clicked
    public void OnStartButton()
    {
        startMenu.SetActive(false);
        weaponSelectMenu.SetActive(true);
    }

    // Called when player chooses a weapon (index corresponds to weaponPrefabs)
    public void OnChooseWeapon(int index)
    {
        // Destroy old weapon(s) in weaponHolder so we don't stack
        foreach (Transform child in weaponHolder)
        {
            Destroy(child.gameObject);
        }

        // Instantiate selected weapon as child of weaponHolder
        GameObject weapon = Instantiate(weaponPrefabs[index], weaponHolder);

        // Reset local position and rotation so it aligns properly in hands
        weapon.transform.localPosition = new Vector3(0.2301598f, 1.182273f, 0.6010823f);
        weapon.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        // Hide weapon select menu, enable player and unfreeze game
        weaponSelectMenu.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1f;
    }
}
