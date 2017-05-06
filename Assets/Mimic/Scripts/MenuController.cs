using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public MiButtonMenu[] Menus;

    private bool _modified = false;
    private string _loadedFile;


    #region Button Message Events
    public void ShowMenu(string sender)
    {
        Debug.Log("Show menu: " + sender);
    }

    public void HideMenu(string sender)
    {
        Debug.Log("Hide menu: " + sender);
    }

    public void NewMimic(string sender)
    {
        Debug.Log("New mimic: " + sender);
    }

    public void CancelNew(string sender)
    {
        Debug.Log("Cancel new: " + sender);
    }

    public void ConfirmNew(string sender)
    {
        Debug.Log("Confrm new: " + sender);
    }

    public void LoadMimic(string sender)
    {
        Debug.Log("Load mimic: " + sender);
    }

    public void CancelLoad(string sender)
    {
        Debug.Log("Cancel load: " + sender);
    }

    public void ConfirmLoad(string sender)
    {
        Debug.Log("Confirm load: " + sender);
    }

    public void SaveMimic(string sender)
    {
        Debug.Log("Save mimic: " + sender);
    }

    public void AnimationList(string sender)
    {
        Debug.Log("Animation list: " + sender);
    }

    public void PlayAnimation(string sender)
    {
        Debug.Log("Play animation: " + sender);
    }

    public void CancelAnimation(string sender)
    {
        Debug.Log("Cancel animation: " + sender);
    }
    #endregion

 
}
