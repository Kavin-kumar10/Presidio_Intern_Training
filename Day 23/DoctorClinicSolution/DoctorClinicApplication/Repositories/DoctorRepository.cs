using DoctorClinicApplication.Context;
using DoctorClinicApplication.Exceptions;
using DoctorClinicApplication.Interface;
using DoctorClinicApplication.Modals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoctorClinicApplication.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly DoctorClinicContext _context;

        public DoctorRepository(DoctorClinicContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }

        public async Task<Doctor> Delete(Doctor entity)
        {
            var doctor = Get(entity.Id);
            if (doctor != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
            throw new NoSuchDoctorFound();
        }

        public async Task<Doctor> Get(int key)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == key);
            return doctor;
            throw new NoSuchDoctorFound();
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            return await _context.Doctors.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Doctor> Update(Doctor entity)
        {
            var doctor = await Get(entity.Id);
            if (doctor != null)
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return doctor;
            }
            throw new NoSuchDoctorFound();
        }
    }
}
