using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using Docs.Extensions;

namespace Docs.Models
{
    /// <summary>
    /// MemberModelBase
    /// </summary>
    public abstract class MemberModelBase : ModelBase
    {
        /// <summary>
        /// Properties
        /// </summary>
        public List<PropertyModel> Properties { get; set; } = new List<PropertyModel>();

        /// <summary>
        /// Methods
        /// </summary>
        public List<MethodModel> Methods { get; set; } = new List<MethodModel>();

        /// <summary>
        /// MemberModelBase
        /// </summary>
        protected MemberModelBase()
        {
        }

        /// <summary>
        /// MemberModelBase
        /// </summary>
        /// <param name="name"></param>
        /// <param name="summary"></param>
        /// <param name="type"></param>
        /// <param name="document"></param>
        protected MemberModelBase(string name, string summary, Type type, XmlDocument document) : base(name, summary)
        {
            AddInfo(type, document);
        }

        /// <summary>
        /// AddInfo
        /// </summary>
        /// <param name="type"></param>
        /// <param name="document"></param>
        public void AddInfo(Type type, XmlDocument document)
        {
            foreach (var propertyInfo in type.GetProperties())
            {
                var propertyInfoSummary = document.GetSummaryFor(propertyInfo);
                var propertyModel = new PropertyModel(propertyInfo.Name, propertyInfoSummary);
                AddProperty(propertyModel);
            }

            foreach (var constructorInfo in type.GetConstructors())
            {
                var constructorInfoSummary = document.GetSummaryFor(constructorInfo, true);
                var methodModel = new MethodModel("New", constructorInfoSummary);
                AddMethod(methodModel);
            }

            foreach (var methodInfo in type
                .GetMethods(BindingFlags.Public | 
                            BindingFlags.Instance | 
                            BindingFlags.Static | 
                            BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName))
            {
                var methodInfoSummary = document.GetSummaryFor(methodInfo, false);
                var methodModel = new MethodModel(methodInfo.Name, methodInfoSummary);
                AddMethod(methodModel);
            }
        }

        /// <summary>
        /// AddProperty
        /// </summary>
        /// <param name="property"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddProperty(PropertyModel property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (Properties.FirstOrDefault(x => x.Name == property.Name) == null)
            {
                Properties.Add(property);
            }
        }

        /// <summary>
        /// AddMethod
        /// </summary>
        /// <param name="method"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddMethod(MethodModel method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            Methods.Add(method);
        }
    }
}