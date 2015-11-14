
namespace YekanPedia.ManagementSystem.InfraStructure.Extension
{
    using System;
    using System.ComponentModel;
    using System.Resources;

    public class LocalizeDescriptionEnumAttribute : DescriptionAttribute
    {
        readonly string _resourceKey;
        readonly ResourceManager _resource;
        public LocalizeDescriptionEnumAttribute(string Name, Type ResourceType)
        {
            _resource = new ResourceManager(ResourceType);
            _resourceKey = Name;
        }

        public override string Description
        {
            get
            {
                string displayName = _resource.GetString(_resourceKey);

                return string.IsNullOrEmpty(displayName)
                    ? string.Format("[[{0}]]", _resourceKey)
                    : displayName;
            }
        }
    }


}
