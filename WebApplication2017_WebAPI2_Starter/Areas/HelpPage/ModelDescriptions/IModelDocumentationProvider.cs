using System;
using System.Reflection;

namespace WebApplication2017_WebAPI2_Starter.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}