using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Docs.Attributes;
using Docs.Extensions;
using Docs.Models;
using Docs.ScanTypes;

namespace Docs
{
    /// <inheritdoc />
    public class Converter : IConverter
    {
        /// <inheritdoc />
        public DocumentationModel Convert(ScanResult scanResult)
        {
            var data = new List<ContextModel>();

            foreach (var context in scanResult.Contexts.OrderBy(x => x.Name))
            {
                var contextModel = new ContextModel(context.Name);

                foreach (var target in context.Targets)
                {
                    var document = scanResult.Documents.FirstOrDefault(x => x.Key == target.Assembly).Value;
                    var summary = document.GetSummaryFor(target.Type);

                    var targetModel = new TargetModel(target.Type.Name, summary, target.Type, document);

                    contextModel.AddTarget(targetModel);
                }

                contextModel.Targets = contextModel.Targets.OrderBy(x => x.Name).ToList();

                data.Add(contextModel);
            }

            foreach (var request in scanResult.Requests)
            {
                var requestAttribute = (DocRequestAttribute)request.Type.GetCustomAttribute(typeof(DocRequestAttribute));
                var targetType = requestAttribute.Target;

                var document = scanResult.Documents.FirstOrDefault(x => x.Key == request.Assembly).Value;
                var summary = document.GetSummaryFor(request.Type);

                var requestModel = new RequestModel(request.Type.Name, summary, request.Type, document, targetType?.Name);

                ContextModel contextModel = null;

                foreach (var context in
                    from context in data
                    from target in context.Targets
                    where target.Name == targetType?.Name
                    select context)
                {
                    contextModel = context;
                }

                contextModel?.AddRequest(requestModel);
            }

            foreach (var target in data.SelectMany(context => context.Targets))
            {
                target.Requests = target.Requests.OrderBy(x => x.Name).ToList();
            }

            return new DocumentationModel(data, DateTime.UtcNow, scanResult.ElapsedMilliseconds);
        }
    }
}