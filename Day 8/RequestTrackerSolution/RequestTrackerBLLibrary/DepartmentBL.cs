﻿using RequestTrackerDALLibrary;
using RequestTrackerExepctions;
using RequestTrackerModalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL: IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;

        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            //_departmentRepository = new DepartmentRepository();//Tight coupling
            _departmentRepository = departmentRepository;//Loose coupling
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            List<Department> AllDepartment = _departmentRepository.GetAll();
            if (AllDepartment != null)
            {
                for (int i = 0; i < AllDepartment.Count; i++)
                {
                    if (AllDepartment[i].Name == departmentOldName)
                    {
                        AllDepartment[i].Name = departmentNewName;
                        return AllDepartment[i];
                    }
                }
            }
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int id)
        {
            List<Department> AllDepartment = _departmentRepository.GetAll();
            if (AllDepartment != null)
            {
                for (int i = 0; i < AllDepartment.Count; i++)
                {
                    if (AllDepartment[i].Id == id)
                    {
                        return AllDepartment[i];
                    }
                }
            }
            throw new NotImplementedException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var departments = _departmentRepository.GetAll();
            for (int i = 0; i < departments.Count; i++)
                if (departments[i].Name == departmentName)
                    return departments[i];
            throw new DepartmentNotFoundException();
        }

        public string GetDepartmentHeadById(int departmentId)
        {
            List<Department> AllDepartment = _departmentRepository.GetAll();
            if (AllDepartment != null)
            {
                for (int i = 0; i < AllDepartment.Count; i++)
                {
                    if (AllDepartment[i].Id == departmentId)
                    {
                        return AllDepartment[i].Department_Head;
                    }
                }
            }
            throw new NotImplementedException();
        }

        public List<Department> GetDepartmentList()
        {
            List<Department> AllDepartment = _departmentRepository.GetAll();
            if (AllDepartment != null) return AllDepartment;
            throw new NotImplementedException();
        }

    }
}
