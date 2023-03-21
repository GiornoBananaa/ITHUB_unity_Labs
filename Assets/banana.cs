using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class banana : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Sprite[] _pictures;
    [SerializeField] private Sprite _deafultPicture;

    //private int[] _buttonsPictures;
    private int _selectedIndex;


    private void Start()
    {
        _selectedIndex = -1;

        for (int i = 0; i < _buttons.Length; i++)
        {
            int number = i;
            _buttons[i].onClick.AddListener(() => SelectPicture(number));
        }
    }

    private void SelectPicture(int index)
    {
        _buttons[index].GetComponent<Image>().sprite = _pictures[index];

        if(_selectedIndex == -1)
        {
            _selectedIndex = index;
            _buttons[index].interactable = false;
        }
        else
        {
            Debug.Log(_pictures[_selectedIndex].name == _pictures[index].name);

            if(_pictures[_selectedIndex].name == _pictures[index].name)
            {
                StartCoroutine(PairSelect(true, _selectedIndex, index));
            }
            else
            {
                StartCoroutine(PairSelect(false, _selectedIndex, index));
            }

            _selectedIndex = -1;
        }
    }

    IEnumerator PairSelect(bool destroy, int index1, int index2)
    {
        _buttons[index2].interactable = false;

        yield return new WaitForSeconds(1);

        if(!destroy)
        {
            _buttons[index1].interactable = true;
            _buttons[index2].interactable = true;


            _buttons[index1].GetComponent<Image>().sprite = _deafultPicture;
            _buttons[index2].GetComponent<Image>().sprite = _deafultPicture;
        }
    }

}
