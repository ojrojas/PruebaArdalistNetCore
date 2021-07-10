using Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICardFailRepository
    {
        Task<TypeIdentification> CreateCardFailRegistryAsync(CardFail card);
        Task<IEnumerable<CardFail>> GetByIdAsync(Guid id);
    }
}