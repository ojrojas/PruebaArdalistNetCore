using Application.Data;
using Application.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class TypeIdentificationRepository : GenerycRepository, ITypeIdentificationRepository
    { /// <summary>
      /// TypeIdentification Repository
      /// </summary>
      /// <author>Oscar Julian Rojas</author>
      /// <date>20/03/2021</date>

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
    }
}