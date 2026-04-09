using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;
using Template.Domain.Interfaces;

namespace Template.Application.Features.Service.Employee
{
    public class EmployeeService : IEmployeeService
    {
        // automapper
        // reposiory

        public IMapper _mapper;
        public IEmployeeRepository _repository;
        // public IUnitOfWork _unitOfWork;

        public EmployeeService(IMapper mapper, IEmployeeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<bool> createEmployee(EmployeeDto employeedto)
        {
            var repo = _mapper.Map<Domain.Entities.Employee>(employeedto);
            // _unitOfWork.EmployeeRepository.AddAsync(repo);
            // _unitOfWork.saveChanges();
            await _repository.AddAsync(repo);

            return await Task.FromResult(true);
        }
    }
}
