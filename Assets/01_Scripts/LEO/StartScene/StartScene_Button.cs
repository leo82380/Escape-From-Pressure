using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartScene_Button : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private enum ButtonType
    {
        Start,
        Load,
        Exit
    }
    [SerializeField] private ButtonType buttonType;
    [SerializeField] private TMP_Text _myText;
    [SerializeField] private List<TMP_Text> _anotherTexts;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (buttonType)
        {
            case ButtonType.Start:
                SceneManager.LoadScene("JSY");
                break;
            case ButtonType.Load:
                DateManager.Instance.Load();
                if (DateManager.Instance.playerData == null)
                {
                    Debug.Log("저장된 데이터가 없습니다.");
                    DateManager.Instance.playerData = new PlayerData();
                    DateManager.Instance.Save();
                }
                break;
            case ButtonType.Exit:
                Application.Quit();
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _myText.fontSize = Mathf.Lerp(_myText.fontSize, 150, Time.deltaTime * 20);
        foreach (var text in _anotherTexts)
        {
            text.fontSize = Mathf.Lerp(text.fontSize, 50, Time.deltaTime * 20);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _myText.fontSize = 80;
        foreach (var text in _anotherTexts)
        {
            text.fontSize = 80;
        }
    }
}
