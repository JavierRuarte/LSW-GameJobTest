using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    KeyCode KeyCode { get; }

    void Execute();
}
