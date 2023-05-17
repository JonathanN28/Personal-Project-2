using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public enum STATE
    {
        IDLE,
        ATTACK,

    }
    public enum EVENT
    {
        ENTER,
        UPDATE,
        EXIT,
    }

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected UnityEngine.AI.NavMeshAgent agent;
    protected Animator npcAnim;
    protected Transform player;
    protected EnemyStateMachine nextState;
    public EnemyStateMachine()
    {
        
    }
}
