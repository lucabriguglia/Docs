﻿using System;
#pragma warning disable 1591

namespace Docs.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class DocTargetAttribute : Attribute
    {
        public string Context { get; }

        public DocTargetAttribute()
        {
        }

        public DocTargetAttribute(string context)
        {
            Context = context;
        }
    }
}