${
    using Typewriter.Extensions.Types;
    Template(Settings settings)
    {
        settings
            .IncludeProject("CMS.Core");
        settings.OutputExtension = ".cs";
        settings.OutputFilenameFactory = file => 
        {
            return $"outputDTOs/{file.Name.Replace(".cs", "") + "DTO.cs"}";
        };
    }
    string OriginalType(Property p)
    {
        if(!p.Type.IsEnumerable && !p.Type.IsPrimitive)
        {
            var refType = p.Type.Name + "DTO";
            return refType;
        }
        else if(p.Type.IsEnumerable && !p.Type.IsPrimitive)
        {
            var refType = "<" + p.Type.TypeArguments.ToString()
                .Replace("<","")
                .Replace(">","")
                +"DTO>";
            return p.Type.OriginalName + refType;
        }
        else
            return p.Type.OriginalName;
    }
    string FromEntity(Property p)
    {
        if(!p.HasSetter)
            return "";
            
        if(!p.Type.IsEnumerable && !p.Type.IsPrimitive)
        {
            var refType = p.Type.Name + "DTO";
            return p.Name + $" = item.{p.Name} != null? {refType}.FromEntity(item.{p.Name}) : null,";
        }
        else if(p.Type.IsEnumerable && !p.Type.IsPrimitive)
        {
            var refType = p.Type.TypeArguments.ToString()
                .Replace("<","")
                .Replace(">","")
                +"DTO";
            return p.Name + " = item." + p.Name +"?.Select(" + refType +".FromEntity)" + ",";
        }
        else
            return p.Name + " = item." + p.Name + ",";
    }
    string ToEntity(Property p)
    {
        if(!p.HasSetter)
            return "";
        if(!p.Type.IsEnumerable && !p.Type.IsPrimitive)
        {
            var refType = p.Type.Name+"DTO";
            return p.Name + " = this." + p.Name +"?.ToEntity()" + ",";
        }
        if(p.Type.IsEnumerable && !p.Type.IsPrimitive)
        {
            var refType = p.Type.TypeArguments.ToString()
                .Replace("<","")
                .Replace(">","")
                +"DTO";
            return p.Name + " = this." + p.Name +"?.Select(x => x.ToEntity())" + ",";
        }
        else
            return p.Name + " = this." + p.Name + ",";
    }
    string NameDTO(Class c)
    {
        return c.Name + "DTO";
    }
}$Classes(:BaseEntity)[using $Namespace;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class $NameDTO
    {
        public int Id { get; set; }$Properties[
        public $OriginalType $Name { get; set; }]
        public static $NameDTO FromEntity($Name item)
        {
            return new $NameDTO()
            {
                Id = item.Id,$Properties[
                $FromEntity]
            };
        }
        public $Name ToEntity()
        {
            return new $Name()
            {
                Id = this.Id,$Properties[
                $ToEntity]
            };
        }
    }
}