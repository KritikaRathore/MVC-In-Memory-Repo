using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment2.Models;
using System.Collections.Concurrent;

namespace Assignment2.Repositories
{
    public class ExerciseRepository<T> : IExerciseRepository<T> where T : Exercise
    {
       private static List<T> Exercises = new List<T>();
        public void Create(T entity)
        {
            Exercises.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Exercises.OrderByDescending(x => x.ExerciseDate).ToList();
        }

        public IEnumerable<T> GetByName(string ExerciseName)
        {
            return Exercises.Where(x => x.ExerciseName.Contains(ExerciseName)).OrderByDescending(x => x.ExerciseDate);           
        }
    }
}