using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    public bool isShow = false;
    public virtual void Show()
    {
        isShow = true;
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        isShow = true;
        gameObject.SetActive(false);
    }
    public void SoundClickButton()
    {
        SoundMusicManager.instance.Click();
    }
}
