﻿using AutoMapper;
using HA.Application.DealFeature.ViewModel;
using HA.Domain.Contract;
using HA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HA.Application.DealFeature.Queries
{
    public class GetAllDealsQuery : IRequest<IEnumerable<DealViewModel>>
    {
        //    public int PageNumber { get; set; }
        //    public int PageSize { get; set; }
    }

    public class GetAllDealHandler : IRequestHandler<GetAllDealsQuery, IEnumerable<DealViewModel>>
    {

        private readonly IGenericRepositoryAsync<Deal, Guid> _genericRepository;
        private readonly IMapper _mapper;

        public GetAllDealHandler(IGenericRepositoryAsync<Deal, Guid> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DealViewModel>> Handle(GetAllDealsQuery request, CancellationToken cancellationToken)
        {
            var DealsList = await _genericRepository.GetAllAsync();
            var DealsListVm = _mapper.Map<IEnumerable<DealViewModel>>(DealsList);
            return DealsListVm;
        }
    }
}
