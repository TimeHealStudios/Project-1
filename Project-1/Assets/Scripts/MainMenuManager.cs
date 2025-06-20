using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject startMenu;
    public GameObject weaponSelectMenu;

    [Header("Player & Weapon Setup")]
    public GameObject player;
    public Transform weaponHolder;
    public GameObject[] weaponPrefabs;

    [Header("UI References")]
    public WeaponUI weaponUI; // Drag the WeaponUI Controller here in Inspector

    void Start()
    {
        Time.timeScale = 0f;
        player.SetActive(false);

        startMenu.SetActive(true);
        weaponSelectMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnStartButton()
    {
        startMenu.SetActive(false);
        weaponSelectMenu.SetActive(true);
    }

    public void OnChooseWeapon(int index)
    {
        // Clear old weapons
        foreach (Transform child in weaponHolder)
        {
            Destroy(child.gameObject);
        }

        GameObject weapon = Instantiate(weaponPrefabs[index], weaponHolder);
        weapon.transform.localPosition = new Vector3(0.23f, 1.18f, 0.6f);
        weapon.transform.localRotation = Quaternion.identity;
        weapon.name = weaponPrefabs[index].name; // Removes (Clone)

        // Assign UI
        Gun gun = weapon.GetComponent<Gun>();
        if (gun != null && weaponUI != null)
        {
            gun.SetWeaponUI(weaponUI);
        }

        // Resume gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        weaponSelectMenu.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1f;
    }
}
