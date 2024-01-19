﻿using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            
                //throw new Exception("Exception--------->>>");
                var companies = _repository.Company.GetAllCompanies(trackChanges);
                //var companiesDto = companies.Select(c => new CompanyDto(c.Id, c.Name ?? "", string.Join(' ', c.Address, c.Country))).ToList(); 
                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                return companiesDto;
           
        }

        public CompanyDto GetCompany(Guid id, bool trackChanges)
        {
            var company =  _repository.Company.GetCompany(id, trackChanges);
            var companyDto = _mapper.Map<CompanyDto>(company);  

            return companyDto;
        }


    }
}
