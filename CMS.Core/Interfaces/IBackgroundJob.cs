using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IBackgroundJob
    {

        string Enqueue([InstantHandle, NotNull] Expression<Action> methodCall);
        // <summary>
        /// Creates a new fire-and-forget job based on a given method call expression.
        /// </summary>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <returns>Unique identifier of a background job.</returns>
        /// 
        /// <exception cref="ArgumentNullException">
        /// <paramref name="methodCall"/> is <see langword="null"/>.
        /// </exception>
        /// 
        /// <seealso cref="EnqueuedState"/>
        /// <seealso cref="O:Hangfire.IBackgroundJobClient.Enqueue"/>
        string Enqueue([NotNull, InstantHandle] Expression<Func<Task>> methodCall);

        /// <summary>
        /// Creates a new fire-and-forget job based on a given method call expression.
        /// </summary>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <returns>Unique identifier of a background job.</returns>
        /// 
        /// <exception cref="ArgumentNullException">
        /// <paramref name="methodCall"/> is <see langword="null"/>.
        /// </exception>
        /// 
        /// <seealso cref="EnqueuedState"/>
        /// <seealso cref="O:Hangfire.IBackgroundJobClient.Enqueue"/>
        string Enqueue<T>([NotNull, InstantHandle] Expression<Action<T>> methodCall);

        /// <summary>
        /// Creates a new fire-and-forget job based on a given method call expression.
        /// </summary>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <returns>Unique identifier of a background job.</returns>
        /// 
        /// <exception cref="ArgumentNullException">
        /// <paramref name="methodCall"/> is <see langword="null"/>.
        /// </exception>
        /// 
        /// <seealso cref="EnqueuedState"/>
        /// <seealso cref="O:Hangfire.IBackgroundJobClient.Enqueue"/>
        string Enqueue<T>([NotNull, InstantHandle] Expression<Func<T, Task>> methodCall);
        /// <summary>
        /// Creates a new background job based on a specified method
        /// call expression and schedules it to be enqueued after a given delay.
        /// </summary>
        /// 
        /// <param name="methodCall">Instance method call expression that will be marshalled to the Server.</param>
        /// <param name="delay">Delay, after which the job will be enqueued.</param>
        /// <returns>Unique identifier of the created job.</returns>
        string Schedule(
            [NotNull, InstantHandle] Expression<Action> methodCall,
            TimeSpan delay);

        /// <summary>
        /// Creates a new background job based on a specified method
        /// call expression and schedules it to be enqueued after a given delay.
        /// </summary>
        /// 
        /// <param name="methodCall">Instance method call expression that will be marshalled to the Server.</param>
        /// <param name="delay">Delay, after which the job will be enqueued.</param>
        /// <returns>Unique identifier of the created job.</returns>
        string Schedule(
            [NotNull, InstantHandle] Expression<Func<Task>> methodCall,
            TimeSpan delay);

        /// <summary>
        /// Creates a new background job based on a specified method call expression
        /// and schedules it to be enqueued at the given moment of time.
        /// </summary>
        /// 
        /// <param name="methodCall">Method call expression that will be marshalled to the Server.</param>
        /// <param name="enqueueAt">The moment of time at which the job will be enqueued.</param>
        /// <returns>Unique identifier of a created job.</returns>
        string Schedule(
            [NotNull, InstantHandle] Expression<Action> methodCall,
            DateTimeOffset enqueueAt);

        /// <summary>
        /// Creates a new background job based on a specified method call expression
        /// and schedules it to be enqueued at the given moment of time.
        /// </summary>
        /// 
        /// <param name="methodCall">Method call expression that will be marshalled to the Server.</param>
        /// <param name="enqueueAt">The moment of time at which the job will be enqueued.</param>
        /// <returns>Unique identifier of a created job.</returns>
        string Schedule(
            [NotNull, InstantHandle] Expression<Func<Task>> methodCall,
            DateTimeOffset enqueueAt);

        /// <summary>
        /// Creates a new background job based on a specified instance method
        /// call expression and schedules it to be enqueued after a given delay.
        /// </summary>
        /// 
        /// <typeparam name="T">Type whose method will be invoked during job processing.</typeparam>
        /// <param name="methodCall">Instance method call expression that will be marshalled to the Server.</param>
        /// <param name="delay">Delay, after which the job will be enqueued.</param>
        /// <returns>Unique identifier of the created job.</returns>
        string Schedule<T>(
            [NotNull, InstantHandle] Expression<Action<T>> methodCall,
            TimeSpan delay);

        /// <summary>
        /// Creates a new background job based on a specified instance method
        /// call expression and schedules it to be enqueued after a given delay.
        /// </summary>
        /// 
        /// <typeparam name="T">Type whose method will be invoked during job processing.</typeparam>
        /// <param name="methodCall">Instance method call expression that will be marshalled to the Server.</param>
        /// <param name="delay">Delay, after which the job will be enqueued.</param>
        /// <returns>Unique identifier of the created job.</returns>
        string Schedule<T>(
            [NotNull, InstantHandle] Expression<Func<T, Task>> methodCall,
            TimeSpan delay);

        /// <summary>
        /// Creates a new background job based on a specified method call expression
        /// and schedules it to be enqueued at the given moment of time.
        /// </summary>
        /// 
        /// <typeparam name="T">The type whose method will be invoked during the job processing.</typeparam>
        /// <param name="methodCall">Method call expression that will be marshalled to the Server.</param>
        /// <param name="enqueueAt">The moment of time at which the job will be enqueued.</param>
        /// <returns>Unique identifier of a created job.</returns>
        string Schedule<T>(
            [NotNull, InstantHandle] Expression<Action<T>> methodCall,
            DateTimeOffset enqueueAt);

        /// <summary>
        /// Creates a new background job based on a specified method call expression
        /// and schedules it to be enqueued at the given moment of time.
        /// </summary>
        /// 
        /// <typeparam name="T">The type whose method will be invoked during the job processing.</typeparam>
        /// <param name="methodCall">Method call expression that will be marshalled to the Server.</param>
        /// <param name="enqueueAt">The moment of time at which the job will be enqueued.</param>
        /// <returns>Unique identifier of a created job.</returns>
        string Schedule<T>(
            [NotNull, InstantHandle] Expression<Func<T, Task>> methodCall,
            DateTimeOffset enqueueAt);

        /// <summary>
        /// Changes state of a job with the specified <paramref name="jobId"/>
        /// to the <see cref="DeletedState"/>. 
        /// <seealso cref="BackgroundJobClientExtensions.Delete(IBackgroundJobClient, string)"/>
        /// </summary>
        /// 
        /// <param name="jobId">An identifier, that will be used to find a job.</param>
        /// <returns>True on a successfull state transition, false otherwise.</returns>
        bool Delete([NotNull] string jobId);
        /// <summary>
        /// Changes state of a job with the specified <paramref name="jobId"/>
        /// to the <see cref="DeletedState"/>. State change is only performed
        /// if current job state is equal to the <paramref name="fromState"/> value.
        /// <seealso cref="BackgroundJobClientExtensions.Delete(IBackgroundJobClient, string, string)"/>
        /// </summary>
        /// 
        /// <param name="jobId">Identifier of job, whose state is being changed.</param>
        /// <param name="fromState">Current state assertion, or null if unneeded.</param>
        /// <returns>True, if state change succeeded, otherwise false.</returns>
        bool Delete([NotNull] string jobId, [CanBeNull] string fromState);

        /// <summary>
        /// Changes state of a job with the specified <paramref name="jobId"/>
        /// to the <see cref="EnqueuedState"/>.
        /// </summary>
        /// 
        /// <param name="jobId">Identifier of job, whose state is being changed.</param>
        /// <returns>True, if state change succeeded, otherwise false.</returns>
        bool Requeue([NotNull] string jobId);
        /// <summary>
        /// Changes state of a job with the specified <paramref name="jobId"/>
        /// to the <see cref="EnqueuedState"/>. If <paramref name="fromState"/> value 
        /// is not null, state change will be performed only if the current state name 
        /// of a job equal to the given value.
        /// </summary>
        /// 
        /// <param name="jobId">Identifier of job, whose state is being changed.</param>
        /// <param name="fromState">Current state assertion, or null if unneeded.</param>
        /// <returns>True, if state change succeeded, otherwise false.</returns>
        bool Requeue([NotNull] string jobId, [CanBeNull] string fromState);

        /// <summary>
        /// Creates a new background job that will wait for a successful completion 
        /// of another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <returns>Unique identifier of a created job.</returns>
        [Obsolete("Deprecated for clarity, please use ContinueJobWith method with the same arguments. Will be removed in 2.0.0.")]
        string ContinueWith(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Action> methodCall);

        /// <summary>
        /// Creates a new background job that will wait for a successful completion 
        /// of another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <returns>Unique identifier of a created job.</returns>
        string ContinueJobWith(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Action> methodCall);

        /// <summary>
        /// Creates a new background job that will wait for a successful completion 
        /// of another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <returns>Unique identifier of a created job.</returns>
        [Obsolete("Deprecated for clarity, please use ContinueJobWith method with the same arguments. Will be removed in 2.0.0.")]
        string ContinueWith<T>(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Action<T>> methodCall);

        /// <summary>
        /// Creates a new background job that will wait for a successful completion 
        /// of another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <returns>Unique identifier of a created job.</returns>
        string ContinueJobWith<T>(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Action<T>> methodCall);
        /// <summary>
        /// Creates a new background job that will wait for another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <param name="options">Continuation options.</param>
        /// <returns>Unique identifier of a created job.</returns>
        [Obsolete("Deprecated for clarity, please use ContinueJobWith method with the same arguments. Will be removed in 2.0.0.")]
        string ContinueWith(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Action> methodCall,
            JobContinuationOptions options);

        /// <summary>
        /// Creates a new background job that will wait for another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <param name="options">Continuation options.</param>
        /// <returns>Unique identifier of a created job.</returns>
        string ContinueJobWith(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Action> methodCall,
            JobContinuationOptions options);

        /// <summary>
        /// Creates a new background job that will wait for another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <param name="options">Continuation options. By default, 
        /// <see cref="JobContinuationOptions.OnlyOnSucceededState"/> is used.</param>
        /// <returns>Unique identifier of a created job.</returns>
        [Obsolete("Deprecated for clarity, please use ContinueJobWith method with the same arguments. Will be removed in 2.0.0.")]
        string ContinueWith(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Func<Task>> methodCall,
            JobContinuationOptions options = JobContinuationOptions.OnlyOnSucceededState);

        /// <summary>
        /// Creates a new background job that will wait for another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <param name="options">Continuation options. By default, 
        /// <see cref="JobContinuationOptions.OnlyOnSucceededState"/> is used.</param>
        /// <returns>Unique identifier of a created job.</returns>
        string ContinueJobWith(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Func<Task>> methodCall,
            JobContinuationOptions options = JobContinuationOptions.OnlyOnSucceededState);

        /// <summary>
        /// Creates a new background job that will wait for another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <param name="options">Continuation options.</param>
        /// <returns>Unique identifier of a created job.</returns>
        [Obsolete("Deprecated for clarity, please use ContinueJobWith method with the same arguments. Will be removed in 2.0.0.")]
        string ContinueWith<T>(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Action<T>> methodCall,
            JobContinuationOptions options);

        /// <summary>
        /// Creates a new background job that will wait for another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <param name="options">Continuation options.</param>
        /// <returns>Unique identifier of a created job.</returns>
        string ContinueJobWith<T>(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Action<T>> methodCall,
            JobContinuationOptions options);

        /// <summary>
        /// Creates a new background job that will wait for another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <param name="options">Continuation options. By default, 
        /// <see cref="JobContinuationOptions.OnlyOnSucceededState"/> is used.</param>
        /// <returns>Unique identifier of a created job.</returns>
        [Obsolete("Deprecated for clarity, please use ContinueJobWith method with the same arguments. Will be removed in 2.0.0.")]
        string ContinueWith<T>(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Func<T, Task>> methodCall,
            JobContinuationOptions options = JobContinuationOptions.OnlyOnSucceededState);

        /// <summary>
        /// Creates a new background job that will wait for another background job to be enqueued.
        /// </summary>
        /// <param name="parentId">Identifier of a background job to wait completion for.</param>
        /// <param name="methodCall">Method call expression that will be marshalled to a server.</param>
        /// <param name="options">Continuation options. By default, 
        /// <see cref="JobContinuationOptions.OnlyOnSucceededState"/> is used.</param>
        /// <returns>Unique identifier of a created job.</returns>
        string ContinueJobWith<T>(
            [NotNull] string parentId,
            [NotNull, InstantHandle] Expression<Func<T, Task>> methodCall,
            JobContinuationOptions options = JobContinuationOptions.OnlyOnSucceededState);
    }
}
