using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public int i = 0;
    delegate void Cycle();
    public GameObject crewmate;
    public GameObject skin;
    void Start()
    {
        crewmate = GameObject.Find(Constants.CREWMATE_OBJECT);
        skin = GameObject.Find(Constants.SKIN_OBJECT);

        crewmate.GetComponent<Image>().sprite = Cosmetics.UpdateSprite();
        skin.GetComponent<Image>().sprite = Cosmetics.UpdateSkin();
    }

    public void LeftButton()
    {
        Cycle cycle = () =>
        {
            i--;
            if (i < 0)
            {
                i = Constants.SKINS.Length - 1;
            }
        };
        SelectSkin(cycle);
    }

    public void RightButton()
    {
        Cycle cycle = () =>
        {
            i++;
            if (i == Constants.SKINS.Length)
            {
                i = 0;
            }
        };
        SelectSkin(cycle);
    }

    private void SelectSkin(Cycle cycle)
    {
        char[] owned = Constants.SKIN_OWNED_MASK.ToCharArray();
        if (PlayerPrefs.HasKey(Constants.SKIN_OWNED_KEY))
        {
            owned = PlayerPrefs.GetString(Constants.SKIN_OWNED_KEY).ToCharArray();
        }
        do
        {
            cycle();
        } while (owned[i] == '0');
        PlayerPrefs.SetInt(Constants.SKIN_SELECTED_KEY, i);
        PlayerPrefs.Save();
        skin.GetComponent<Image>().sprite = Cosmetics.UpdateSkin();
    }

    public void UpdateSprite()
    {
        crewmate.GetComponent<Image>().sprite = Cosmetics.UpdateSprite();
    }

    public void UpdateSkin()
    {
        skin.GetComponent<Image>().sprite = Cosmetics.UpdateSkin();
    }
}
