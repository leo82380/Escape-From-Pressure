using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    getObject,
    notGetObject,
    fakeObject,
    imageObject,
    offeringObject,
    eyeTrickObject,
    tvObject
}
public class PlayerCheck : MonoBehaviour
{
    public ObjectType _objType;
    [SerializeField] private string _objectName;
    [SerializeField] public string _interactionText;
    [SerializeField] private string _explainText;
    [SerializeField] private int getObjectNumber;
    [SerializeField] private GameObject trickObject;
    [SerializeField] private int[] mat;
    [SerializeField] private PictureMaterial[] _pictureMat;

    public bool isTyping;
    public bool fakeisRun;
    public bool imageisRun;
    public bool globeisBroken;
    private DialogueManager _dialogueManager;
    private Inventory _inventory;

    private void Awake()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        _inventory = FindObjectOfType<Inventory>();
    }
    public void Typing()
    {
        if(!isTyping && _dialogueManager.canTyping)
        {
            isTyping = true;
            StartCoroutine(_dialogueManager.TypingRoutine(_objectName, _explainText, this));
        }
    }
    public void GetObject()
    {
        _inventory.InventoryImageSetActive(getObjectNumber);
        Destroy(gameObject);
    }

    public void TrickObject()
    {
        for (int i = 0; i < _pictureMat.Length; i++)
        {
            _pictureMat[i].ChangeMaterial(mat[i]);
        }
        Destroy(gameObject);
        fakeisRun = true;
    }

    public void ImageObject()
    {
        StartCoroutine(ChangeImage());
    }

    IEnumerator ChangeImage()
    {
        if(!imageisRun)
        {
            _pictureMat[2].ChangeMaterial(4);
            yield return new WaitForSeconds(3f);
            _pictureMat[2].ChangeMaterial(10);
            for (int i = 0; i < 2; i++)
                _pictureMat[i].GetComponent<Rigidbody>().isKinematic = false;
            imageisRun = true;
        }
        yield return null;
    }

    public void OfferingBoxObject()
    {
        if(!globeisBroken)
        {
            globeisBroken = true;
            _explainText = "";
            FindObjectOfType<Globe>().ChangeGlobe();
        }
        else if(_inventory.hasObject[1] && globeisBroken)
        {
            FindObjectOfType<OfferingBox>().MoveDown();
        }
    }

    public void IrisChangeObject(bool active)
    {
        trickObject.SetActive(active);
        Destroy(gameObject);
    }
}
