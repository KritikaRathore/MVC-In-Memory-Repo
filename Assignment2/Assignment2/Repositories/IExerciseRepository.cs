using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    public interface IExerciseRepository<T> where T : Exercise
    {
        // search Exercise by Name
        IEnumerable<T> GetByName(string ExerciseName);

        void Create(T entity);

        //return all Exercise list
        IEnumerable<T> GetAll();

    }
}
