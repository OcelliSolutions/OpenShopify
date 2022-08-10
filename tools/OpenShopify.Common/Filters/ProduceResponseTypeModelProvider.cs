﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using OpenShopify.Common.Models;

namespace OpenShopify.Common.Filters;

/// <summary>
///     There are some general rules as far as what the response types for any given endpoint can be. These are centrally
///     managed here.
/// </summary>
public class ProduceResponseTypeModelProvider : IApplicationModelProvider
{
    public int Order => 3;

    public void OnProvidersExecuted(ApplicationModelProviderContext context)
    {
    }

    public void OnProvidersExecuting(ApplicationModelProviderContext context)
    {
        foreach (var controller in context.Result.Controllers)
        {
            foreach (var action in controller.Actions)
            {
                var returnType = typeof(ErrorResponse);
                if (action.ActionMethod.ReturnType.GenericTypeArguments.Any())
                {
                    if (action.ActionMethod.ReturnType.GenericTypeArguments[0].GetGenericArguments().Any())
                        returnType = action.ActionMethod.ReturnType.GenericTypeArguments[0].GetGenericArguments()[0];
                }
                
                AddUniversalStatusCodes(action, returnType);
                /*
                var methodVerbs = action.Attributes.OfType<HttpMethodAttribute>().SelectMany(x => x.HttpMethods).Distinct();
                if (!methodVerbs.Contains("GET")) //POST, PUT, DELETE all have these.
                    AddPostStatusCodes(action, returnType);
                */
            }
        }
    }

    public void AddProducesResponseTypeAttribute(ActionModel action, Type? returnType, int statusCodeResult)
    {
        if (returnType != null)
            action.Filters.Add(new ProducesResponseTypeAttribute(returnType, statusCodeResult));
        else if (returnType == null) action.Filters.Add(new ProducesResponseTypeAttribute(statusCodeResult));
    }

    public void AddUniversalStatusCodes(ActionModel action, Type returnType)
    {
    }

    public void AddPostStatusCodes(ActionModel action, Type returnType)
    {
        AddProducesResponseTypeAttribute(action, null, StatusCodes.Status200OK);
    }
}