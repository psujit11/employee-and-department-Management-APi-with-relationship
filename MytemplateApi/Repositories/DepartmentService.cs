using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MytemplateApi.Data;
using MytemplateApi.DTOs;
using MytemplateApi.Models;

namespace MytemplateApi.Repositories
{
    public class DepartmentService : IGenericCrudService<Department, CreateDepartmentDto, GetDepartmentDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDepartmentDto> GetByIdAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return _mapper.Map<GetDepartmentDto>(department);
        }

        public async Task<IEnumerable<GetDepartmentDto>> GetAllAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return _mapper.Map<IEnumerable<GetDepartmentDto>>(departments);
        }

        public async Task<GetDepartmentDto> AddAsync(CreateDepartmentDto createDto)
        {
            var department = _mapper.Map<Department>(createDto);
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetDepartmentDto>(department);
        }

        public async Task<GetDepartmentDto> UpdateAsync(int id, CreateDepartmentDto updateDto)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                throw new Exception("Department not found");
            }

            _mapper.Map(updateDto, department);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetDepartmentDto>(department);
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                throw new Exception("Department not found");
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }

}
