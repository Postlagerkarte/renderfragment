﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppRenderFragment.Pages
{
    public class ZoneService
    {

        public event Action StateHasChanged;

        private List<RenderFragment> frags = new List<RenderFragment>();

        public void Register(RenderFragment frag)
        {
            frags.Add(frag);
        }

        public void Swap()
        {
            var temp = frags[0];
            frags[0] = frags[1];
            frags[1] = temp;
            StateHasChanged?.Invoke();
        }

        public List<RenderFragment> GetFrags(int zoneId)
        {
            if(zoneId == 1)
            {
                return frags.Take(1).ToList();
            }

            if(zoneId == 2)
            {
                return frags.Skip(1).Take(1).ToList();
            }

            throw new InvalidOperationException("unkown zone id");
        }
      
            
    }
}
