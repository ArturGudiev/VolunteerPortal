//-----------------------------User-section----------------------------------------------------
//  <User-defined part of application>
//
//      This is partial class that can be invoked from main entry point
//      This class is purposed for user-defined bussines logic of the application
//      The user should add proprietary code.
//      All modifications will be preserved during all automatic re-generations of the project
//  </User-defined part of application>
//----------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using Ubiq.Graphics;
using System.Threading.Tasks;

namespace Application0
{
    partial class Application0
    {
        public Controller currentController;
       
        protected async Task UserSection()
        {
            currentController = LoginController.getInstance(this);
            
            for (; ; )
            {
                currentController.action();
                await Wait();
            }
        }
        
    }
    
}