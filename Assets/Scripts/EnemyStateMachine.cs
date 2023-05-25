using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;
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
    protected NavMeshAgent agent;
    protected Animator npcAnim;
    protected Transform player;
    protected EnemyStateMachine nextState;
    public EnemyStateMachine(GameObject _npc, NavMeshAgent _agent, Animator _npcAnim, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        npcAnim = _npcAnim;
        player = _player;
    }

    public virtual void StageEnter()
    {
        stage = EVENT.UPDATE;
    }
    public virtual void StageUpdate()
    {
        stage = EVENT.UPDATE;
    }
    public virtual void StageExit()
    {
        stage = EVENT.EXIT;
    }
    public EnemyStateMachine Runtime()
    {
        if (stage == EVENT.ENTER)
        {
            StageEnter();
        }
        else if (stage == EVENT.UPDATE)
        {
            StageUpdate();
        }
        else if (stage == EVENT.EXIT)
        {
            StageExit();
            return nextState;
        }

        return this;
    }
    
    
    
    
}

public class Idle : EnemyStateMachine
{
    private int currentWaypoint = 0;
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _npcAnim, Transform _player) : base(_npc, _agent, _npcAnim, _player)
    {
        name = STATE.IDLE;
    }
    public override void StageEnter()
    {
        npcAnim.SetTrigger("enemyIdle");
        if (!agent.hasPath)
        {
            agent.SetDestination(WaypointsSingleton.Singleton.IdleWaypoints[currentWaypoint].transform.position);
        }
        base.StageEnter();
    }
    public override void StageUpdate()
    {
        if (agent.remainingDistance < 1f)
        {
            if (WaypointsSingleton.Singleton.IdleWaypoints.Count > currentWaypoint)
            {
                currentWaypoint++;
            }
        }
    }
    public override void StageExit()
    {
        npcAnim.ResetTrigger("enemyIdle");
        base.StageExit();
    }
}

public class Attack : EnemyStateMachine
{
    public Attack(GameObject _npc, NavMeshAgent _agent, Animator _npcAnim, Transform _player) : base(_npc, _agent, _npcAnim, _player)
    {
        name = STATE.ATTACK;
        
    }
    public override void StageEnter()
    {
        npcAnim.SetTrigger("enemyHit");
        base.StageEnter();
    }
    public override void StageUpdate()
    {
        
    }
    public override void StageExit()
    {
        npcAnim.ResetTrigger("enemyHit");
        base.StageExit();
    }
}

