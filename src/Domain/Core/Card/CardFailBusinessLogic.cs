using Application.Commons;
using Application.Dtos;
using Application.Entities;
using Application.Repositories;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Application.Core
{
    class CardFailBusinessLogic
    {
        /// <summary>
        /// User repository
        /// </summary>
        private readonly ICardFailRepository _cardFailRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cardFailRepository"></param>
        /// <param name="mapper"></param>
        public CardFailBusinessLogic(ICardFailRepository cardFailRepository, IMapper mapper)
        {
            _cardFailRepository = cardFailRepository;
            _mapper = mapper;
        }



        /// <summary>
        /// Method create user
        /// </summary>
        /// <param name="userdto">User create</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>User created</returns>
        public async Task<Response<CardFailDto>> CreateUser(CardFailDto cardFail)
        {
            var response = new Response<CardFailDto>();
            response.GetCorrelation();

          
            var card = this._mapper.Map<CardFail>(cardFail);
            var result = await this._cardFailRepository.CreateCardFailRegistryAsync(card);
            response.Data = this._mapper.Map<CardFailDto>(result);
         
            return response;
        }

        /// <summary>
        /// Method update user
        /// </summary>
        /// <param name="userdto">User to update</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>User updated</returns>
        public async Task<Response<CardFailDto>> GetById(Guid id)
        {
            var response = new Response<CardFailDto>();
            response.GetCorrelation();


         
            var result = await this._cardFailRepository.GetByIdAsync(id);
            response.Data = this._mapper.Map<CardFailDto>(result);

            return response;
        }

    }
}
