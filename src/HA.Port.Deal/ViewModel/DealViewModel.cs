﻿using AutoMapper;
using HA.Application.Common.Mapping;
using HA.Domain.Entities;
using System;

namespace HA.Application.DealFeature.ViewModel
{
    public class DealViewModel : IMapFrom<Deal>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Deal, DealViewModel>()
                .ForMember(destination => destination.Id, source => source.MapFrom(source => source.Id));
        }

    }
}