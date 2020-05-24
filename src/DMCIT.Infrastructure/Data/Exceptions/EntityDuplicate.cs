﻿using System;

namespace DMCIT.Infrastructure.Data.Exceptions
{
    class EntityDuplicate : Exception
    {
        public EntityDuplicate(Type type, object value) : base(String.Format("ENTITY TYPE {0}:{1} HAS BEEN DUPLICATE", type.Name, value))
        {

        }
    }
}
