﻿using VSOP.Application.Abstractions.Messaging;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Application.Requests.StoredCommodities.Queries.GetStoredCommodityById
{
    public sealed record GetStoredCommodityByIdQuery(Guid Id) : IQuery<StoredCommodity>;

}