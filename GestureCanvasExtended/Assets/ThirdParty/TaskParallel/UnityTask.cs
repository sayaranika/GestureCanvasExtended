﻿using System;
using System.Collections.Generic;
using UnityEngine;
using CI.TaskParallel.Core;

namespace CI.TaskParallel
{
    /// <summary>
    /// Represents an asynchronous operation
    /// </summary>
    public class UnityTask : IUnityTask
    {
        private const string DISPATCHER_GAMEOBJECT_NAME = "TaskParallelDispatcher";

        public UnityTaskState State
        {
            get; protected set;
        }

        protected UnityThread _thread;
        protected IUnityTask _continuation;

        private static Dispatcher _dispatcher;

        /// <summary>
        /// Initialises a new UnityTask with the specified action
        /// </summary>
        /// <param name="action">The delegate that represents the code to execute in the UnityTask</param>
        public UnityTask(Action action)
        {
            Action wrapperAction = () =>
            {
                try
                {
                    action();
                }
                catch
                {
                    State = UnityTaskState.Faulted;
                }
            };

            Initialise(wrapperAction);
        }

        protected UnityTask()
        {
        }

        protected void Initialise(Action action)
        {
            action += () =>
            {
                if (State != UnityTaskState.Aborted && State != UnityTaskState.Faulted)
                {
                    State = UnityTaskState.Finished;
                }

                if (_continuation != null && State != UnityTaskState.Aborted)
                {
                    _continuation.Start();
                }
            };

            _thread = new UnityThread(action);

            State = UnityTaskState.Created;
        }

        /// <summary>
        /// Starts this UnityTask
        /// </summary>
        public void Start()
        {
            CreateDispatcherGameObject();

            if (State == UnityTaskState.Created)
            {
                State = UnityTaskState.Running;

                _thread.Start();
            }
        }

        /// <summary>
        /// Aborts this UnityTask - will throw a ThreadAbortedException
        /// </summary>
        public void Abort()
        {
            if (State == UnityTaskState.Running)
            {
                _thread.Abort();

                State = UnityTaskState.Aborted;
            }
        }

        /// <summary>
        /// Waits for this UnityTask to complete
        /// </summary>
        public void Wait()
        {
            if (State == UnityTaskState.Running)
            {
                _thread.Join();
            }
        }

        /// <summary>
        /// Creates a continuation that executes asynchronously when the target UnityTask completes
        /// </summary>
        /// <param name="action">An action to run when the UnityTask completes. When run, the delegate will be passed the completed UnityTask as an argument</param>
        /// <returns>A new continuation UnityTask</returns>
        public UnityTask ContinueWith(Action<UnityTask> action)
        {
            Action wrapper = () =>
            {
                try
                {
                    action(this);
                }
                catch
                {
                    State = UnityTaskState.Faulted;

                    throw;
                }
            };

            var continuation = new UnityTask(wrapper);
            _continuation = continuation;

            return continuation;
        }

        /// <summary>
        /// Creates a continuation that executes asynchronously when the target UnityTask completes
        /// </summary>
        /// <typeparam name="TResult">The type of the result produced by the continuation</typeparam>
        /// <param name="function">A function to run when the UnityTask completes. When run, the delegate will be passed the completed UnityTask as an argument</param>
        /// <returns>A new continuation UnityTask</returns>
        public UnityTask<TResult> ContinueWith<TResult>(Func<UnityTask, TResult> function)
        {
            Func<TResult> wrapperFunc = () =>
            {
                return function(this);
            };

            var continuation = new UnityTask<TResult>(wrapperFunc);
            _continuation = continuation;

            return continuation;
        }

        /// <summary>
        /// Creates a continuation that executes synchronously on the UI thread when the target UnityTask completes
        /// </summary>
        /// <param name="action">An action to run when the UnityTask completes. When run, the delegate will be passed the completed UnityTask as an argument</param>
        public void ContinueOnUIThread(Action<UnityTask> action)
        {
            Action wrapper = () =>
            {
                action(this);
            };

            _continuation = new UnityUITask(wrapper);
        }

        /// <summary>
        /// Runs the specified work on a new thread and returns a UnityTask object that represents the work
        /// </summary>
        /// <param name="action">The work to execute asynchronously</param>
        /// <returns>A UnityTask object that represents the work to be run on a new thread</returns>
        public static UnityTask Run(Action action)
        {
            var unityTask = new UnityTask(action);
            unityTask.Start();

            return unityTask;
        }

        /// <summary>
        /// Runs the specified work on a new thread and returns a UnityTask object that represents the work
        /// </summary>
        /// <typeparam name="TResult">The return type of the UnityTask</typeparam>
        /// <param name="action">The work to execute asynchronously</param>
        /// <returns>A UnityTask object that represents the work to be run on a new thread</returns>
        public static UnityTask<TResult> Run<TResult>(Func<TResult> action)
        {
            var unityTask = new UnityTask<TResult>(action);
            unityTask.Start();

            return unityTask;
        }

