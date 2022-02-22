using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    KeyCode KeyCode { get; }

    void Execute();
}
