﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Docs.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AreaModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<TargetModel> Targets => _targets.AsReadOnly();
        private readonly List<TargetModel> _targets = new List<TargetModel>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AreaModel(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddTarget(TargetModel target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (_targets.Single(x => x.Name == target.Name) == null)
            {
                _targets.Add(target);
            }
        }
    }
}