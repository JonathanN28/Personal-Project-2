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
    protected Transform playerBall;
    protected EnemyStateMachine nextState;
    public EnemyStateMachine(GameObject _npc, NavMeshAgent _agent, Animator _npcAnim, Transform _playerBall)
    {
        npc = _npc;
        agent = _agent;
        npcAnim = _npcAnim;
        playerBall = _playerBall;
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

    public bool CanHitBall()
    {
        if (playerBall.position.z > 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}

public class Idle : EnemyStateMachine
{
    private int currentWaypoint = 0;
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _npcAnim, Transform _playerBall) : base(_npc, _agent, _npcAnim, _playerBall)
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
            currentWaypoint++;
            if (currentWaypoint > WaypointsSingleton.Singleton.IdleWaypoints.Count - 1)
            {
                currentWaypoint = 0;
            }
            agent.SetDestination(WaypointsSingleton.Singleton.IdleWaypoints[currentWaypoint].transform.position);
        }
        else if (CanHitBall())
        {
            nextState = new Attack(npc, agent, npcAnim, playerBall);
            base.StageExit();
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

    private int currentWaypoint = 0;
    public Attack(GameObject _npc, NavMeshAgent _agent, Animator _npcAnim, Transform _playerBall) : base(_npc, _agent, _npcAnim, _playerBall)
    {
        name = STATE.ATTACK;
        
    }
    public override void StageEnter()
    {
        if (agent.hasPath)
        {
            agent.ResetPath();
            agent.SetDestination(WaypointsSingleton.Singleton.AttackWaypoints[currentWaypoint].transform.position);
        }
        base.StageEnter();
    }
    public override void StageUpdate()
    {
        Debug.Log(agent.destination);
    }
    public override void StageExit()
    {
        base.StageExit();
    }
    
}

