using CMS.Core.Interfaces;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Services
{
    public class DefaultBackgroundJob : CMS.Core.Interfaces.IBackgroundJob
    {
        public string ContinueJobWith([NotNull] string parentId, [InstantHandle, NotNull] Expression<Action> methodCall)
        {
            return BackgroundJob.ContinueJobWith(parentId, methodCall);
        }

        public string ContinueJobWith<T>([NotNull] string parentId, [InstantHandle, NotNull] Expression<Action<T>> methodCall)
        {
            return BackgroundJob.ContinueJobWith<T>(parentId, methodCall);
        }

        public string ContinueJobWith([NotNull] string parentId, [InstantHandle, NotNull] Expression<Action> methodCall, Core.Interfaces.JobContinuationOptions options)
        {
            return BackgroundJob.ContinueJobWith(parentId,methodCall, (Hangfire.JobContinuationOptions)options);
        }

        public string ContinueJobWith([NotNull] string parentId, [InstantHandle, NotNull] Expression<Func<Task>> methodCall, Core.Interfaces.JobContinuationOptions options = Core.Interfaces.JobContinuationOptions.OnlyOnSucceededState)
        {
            return BackgroundJob.ContinueJobWith(parentId, methodCall, (Hangfire.JobContinuationOptions)options);
        }

        public string ContinueJobWith<T>([NotNull] string parentId, [InstantHandle, NotNull] Expression<Action<T>> methodCall, Core.Interfaces.JobContinuationOptions options)
        {
            return BackgroundJob.ContinueJobWith<T>(parentId, methodCall, (Hangfire.JobContinuationOptions)options);
        }

        public string ContinueJobWith<T>([NotNull] string parentId, [InstantHandle, NotNull] Expression<Func<T, Task>> methodCall, Core.Interfaces.JobContinuationOptions options = Core.Interfaces.JobContinuationOptions.OnlyOnSucceededState)
        {
            return BackgroundJob.ContinueJobWith<T>(parentId, methodCall, (Hangfire.JobContinuationOptions)options);
        }

        public string ContinueWith([NotNull] string parentId, [InstantHandle, NotNull] Expression<Action> methodCall)
        {
            return BackgroundJob.ContinueJobWith(parentId, methodCall);
        }

        public string ContinueWith<T>([NotNull] string parentId, [InstantHandle, NotNull] Expression<Action<T>> methodCall)
        {
            return BackgroundJob.ContinueJobWith<T>(parentId, methodCall);
        }

        public string ContinueWith([NotNull] string parentId, [InstantHandle, NotNull] Expression<Action> methodCall, Core.Interfaces.JobContinuationOptions options)
        {
            return BackgroundJob.ContinueJobWith(parentId, methodCall, (Hangfire.JobContinuationOptions)options);
        }

        public string ContinueWith([NotNull] string parentId, [InstantHandle, NotNull] Expression<Func<Task>> methodCall, Core.Interfaces.JobContinuationOptions options = Core.Interfaces.JobContinuationOptions.OnlyOnSucceededState)
        {
            return BackgroundJob.ContinueJobWith(parentId, methodCall, (Hangfire.JobContinuationOptions)options);
        }

        public string ContinueWith<T>([NotNull] string parentId, [InstantHandle, NotNull] Expression<Action<T>> methodCall, Core.Interfaces.JobContinuationOptions options)
        {
            return BackgroundJob.ContinueJobWith<T>(parentId, methodCall, (Hangfire.JobContinuationOptions)options);
        }

        public string ContinueWith<T>([NotNull] string parentId, [InstantHandle, NotNull] Expression<Func<T, Task>> methodCall, Core.Interfaces.JobContinuationOptions options = Core.Interfaces.JobContinuationOptions.OnlyOnSucceededState)
        {
            return BackgroundJob.ContinueJobWith<T>(parentId, methodCall, (Hangfire.JobContinuationOptions)options);
        }

        public bool Delete([NotNull] string jobId)
        {
            return BackgroundJob.Delete(jobId);
        }

        public bool Delete([NotNull] string jobId, [CanBeNull] string fromState)
        {
            return BackgroundJob.Delete(jobId, fromState);
        }
        public string Enqueue([InstantHandle, NotNull] Expression<Action> methodCall)
        {
            return BackgroundJob.Enqueue(methodCall);
        }

        public string Enqueue([InstantHandle, NotNull] Expression<Func<Task>> methodCall)
        {
            return BackgroundJob.Enqueue(methodCall);
        }

        public string Enqueue<T>([InstantHandle, NotNull] Expression<Action<T>> methodCall)
        {
            return BackgroundJob.Enqueue<T>(methodCall);
        }

        public string Enqueue<T>([InstantHandle, NotNull] Expression<Func<T, Task>> methodCall)
        {
            return BackgroundJob.Enqueue<T>(methodCall);
        }

        public bool Requeue([NotNull] string jobId)
        {
            return BackgroundJob.Requeue(jobId);
        }

        public bool Requeue([NotNull] string jobId, [CanBeNull] string fromState)
        {
            return BackgroundJob.Requeue(jobId, fromState);
        }

        public string Schedule([InstantHandle, NotNull] Expression<Action> methodCall, TimeSpan delay)
        {
            return BackgroundJob.Schedule(methodCall, delay);
        }

        public string Schedule([InstantHandle, NotNull] Expression<Func<Task>> methodCall, TimeSpan delay)
        {
            return BackgroundJob.Schedule(methodCall, delay);
        }

        public string Schedule([InstantHandle, NotNull] Expression<Action> methodCall, DateTimeOffset enqueueAt)
        {
            return BackgroundJob.Schedule(methodCall, enqueueAt);
        }

        public string Schedule([InstantHandle, NotNull] Expression<Func<Task>> methodCall, DateTimeOffset enqueueAt)
        {
            return BackgroundJob.Schedule(methodCall, enqueueAt);
        }

        public string Schedule<T>([InstantHandle, NotNull] Expression<Action<T>> methodCall, TimeSpan delay)
        {
            return BackgroundJob.Schedule<T>(methodCall, delay);
        }

        public string Schedule<T>([InstantHandle, NotNull] Expression<Func<T, Task>> methodCall, TimeSpan delay)
        {
            return BackgroundJob.Schedule<T>(methodCall, delay);
        }

        public string Schedule<T>([InstantHandle, NotNull] Expression<Action<T>> methodCall, DateTimeOffset enqueueAt)
        {
            return BackgroundJob.Schedule<T>(methodCall, enqueueAt);
        }

        public string Schedule<T>([InstantHandle, NotNull] Expression<Func<T, Task>> methodCall, DateTimeOffset enqueueAt)
        {

            BackgroundJob.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
            return BackgroundJob.Schedule<T>(methodCall, enqueueAt);
        }
    }
}
