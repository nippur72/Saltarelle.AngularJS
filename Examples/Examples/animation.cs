using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;

using AngularJS;
using jQueryApi;


namespace TestAngularJS
{                           
   public class AnimationExample
   {
      public static void Main()
      {        
         Module app = new Module("myApp");
         app.Animation<CoolAnimation>("cool-animation-show");
         app.Controller<AnimationController>();
      }   
   }  

   public class AnimationController
   {
      public bool show_block = true;

      public void switch_show()
      {
         show_block = !show_block;
      }

      public List<string> names;

      public AnimationController(Scope _scope)
      {
         names = new List<string>();
         names.Add("pippo");
         names.Add("pluto");
         names.Add(Angular.UpperCase(Angular.BuiltinFilters.jsonFilter.Filter(Angular.Version)));
      }

      public void add()
      {
         names.Insert(0,"item "+names.Count.ToString());
      }

      public void remove(int index)
      {
         names.RemoveAt(index);
      }      
   }  
   
   public class CoolAnimation
   {
      public CoolAnimation(RootScope _rootScope)
      {
         //System.Diagnostics.Debug.Break();
      }

      public void Setup(System.Html.Element element)
      {
         //this is called before the animation
         jQuery.FromElement(element).CSS("opacity",0);
      }

      public void Start(System.Html.Element element, Action done, object memo)
      {
         var ob = new JsDictionary("opacity",1);
         jQuery.FromElement(element).Animate(ob, new TypeOption<int,EffectDuration>(), EffectEasing.Linear, ()=>{done();});
      }

      public void Cancel(System.Html.Element element, Action done)
      {
      }
   }    
}

/*
//you can inject stuff!
myModule.animation('cool-animation', ['$rootScope', function($rootScope) {
  return { 
    setup : function(element) {
      //this is called before the animation
      jQuery(element).css({
        'border-width':0
      }); 
    },
    start : function(element, done, memo) {
      //this is where the animation is expected to be run
      jQuery(element).animate({
        'border-width':20
      }, function() {
        //call done to close when the animation is complete
        done(); 
      });
    },
    cancel : function(element, done) {
      //this is called when another animation is started
      //whilst the previous animation is still chugging away
    }   
  };
}]);
*/