        /// <summary>
        /// Queues the specified work to run on the UI thread
        /// </summary>
        /// <param name="action">The work to execute synchronously on the UI thread</param>
        public static void RunOnUIThread(Action action)
        {
            CreateDispatcherGameObject();

            _dispatcher.Enqueue(action);
        }

        /// <summary>
        /// Waits for all of the provided UnityTask objects to complete execution
        /// </summary>
        /// <param name="unityTasks">The UnityTasks to wait on for completion</param>
        public static void WaitAll(params UnityTask[] unityTasks)
        {
            WaitOnTasks(unityTasks);
        }

        /// <summary>
        /// Waits for all of the provided UnityTask objects to complete execution
        /// </summary>
        /// <param name="unityTasks">The UnityTasks to wait on for completion</param>
        public static void WaitAll(IEnumerable<UnityTask> unityTasks)
        {
            WaitOnTasks(unityTasks);
        }

        /// <summary>
        /// Executes the specified callback on the UI thread when all the provided UnityTask objects have completed execution
        /// </summary>
        /// <param name="callback">The callback to be executed</param>
        /// <param name="unityTasks">The UnityTasks to monitor for completion</param>
        public static void WhenAll(Action callback, params UnityTask[] unityTasks)
        {
            Run(() =>
            {
                WaitOnTasks(unityTasks);

                RunOnUIThread(callback);
            });
        }

        /// <summary>
        /// Executes the specified callback on the UI thread when all the provided UnityTask objects have completed execution
        /// </summary>
        /// <param name="callback">The callback to be executed</param>
        /// <param name="unityTasks">The UnityTasks to monitor for completion</param>
        public static void WhenAll(Action callback, IEnumerable<UnityTask> unityTasks)
        {
            Run(() =>
            {
                WaitOnTasks(unityTasks);

                RunOnUIThread(callback);
            });
        }

        private static void WaitOnTasks(IEnumerable<UnityTask> unityTasks)
        {
            foreach (var unityTask in unityTasks)
            {
                unityTask.Wait();
            }
        }

        private static void CreateDispatcherGameObject()
        {
            if (_dispatcher == null)
            {
                _dispatcher = new GameObject(DISPATCHER_GAMEOBJECT_NAME).AddComponent<Dispatcher>();
            }
        }
    }

    /// <summary>
    /// Represents an asynchronous operation that can return a value
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by this UnityTask</typeparam>
    public class UnityTask<TResult> : UnityTask
    {
        /// <summary>
        /// Gets the result value of this UnityTask
        /// </summary>
        public TResult Result
        {
            get; set;
        }

        /// <summary>
        /// Initialises a new UnityTask with the specified function
        /// </summary>
        /// <param name="function">The delegate that represents the code to execute in the UnityTask. When the function has completed, 
        /// the UnityTask's Result property will be set to return the result value of the function</param>
        public UnityTask(Func<TResult> function)
        {
            Action wrapperAction = () =>
            {
                try
                {
                    Result = function();
                }
                catch
                {
                    State = UnityTaskState.Faulted;
                }
            };

            Initialise(wrapperAction);
        }

        /// <summary>
        /// Creates a continuation that executes asynchronously when the target UnityTask completes
        /// </summary>
        /// <param name="action">An action to run when the UnityTask completes. When run, the delegate will be passed the completed UnityTask as an argument</param>
        /// <returns>A new continuation UnityTask</returns>
        public UnityTask ContinueWith(Action<UnityTask<TResult>> action)
        {
            Action wrapper = () =>
            {
                action(this);
            };

            var continuation = new UnityTask(wrapper);
            _continuation = continuation;

            return continuation;
        }

        /// <summary>
        /// Creates a continuation that executes asynchronously when the target UnityTask completes
        /// </summary>
        /// <typeparam name="NewTResult">The type of the result produced by the continuation</typeparam>
        /// <param name="function">A function to run when the UnityTask completes. When run, the delegate will be passed the completed UnityTask as an argument</param>
        /// <returns>A new continuation UnityTask</returns>
        public UnityTask<NewTResult> ContinueWith<NewTResult>(Func<UnityTask<TResult>, NewTResult> function)
        {
            Func<NewTResult> wrapperFunc = () =>
            {
                return function(this);
            };

            var continuation = new UnityTask<NewTResult>(wrapperFunc);
            _continuation = continuation;

            return continuation;
        }

        /// <summary>
        /// Creates a continuation that executes synchronously on the UI thread when the target UnityTask completes
        /// </summary>
        /// <param name="action">The work to execute synchronously on the UI thread</param>
        public void ContinueOnUIThread(Action<UnityTask<TResult>> action)
        {
            Action wrapper = () =>
            {
                action(this);
            };

            _continuation = new UnityUITask(wrapper);
        }
    }
}