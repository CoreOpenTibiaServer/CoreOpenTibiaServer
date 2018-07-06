// <copyright file="GenericEventAction.cs" company="2Dudes">
// Copyright (c) 2018 2Dudes. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

using System;
using COMMO.Common.Helpers;
using COMMO.Scheduling.Contracts;

namespace COMMO.Server
{
    internal class GenericEventAction : IEventAction
    {
        private Action action;

        public GenericEventAction(Action action)
        {
            action.ThrowIfNull();

            this.action = action;
        }

        public void Execute()
        {
            action();
        }
    }
}