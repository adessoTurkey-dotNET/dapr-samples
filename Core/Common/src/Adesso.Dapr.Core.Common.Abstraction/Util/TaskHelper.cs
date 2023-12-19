using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adesso.Dapr.Core.Common.Abstraction.Util
{
    public static class TaskHelper
    {
        public static async Task<(T0, T1)> WhenAll<T0, T1>(Task<T0> task0, Task<T1> task1)
        {
            await Task.WhenAll(task0, task1);
            return (task0.Result, task1.Result);
        }

        public static async Task<(T0, T1, T2)> WhenAll<T0, T1, T2>(Task<T0> task0, Task<T1> task1, Task<T2> task2)
        {
            await Task.WhenAll(task0, task1, task2);
            return (task0.Result, task1.Result, task2.Result);
        }

        public static async Task<(T0, T1, T2, T3)> WhenAll<T0, T1, T2, T3>(Task<T0> task0, Task<T1> task1, Task<T2> task2, Task<T3> task3)
        {
            await Task.WhenAll(task0, task1, task2, task3);
            return (task0.Result, task1.Result, task2.Result, task3.Result);
        }

        public static async Task<(T0, T1, T2, T3, T4)> WhenAll<T0, T1, T2, T3, T4>(Task<T0> task0, Task<T1> task1, Task<T2> task2, Task<T3> task3, Task<T4> task4)
        {
            await Task.WhenAll(task0, task1, task2, task3, task4);
            return (task0.Result, task1.Result, task2.Result, task3.Result, task4.Result);
        }

        public static async Task<(T0, T1, T2, T3, T4, T5)> WhenAll<T0, T1, T2, T3, T4, T5>(Task<T0> task0, Task<T1> task1, Task<T2> task2, Task<T3> task3, Task<T4> task4, Task<T5> task5)
        {
            await Task.WhenAll(task0, task1, task2, task3, task4, task5);
            return (task0.Result, task1.Result, task2.Result, task3.Result, task4.Result, task5.Result);
        }

        public static async Task<List<T>> WhenAll<T>(
            IEnumerable<Task<T>> taskItems)
        {
            var tasks = taskItems as Task<T>[] ?? taskItems.ToArray();
            return await WhenAllByParams(tasks);
        }

        public static async Task<List<T>> WhenAllByParams<T>(
            params Task<T>[] taskItems)
        {
            await Task.WhenAll(taskItems);

            return taskItems.Select(taskItem => taskItem.GetAwaiter().GetResult()).ToList();
        }
    }
}
