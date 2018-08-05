﻿#if CSHARP_7_OR_LATER
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System;

namespace UniRx.Async
{
    public partial struct UniTask
    {
        public static async UniTask Run(Action action, bool configureAwait = true)
        {
            await UniTask.SwitchToThreadPool();
            action();
            if (configureAwait)
            {
                await UniTask.Yield();
            }
        }

        public static async UniTask Run(Action<object> action, object state, bool configureAwait = true)
        {
            await UniTask.SwitchToThreadPool();
            action(state);
            if (configureAwait)
            {
                await UniTask.Yield();
            }
        }

        public static async UniTask<T> Run<T>(Func<T> func, bool configureAwait = true)
        {
            await UniTask.SwitchToThreadPool();
            var result = func();
            if (configureAwait)
            {
                await UniTask.Yield();
            }
            return result;
        }

        public static async UniTask<T> Run<T>(Func<object, T> func, object state, bool configureAwait = true)
        {
            await UniTask.SwitchToThreadPool();
            var result = func(state);
            if (configureAwait)
            {
                await UniTask.Yield();
            }
            return result;
        }
    }
}

#endif