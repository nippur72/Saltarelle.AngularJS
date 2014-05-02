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
   #region untyped attempt
   [Imported]
   public sealed class QService
   {
      //[ScriptName("all")]    public IPromise<any[]> All(promises: IPromise<any>[]);
      //[ScriptName("all")]    public IPromise<{[id: string]: any}> All(promises: {[id: string]: IPromise<any>;});
      [ScriptName("defer")]  public Deferred Defer() { return null; }
      [ScriptName("reject")] public Promise Reject(){ return null; }
      [ScriptName("reject")] public Promise Reject(object reason){ return null; }
      [ScriptName("when")]   public Promise When(Promise value){ return null; }
      [ScriptName("when")]   public Promise When(object value){ return null; }
   }    
   
   [Imported]
   public sealed class Promise
   {
      // 0-p
      [ScriptName("then")] public Promise Then()                                                              { return null; }

      // 1-p
      [ScriptName("then")] public Promise Then(Action successCallback)                                        { return null; }
      [ScriptName("then")] public Promise Then(Action<object> successCallback)                                { return null; }

      // 2-p
      [ScriptName("then")] public Promise Then(Action         successCallback, Action         errorCallback)  { return null; }
      [ScriptName("then")] public Promise Then(Action         successCallback, Action<object> errorCallback)  { return null; }
      [ScriptName("then")] public Promise Then(Action<object> successCallback, Action         errorCallback)  { return null; }
      [ScriptName("then")] public Promise Then(Action<object> successCallback, Action<object> errorCallback)  { return null; }
      
      // 3-p
      [ScriptName("then")] public Promise Then(Action         successCallback, Action         errorCallback, Action         notifyCallback) { return null; }
      [ScriptName("then")] public Promise Then(Action         successCallback, Action         errorCallback, Action<object> notifyCallback) { return null; }
      [ScriptName("then")] public Promise Then(Action         successCallback, Action<object> errorCallback, Action         notifyCallback) { return null; }
      [ScriptName("then")] public Promise Then(Action         successCallback, Action<object> errorCallback, Action<object> notifyCallback) { return null; }
      [ScriptName("then")] public Promise Then(Action<object> successCallback, Action         errorCallback, Action         notifyCallback) { return null; }
      [ScriptName("then")] public Promise Then(Action<object> successCallback, Action         errorCallback, Action<object> notifyCallback) { return null; }
      [ScriptName("then")] public Promise Then(Action<object> successCallback, Action<object> errorCallback, Action         notifyCallback) { return null; }
      [ScriptName("then")] public Promise Then(Action<object> successCallback, Action<object> errorCallback, Action<object> notifyCallback) { return null; }

      //[ScriptName("catch")] public Promise Catch<TResult>(Action<object> onRejected: (reason: any) => IHttpPromise<TResult>){ return null; }
      //[ScriptName("catch")] public Promise Catch<TResult>(onRejected: (reason: any) => IPromise<TResult>)    { return null; }
      //[ScriptName("catch")] public Promise Catch<TResult>(onRejected: (reason: any) => TResult)              { return null; }

      [ScriptName("finally")] public Promise Finally(Action FinallyCallback) { return null; }

      [InlineCode("({this}.then(function(response     ) {{ {fn}(response); }}),{this})")] public Promise Success(Action<object> fn) { return null; }
      [InlineCode("({this}.then(null,function(response) {{ {fn}(response); }}),{this})")] public Promise Error  (Action<object> fn) { return null; }      
      [InlineCode("({this}.then(function(response     ) {{ {fn}(); }}),{this})")] public Promise Success(Action fn) { return null; }
      [InlineCode("({this}.then(null,function(response) {{ {fn}(); }}),{this})")] public Promise Error  (Action fn) { return null; }      
   }                         

   [Imported]
   public sealed class Deferred 
   {
      [ScriptName("resolve")] public void Resolve() {}
      [ScriptName("resolve")] public void Resolve(object value) {}
      [ScriptName("reject")]  public void Reject() {}
      [ScriptName("reject")]  public void Reject(object reason) {}
      [ScriptName("notify")]  public void Notify() {}
      [ScriptName("notify")]  public void Notify(object state) {}
      [ScriptName("promise")] public Promise Promise;
   }
   #endregion


   #region typed attempt
   /*
   [Imported]
   public sealed class QService
   {
      //[ScriptName("all")]    public IPromise<any[]> All(promises: IPromise<any>[]);
      //[ScriptName("all")]    public IPromise<{[id: string]: any}> All(promises: {[id: string]: IPromise<any>;});
      [ScriptName("defer")]  public IDeferred<T> Defer<T>() { return null; }
      [ScriptName("reject")] public IPromise<object> Reject(){ return null; }
      [ScriptName("reject")] public IPromise<object> Reject(object reason){ return null; }
      [ScriptName("when")]   public IPromise<T> When<T>(IPromise<T> value){ return null; }
      [ScriptName("when")]   public IPromise<T> When<T>(T value){ return null; }
   }    
   
   [Imported]
   public sealed class IPromise<T>
   {
      [ScriptName("then")] public IPromise<TResult> Then<TResult>(Func<T,IPromise<TResult>> successCallback)                                                                        { return null; }
      [ScriptName("then")] public IPromise<TResult> Then<TResult>(Func<T,IPromise<TResult>> successCallback, Func<object,object> errorCallback)                                     { return null; }
      [ScriptName("then")] public IPromise<TResult> Then<TResult>(Func<T,IPromise<TResult>> successCallback, Func<object,object> errorCallback, Func<object,object> notifyCallback) { return null; }

      [ScriptName("then")] public IPromise<TResult> Then<TResult>(successCallback: (promiseValue: T) => IPromise<TResult>, errorCallback?: (reason: any) => any, notifyCallback?: (state: any) => any){ return null; }
      [ScriptName("then")] public IPromise<TResult> Then<TResult>(successCallback: (promiseValue: T) => TResult, errorCallback?: (reason: any) => TResult, notifyCallback?: (state: any) => any){ return null; }

      [ScriptName("catch")] public IPromise<TResult> Catch<TResult>(Action<object> onRejected: (reason: any) => IHttpPromise<TResult>){ return null; }
      [ScriptName("catch")] public IPromise<TResult> Catch<TResult>(onRejected: (reason: any) => IPromise<TResult>)    { return null; }
      [ScriptName("catch")] public IPromise<TResult> Catch<TResult>(onRejected: (reason: any) => TResult)              { return null; }

      [ScriptName("finally")] public IPromise<TResult> Finally<TResult>(Action FinallyCallback) { return null; }
   }                         

   [Imported]
   public sealed class IDeferred<T> 
   {
      [ScriptName("resolve")] public void Resolve() {}
      [ScriptName("resolve")] public void Resolve(T value) {}
      [ScriptName("reject")]  public void Reject() {}
      [ScriptName("reject")]  public void Reject(object reason) {}
      [ScriptName("notify")]  public void Notify() {}
      [ScriptName("notify")]  public void Notify(object state) {}
      [ScriptName("promise")] public IPromise<T> Promise;
   }
   */
   #endregion
}

