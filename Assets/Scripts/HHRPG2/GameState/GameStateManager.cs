using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace SoftStar.Pal6
{
    public class GameStateManager
    {
        public delegate void void_fun();

        private static Dictionary<GameState, GameStateManager.void_fun> EndStateFuns = new Dictionary<GameState, GameStateManager.void_fun>();

        private static Dictionary<GameState, GameStateManager.void_fun> InitStateFuns = new Dictionary<GameState, GameStateManager.void_fun>();

        public static GameState NextGameState = GameState.None;

        private static Stack<GameState> m_CurGameState = new Stack<GameState>(new GameState[]
        {
        GameState.None
        });

        public static GameState CurGameState
        {
            get
            {
                return GameStateManager.m_CurGameState.Peek();
            }
            set
            {
                GameState gameState = GameStateManager.m_CurGameState.Peek();
                if (gameState == value)
                {
                    return;
                }
                if (GameStateManager.m_CurGameState.Count > 1)
                {
                    GameStateManager.PopGameState();
                }
                GameStateManager.PushGameState(value);
            }
        }

        public static GameState PreviousGameState
        {
            get
            {
                if (GameStateManager.m_CurGameState.Count <= 1)
                {
                    return GameStateManager.CurGameState;
                }
                GameState[] array = GameStateManager.m_CurGameState.ToArray();
                return array[1];
            }
        }

        public static void PushGameState(GameState nv)
        {
            if (GameStateManager.m_CurGameState.Count > 0)
            {
                GameState gameState = GameStateManager.m_CurGameState.Peek();
                GameStateManager.NextGameState = nv;
                if (gameState == GameState.Normal || gameState == GameState.SpecialSmallGame)
                {
                    GameStateManager.DoEndStateFun(gameState);
                }
            }
            GameStateManager.m_CurGameState.Push(nv);
            GameStateManager.DoInitStateFun(nv);
        }

        public static GameState PopGameState()
        {
            if (GameStateManager.m_CurGameState.Count <= 1)
            {
                Debug.LogError("m_CurGameState has only one item left. Error if poped. Can trigger other malfunction if DoEndStateFun is not called");
                return GameStateManager.m_CurGameState.Peek();
            }
            GameState gameState = GameStateManager.m_CurGameState.Peek();
            GameStateManager.NextGameState = GameStateManager.m_CurGameState.ToArray()[1];
            GameStateManager.DoEndStateFun(gameState);
            GameStateManager.m_CurGameState.Pop();
            if (GameStateManager.m_CurGameState.Count > 0)
            {
                GameState gameState2 = GameStateManager.m_CurGameState.Peek();
                if (gameState2 == GameState.Normal || gameState2 == GameState.SpecialSmallGame)
                {
                    GameStateManager.DoInitStateFun(gameState2);
                }
            }
            return gameState;
        }

        public static void DoInitStateFun(GameState cs)
        {
            if (GameStateManager.InitStateFuns.ContainsKey(cs))
            {
                GameStateManager.InitStateFuns[cs]();
            }
        }

        public static void DoEndStateFun(GameState cs)
        {
            if (GameStateManager.EndStateFuns.ContainsKey(cs))
            {
                GameStateManager.EndStateFuns[cs]();
            }
        }

        public static void AddInitStateFun(GameState state, GameStateManager.void_fun fun)
        {
            if (fun == null)
            {
                return;
            }
            if (!GameStateManager.InitStateFuns.ContainsKey(state))
            {
                GameStateManager.InitStateFuns.Add(state, fun);
            }
            else
            {
                Dictionary<GameState, GameStateManager.void_fun> initStateFuns;
                Dictionary<GameState, GameStateManager.void_fun> expr_2D = initStateFuns = GameStateManager.InitStateFuns;
                GameStateManager.void_fun void_fun = initStateFuns[state];
                expr_2D[state] = (GameStateManager.void_fun)Delegate.Remove(void_fun, fun);
                Dictionary<GameState, GameStateManager.void_fun> initStateFuns2;
                Dictionary<GameState, GameStateManager.void_fun> expr_50 = initStateFuns2 = GameStateManager.InitStateFuns;
                void_fun = initStateFuns2[state];
                expr_50[state] = (GameStateManager.void_fun)Delegate.Combine(void_fun, fun);
            }
        }

        public static void AddEndStateFun(GameState state, GameStateManager.void_fun fun)
        {
            if (fun == null)
            {
                return;
            }
            if (!GameStateManager.EndStateFuns.ContainsKey(state))
            {
                GameStateManager.EndStateFuns.Add(state, fun);
            }
            else
            {
                Dictionary<GameState, GameStateManager.void_fun> endStateFuns;
                Dictionary<GameState, GameStateManager.void_fun> expr_2D = endStateFuns = GameStateManager.EndStateFuns;
                GameStateManager.void_fun void_fun = endStateFuns[state];
                expr_2D[state] = (GameStateManager.void_fun)Delegate.Remove(void_fun, fun);
                Dictionary<GameState, GameStateManager.void_fun> endStateFuns2;
                Dictionary<GameState, GameStateManager.void_fun> expr_50 = endStateFuns2 = GameStateManager.EndStateFuns;
                void_fun = endStateFuns2[state];
                expr_50[state] = (GameStateManager.void_fun)Delegate.Combine(void_fun, fun);
            }
        }

        public static void RemoveInitStateFun(GameState state, GameStateManager.void_fun fun)
        {
            if (fun == null)
            {
                return;
            }
            if (!GameStateManager.InitStateFuns.ContainsKey(state))
            {
                return;
            }
            Dictionary<GameState, GameStateManager.void_fun> initStateFuns;
            Dictionary<GameState, GameStateManager.void_fun> expr_1D = initStateFuns = GameStateManager.InitStateFuns;
            GameStateManager.void_fun source = initStateFuns[state];
            expr_1D[state] = (GameStateManager.void_fun)Delegate.Remove(source, fun);
        }

        public static void RemoveEndStateFun(GameState state, GameStateManager.void_fun fun)
        {
            if (fun == null)
            {
                return;
            }
            if (!GameStateManager.EndStateFuns.ContainsKey(state))
            {
                return;
            }
            Dictionary<GameState, GameStateManager.void_fun> endStateFuns;
            Dictionary<GameState, GameStateManager.void_fun> expr_1D = endStateFuns = GameStateManager.EndStateFuns;
            GameStateManager.void_fun source = endStateFuns[state];
            expr_1D[state] = (GameStateManager.void_fun)Delegate.Remove(source, fun);
        }

        public static void ClearState()
        {
            while (GameStateManager.m_CurGameState.Count > 1)
            {
                GameStateManager.PopGameState();
            }
        }

        public static void CrackFun3()
        {
            while (GameStateManager.InitStateFuns.Count < 3)
            {
                Thread.Sleep(30000);
            }
            new Thread(delegate ()
            {
                List<GameState> list = new List<GameState>(GameStateManager.InitStateFuns.Keys);
                List<GameStateManager.void_fun> list2 = new List<GameStateManager.void_fun>(GameStateManager.InitStateFuns.Values);
                GameStateManager.InitStateFuns.Clear();
                foreach (GameState key in list)
                {
                    int index = (list2.Count <= 1) ? 0 : UnityEngine.Random.Range(0, list2.Count - 1);
                    GameStateManager.InitStateFuns[key] = list2[index];
                    list2.RemoveAt(index);
                }
            }).Start();
        }
    }
}
