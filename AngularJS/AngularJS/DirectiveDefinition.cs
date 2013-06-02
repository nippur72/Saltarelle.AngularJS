using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace AngularJS
{       
   [Flags] public enum RestrictFlags { Element=1, Attribute=2, Class=4, Comment=8 };
   
   public enum ScopeModes { Existing, New, Isolate };

   public enum BindingStrategies { AsString, AsProperty, AsFunction };

   public class ScopeBindings
   {      
      public string AttributeName = null; 
      public BindingStrategies Strategy = BindingStrategies.AsString;
      public string TemplateAttributeName = null; 

      public ScopeBindings(string AttributeName)
      {
         this.AttributeName = AttributeName;
         this.Strategy = BindingStrategies.AsString; 
      } 

      public ScopeBindings(string AttributeName, BindingStrategies Strategy)
      {
         this.AttributeName = AttributeName;
         this.Strategy = Strategy;         
      } 
      
      public ScopeBindings(string AttributeAlias, BindingStrategies Strategy, string TemplateAttributeName)
      {
         this.AttributeName = AttributeAlias;
         this.Strategy = Strategy;         
         this.TemplateAttributeName = TemplateAttributeName;
      } 

      public string ScopeBindingString()
      {
         var s = "";
              if(Strategy==BindingStrategies.AsString)    s = "@";
         else if(Strategy==BindingStrategies.AsProperty)  s = "=";
         else if(Strategy==BindingStrategies.AsFunction)  s = "&";

         if(TemplateAttributeName!=null) s+=TemplateAttributeName;
         return s;
      }     
   }
   
   public class DirectiveDefinition
   {
      public string Name;
      public RestrictFlags Restrict = RestrictFlags.Attribute;
      public int? Priority;   
      public string Template;
      public string TemplateUrl;
      public bool Replace;
      public bool Transclude;
      public ScopeModes ScopeMode = ScopeModes.Existing;
      public List<ScopeBindings> ScopeAttributes = new List<ScopeBindings>();      
      public string Require;      
      public dynamic Compile;
      public Type SharedController;
      public Type DirectiveController;

      private string RestrictString()
      {
         string s = "";
         if((Restrict & RestrictFlags.Element  )==RestrictFlags.Element  ) s+="E";
         if((Restrict & RestrictFlags.Attribute)==RestrictFlags.Attribute) s+="A";
         if((Restrict & RestrictFlags.Class    )==RestrictFlags.Class    ) s+="C";
         if((Restrict & RestrictFlags.Comment  )==RestrictFlags.Comment  ) s+="M";
         return s;
      }

      protected string RequireDirective(string ControllerName, bool LookParent, bool Optional)
      {
         string s = ControllerName;
         if(Optional) s="?"+s;
         if(LookParent) s="^"+s;         
         return s;
      }      

      public JsDictionary CreateDefinitionObject()
      {
         JsDictionary result = new JsDictionary();
         
         // maps name
         if(Name!=null) result["name"] = Name;

         // maps priority
         if(Priority!=null) result["priority"] = Priority;

         // maps restrict
         result["restrict"] = RestrictString();

         // maps template and templateUrl
              if(Template!=null) result["template"] = Template;
         else if(TemplateUrl!=null) result["templateUrl"] = TemplateUrl;

         // maps replace
         result["replace"] = Replace;

         // maps transclude
         result["transclude"] = Transclude;

         // maps scope
              if(ScopeMode == ScopeModes.Existing) result["scope"] = false;
         else if(ScopeMode == ScopeModes.New)      result["scope"] = true;
         else if(ScopeMode == ScopeModes.Isolate)
         {
            JsDictionary scope = new JsDictionary();
            foreach(ScopeBindings sb in ScopeAttributes)
            {
               scope[sb.AttributeName] = sb.ScopeBindingString();
            }
            result["scope"] = scope;
         }         

         // maps compile function
         
         // maps (shared) controller         
         if(SharedController != null)
         {
            var scontr = SharedController.BuildControllerFunction(ThisMode.This);
            result["controller"] = scontr;                            
         }                                                    

         // directive controller ('link' function) is managed during the registration process
                                                             
         // maps require
         if(Require!=null) result["require"] = Require;

         return result;
      }

   }
}

