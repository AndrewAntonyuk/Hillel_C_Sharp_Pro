﻿using ClinicAppointment.Domain.Entities;

namespace ClinicAppointment.Service.Interfaces
{
    public interface IDoctorService
    {
        Doctor Create(Doctor doctor);

        IEnumerable<Doctor> GetAll();

        Doctor? Get(int id);

        bool Delete(int id);

        Doctor Update(int id, Doctor doctor);

        void ShowInfo(Doctor doctor);
    }
}