using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Results;

namespace BookstoreBL.Services
{
    public class BLResponse<T>
    {
        public bool hasErrors { get; set; }
        public IList<ValidationFailure> errors { get; set; }
        public T entity { get; set; }

        public BLResponse(IList<ValidationFailure> _errors, T _entity)
        {
            hasErrors = false;
            if(_errors.Count > 0)
            {
                hasErrors = true;
            }
            errors = _errors;
            entity = _entity;
        }
    }
}