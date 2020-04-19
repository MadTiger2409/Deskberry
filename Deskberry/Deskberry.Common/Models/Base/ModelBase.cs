using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.Common.Models.Base
{
    public class ModelBase
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public ModelBase()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}