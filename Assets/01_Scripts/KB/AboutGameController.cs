using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AboutGameController : MonoSingleton<AboutGameController>, IPointerClickHandler
{
    [SerializeField] private List<GameObject> pages;
    [SerializeField] private GameObject goBackButton;
    [SerializeField] private GameObject whitePanel;
    
    private int index;

    private void Start()
    {
        HidePanel();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        pages[index].SetActive(true);
        for (int i = 0; i < pages.Count; i++)
        {
            if (i != index)
            {
                pages[i].SetActive(false);
            }
        }
    }

    public void ShowPanel()
    {
        whitePanel.SetActive(true);
        ChangePage(0);
    }

    private void HidePanel() =>
        whitePanel.SetActive(false);
    
    public void NextPage()
    {
        index++;
        ChangePage(index);
    }

    public void GoBackPage()
    {
        index--;
        ChangePage(index);
    }

    private void ChangePage(int i)
    {
        if (i == 3)
        {
            HidePanel();
            index = 0;
            return;
        }
        i = Mathf.Clamp(index, 0, 2);
        
        for (int ii = 0; ii < pages.Count; ii++)
        {
            if(ii != i) pages[ii].SetActive(false);
            else pages[ii].SetActive(true);
        }

        if (i == 0)
        {
            goBackButton.SetActive(false);
        }
        else
        {
            goBackButton.SetActive(true);
        }
    }
}
