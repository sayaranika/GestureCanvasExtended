﻿using System;

namespace CI.TaskParallel.Core
{
    public class UnityUITask : IUnityTask
    {
        private readonly Action _action;

        public UnityUITask(Action action)
        {
            _action = action;
        }

        public void Start()
        {
            UnityTask.RunOnUIThread(_action);
        }
    }
}