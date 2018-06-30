using AutoMapper;
using Greenfinch.Newsletter.Web.Core.Models;
using Greenfinch.Newsletter.Web.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Subscriber, SubscriberViewModel>();
            CreateMap<SubscriberViewModel, Subscriber>();
        }
    }
}
