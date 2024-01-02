using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartScene_Button : MonoBehaviour, IPointerClickHandler
{
    private enum ButtonType
    {
        Start,
        Load,
        Exit
    }
    [SerializeField] private ButtonType buttonType;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (buttonType)
        {
            case ButtonType.Start:
                SceneManager.LoadScene("StartScene");
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
}
