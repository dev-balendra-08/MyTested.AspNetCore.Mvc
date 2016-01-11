﻿namespace MyTested.Mvc.Builders.ActionResults.HttpNotFound
{
    using Contracts.ActionResults.HttpNotFound;
    using Microsoft.AspNet.Mvc;
    using Models;
    using System;
    using Contracts.Base;
    using Internal.Extensions;
    using Exceptions;

    /// <summary>
    /// Used for testing HTTP not found result.
    /// </summary>
    /// <typeparam name="TActionResult">Type of not found result - HttpNotFoundResult or HttpNotFoundObjectResult.</typeparam>
    public class HttpNotFoundTestBuilder<TActionResult>
        : BaseResponseModelTestBuilder<TActionResult>, IHttpNotFoundTestBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpNotFoundTestBuilder{TActionResult}" /> class.
        /// </summary>
        /// <param name="controller">Controller on which the action will be tested.</param>
        /// <param name="actionName">Name of the tested action.</param>
        /// <param name="caughtException">Caught exception during the action execution.</param>
        /// <param name="actionResult">Result from the tested action.</param>
        public HttpNotFoundTestBuilder(
            Controller controller,
            string actionName,
            Exception caughtException,
            TActionResult actionResult)
            : base(controller, actionName, caughtException, actionResult)
        {
        }

        /// <summary>
        /// Tests whether no response model is returned from the invoked action.
        /// </summary>
        /// <returns>Base test builder with action.</returns>
        public IBaseTestBuilderWithCaughtException WithNoResponseModel()
        {
            var actualResult = this.ActionResult as HttpNotFoundResult;
            if (actualResult == null)
            {
                throw new ResponseModelAssertionException(string.Format(
                        "When calling {0} action in {1} expected to not have response model but in fact response model was found.",
                        this.ActionName,
                        this.Controller.GetName()));
            }

            return this;
        }
    }
}
