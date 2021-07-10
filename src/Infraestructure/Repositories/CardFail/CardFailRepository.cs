using Application.Commons;
using Application.Data;
using Application.Entities;
using Dapper;
using Data.Querys;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class CardFailRepository : GenerycRepository, ICardFailRepository
    {
        /// <summary>
        /// CardFailRepository Repository
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>

        /// <summary>
        /// Contructor Repository CardFailRepository
        /// </summary>
        /// <param name="configuration">Configuration Api application.Api</param>
        public CardFailRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// GetAll CardFailRepository Method repository
        /// </summary>
        /// <returns>All CardFailRepository entity</returns>
        public async Task<IEnumerable<CardFail>> GetByIdAsync(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCardFailParameters.ID),id);

            return await GetAsync<CardFail>(CardFailsQuerys.SelectCardFilsById, null, CommandType.Text);
        }

        /// <summary>
        /// Insert CardFailRepository method repository
        /// </summary>
        /// <param name="typeIdentificacion">Tipo de CardFailRepository model</param>
        /// <returns>Type CardFailRepository create</returns>
        public async Task<TypeIdentification> CreateCardFailRegistryAsync(CardFail card)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCardFailParameters.ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCardFailParameters.Quantities), card.Quantities);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCardFailParameters.CREATED_BY), card.CreatedBy);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCardFailParameters.CREATED_ON), card.CreatedOn);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCardFailParameters.STATE), card.State);

            return await GetAsyncFirst<TypeIdentification>(QueryTypeIdentification.InsertTypeIdentification, parameters, CommandType.Text);
        }
    }
}
