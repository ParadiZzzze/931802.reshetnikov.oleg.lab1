using System;
using Lab1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Services
{
    public class InjectionService : IServiceInjection
    {
        private int X;
        private int Y;
        public CalcModel Calculate()
        {
            Random rnd = new();
            X = rnd.Next() % 11;
            Y = rnd.Next() % 11;
            return new CalcModel(X, Y,
                $"{X} + {Y} = {X + Y}",
                $"{X} - {Y} = {X - Y}",
                $"{X} * {Y} = {X * Y}",
                Y != 0 ? $"{X} / {Y} = {X / Y}" : "Division by zero");
        }
    }
}