#region typescript implementation (for reference)
/*
///////////////////////////////////////////////////////////////////////////
// QService
// see http://docs.angularjs.org/api/ng.$q
///////////////////////////////////////////////////////////////////////////
interface IQService {
   all(promises: IPromise<any>[]): IPromise<any[]>;
   all(promises: {[id: string]: IPromise<any>;}): IPromise<{[id: string]: any}>;
   defer<T>(): IDeferred<T>;
   reject(reason?: any): IPromise<void>;
   when<T>(value: IPromise<T>): IPromise<T>;
   when<T>(value: T): IPromise<T>;
}

interface IPromise<T> {
   then<TResult>(successCallback: (promiseValue: T) => IHttpPromise<TResult>, errorCallback?: (reason: any) => any, notifyCallback?: (state: any) => any): IPromise<TResult>;
   then<TResult>(successCallback: (promiseValue: T) => IPromise<TResult>, errorCallback?: (reason: any) => any, notifyCallback?: (state: any) => any): IPromise<TResult>;
   then<TResult>(successCallback: (promiseValue: T) => TResult, errorCallback?: (reason: any) => TResult, notifyCallback?: (state: any) => any): IPromise<TResult>;


   catch<TResult>(onRejected: (reason: any) => IHttpPromise<TResult>): IPromise<TResult>;
   catch<TResult>(onRejected: (reason: any) => IPromise<TResult>): IPromise<TResult>;
   catch<TResult>(onRejected: (reason: any) => TResult): IPromise<TResult>;

   finally<TResult>(finallyCallback: ()=>any):IPromise<TResult>;
}

interface IDeferred<T> {
   resolve(value?: T): void;
   reject(reason?: any): void;
   notify(state?:any): void;
   promise: IPromise<T>;
}
*/
#endregion 