using PersonasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.DataServices
{
    public interface IRestDataService
    {
        Task<List<Persona>> GetAllPersonasAsync();
        Task AddPersonaAsync(Persona persona);
        Task UpdatePersonasAsync(Persona persona);
        Task DeletePersonaAsync(int id);        
    }
}
