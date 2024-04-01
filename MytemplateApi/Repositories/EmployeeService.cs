using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MytemplateApi.Data;
using MytemplateApi.DTOs;
using MytemplateApi.Models;

namespace MytemplateApi.Repositories
{
    public class EmployeeService : IGenericCrudService<Employee, CreateEmployeeDto, GetEmployeeDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetEmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return _mapper.Map<GetEmployeeDto>(employee);
        }

        public async Task<IEnumerable<GetEmployeeDto>> GetAllAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<GetEmployeeDto>>(employees);
        }

        public async Task<GetEmployeeDto> AddAsync(CreateEmployeeDto createDto)
        {
            var employee = _mapper.Map<Employee>(createDto);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetEmployeeDto>(employee);
        }

        public async Task<GetEmployeeDto> UpdateAsync(int id, CreateEmployeeDto updateDto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            _mapper.Map(updateDto, employee);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetEmployeeDto>(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }

}
