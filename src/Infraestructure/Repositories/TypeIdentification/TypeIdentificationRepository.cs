using Application.Commons;
using Application.Data;
using Application.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class TypeIdentificationRepository : GenerycRepository, ITypeIdentificationRepository
    { 
       /// <summary>
      /// TypeIdentification Repository
      /// </summary>
      /// <author>Oscar Julian Rojas</author>
      /// <date>10/07/2021</date>

      /// <summary>
      /// Contructor Repository TypeIdentification
      /// </summary>
      /// <param name="configuration">Configuration Api application.Api</param>
        public TypeIdentificationRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// GetAll TypeIdentification Method repository
        /// </summary>
        /// <returns>All TypeIdenfication entity</returns>
        public async Task<IEnumerable<TypeIdentification>> GetAll()
        {
            return await GetAsync<TypeIdentification>(QueryTypeIdentification.GetAllTypeIdentification, null, CommandType.Text);
        }

        /// <summary>
        /// Insert typeidentificacion method repository
        /// </summary>
        /// <param name="typeIdentificacion">Tipo de identificacion model</param>
        /// <returns>Type Identificacion create</returns>
        public async Task<TypeIdentification> CreateTypeIdentification(TypeIdentification typeIdentificacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTypeIdentificationParameters.ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTypeIdentificationParameters.Description), typeIdentificacion.Description);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTypeIdentificationParameters.CREATED_BY), typeIdentificacion.CreatedBy);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTypeIdentificationParameters.CREATED_ON), typeIdentificacion.CreatedOn);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTypeIdentificationParameters.STATE), typeIdentificacion.State);

            return await GetAsyncFirst<TypeIdentification>(QueryTypeIdentification.InsertTypeIdentification, parameters, CommandType.Text);
        }
    }
}