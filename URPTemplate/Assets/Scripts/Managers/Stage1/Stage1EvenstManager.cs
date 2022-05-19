using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stage1EventsManager : EventsManager
{
    public UnityEvent OnTsuyoiJuryokuDialogueEvent;

    [SerializeField] IngameUIModel _ingameUiModel;

    private void Awake()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        OnTsuyoiJuryokuDialogueEvent.AddListener(_ingameUiModel);
    }
}
