﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Ui.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCardHistory(this IServiceCollection services) => services.AddScoped<CardHistory>();
    }
}
