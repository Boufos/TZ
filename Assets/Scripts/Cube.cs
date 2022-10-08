using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private MoveCounter move;
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private GameObject winPanel;
    private Transform _startCell;
    private Canvas _canvas;
    private Transform _lastCillTrriger;
    private Cell _cell;

    private void Start()
    {
        _canvas = GetComponentInParent<Canvas>();
        _cell = GetComponentInParent<Cell>();
        _startCell = _cell.transform;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _cell.IsEmpty = true;
        gameObject.transform.SetParent(_canvas.transform);
        move.AddCount(_cell);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero, 110f, 1 << 6);
        if (hit.collider != null && hit.collider.GetComponent<Cell>().IsEmpty)
        {
            _lastCillTrriger = hit.transform;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Cell cell = _lastCillTrriger.GetComponent<Cell>();
        if (!cell.MustBeFiled)
        {
            errorPanel.SetActive(true);
            RestartCube();
        }
        else
        {
            _cell = cell.GetComponent<Cell>();
            move.RemoveCount(_cell);
            cell.GetComponent<Cell>().IsEmpty = false;
            gameObject.transform.SetParent(_lastCillTrriger);
            gameObject.transform.localPosition = Vector2.zero;

        }

    }

    public void RestartCube()
    {
        gameObject.transform.SetParent(_startCell);
        gameObject.transform.localPosition = Vector2.zero;
    }

}
