using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;
using AngularJS.Animate;
using System.Diagnostics;

namespace TestAngularJS
{                           
   public class AnimationExample
   {
      public static void Main()
      {        
         Module app = new Module("myApp", ngAnimate.ModuleName);         

         app.Animation<SpecialAnimation>(".special-animation");

         app.Controller<AnimationController>();
      }   
   }  

   public class AnimationController
   {
      public bool Checked;
      public string bodytext;
      public string[] items;
      public string filter;
      public bool runAnimation;

      public AnimationController(Scope _scope)
      {
         Checked = false;
         bodytext = "This text is animated when shown on/off";
         items = new string[] { "Rome", "Tokyo", "New York", "London", "Paris", "Moscow", "Berlin" };         
         runAnimation = false;
      }

      public void startAnimation()
      {
         runAnimation = !runAnimation;
      }
   }    

   public class SpecialAnimation : IAnimation
   {      
      private string scrolltext = "*** CBM BASIC V2 *** 3583 BYTES FREE READY. 10 PRINT 'HELLO' 20 GOTO 10 RUN";

      private Interval Interval;

      public SpecialAnimation(Interval _interval)
      {
         this.Interval = _interval;
      }

      public object GetDefinition()
      {         
         Func<List<System.Html.Element>,string,Action,Action> removeClass = (element,className,doneCallback)=>
         {                                   
            // keep tracks of the timer
            Promise timerPromise = null;

            // the cancel/end animation funcion
            Action cancelCallback = ()=>
            { 
               Interval.Cancel(timerPromise);               
            };

            // the function that updated the control
            Action<System.Html.Element> OnTick = (el)=>
            {
               int l = el.TextContent.Length;
               if(l<scrolltext.Length) 
               {
                  el.TextContent = scrolltext.Substring(0,l+1);
               }
               else
               { 
                  cancelCallback(); // stops the animation
                  doneCallback(); 
               }               
            };
                                                                  
            if(className == "ng-hide") 
            {
               // We're unhiding the element, i.e. showing the element
               var el = element[0];
               el.TextContent="*";               
               
               timerPromise = Interval.Set(()=>OnTick(el),100);               
            } 
            else doneCallback(); 

            return cancelCallback;
         };
         
         // Action<bool> addClass(element, string className, Action done)
         Action<List<System.Html.Element>,string,Action> addClass = (element,className,done)=>
         {            
            if(className == "ng-hide") 
            {
               // We're hiding the element
               done();
            } 
            else done(); 
         };
         
         return new { addClass=addClass, removeClass=removeClass };
      }
   }   
}
