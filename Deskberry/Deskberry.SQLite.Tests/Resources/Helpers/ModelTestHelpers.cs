using Deskberry.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.Tests.Resources.Helpers
{
    public static class ModelTestHelpers
    {
        public static bool CheckTime<T>(T model, DateTime testStartTime) where T : ModelBase
        {
            return (model.CreatedAt != default) && (model.CreatedAt.Ticks >= testStartTime.Ticks);
        }
    }
}