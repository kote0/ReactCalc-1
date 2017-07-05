﻿using DomainModels.Repository;
using ReactCalc;
using System.Linq;
using System.Web.Mvc;

namespace WebCalc
{
    public static class CalcHelper
    {
        public static void UpdateOperations()
        {
            var calcOperations = new Calc().Operations;

            var operationRepository = DependencyResolver.Current.GetService<IOperationRepository>();

            var dbOperations = operationRepository.GetAll();
            var fullNames = dbOperations.Select(o => o.FullName.ToLower());

            foreach (var calcOper in calcOperations)
            {
                var fullName = calcOper.GetType().FullName.ToLower();
                if (fullNames.Contains(fullName))
                    continue;

                var newOper = operationRepository.Create();
                newOper.FullName = fullName;
                newOper.Name = calcOper.Name;

                operationRepository.Update(newOper);
            }
        }
    }
}