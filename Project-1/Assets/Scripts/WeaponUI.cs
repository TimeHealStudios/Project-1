using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    public TextMeshProUGUI weaponNameText;
    public TextMeshProUGUI ammoText;

    void Start()
    {
        // Placeholder setup
        weaponNameText.text = "Shrimp Gun";
        ammoText.text = "?? / ??";
    }

    // Optional: later your friend can call this when ammo changes
    public void UpdateWeaponUI(string weaponName, int ammo, int maxAmmo)
    {
        weaponNameText.text = weaponName;
        ammoText.text = ammo + " / " + maxAmmo;
    }
}
