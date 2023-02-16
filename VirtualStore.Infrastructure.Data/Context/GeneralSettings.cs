using System;
namespace VirtualStore.Infrastructure.Data.Context
{
    public class GeneralSettings
    {
        public string StringConnection { get; set; } = null!;

        public string DataBaseName { get; set; } = null!;

        //Schemas

        public string PersonCollectionName { get; set; } = null!;

        public string ProductCollectionName { get; set; } = null!;

        public string CartCollectionName { get; set; } = null!;

        public GeneralSettings()
        {
        }
    }
}

