using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.API.Jobs
{
    public static class SchedulerHelper
    {
        
        public static async void SchedulerSetup()
        {
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = await schedulerFactory.GetScheduler();

            // Zaman dilimi ayarını belirle (örneğin, UTC)
            

            await scheduler.Start();

            // Geriye dönük saat farkı oluşturulmamalı
            var showDateTimeJob = JobBuilder.Create<OrderStatusJob>()
                .WithIdentity("OrderStatusJob")
                .Build();

            var trigger = Quartz.TriggerBuilder.Create()
                .WithIdentity("OrderStatusJob")
                .StartNow()
                .WithCronSchedule("0 0/1 * 1/1 * ? *") // Her dakika çalıştırmak için örnek bir Cron ifadesi
                .Build();

            var result = await scheduler.ScheduleJob(showDateTimeJob, trigger);
        }
    }
}
