using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCounter : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    private int _cellMustBeFilled = 0;
    private void Awake()
    {
        Cell[] cells = GetComponentsInChildren<Cell>();

        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].MustBeFiled)
            {
                _cellMustBeFilled++;
            }
        }
    }

    public void AddCount(Cell cell)
    {

        if (cell.MustBeFiled && !cell.CompareTag("BigCell"))
        {
            _cellMustBeFilled++;
        }
    }

    public void RemoveCount(Cell cell)
    {
        if (cell.MustBeFiled && !cell.CompareTag("BigCell"))
        {
            _cellMustBeFilled--;
        }
        if (_cellMustBeFilled == 0)
        {
            Animator[] animators = FindObjectsOfType<Animator>();
            for (int i = 0; i < animators.Length; i++)
            {
                animators[i].SetBool("Win", true);
            }
            StartCoroutine(WaitWinPanel());
        }
    }

    IEnumerator WaitWinPanel()
    {
        yield return new WaitForSeconds(0.4f);
        winPanel.SetActive(true);
        Animator[] animators = FindObjectsOfType<Animator>();
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetBool("Win", false);
        }

    }
}

