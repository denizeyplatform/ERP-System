using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Features.Service.Employee
{
    public class EmployeeService : IEmployeeService
    {
        // automapper
        // reposiory

        public IMapper _mapper;
        public IEmployeeRepository _repository;

        public IUnitOfWork _unitOfWork;

        public EmployeeService(IMapper mapper, IEmployeeRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> createEmployee(EmployeeDto employeedto)
        {
            var repo = _mapper.Map<Domain.Entities.Employee>(employeedto);
         
            await _unitOfWork.AttendanceRepository.checkIn(new Domain.Entities.Attendance() { });

            await _unitOfWork.Repository<Domain.Entities.Employee>().AddAsync(repo);

            await _unitOfWork.Repository<Attendance>().GetAllAsync();

            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public Task<bool> deleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeDto>> getAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> getEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateEmployee(int id, EmployeeDto employeedto)
        {
            throw new NotImplementedException();
        }
    }
}
