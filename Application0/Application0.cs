﻿//------------------------------------------------------------------------------
// <auto-generated class>
//     This code was generated by Ubiq Mobile plug-in (read only).
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//     You MUST NOT modify this source
//     This class contains initialization section and descriptions of 
//     component's interfaces
// </auto-generated class>
//------------------------------------------------------------------------------



using System;
using System.Reflection;
using System.Xml.Linq;
using System.Threading.Tasks;
using Ubiq.Graphics;
using Ubiq.Attributes;
using Ubiq.InterfaceAPI;


[assembly: UbiqUID("6e07efff-0b7b-4579-9d05-abf7236b6db6")]

namespace Application0
{
	
	[AppDescription("Application0")]
    public partial class Application0 : MExtendedThreadApp
    {

		VisualElement _ubiqdesign;


	    //Initialized UI form and ubiq components
		private void InitUI()
        {
			_ubiqdesign = Screen.CreateElement("UbiqDesign");

        }

		//Main entry point of application
        protected override async Task MainOverride()
        {
			
			Screen.GrabResources(Assembly.GetExecutingAssembly());
            InitUI();
            await UserSection();
        }
    }
}

