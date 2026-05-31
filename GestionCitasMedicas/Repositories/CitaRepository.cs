using GestionCitasMedicas.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Repositories
{
    public class CitaRepository : Repository<Cita>
    {
        public void AgregarCita(Cita cita)
        {
            datos.Add(cita);
        }
    }
}
