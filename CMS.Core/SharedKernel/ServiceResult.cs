﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.SharedKernel
{
    public class ServiceResult
    {
        private static readonly ServiceResult _success = new ServiceResult(true);

        /// <summary>
        ///     Failure constructor that takes error messages
        /// </summary>
        /// <param name="errors"></param>
        public ServiceResult(params string[] errors) : this((IEnumerable<string>)errors)
        {
        }

        /// <summary>
        ///     Failure constructor that takes error messages
        /// </summary>
        /// <param name="errors"></param>
        public ServiceResult(IEnumerable<string> errors)
        {
            if (errors == null)
            {
                errors = new[] { "Default result error message" };
            }
            Succeeded = false;
            Errors = errors;
        }

        /// <summary>
        /// Constructor that takes whether the result is successful
        /// </summary>
        /// <param name="success"></param>
        protected ServiceResult(bool success)
        {
            Succeeded = success;
            Errors = new string[0];
        }

        /// <summary>
        ///     True if the operation was successful
        /// </summary>
        public bool Succeeded { get; private set; }

        /// <summary>
        ///     List of errors
        /// </summary>
        public IEnumerable<string> Errors { get; private set; }

        public object DataResult { get; set; }

        /// <summary>
        ///     Static success result
        /// </summary>
        /// <returns></returns>
        public static ServiceResult Success
        {
            get { return _success; }
        }

        /// <summary>
        ///     Failed helper method
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static ServiceResult Failed(params string[] errors)
        {
            return new ServiceResult(errors);
        }

        public override string ToString()
        {
            if (Succeeded)
                return "Succeeded";
            else
            {
                return string.Join("; ", Errors);
            }
        }

    }
}
