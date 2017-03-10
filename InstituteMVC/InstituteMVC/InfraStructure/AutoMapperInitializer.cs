using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteMVC.InfraStructure
{
    public class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(AutoMapperInitializer));
            });
        }
    }
}